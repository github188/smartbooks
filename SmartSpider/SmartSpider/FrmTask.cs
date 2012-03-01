namespace SmartSpider {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Config;
    using System.Xml.Serialization;
    using System.IO;

    public partial class FrmTask : Form {
        /// <summary>
        /// 任务单元
        /// </summary>
        private TaskUnit _TaskUnit = new TaskUnit();
        
        public FrmTask(ref TaskUnit taskUnit) {
            InitializeComponent();
            this._TaskUnit = taskUnit;

            this.SetUnitToUI();
        }

        /// <summary>
        /// 保存任务配置
        /// </summary>
        private void SaveTaskConfig() {
            XmlSerializer xs = new XmlSerializer(typeof(Task));
            Stream writeStream = new FileStream("", FileMode.CreateNew, FileAccess.Write, FileShare.Write);
            xs.Serialize(writeStream, this._TaskUnit.TaskConfig);
            writeStream.Close();
            writeStream.Dispose();
        }

        /// <summary>
        /// 绑定任务单元到UI界面,用于新建/修改任务
        /// </summary>
        private void SetUnitToUI() {
            this.txtName.Text = this._TaskUnit.TaskConfig.Name;
            this.txtDescription.Text = this._TaskUnit.TaskConfig.Description;
            this.txtCookie.Text = this._TaskUnit.TaskConfig.Cookie;
            this.nudThreadNumber.Value = this._TaskUnit.TaskConfig.ThreadNumber;
            this.txtStartingUrlTemplate.Text = this._TaskUnit.TaskConfig.UrlListManager.StartingUrlTemplate;
        }

        /// <summary>
        /// 获取当前已修改的UI界面任务配置设置
        /// </summary>
        /// <returns>任务单元</returns>
        private TaskUnit GetUiConfig() {
            TaskUnit unit = new TaskUnit();
            //获取修改后的界面设置
            return unit;
        }
    }
}
