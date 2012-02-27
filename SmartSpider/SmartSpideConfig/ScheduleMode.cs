namespace SmartSpider.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// 任务调度模式
    /// </summary>
    [Serializable]
    public enum ScheduleMode {
        /// <summary>
        /// 时间段
        /// </summary>
        [XmlEnum("Time")]
        Time = 0,
        /// <summary>
        /// 天
        /// </summary>
        [XmlEnum("Day")]
        Day = 1,
    }
}