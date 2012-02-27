using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartSpider {
    public partial class FrmLoading : Form {
        public FrmLoading() {
            InitializeComponent();
        }
        
        private void FrmLoading_Load(object sender, EventArgs e) {
            this.timerLoading.Interval = 1800;
            this.timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e) {
            if (this.Opacity % 1 == 0) {
                this.Opacity += 0.001;
            } else {
                this.timerLoading.Stop();
                this.Hide();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }
    }
}
