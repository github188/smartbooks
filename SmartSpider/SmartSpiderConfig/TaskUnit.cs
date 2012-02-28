namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Collections.Specialized;
    using System.IO;

    public class TaskUnit :IDisposable {
        #region 私有变量定义
        private Task _TaskConfig = new Task();
        private Action _Action = new Action();
        private DataTable _Results = new DataTable();
        private HttpHelper _HttpHelper = new HttpHelper();
        private string _ConfigPath = "";
        /// <summary>
        /// 导航Url地址集合
        /// </summary>
        private StringCollection NavigationUrls = new StringCollection();
        #endregion
        
        #region 公共方法定义
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
        /// 开始
        /// </summary>
        public void Start() {
            this._Action = Config.Action.Start;

            /*
             * 整体处理流程:
             * 第一阶段:
             * 0.NULL无状态
             * 1.加载起始Url
             * 第二阶段:
             * 2.登录
             * 第三阶段:
             * 3.访问
             * 4.提取下一层网址
             * 5.提取下一页网址
             * 第四阶段(循环):
             * 6.获取Web代理
             * 6.1访问
             * 7.提取结果
             * 8.过滤
             * 9.处理结果行
             * 第五阶段:
             * 10.下载内容文件
             * 11.处理内容文件
             * 12.下载单个文件
             * 13.处理单个文件
             * 第六阶段:
             * 14.发布结果
             * 15.设置任务状态完成
             */


        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() {
            this._Action = Config.Action.Stop;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() {
            this._Action = Config.Action.Pause;
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Continue() {
            this._Action = Config.Action.Continue;
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        public void DeleteTask() {
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

        #region 公共属性定义
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
