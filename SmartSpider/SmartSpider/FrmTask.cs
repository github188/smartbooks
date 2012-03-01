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
            this.txtName.Text = this._TaskUnit.TaskConfig.Name;                                                         //任务名称
            this.txtDescription.Text = this._TaskUnit.TaskConfig.Description;                                           //任务描述
            this.txtCookie.Text = this._TaskUnit.TaskConfig.Cookie;                                                     //Cookie
            this.nudThreadNumber.Value = this._TaskUnit.TaskConfig.ThreadNumber;                                        //线程数量
            this.txtStartingUrlTemplate.Text = this._TaskUnit.TaskConfig.UrlListManager.StartingUrlTemplate;            //起始Url地址模板
            this.txtConnectionString.Text = this._TaskUnit.TaskConfig.ConnectionString;                                 //数据库连接字符串
            this.chbDeleteResultAfterPublication.Checked = this._TaskUnit.TaskConfig.DeleteResultAfterPublication;      //发布结果后删除数据
            this.chbDisableScheduleAfterFinish.Checked = this._TaskUnit.TaskConfig.DisableScheduleAfterFinish;          //取消定时采集
            this.txtPluginPath.Text = this._TaskUnit.TaskConfig.PluginPath;                                             //插件路径
            this.chbUseProcedure.Checked = this._TaskUnit.TaskConfig.UseProcedure;                                      //使用存储过程
                        
            //CurrentResultCount
            //DatabaseType
            //ElapsedTime
            //ErrorRowsCount
            //ExtractionRules
            //IgnoreDataColumnNotFound
            //lastLogFileName
            //lastStoppingTime
            //LoginAtRegularIntervals
            //LoginAutomatically
            //LoginInterval
            //LoginSuccessFlag
            //LoginTargetUrl
            //LoginUrl
            //LoginUrlReferer
            //OutputDetailedLog
            //PluginData
            //PublicationTarget
            //PublishResultDircetly
            //RepeatedRowsCount
            //ResultCount
            //SaveErrorRows
            //SaveLogToFile
            //SaveRepeatedRows
            //ScheduleDays
            //ScheduleEnabled
            //ScheduleFromDay
            //WeekScheduleFromDayOfWeek
            //ScheduleFromHour
            //ScheduleHours
            //ScheduleLimitTimeRange
            //ScheduleMinutes
            //ScheduleModeScheduleMode
            //ScheduleToDay
            //WeekScheduleToDayOfWeek
            //ScheduleToHour
            //DateTimeStartingTime
            //ActionState
            //ThreadNumber
            //UrlListManagerUrlListManager
            //UsePluginOfDownloadContentFile
            //UsePluginOfDownloadSingleFile
            //UsePluginOfFilter
            //UsePluginOfGetWebProxy
            //UsePluginOfLogin
            //UsePluginOfProcessContentFile
            //UsePluginOfProcessResultRow
            //UsePluginOfProcessSingleFile
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