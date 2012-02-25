namespace SmartSpide.Config {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// 任务状态
    /// </summary>
    [Serializable]
    public enum State {
        /// <summary>
        /// 停止
        /// </summary>
        [XmlEnum("Stopped")]
        Stopped = 0,
    }
}
