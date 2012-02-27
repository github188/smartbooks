using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpider.Config {
    public class TaskUnit : ISmartSpider {
        private Task _TaskConfig;
        private Action _Action;

        /// <summary>
        /// 任务配置
        /// </summary>
        public Task TaskConfig {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        public Action Action {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }
        /// <summary>
        /// 开始
        /// </summary>
        public void Start() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue() {
            throw new System.NotImplementedException();
        }

        public event LogEventHanlder Log;

        /// <summary>
        /// 创建任务对象
        /// </summary>
        public void Create(string taskPath, string pluginPath, SmartSpiderInformation smartSpiderInfo, Action action, bool firstCall) {
            throw new NotImplementedException();
        }

        public void Dispose(Action action) {
            throw new NotImplementedException();
        }

        public void DownloadContentFile(string url, string path, string skipIfFileExisted, string cookie, string referer) {
            throw new NotImplementedException();
        }

        public string DownloadSingleFile(string url, string path, string fileNamePrefix, string skipIfFileExisted, string cookie, string referer) {
            throw new NotImplementedException();
        }

        public string ExtractResult(string extractionRule, string dataColumn, string htmlText, string url) {
            throw new NotImplementedException();
        }

        public bool Filter(string result, string extractionRule, string dataColumn, System.Data.DataRow extractingResultRow) {
            throw new NotImplementedException();
        }

        public RequiredOptions GetRequiredOptions() {
            throw new NotImplementedException();
        }

        public void GetSettingForm(string taskPath, string[] selectedTaskPaths, string pluginPath, SmartSpiderInformation smartSpiderInfo) {
            throw new NotImplementedException();
        }

        public SmartSpiderWebProxy GetWebProxy(string requestingUrl, string retryTimes) {
            throw new NotImplementedException();
        }

        public string LoadStartingUrl(string template, ref int position, string cookie) {
            throw new NotImplementedException();
        }

        public string Login(string url) {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.StringCollection PickNextLayerUrls(string htmlText, string layer, string url, string cookie) {
            throw new NotImplementedException();
        }

        public string PickNextPageUrl(string htmlText, string layer, string url, string cookie) {
            throw new NotImplementedException();
        }

        public void ProcessContentFile(string path, bool skipped) {
            throw new NotImplementedException();
        }

        public bool ProcessResultRow(System.Data.DataRow extractedResultRow) {
            throw new NotImplementedException();
        }

        public string ProcessSingleFile(string path, string fileNamePrefix, bool skipped) {
            throw new NotImplementedException();
        }

        public string Visit(string url, string[] postData, string layer, string cookie, string referer) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 采集结果
        /// </summary>
        public System.Data.DataTable Results {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        private System.Data.DataTable _Results;

        /// <summary>
        /// Http助手
        /// </summary>
        public HttpHelper HttpHelper {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        private HttpHelper _HttpHelper;
    }
}
