using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpider.Config {
    /// <param name="sender">事件源</param>
    /// <param name="action">任务状态</param>
    public delegate void OnTaskStatusChanges(object sender, Action action);
}
