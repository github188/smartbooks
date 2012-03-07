namespace SmartSpider.Utility {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using Config;

    /// <summary>
    /// 任务项
    /// </summary>
    public class TaskViewItem : ListViewItem {

        private Action _Action;
        private TaskUnit _unit;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unit"></param>
        public TaskViewItem(ref TaskUnit unit) {
            this._Action = unit.Action;
            this._unit = unit;
            SubItems.Clear();
            Text = unit.TaskConfig.Name;
            ToolTipText = unit.TaskConfig.Description;
            ImageKey = "taskmin.png";
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

            //加入任务单元相应事件
        }

        /// <summary>
        /// 获取当前任务状态
        /// </summary>
        public Action Action {
            get {
                return _Action;
            }
        }

        /// <summary>
        /// 更新任务状态
        /// </summary>
        /// <param name="action">任务状态</param>
        /// <param name="successExtract">完成提取</param>
        /// <param name="extractUrls">提取网址</param>
        /// <param name="successStartUrls">完成起始</param>
        /// <param name="startUrlsCount">起始地址</param>
        /// <param name="histortCount">历史记录</param>
        /// <param name="currentExtract">当前采集</param>
        /// <param name="extractResult">采集结果</param>
        /// <param name="publishRepeated">发布重复</param>
        /// <param name="publishError">发布出错</param>
        /// <param name="timeSpan">采集用时</param>
        /// <param name="startTime">开始时间</param>
        private void UpDateTaskStatus(Action action, int successExtract, int extractUrls, int successStartUrls, int startUrlsCount, int histortCount, int currentExtract, int extractResult, int publishRepeated, int publishError, int timeSpan, DateTime startTime) {
            this.Tag = this._Action;
            this.ImageKey = ""; //图标状态
            this.SubItems[0].Text = successExtract.ToString();
            this.SubItems[1].Text = extractUrls.ToString();
            this.SubItems[2].Text = successStartUrls.ToString();
            this.SubItems[3].Text = startUrlsCount.ToString();
            this.SubItems[4].Text = histortCount.ToString();
            this.SubItems[5].Text = currentExtract.ToString();
            this.SubItems[6].Text = extractResult.ToString();
            this.SubItems[7].Text = publishRepeated.ToString();
            this.SubItems[8].Text = publishError.ToString();
            this.SubItems[9].Text = timeSpan.ToString() + "秒";
            this.SubItems[10].Text = startTime.ToString("H:mm:ss yy-MM-dd");
        }
    }
}
