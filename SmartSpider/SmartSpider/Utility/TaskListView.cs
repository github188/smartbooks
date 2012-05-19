using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SmartSpider.Utility
{
    public class TaskListView : ListView
    {
        #region 公共字段定义
        public List<Config.TaskUnit> _TaskItem = new List<Config.TaskUnit>(); 
        #endregion

        #region 公共属性定义
        /// <summary>
        /// 任务项集合
        /// </summary>
        public List<Config.TaskUnit> TaskItem
        {
            get { return _TaskItem; }
            set { _TaskItem = value; }
        }
        #endregion

        #region 公共方法定义
        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskListView()
        {
            //初始化组建
            InitializeComponent();

            //加载Xml配置文件
            LoadLocationTaskItem();
        }

        /// <summary>
        /// 刷新任务项状态
        /// </summary>
        /// <param name="index">任务项索引</param>
        /// <param name="task">任务项</param>
        public void RefreshTaskStatus(int index, Config.TaskUnit task)
        {
            //更新项文字信息
            task.TaskConfig.ElapsedTime = DateTime.Now.Subtract(task.TaskConfig.StartingTime).Seconds;
            this.Items[index].SubItems[1].Text = task.TaskConfig.UrlListManager.PickedUrlsPosition.ToString();
            this.Items[index].SubItems[2].Text = task.TaskConfig.UrlListManager.PickedUrlsCount.ToString();
            this.Items[index].SubItems[3].Text = task.TaskConfig.UrlListManager.StartingUrlListPosition.ToString();
            this.Items[index].SubItems[4].Text = task.TaskConfig.UrlListManager.StartingUrlList.Count.ToString();
            this.Items[index].SubItems[5].Text = task.TaskConfig.UrlListManager.HistoryUrlsCount.ToString();
            this.Items[index].SubItems[6].Text = task.Results.Rows.Count.ToString();
            this.Items[index].SubItems[7].Text = task.TaskConfig.ResultCount.ToString();
            this.Items[index].SubItems[8].Text = task.TaskConfig.RepeatedRowsCount.ToString();
            this.Items[index].SubItems[9].Text = task.TaskConfig.ErrorRowsCount.ToString();
            this.Items[index].SubItems[10].Text = task.TaskConfig.ElapsedTime + " 秒";
            this.Items[index].SubItems[11].Text = task.TaskConfig.StartingTime.ToString("yyyy-MM-dd HH:mm:ss");    //开始时间

            //刷新图标
            switch (task.Action)
            {
                case Config.Action.Finish:
                    this.Items[index].ImageKey = "editmin.png";
                    break;
                case Config.Action.Ready:
                    this.Items[index].ImageKey = "taskmin.png";
                    break;
                case Config.Action.Start:
                    this.Items[index].ImageKey = "startmin.png";
                    break;
                case Config.Action.Pause:
                    this.Items[index].ImageKey = "pausemin.png";
                    break;
                case Config.Action.Stop:
                    this.Items[index].ImageKey = "stopmin.png";
                    break;
            }
        }

        /// <summary>
        /// 显示分组项到items视图中
        /// </summary>
        /// <param name="groupText">分组名称</param>
        public void ShowGroupItem(string groupText)
        {
            //清除现有项集合
            this.Items.Clear();

            //遍历集合项
            foreach (Config.TaskUnit task in _TaskItem)
            {
                if (task != null && task.ConfigDir.Equals(groupText))
                {
                    this.Items.Add(new Utility.TaskViewItem(task.TaskConfig.Name, task.TaskConfig.Description));
                    RefreshTaskStatus(this.Items.Count - 1, task);
                }
            }

            //刷新控件视图
            this.Refresh();
        }

        public void StartTask()
        {
        }

        public void PauseTask()
        {
        }

        public void StopTask()
        {
        }


        #endregion

        #region 私有方法定义
        /// <summary>
        /// 初始化组件
        /// </summary>
        private void InitializeComponent()
        {
            #region 初始化子控件
            this.taskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractStartSuccessUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractStartUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleaseRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleaseError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtractSpaceTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            // 
            // taskName
            // 
            this.taskName.Text = "任务名称";
            this.taskName.Width = 150;
            this.taskName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractCount
            // 
            this.ExtractCount.Text = "完成提取";
            this.ExtractCount.Width = 80;
            this.ExtractCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractURL
            // 
            this.ExtractURL.Text = "提取网址";
            this.ExtractURL.Width = 80;
            this.ExtractURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractStartSuccessUrl
            // 
            this.ExtractStartSuccessUrl.Text = "完成起始";
            this.ExtractStartSuccessUrl.Width = 80;
            this.ExtractStartSuccessUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractStartUrl
            // 
            this.ExtractStartUrl.Text = "起始地址";
            this.ExtractStartUrl.Width = 80;
            this.ExtractStartUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractHistory
            // 
            this.ExtractHistory.Text = "历史记录";
            this.ExtractHistory.Width = 80;
            this.ExtractHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractCurrent
            // 
            this.ExtractCurrent.Text = "当前采集";
            this.ExtractCurrent.Width = 80;
            this.ExtractCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractResult
            // 
            this.ExtractResult.Text = "采集结果";
            this.ExtractResult.Width = 80;
            this.ExtractResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReleaseRepeat
            // 
            this.ReleaseRepeat.Text = "发布重复";
            this.ReleaseRepeat.Width = 80;
            this.ReleaseRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReleaseError
            // 
            this.ReleaseError.Text = "发布出错";
            this.ReleaseError.Width = 80;
            this.ReleaseError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtractSpaceTime
            // 
            this.ExtractSpaceTime.Text = "采集用时";
            this.ExtractSpaceTime.Width = 120;
            this.ExtractSpaceTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartTime
            // 
            this.StartTime.Text = "开始时间";
            this.StartTime.Width = 150;
            this.StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            #endregion

            #region 初始化主控件属性
            this.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FullRowSelect = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "livTaskView";
            this.Size = new System.Drawing.Size(389, 150);
            this.TabIndex = 0;
            this.HideSelection = false;
            this.UseCompatibleStateImageBehavior = false;
            this.View = System.Windows.Forms.View.Details;
            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.taskName,
                this.ExtractCount,
                this.ExtractURL,
                this.ExtractStartSuccessUrl,
                this.ExtractStartUrl,
                this.ExtractHistory,
                this.ExtractCurrent,
                this.ExtractResult,
                this.ReleaseRepeat,
                this.ReleaseError,
                this.ExtractSpaceTime,
                this.StartTime});
            #endregion

        }
        /// <summary>
        /// 加载本地xml Task配置文件
        /// </summary>
        private void LoadLocationTaskItem()
        {
            string taskRootPath = AppDomain.CurrentDomain.BaseDirectory + "Task";
            string[] files = Directory.GetFiles(taskRootPath, "*.xml", SearchOption.AllDirectories);            
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Config.Task));
                    Stream readStream = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                    Config.Task task = (Config.Task)xs.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();

                    Config.TaskUnit unit = new Config.TaskUnit();
                    unit.ConfigPath = files[i];
                    unit.TaskConfig = task;
                    unit.ConfigDir = Directory.GetParent(files[i]).FullName;

                    this._TaskItem.Add(unit);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region 私有字段定义
        private System.Windows.Forms.ColumnHeader taskName;
        private System.Windows.Forms.ColumnHeader ExtractCount;
        private System.Windows.Forms.ColumnHeader ExtractURL;
        private System.Windows.Forms.ColumnHeader ExtractStartSuccessUrl;
        private System.Windows.Forms.ColumnHeader ExtractStartUrl;
        private System.Windows.Forms.ColumnHeader ExtractHistory;
        private System.Windows.Forms.ColumnHeader ExtractCurrent;
        private System.Windows.Forms.ColumnHeader ExtractResult;
        private System.Windows.Forms.ColumnHeader ReleaseRepeat;
        private System.Windows.Forms.ColumnHeader ReleaseError;
        private System.Windows.Forms.ColumnHeader ExtractSpaceTime;
        private System.Windows.Forms.ColumnHeader StartTime;
        #endregion
    }
}
