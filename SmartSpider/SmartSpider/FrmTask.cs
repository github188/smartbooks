using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartSpider.Config;

namespace SmartSpider {
    public partial class FrmTask : Form {
        /// <summary>
        /// 任务单元
        /// </summary>
        private TaskUnit _TaskUnit = new TaskUnit();
        
        public FrmTask(TaskUnit taskUnit) {
            InitializeComponent();
            this._TaskUnit = taskUnit;
        }
    }
}
