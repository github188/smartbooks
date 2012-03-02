using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpider.Config {
    /// <summary>
    /// 当增加一条采集结果记录时触发的事件委托
    /// </summary>
    public delegate void OnAppendResult(System.Data.DataRow row);
}
