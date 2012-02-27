using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpider.Config {
    public class TaskController {
        private SmartSpider.Config.TaskUnit[] _TaskUnit;
        /// <summary>
        /// </summary>
        private Configuration _Configuration;
        /// <summary>
        /// 任务集合
        /// </summary>
        public TaskUnit[] TaskUnit {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 系统配置
        /// </summary>
        public Configuration Configuration {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        /// <summary>
        /// 增加一个任务单元到任务控制器
        /// </summary>
        public void Add(TaskUnit task) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 移除一个任务单元
        /// </summary>
        /// <param name="task">任务单元</param>
        public void Remove(TaskUnit task) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 移除指定索引处的任务单元
        /// </summary>
        /// <param name="index">索引位置</param>
        public void Remove(int index) {
            throw new System.NotImplementedException();
        }
    }
}
