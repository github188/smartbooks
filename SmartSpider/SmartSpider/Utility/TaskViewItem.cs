namespace SmartSpider.Utility {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Config;

    /// <summary>
    /// 任务项
    /// </summary>
    public class TaskViewItem : ListViewItem {
        private delegate void SetImagekey(Action a);

        public TaskUnit TaskUnit;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unit"></param>
        public TaskViewItem(ref TaskUnit unit, int taskIndex) {
            this.TaskUnit = unit;
            UpItemIcon();
            SubItems.Clear();
            Text = unit.TaskConfig.Name;
            ToolTipText = unit.TaskConfig.Description;
            Tag = taskIndex;
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));
            SubItems.Add(new ListViewItem.ListViewSubItem(this, "0"));

            this.TaskUnit.OnTaskStatusChanges += new OnTaskStatusChanges(unit_OnTaskStatusChanges);
            this.TaskUnit.onAppendResult += new OnAppendSingleResult(unit_onAppendResult);

            UpDateTaskStatus();
        }

        /// <summary>
        /// 获取当前任务状态
        /// </summary>
        public Action Action {
            get {
                return TaskUnit.Action;
            }
        }

        /// <summary>
        /// 更新任务ICO图标
        /// </summary>
        private void UpItemIcon() {
            try {
                switch (TaskUnit.Action) {
                    case Config.Action.Finish:
                        ImageKey = "editmin.png";
                        break;
                    case Config.Action.Ready:
                        ImageKey = "taskmin.png";
                        break;
                    case Config.Action.Start:
                        ImageKey = "startmin.png";
                        break;
                    case Config.Action.Pause:
                        ImageKey = "pausemin.png";
                        break;
                    case Config.Action.Stop:
                        ImageKey = "stopmin.png";
                        break;
                }
            } catch { }
        }

        /// <summary>
        /// 刷新任务状态数据
        /// </summary>
        private void UpDateTaskStatus() {
            try {
                UpItemIcon();
                TaskUnit.TaskConfig.ElapsedTime = DateTime.Now.Subtract(TaskUnit.TaskConfig.StartingTime).Seconds;

                this.SubItems[1].Text = TaskUnit.TaskConfig.UrlListManager.PickedUrlsPosition.ToString();
                this.SubItems[2].Text = TaskUnit.TaskConfig.UrlListManager.PickedUrlsCount.ToString();
                this.SubItems[3].Text = TaskUnit.TaskConfig.UrlListManager.StartingUrlListPosition.ToString();
                this.SubItems[4].Text = TaskUnit.TaskConfig.UrlListManager.StartingUrlList.Count.ToString();
                this.SubItems[5].Text = TaskUnit.TaskConfig.UrlListManager.HistoryUrlsCount.ToString();
                this.SubItems[6].Text = TaskUnit.Results.Rows.Count.ToString();
                this.SubItems[7].Text = TaskUnit.TaskConfig.ResultCount.ToString();
                this.SubItems[8].Text = TaskUnit.TaskConfig.RepeatedRowsCount.ToString();
                this.SubItems[9].Text = TaskUnit.TaskConfig.ErrorRowsCount.ToString();
                this.SubItems[10].Text = TaskUnit.TaskConfig.ElapsedTime + " 秒";
                this.SubItems[11].Text = TaskUnit.TaskConfig.StartingTime.ToString("yyyy-MM-dd HH:mm:ss");    //开始时间                
            } catch { }
        }

        //任务状态改变
        private void unit_OnTaskStatusChanges(object sender, Action a) {
            UpItemIcon();
        }
        //当增加一条采集结果时
        private void unit_onAppendResult(params object[] values) {
            this.UpDateTaskStatus();
        }
    }
}
