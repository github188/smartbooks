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
        private void Start(object sender) {
            string timeTick = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            if (this.Action == Config.Action.Running) {
                eventArgs.Message = string.Format("{0} 任务正在运行中,启动任务失败...", timeTick);
                this.AppendLog();
                return;
            }
            eventArgs.Message = string.Format("{0} 开始任务", timeTick);
            this.AppendLog();

            this._TaskConfig.StartingTime = DateTime.Now;
            this.Action = Config.Action.Running;

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

            //设置任务状态为完成
            this.Action = Config.Action.Finish;
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
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents), startUrl);
                    ExtractTheContents(startUrl);
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
            string htmlText = "";
            try {
                //请求Web服务器返回Html文本
                htmlText = this._HttpHelper.RequestResult(contentUrl);
            } catch (Exception e) {
                eventArgs.Message = string.Format("请求失败:{0} 原因:{1}", contentUrl,e.Message);
                this.AppendLog();
            }

            //提取内容
            ParseExtractRoles parseHtml = new ParseExtractRoles(
                _TaskConfig.ExtractionRules,
                htmlText,
                _HttpHelper.WebResponse);
            string[] res = parseHtml.Exec();
            this._Results.Rows.Add(res);

            if (this.onAppendResult != null) {
                this.onAppendResult(res);
            }

            //发布结果选项：直接发布到数据库
            if (this.TaskConfig.PublishResultDircetly) {
                PublishResult();
                Results.Rows.Clear();   //清除现有的采集结果
            }

            //当完成一条采集结果时
            if (this.OnTaskComplete != null) {
                this.OnTaskComplete();
            }
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

                string timeTick = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

                /*监测是否满足任务启动条件*/
                switch (this.Action) {
                    case Config.Action.Ready:   //准备
                        time.Change(Timeout.Infinite, Timeout.Infinite);   //停止
                        eventArgs.Message = string.Format("{0} 任务准备就绪...", timeTick);
                        break;
                    case Config.Action.Start:   //开始
                        StartTask();
                        break;
                    case Config.Action.Pause:   //暂停
                        time.Change(Timeout.Infinite, Timeout.Infinite);   //停止,暂时没有好的办法来停止任务的执行
                        eventArgs.Message = string.Format("{0} 暂停任务...", timeTick);
                        break;
                    case Config.Action.Stop:    //停止
                        time.Change(Timeout.Infinite, Timeout.Infinite);   //停止
                        eventArgs.Message = string.Format("{0} 停止任务...", timeTick);
                        break;
                    case Config.Action.Finish:  //完成
                        //time.Change(Timeout.Infinite, Timeout.Infinite);   //停止
                        eventArgs.Message = string.Format("{0} 任务完成...", timeTick);
                        break;
                    case Config.Action.Running: //运行中
                        eventArgs.Message = string.Format("{0} 任务运行中...", timeTick);
                        break;
                }
                this.AppendLog();
            }
        }

        /// <summary>
        /// 启动任务
        /// </summary>
        private void StartTask() {
            if (TaskConfig.ScheduleEnabled) {
                /*调度模式:每间隔时间段*/
                if (TaskConfig.ScheduleMode == ScheduleMode.Time) {
                    long tick = TaskConfig.ScheduleDays * 86400000;
                    tick += TaskConfig.ScheduleHours * 3600000;
                    tick += TaskConfig.ScheduleMinutes * 60000;
                    time.Change(0, tick);

                    eventArgs.Message = string.Format("{0} {1} 定时采集将于 {2} 秒后再次启动任务...",
                        DateTime.Now.ToLongDateString(),
                        DateTime.Now.ToLongTimeString(),
                        (tick / 1000).ToString());
                    this.AppendLog();
                }

                /*调度模式:每当经过每星期几中的时间范围*/
                if (TaskConfig.ScheduleMode == ScheduleMode.Day) {
                    /*
                     * 1.获取当前时间
                     * 2.判断当前时间是否位于指定的时间段内(开始时间、结束时间)区间
                     * 3.开始任务
                     */
                }
            } else {                
                time.Change(0, Timeout.Infinite);   //普通方式启动任务,紧执行一次
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
            set { _RepeatedRow = value; }
        }
        #endregion
    }
}