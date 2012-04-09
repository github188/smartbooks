using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartSpider {
    public partial class FrmReplace : Form {
        public List<Config.Replacement> Replace = new List<Config.Replacement>();

        public FrmReplace() {
            InitializeComponent();
        }

        public FrmReplace(List<Config.Replacement> replace) {
            this.Replace = replace;
        }
    }
}