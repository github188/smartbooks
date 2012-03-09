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
        private TaskUnit _unit;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unit"></param>
        public TaskViewItem(ref TaskUnit unit) {
            this._unit = unit;
            UpItemIcon();
            SubItems.Clear();
            Text = unit.TaskConfig.Name;
            ToolTipText = unit.TaskConfig.Description;
            Tag = _unit;            
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

            this._unit.OnTaskStatusChanges += new OnTaskStatusChanges(unit_OnTaskStatusChanges);
            this._unit.onAppendResult += new OnAppendSingleResult(unit_onAppendResult);

            UpDateTaskStatus();
        }

        /// <summary>
        /// 获取当前任务状态
        /// </summary>
        public Action Action {
            get {
                return _unit.Action;
            }
        }

        /// <summary>
        /// 更新任务ICO图标
        /// </summary>
        private void UpItemIcon() {
            switch (_unit.Action) {
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
        }

        /// <summary>
        /// 刷新任务状态数据
        /// </summary>
        private void UpDateTaskStatus() {
            try {
                UpItemIcon();
                _unit.TaskConfig.ElapsedTime = DateTime.Now.Subtract(_unit.TaskConfig.StartingTime).Seconds;

                this.SubItems[1].Text = _unit.TaskConfig.UrlListManager.PickedUrlsPosition.ToString();
                this.SubItems[2].Text = _unit.TaskConfig.UrlListManager.PickedUrlsCount.ToString();
                this.SubItems[3].Text = _unit.TaskConfig.UrlListManager.StartingUrlListPosition.ToString();
                this.SubItems[4].Text = _unit.TaskConfig.UrlListManager.StartingUrlList.Count.ToString();
                this.SubItems[5].Text = _unit.TaskConfig.UrlListManager.HistoryUrlsCount.ToString();
                this.SubItems[6].Text = _unit.Results.Rows.Count.ToString();
                this.SubItems[7].Text = _unit.TaskConfig.ResultCount.ToString();
                this.SubItems[8].Text = _unit.TaskConfig.RepeatedRowsCount.ToString();
                this.SubItems[9].Text = _unit.TaskConfig.ErrorRowsCount.ToString();
                this.SubItems[10].Text = _unit.TaskConfig.ElapsedTime + " 秒";
                this.SubItems[11].Text = _unit.TaskConfig.StartingTime.ToString("yyyy-MM-dd HH:mm:ss");    //开始时间                
            } catch (Exception ex) {
                throw ex;
            }
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
