namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
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
        public TaskUnit() {
            //构造采集结果数据表结构
            this._Results = new DataTable();
            foreach (ExtractionRule rule in this._TaskConfig.ExtractionRules) {
                DataColumn colume = new DataColumn();
                colume.DataType = typeof(string);
                colume.ColumnName = rule.DataColumn;
                colume.Caption = rule.Name;
                colume.Unique = rule.DataUnique;

                this._Results.Columns.Add(colume);
            }
            this._HttpHelper = new HttpHelper(Encoding.GetEncoding(this._TaskConfig.UrlListManager.UrlEncoding));
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start() {
            eventArgs.Message = DateTime.Now.ToString();
            this.AppendLog();
            eventArgs.Message = "开始任务 " + this._TaskConfig.Name;
            this.AppendLog();

            this._Action = Config.Action.Start;

            StringCollection startUrls = this.LoadingStartingUrl();
            foreach (string startUrl in startUrls) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheNavigationAddress), startUrl);
                Thread.Sleep(1);
            }

            eventArgs.Message = "加载导航地址";
            this.AppendLog();

            ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents));
            Thread.Sleep(1);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            this._Action = Config.Action.Stop;
            eventArgs.Message = "停止任务";
            this.AppendLog();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            this._Action = Config.Action.Pause;
            eventArgs.Message = "暂停任务";
            this.AppendLog();
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue() {
            this._Action = Config.Action.Continue;
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

        /// <summary>
        /// 提取导航地址
        /// </summary>
        /// <param name="start">起始地址Url</param>
        private void ExtractTheNavigationAddress(object start) {
            string startUrl = (string)start;
            foreach (NavigationRule navigationRole in this._TaskConfig.UrlListManager.NavigationRules) {
                eventArgs.Message = "从起始页面提取导航Url：" + start;
                this.AppendLog();

                //监测当前任务状态
                if (this._Action == Config.Action.Start || this._Action == Config.Action.Continue) {
                    string htmlText = this._HttpHelper.RequestResult(startUrl);
                    StringCollection navUrls = this.LoadingNavigationRule(navigationRole, htmlText);
                    foreach (string url in navUrls) {
                        NavigationUrls.Add(url);
                    }
                } else if (this._Action == Config.Action.Pause) {
                    Thread.Sleep(10000);    //挂起10秒钟
                } else if (this._Action == Config.Action.Stop ||
                    this._Action == Config.Action.Ready ||
                    this._Action == Config.Action.Finish) {
                    Thread.CurrentThread.Abort();   //终止线程
                    return;
                }
            }
        }

        /// <summary>
        /// 采集内容(线程池回调方法)
        /// </summary>
        private void ExtractTheContents(object param) {
            foreach (string navUrl in NavigationUrls) {
                eventArgs.Message = "采集内容：" + navUrl;
                this.AppendLog();

                if (this._Action == Config.Action.Start || this._Action == Config.Action.Continue) {
                    DataRow row = this._Results.NewRow();
                    foreach (ExtractionRule extractionRule in this._TaskConfig.ExtractionRules) {
                        string htmlText = this._HttpHelper.RequestResult(navUrl);
                        string resultContent = this.LoadingExtractionRule(extractionRule, htmlText);
                        row[extractionRule.DataColumn] = resultContent;
                    }

                    this._Results.Rows.Add(row);
                    NavigationUrls.Remove(navUrl);  //移除采集的Url地址
                } else if (this._Action == Config.Action.Pause) {
                    Thread.Sleep(10000);    //任务暂停状态，挂起10秒钟
                } else if (this._Action == Config.Action.Stop || this._Action == Config.Action.Ready ||
                    this._Action == Config.Action.Finish) {
                    Thread.CurrentThread.Abort();   //终止线程
                    return;
                }
            }
            this._Action = Config.Action.Finish;    //设置任务状态为完成
            eventArgs.Message = "任务执行完毕。";
            this.AppendLog();
        }

        /// <summary>
        /// 加载提取规则
        /// </summary>
        /// <param name="extractionRule">内容提取规则</param>
        /// <param name="htmlText">Html文本</param>
        private string LoadingExtractionRule(SmartSpider.Config.ExtractionRule extractionRule, string htmlText) {
            eventArgs.Message = "开始提取内容";
            this.AppendLog();
            string result = string.Empty;

            //特殊结果
            if (extractionRule.TimeAsResult) return DateTime.Now.ToString();  //记录采集时间
            if (extractionRule.UrlAsResult) return this.HttpHelper.WebRequest.RequestUri.ToString();  //记录当前网址
            if (extractionRule.ResponseHeaderAsResult) return this.HttpHelper.WebResponse.Headers[extractionRule.ResponseHeaderName];   //响应头作为结果  
            if (extractionRule.ConstantAsResult) return extractionRule.ConstantValue;   //将固定值最为结果
            //if(extractionRule.PostParametersAsResult) return this.HttpHelper.WebRequest.GetRequestStream();   //POST参数作为结果
            //if (extractionRule.LinkTextAsResult) return ""; //链接文本作为结果


            //截取内容
            int indexPreviousFlag = htmlText.IndexOf(extractionRule.FollowingFlag); //信息前标志
            int indexFollowingFlag = htmlText.IndexOf(extractionRule.PreviousFlag); //信息后标志
            int indexLength = indexFollowingFlag - indexPreviousFlag;
            if (indexLength > 1) {
                result = htmlText.Substring(indexPreviousFlag, indexLength);
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
                    MatchCollection matchs = Regex.Matches(result, htmlMark.RegexText,RegexOptions.IgnoreCase);
                    foreach (Match match in matchs) {
                        HtmlMarkDictionary directory = new HtmlMarkDictionary();
                        directory.Index = match.Index;
                        directory.Text = match.Value;
                        element.Add(directory);
                    }
                }
                element.Sort();
                result = "";
                foreach (HtmlMarkDictionary elm in element) {
                    result += elm.Text;
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
            eventArgs.Message = "加载导航规则";
            this.AppendLog();
            StringCollection navigationUrls = new StringCollection();
            if (navigationRule.Terminal) return navigationUrls;
            MatchCollection matchColl = Regex.Matches(htmlText, navigationRule.NextLayerUrlPattern);
            foreach (Match match in matchColl) {
                navigationUrls.Add(match.Value);
            }
            return new StringCollection();
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
                string url = pageUrl.PagedUrlPattern;
                if (pageUrl.Format == PagedUrlPatternsMode.Increment) { //递增模式
                    for (int i = pageUrl.StartPage; i < pageUrl.EndPage; i += pageUrl.Step) {
                        if (regexMatch.Count != 0) {
                            url = url.Replace(regexMatch[0].Value, i.ToString());
                        }
                        startingUrls.Add(url);
                    }
                } else if (pageUrl.Format == PagedUrlPatternsMode.Decreasing) { //递减模式
                    for (int i = pageUrl.EndPage; i > pageUrl.StartPage; i -= pageUrl.Step) {
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
        /// 发布采集结果
        /// </summary>
        private void PublishResult() {
            if (this._Action == Config.Action.Finish) {
                eventArgs.Message = "开始发布结果";
                this.AppendLog();
            } else {
                eventArgs.Message = "任务未完成，不允许发布结果。";
                this.AppendLog();
            }
        }

        /// <summary>
        /// 追加日志记录信息
        /// </summary>
        private void AppendLog() {
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
        }

        /// <summary>
        /// 追加一条数据记录
        /// </summary>
        /// <param name="row">数据行</param>
        private void AppendRow(System.Data.DataRow row) {
            if (this.onAppendResult != null) {
                this.onAppendResult(row);
            }
        }
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
