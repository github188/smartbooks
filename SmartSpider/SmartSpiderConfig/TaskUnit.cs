namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Specialized;
    using System.IO;
    using System.Threading;
    using System.Text.RegularExpressions;

    public class TaskUnit : IDisposable {
        #region 公共事件定义
        /// <summary>
        /// 日志记录事件
        /// </summary>
        public event LogEventHanlder Log;
        /// <summary>
        /// 当增加一条采集结果行时触发的事件
        /// </summary>
        public event OnAppendResult onAppendResult;
        /// <summary>
        /// 当任务状态改变时执行的事件
        /// </summary>
        public event OnTaskStatusChanges OnTaskStatusChanges;
        #endregion

        #region 私有变量定义
        private Task _TaskConfig = new Task();
        private Action _Action = new Action();
        private DataTable _Results = new DataTable();
        private HttpHelper _HttpHelper;
        private string _ConfigPath = "";
        private LogEventArgs eventArgs = new LogEventArgs("", 0, true);
        private StringCollection NavigationUrls = new StringCollection();
        #endregion

        #region 公共方法定义

        #region 任务控制

        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskUnit() {
            this._HttpHelper = new HttpHelper(Encoding.GetEncoding(this._TaskConfig.UrlListManager.UrlEncoding));
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start() {
            this.Action = Config.Action.Start;
            eventArgs.Message = string.Format("{0}\r\n开始任务 {1}\r\n", DateTime.Now.ToString(), this._TaskConfig.Name);
            this.AppendLog();

            #region 构造采集结果数据表结构
            this._Results = new DataTable();
            foreach (ExtractionRule rule in this._TaskConfig.ExtractionRules) {
                DataColumn colume = new DataColumn();
                colume.DataType = typeof(string);
                colume.ColumnName = rule.Name;
                colume.Caption = rule.DataColumn;
                colume.Unique = rule.DataUnique;
                this._Results.Columns.Add(colume);
            }
            #endregion

            #region 根据起始页面规则，加载导航地址采集规则
            StringCollection startUrls = this.LoadingStartingUrl();
            foreach (string startUrl in startUrls) {
                //ExtractTheNavigationAddress(startUrl);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheNavigationAddress), startUrl);
            }
            #endregion
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            this.Action = Config.Action.Stop;
            eventArgs.Message = "停止任务";
            this.AppendLog();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            this.Action = Config.Action.Pause;
            eventArgs.Message = "暂停任务";
            this.AppendLog();
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue() {
            this.Action = Config.Action.Continue;
            eventArgs.Message = "继续任务";
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
                        //根据导航地址提取内容结果
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents), url);
                        //ExtractTheContents(url);
                    }
                }
            }
        }

        /// <summary>
        /// 提取请求结果内容
        /// </summary>
        /// <param name="param">导航地址Url</param>
        private void ExtractTheContents(object param) {
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

            //发布结果
            if (this.TaskConfig.PublishResultDircetly) {
                PublishResult();
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
            eventArgs.Message = "开始发布结果";
            this.AppendLog();

            if (this.TaskConfig.DatabaseType == DatabaseType.Access) {
                return PublishResultToAccess();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.MySql) {
                return PublishResultToMySql();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.Oracle) {
                return PublishResultToOracle();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.SqlLite) {
                return PublishResultToSqlLite();
            } else if (this.TaskConfig.DatabaseType == DatabaseType.SqlServer) {
                return PublishResultToSqlServer();
            }

            return 0;
        }

        /// <summary>
        /// 发布结果到Access数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        private int PublishResultToAccess() {
            return 0;
        }

        /// <summary>
        /// 发布结果到MySql数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        private int PublishResultToMySql() {
            return 0;
        }

        /// <summary>
        /// 发布结果到Oracle数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        private int PublishResultToOracle() {
            return 0;
        }

        /// <summary>
        /// 发布结果到SqlLite数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        private int PublishResultToSqlLite() {
            return 0;
        }

        /// <summary>
        /// 发布结果到SqlServer数据库
        /// </summary>
        /// <returns>发布成功记录数</returns>
        private int PublishResultToSqlServer() {
            int publishResultCount = 0;
            SqlConnection sqlConn = new SqlConnection(this.TaskConfig.ConnectionString);
            try {
                sqlConn.Open();
                if (this.TaskConfig.UseProcedure) {
                    #region 使用存储过程发布结果
                    SqlCommand cmd = new SqlCommand();
                    foreach (DataRow row in this.Results.Rows) {
                        foreach (DataColumn col in this.Results.Columns) {
                            SqlParameter colParam = new SqlParameter(col.Caption, row[col.ColumnName].ToString().Replace('\'', '\"'));
                            cmd.Parameters.Add(colParam);
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConn;
                    cmd.CommandTimeout = 10;
                    cmd.CommandText = this.TaskConfig.PublicationTarget;
                    publishResultCount = cmd.ExecuteNonQuery();
                    #endregion
                } else {
                    #region 发布到数据库表
                    List<string> inserts = new List<string>();
                    #region 构造Insert语句
                    foreach (DataRow row in this.Results.Rows) {
                        string into = "";
                        string values = "";
                        for (int i = 0; i < this.Results.Columns.Count; i++) {
                            if (i < this.Results.Columns.Count - 1) {
                                into += string.Format("{0}", this.Results.Columns[i].Caption);
                                values += string.Format("'{0}'", row[this.Results.Columns[i].ColumnName].ToString().Replace('\'', '\"'));
                            } else {
                                into += string.Format("{0},", this.Results.Columns[i].Caption);
                                values += string.Format("'{0}',", row[this.Results.Columns[i].ColumnName].ToString().Replace('\'', '\"'));
                            }
                        }
                        inserts.Add(string.Format("insert into {0}({1})values({2})",
                                this.TaskConfig.PublicationTarget, into, values));
                    }
                    #endregion

                    SqlCommand cmd = new SqlCommand();
                    foreach (string item in inserts) {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConn;
                        cmd.CommandTimeout = 10;
                        cmd.CommandText = item;
                        publishResultCount += cmd.ExecuteNonQuery();
                    }
                    cmd.Dispose();
                    #endregion
                }
            } catch (Exception e) {
                eventArgs.Message = string.Format("发布结果到 {0} 数据库时出现错误，错误详细信息：", DatabaseType.SqlServer, e.Message);
                this.AppendLog();
            } finally {
                sqlConn.Close();
                sqlConn.Dispose();
            }
            return publishResultCount;
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
        #endregion
    }
}
