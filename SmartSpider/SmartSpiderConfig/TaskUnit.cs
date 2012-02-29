namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Collections.Specialized;
    using System.IO;
    using System.Threading;

    public class TaskUnit :IDisposable {
        #region 公共事件定义
        /// <summary>
        /// 日志记录事件
        /// </summary>
        public event LogEventHanlder Log;
        #endregion

        #region 私有变量定义
        private Task _TaskConfig = new Task();
        private Action _Action = new Action();
        private DataTable _Results = new DataTable();
        private HttpHelper _HttpHelper = new HttpHelper();
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
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start() {
            eventArgs.Message = "开始任务 " + this._TaskConfig.Name;
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }

            this._Action = Config.Action.Start;

            StringCollection startUrls = this.LoadingStartingUrl();
            foreach (string startUrl in startUrls) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheNavigationAddress), startUrl);
                Thread.Sleep(1);
            }

            eventArgs.Message = "加载导航地址";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(ExtractTheContents));
            Thread.Sleep(1);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            this._Action = Config.Action.Stop;
            eventArgs.Message = "停止任务";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            this._Action = Config.Action.Pause;
            eventArgs.Message = "暂停任务";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue() {
            this._Action = Config.Action.Continue;
            eventArgs.Message = "继续任务";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        public void DeleteTask() {
            eventArgs.Message = "删除任务配置文件" + _ConfigPath;
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }

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
                if (this.Log != null) {
                    this.Log(this, eventArgs);
                }

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
                if (this.Log != null) {
                    this.Log(this, eventArgs);
                }

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
                    Thread.Sleep(10000);    //挂起10秒钟
                } else if (this._Action == Config.Action.Stop || this._Action == Config.Action.Ready ||
                    this._Action == Config.Action.Finish) {
                    Thread.CurrentThread.Abort();   //终止线程
                    return;
                }
            }
            this._Action = Config.Action.Finish;    //设置任务状态为完成
            eventArgs.Message = "任务执行完毕。";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }
        }

        /// <summary>
        /// 加载提取规则
        /// </summary>
        /// <param name="extractionRule">内容提取规则</param>
        /// <param name="htmlText">Html文本</param>
        public string LoadingExtractionRule(SmartSpider.Config.ExtractionRule extractionRule, string htmlText) {
            eventArgs.Message = "开始提取内容";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }

            return eventArgs.Message;
        }

        /// <summary>
        /// 加载导航规则
        /// </summary>
        /// <param name="navigationRule">导航Url提取规则</param>
        /// <param name="htmlText">Html文本</param>
        public StringCollection LoadingNavigationRule(SmartSpider.Config.NavigationRule navigationRule, string htmlText) {
            eventArgs.Message = "加载导航规则";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }

            return new StringCollection();
        }

        /// <summary>
        /// 加载起始地址
        /// </summary>
        public StringCollection LoadingStartingUrl() {
            eventArgs.Message = "加载起始地址";
            if (this.Log != null) {
                this.Log(this, eventArgs);
            }

            return new StringCollection();
        }

        /// <summary>
        /// 发布采集结果
        /// </summary>
        public void PublishResult() {
            if (this._Action == Config.Action.Finish) {
                eventArgs.Message = "开始发布结果";
                if (this.Log != null) {
                    this.Log(this, eventArgs);
                }
            } else {
                eventArgs.Message = "任务未完成，不允许发布结果。";
                if (this.Log != null) {
                    this.Log(this, eventArgs);
                }
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
