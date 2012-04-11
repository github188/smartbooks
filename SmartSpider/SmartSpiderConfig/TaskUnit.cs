namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Collections.Specialized;
    using System.IO;
    using System.Threading;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public delegate void OnTaskStatusChanges(object sender, Action action);
    public delegate void LogEventHanlder(LogEventArgs e);
    public delegate void OnTaskStarting();
    public delegate void OnTaskPause();
    public delegate void OnTaskStop();
    public delegate void OnTaskComplete();
    public delegate void OnAppendSingleResult(params object[] values);
    public delegate void OnPublishResult();

    public class TaskUnit : IDisposable {
        #region 公共事件定义
        /// <summary>
        /// 日志记录事件
        /// </summary>
        public event LogEventHanlder Log;
        /// <summary>
        /// 当增加一条采集结果行时触发的事件
        /// </summary>
        public event OnAppendSingleResult onAppendResult;
        /// <summary>
        /// 当任务状态改变时执行的事件
        /// </summary>
        public event OnTaskStatusChanges OnTaskStatusChanges;
        /// <summary>
        /// 当任务完成时产生的事件
        /// </summary>
        public event OnTaskComplete OnTaskComplete;
        #endregion

        #region 私有变量定义
        private Task _TaskConfig = new Task();
        private Action _Action = new Action();
        private DataTable _Results = new DataTable();
        private DataTable _ErrorRow;  //错误行
        private DataTable _RepeatedRow;   //重复行
        private HttpHelper _HttpHelper;
        private string _ConfigPath = "";
        private string _ConfigDir = "";
        private LogEventArgs eventArgs = new LogEventArgs("", 0, true);
        private StringCollection NavigationUrls = new StringCollection();
        public Timer time;
        #endregion

        #region 公共方法定义

        #region 任务控制

        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskUnit() {
            this._HttpHelper = new HttpHelper(Encoding.GetEncoding(this._TaskConfig.UrlListManager.UrlEncoding));
            time = new Timer(new TimerCallback(Start), "", Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start(object sender) {
            this.Action = Config.Action.Start;
            this._TaskConfig.StartingTime = DateTime.Now;
            eventArgs.Message = string.Format("{0}\r\n开始任务 {1}\r\n", DateTime.Now.ToString(), this._TaskConfig.Name);
            this.AppendLog();

            #region 监测定时采集功能
            /*启用定时采集*/
            if (TaskConfig.ScheduleEnabled) {
                /*实现代码*/
            }
            #endregion

            #region 构造采集结果数据表结构
            this._Results = new DataTable();
            foreach (ExtractionRule rule in this._TaskConfig.ExtractionRules) {
                DataColumn colume = new DataColumn();
                colume.DataType = typeof(string);
                colume.ColumnName = rule.Name;
                colume.Caption = rule.DataColumn;
                //colume.Unique = rule.DataUnique;
                this._Results.Columns.Add(colume);
            }
            #endregion

            #region 根据起始页面规则，加载导航地址采集规则
            StringCollection startUrls = this.LoadingStartingUrl();
            foreach (string startUrl in startUrls) {
                if (this.Action == Config.Action.Stop || this.Action == Config.Action.Pause) return;
                ExtractTheNavigationAddress(startUrl);
                //ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheNavigationAddress), startUrl);
            }
            #endregion
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            /*停止任务*/
            //time.Change(Timeout.Infinite, Timeout.Infinite);

            this.Action = Config.Action.Stop;
            eventArgs.Message = "停止任务";
            this.AppendLog();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            /*停止任务(之后选择合适的方式暂停)*/
            //time.Change(Timeout.Infinite, Timeout.Infinite);

            this.Action = Config.Action.Pause;
            eventArgs.Message = "暂停任务";
            this.AppendLog();
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        public void DeleteTask() {
            eventArgs.Message = "删除任务配置文件" + _ConfigPath;
            this.AppendLog();

            //删除任务配置文件，并销毁对象自身。
            File.Delete(this._ConfigPath);
            this.Dispose();
        }

        /// <summary>
        /// 销毁资源
        /// </summary>
        public void Dispose() {
            this._HttpHelper = null;
            this._Results = null;
            this._TaskConfig = null;
        }
        #endregion

        #region 采集结果处理
        /// <summary>
        /// 提取导航地址
        /// </summary>
        /// <param name="start">起始地址Url</param>
        private void ExtractTheNavigationAddress(object start) {
            string startUrl = (string)start;
            eventArgs.Message = string.Format("提取导航地址 {0}", start);
            this.AppendLog();

            foreach (NavigationRule navigationRole in this._TaskConfig.UrlListManager.NavigationRules) {
                if (this.Action == Config.Action.Stop || this.Action == Config.Action.Pause) return;
                // 采用深度优先模式提取内容采集结果
                string htmlText = "";
                try {
                    htmlText = this._HttpHelper.RequestResult(startUrl);
                } catch (Exception e) {
                    eventArgs.Message = string.Format("请求网址失败 {0},原因 {1}\r\n", start, e.Message);
                    this.AppendLog();
                }

                //判断是否为最终页面导航规则，如果为最终页面导航规则，则直接提取页面内容。
                if (navigationRole.Terminal) {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents), startUrl);
                } else {
                    StringCollection navUrls = this.LoadingNavigationRule(navigationRole, htmlText);
                    foreach (string url in navUrls) {
                        if (this.Action == Config.Action.Stop || this.Action == Config.Action.Pause) return;
                        //根据导航地址提取内容结果
                        ExtractTheContents(url);
                        //ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents), url);
                    }
                }
            }
        }

        /// <summary>
        /// 提取请求结果内容
        /// </summary>
        /// <param name="param">导航地址Url</param>
        private void ExtractTheContents(object param) {
            if (this.Action == Config.Action.Stop) return;

            string contentUrl = (string)param;
            DataRow row = this._Results.NewRow();
            string htmlText = "";
            eventArgs.Message = string.Format("采集内容 {0}\r\n", contentUrl);
            this.AppendLog();
            try {
                //请求Web服务器返回Html文本
                htmlText = this._HttpHelper.RequestResult(contentUrl);
            } catch (Exception e) {
                eventArgs.Message = string.Format("请求失败 {0} ", contentUrl);
                this.AppendLog();
                eventArgs.Message = string.Format("原因 {0}\r\n", e.Message);
                this.AppendLog();
            }

            //循环内容采集规则
            string[] r = new string[this._TaskConfig.ExtractionRules.Count];
            for (int i = 0; i < this._TaskConfig.ExtractionRules.Count; i++) {
                string result = this.LoadingExtractionRule(_TaskConfig.ExtractionRules[i], htmlText);
                row[_TaskConfig.ExtractionRules[i].Name] = result;
                r[i] = result;
            }

            //内容提取结果加入采集结果
            this._Results.Rows.Add(row);
            if (this.onAppendResult != null) {
                this.onAppendResult(r);
            }

            //发布结果选项：直接发布到数据库
            if (this.TaskConfig.PublishResultDircetly) {
                PublishResult();
                Results.Rows.Clear();   //清除现有的采集结果
            }

            //当任务完成时产生的事件
            if (this.OnTaskComplete != null) {
                this.OnTaskComplete();
            }
        }

        /// <summary>
        /// 加载提取规则
        /// </summary>
        /// <param name="extractionRule">内容提取规则</param>
        /// <param name="htmlText">Html文本</param>
        private string LoadingExtractionRule(SmartSpider.Config.ExtractionRule extractionRule, string htmlText) {
            string result = string.Empty;

            //特殊结果
            if (extractionRule.TimeAsResult) return DateTime.Now.ToString();  //记录采集时间
            if (extractionRule.UrlAsResult) return this.HttpHelper.WebRequest.RequestUri.ToString();  //记录当前网址
            if (extractionRule.ResponseHeaderAsResult) return this.HttpHelper.WebResponse.Headers[extractionRule.ResponseHeaderName];   //响应头作为结果  
            if (extractionRule.ConstantAsResult) return extractionRule.ConstantValue;   //将固定值最为结果
            //if(extractionRule.PostParametersAsResult) return this.HttpHelper.WebRequest.GetRequestStream();   //POST参数作为结果
            //if (extractionRule.LinkTextAsResult) return ""; //链接文本作为结果


            //截取内容
            int indexPreviousFlag = htmlText.IndexOf(extractionRule.PreviousFlag);//信息前标志
            int indexFollowingFlag = htmlText.IndexOf(extractionRule.FollowingFlag);//信息后标志
            int indexLength = indexFollowingFlag - indexPreviousFlag;
            if (indexLength > 1) {
                result = htmlText.Substring(indexPreviousFlag + extractionRule.PreviousFlag.Length,
                    indexLength - extractionRule.FollowingFlag.Length);
            }

            //过滤信息
            if (result.Length != 0) {
                #region 采集结果替换
                foreach (Replacement replacement in extractionRule.Replacements) {
                    // 使用正则表达式替换结果
                    if (replacement.UseRegex) {
                        MatchCollection matchs = Regex.Matches(result, replacement.OldValue);
                        foreach (Match match in matchs) {
                            result = result.Replace(match.Value, replacement.NewValue);
                        }
                    } else {
                        result = result.Replace(replacement.OldValue, replacement.NewValue);
                    }
                }
                #endregion

                #region 保留HTML标记
                //<p ([^>]+)>([^<]+)</p>
                List<HtmlMarkDictionary> element = new List<HtmlMarkDictionary>();
                foreach (HtmlMark htmlMark in extractionRule.ReservedHtmlMarks) {
                    MatchCollection matchs = Regex.Matches(result, htmlMark.RegexText, RegexOptions.IgnoreCase);
                    foreach (Match match in matchs) {
                        HtmlMarkDictionary directory = new HtmlMarkDictionary();
                        directory.Index = match.Index;
                        directory.Text = match.Value;
                        element.Add(directory);
                    }
                }
                if (element.Count != 0) {
                    element.Sort();
                    result = "";
                    foreach (HtmlMarkDictionary elm in element) {
                        result += elm.Text;
                    }
                }
                #endregion
            }
            return result;
        }

        /// <summary>
        /// 加载导航规则
        /// </summary>
        /// <param name="navigationRule">导航Url提取规则</param>
        /// <param name="htmlText">Html文本</param>
        private StringCollection LoadingNavigationRule(SmartSpider.Config.NavigationRule navigationRule, string htmlText) {
            StringCollection navigationUrls = new StringCollection();
            MatchCollection matchColl = Regex.Matches(htmlText, navigationRule.NextLayerUrlPattern);
            foreach (Match match in matchColl) {
                navigationUrls.Add(match.Value);
            }
            return navigationUrls;
        }

        /// <summary>
        /// 加载起始地址
        /// </summary>
        private StringCollection LoadingStartingUrl() {
            eventArgs.Message = "加载起始地址";
            this.AppendLog();

            StringCollection startingUrls = new StringCollection();
            //先加载列表地址
            foreach (string url in this._TaskConfig.UrlListManager.StartingUrlList) {
                startingUrls.Add(url);
            }

            //加载模板网址
            //匹配：{[0-9,-]*} {100,1,-1}            
            foreach (PagedUrlPatterns pageUrl in this._TaskConfig.UrlListManager.PagedUrlPattern) {
                MatchCollection regexMatch = Regex.Matches(pageUrl.PagedUrlPattern, "{[0-9,-]*}");
                if (pageUrl.Format == PagedUrlPatternsMode.Increment) { //递增模式
                    for (double i = pageUrl.StartPage; i <= pageUrl.EndPage; i += pageUrl.Step) {
                        string url = pageUrl.PagedUrlPattern;
                        if (regexMatch.Count != 0) {
                            url = url.Replace(regexMatch[0].Value, i.ToString());
                        }
                        startingUrls.Add(url);
                    }
                } else if (pageUrl.Format == PagedUrlPatternsMode.Decreasing) { //递减模式
                    for (double i = pageUrl.EndPage; i >= pageUrl.StartPage; i -= pageUrl.Step) {
                        string url = pageUrl.PagedUrlPattern;
                        if (regexMatch.Count != 0) {
                            url = url.Replace(regexMatch[0].Value, i.ToString());
                        }
                        startingUrls.Add(url);
                    }
                }
            }
            return startingUrls;
        }

        /// <summary>
        /// 追加日志记录信息
        /// </summary>
        private void AppendLog() {
            if (this.Log != null) {
                this.Log(eventArgs);
            }
        }
        #endregion

        #region 发布结果

        /// <summary>
        /// 发布采集结果
        /// </summary>
        /// <returns>发布成功记录条数</returns>
        public int PublishResult() {
            eventArgs.Message = "开始发布采集结果";
            this.AppendLog();

            if (this.TaskConfig.DatabaseType == DatabaseType.Access) {
                eventArgs.Message = "发布到Access数据库...";
                this.AppendLog();
                return PublishResultToAccess();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.MySql) {
                eventArgs.Message = "发布到MySql数据库...";
                this.AppendLog();
                return PublishResultToMySql();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.Oracle) {
                eventArgs.Message = "发布到Oracle数据库...";
                this.AppendLog();
                return PublishResultToOracle();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.SqlLite) {
                eventArgs.Message = "发布到SqlLite数据库...";
                this.AppendLog();
                return PublishResultToSqlLite();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.SqlServer) {
                eventArgs.Message = "发布到SqlServer数据库...";
                this.AppendLog();
                return PublishResultToSqlServer();
            }

            return 0;
        }

        /// <summary>
        /// 发布结果到Access数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        public int PublishResultToAccess() {
            //string cnStr = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " + "c:\\data.mdb";

            //ADOX.Catalog catalog = new Catalog();
            //try{
            //    //创建数据库
            //    catalog.Create(cnStr);

            //    //链接数据库
            //    ADODB.Connection adodbcn = new ADODB.Connection();
            //    adodbcn.Open(cnStr, null, null, -1);
            //    catalog.ActiveConnection = adodbcn;

            //    //新建表
            //    ADOX.Table table = new ADOX.Table();
            //    table.Name = "Results";

            //    ADOX.Column column = new ADOX.Column();
            //    column.ParentCatalog = catalog;
            //    column.Type = ADOX.DataTypeEnum.adInteger;
            //    column.Name = "GID";
            //    column.DefinedSize = 9;
            //    column.Properties["AutoIncrement"].Value = true;

            //    //设置主键
            //    table.Keys.Append("PrimaryKey", ADOX.KeyTypeEnum.adKeyPrimary, "GID", "", "");
            //    foreach (DataColumn col in this.Results.Columns) {
            //        table.Columns.Append(col.ColumnName, DataTypeEnum.adVarChar, 8000);
            //    }

            //    catalog.Tables.Append(table);
            //    adodbcn.Close();
            //    table = null;
            //    catalog = null;
            //}
            //catch{
            //}

            //OleDbConnection cn = new OleDbConnection(cnStr);
            //OleDbDataAdapter da = new OleDbDataAdapter("select * from Results", cn);
            //OleDbCommandBuilder cmb = new OleDbCommandBuilder(da);
            //int res = da.Update(Results);
            //cn.Close();
            //cn.Dispose();
            //return res;
            return 0;
        }

        /// <summary>
        /// 发布结果到MySql数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        public int PublishResultToMySql() {
            return 0;
        }

        /// <summary>
        /// 发布结果到Oracle数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        public int PublishResultToOracle() {
            return 0;
        }

        /// <summary>
        /// 发布结果到SqlLite数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        public int PublishResultToSqlLite() {
            return 0;
        }

        /// <summary>
        /// 发布结果到SqlServer数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        public int PublishResultToSqlServer() {
            int publishResultCount = 0;
            SqlConnection sqlConn = new SqlConnection(this.TaskConfig.ConnectionString);
            try {
                sqlConn.Open();
                if (this.TaskConfig.UseProcedure) {
                    #region 使用存储过程发布结果
                    eventArgs.Message = "使用存储过程发布...";
                    this.AppendLog();
                    
                    foreach (DataRow row in this.Results.Rows) {
                        #region 忽略不存在的参数
                        try {
                            SqlCommand cmd = new SqlCommand();
                            foreach (DataColumn col in this.Results.Columns) {
                                SqlParameter colParam = new SqlParameter("@" + col.Caption, row[col.ColumnName].ToString().Replace('\'', '\"'));
                                cmd.Parameters.Add(colParam);
                            }
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = sqlConn;
                            cmd.CommandTimeout = 10;
                            cmd.CommandText = this.TaskConfig.PublicationTarget;
                            publishResultCount = cmd.ExecuteNonQuery();

                            #region 保存重复行
                            if (publishResultCount == -1 && TaskConfig.SaveRepeatedRows) {
                                if (RepeatedRow == null) {
                                    RepeatedRow = Results.Clone();
                                }
                                RepeatedRow.Rows.Add(row);
                            }
                            #endregion
                        } catch (Exception ex) {
                            #region 保存出错行
                            if (TaskConfig.SaveErrorRows) {
                                if (ErrorRow == null) {
                                    ErrorRow = Results.Clone();
                                }
                                ErrorRow.Rows.Add(row);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                } else {
                    #region 初始化发布结果数据库连接对象
                    eventArgs.Message = "发布到数据库表...";
                    this.AppendLog();
                    DataTable dt = new DataTable();
                    string selectCommand = string.Format("SELECT top 0 * FROM {0}", this.TaskConfig.PublicationTarget);
                    SqlDataAdapter da = new SqlDataAdapter(selectCommand, sqlConn);
                    da.Fill(dt);
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    #endregion

                    #region 处理重复行(暂未实现)
                    //过滤掉重复行,监测是否有唯一的列
                    //List<string> uniqeColumn = new List<string>();
                    //foreach (DataColumn col in Results.Columns) {
                    //    uniqeColumn.Add(col.ColumnName);
                    //}
                    //Results = Results.DefaultView.ToTable(true, uniqeColumn.ToArray());
                    ///*保存重复的行*/
                    //if (TaskConfig.SaveRepeatedRows) {
                    //    if (RepeatedRow == null) {
                    //        RepeatedRow = Results.Clone();
                    //    }
                    //}
                    #endregion

                    #region 忽略不存在的字段&保存出错行
                    foreach (DataRow row in Results.Rows) {
                        DataRow newRow = dt.NewRow();   //新行对象
                        bool errorIdentity = false;     //错误标示
                        foreach (DataColumn col in Results.Columns) {
                            #region 忽略不存在的数据列选项,找不到对应的字段则忽略
                            try {
                                newRow[col.Caption] = row[col.ColumnName];
                            } catch (Exception ex) {
                                errorIdentity = true;   //设定当前行错误标志
                                if (TaskConfig.IgnoreDataColumnNotFound) {
                                    continue;
                                } else {
                                    throw ex;
                                }
                            }
                            #endregion
                        }
                        dt.Rows.Add(newRow);

                        /*保存出错行*/
                        if (errorIdentity && TaskConfig.SaveErrorRows) {
                            if (ErrorRow == null) {
                                ErrorRow = Results.Clone();
                            }
                            ErrorRow.Rows.Add(row);
                        }
                    }
                    #endregion

                    #region 发布采集结果到数据库
                    publishResultCount = da.Update(dt);
                    #endregion
                }
            } catch (Exception e) {
                eventArgs.Message = string.Format("发布出错:{0}", e.Message);
                this.AppendLog();
            } finally {
                sqlConn.Close();
                sqlConn.Dispose();
                eventArgs.Message = string.Format("操作完成: 共 {0} 条记录。", publishResultCount.ToString());
                this.AppendLog();
            }

            #region 结果文件发布到数据库后，删除结果文件数据
            if (TaskConfig.DeleteResultAfterPublication) {
                Results.Rows.Clear();
            }
            #endregion

            return publishResultCount;
        }
        #endregion

        #region 保存配置文件
        /// <summary>
        /// 保存任务配置到Xml文件(默认路径)
        /// </summary>
        public void SaveTaskConfiguration() {
            SaveTaskConfiguration(this.ConfigPath, true);
        }

        /// <summary>
        /// 保存任务配置文件(xml)到 filePath 路径
        /// </summary>
        /// <param name="filePath">xml文件路径</param>
        public void SaveTaskConfiguration(string filePath) {
            SaveTaskConfiguration(filePath, true);
        }

        /// <summary>
        /// 保存任务配置文件(xml)到 filePath 路径,允许指定一个选项 isCover 指示是否覆盖现有的文件
        /// </summary>
        /// <param name="filePath">xml保存路径</param>
        /// <param name="isCover">是否覆盖现有的文件(如果存在)</param>
        public void SaveTaskConfiguration(string filePath, bool isCover) {
            SaveTaskConfiguration(filePath, isCover, TaskConfig);
        }

        /// <summary>
        /// 保存任务配置文件(xml)到 filePath 路径,允许指定一个选项 isCover 指示是否覆盖现有的文件
        /// </summary>
        /// <param name="filePath">xml保存路径</param>
        /// <param name="isCover">是否覆盖现有的文件(如果存在)</param>
        /// <param name="task">task任务配置信息对象</param>
        public void SaveTaskConfiguration(string filePath, bool isCover, Task task) {
            //以覆盖方式保存配置文件
            if (isCover) {
                try {
                    XmlSerializer xs = new XmlSerializer(typeof(Task));
                    Stream writeStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write);
                    xs.Serialize(writeStream, task);
                    writeStream.Close();
                    writeStream.Dispose();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
        #endregion

        #endregion

        #region 公共属性定义
        /// <summary>
        /// 任务配置
        /// </summary>
        public Task TaskConfig {
            get {
                return _TaskConfig;
            }
            set {
                _TaskConfig = value;
            }
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        public Action Action {
            get {
                return _Action;
            }
            set {
                _Action = value;
                if (OnTaskStatusChanges != null) {
                    this.OnTaskStatusChanges(this, value);
                }
            }
        }

        /// <summary>
        /// 采集结果
        /// </summary>
        public DataTable Results {
            get {
                return _Results;
            }
            set {
                _Results = value;
            }
        }

        /// <summary>
        /// Http助手
        /// </summary>
        public HttpHelper HttpHelper {
            get {
                return _HttpHelper;
            }
            set {
                _HttpHelper = value;
            }
        }

        /// <summary>
        /// Task配置文件路径
        /// </summary>
        public string ConfigPath {
            get { return _ConfigPath; }
            set { _ConfigPath = value; }
        }

        /// <summary>
        /// 配置文件目录
        /// </summary>
        public string ConfigDir {
            get { return _ConfigDir; }
            set { _ConfigDir = value; }
        }

        /// <summary>
        /// 采集结果出错行
        /// </summary>
        public DataTable ErrorRow {
            get { return _ErrorRow; }
            set { _ErrorRow = value; }
        }

        /// <summary>
        /// 采集结果重复行
        /// </summary>
        public DataTable RepeatedRow {
            get { return _RepeatedRow; }
            set { _RepeatedRow = value;}
        }
        #endregion
    }
}
