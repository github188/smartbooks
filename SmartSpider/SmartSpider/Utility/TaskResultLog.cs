namespace SmartSpider.Utility {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Data;    

    public class TaskResultLog : TabPage {
        private SplitContainer splitContainerMain = new SplitContainer();
        private RichTextBox rtxLogEvent = new RichTextBox();
        private DataGridView dgvResult = new DataGridView();
        private delegate void SetTextCallback(Config.LogEventArgs e);
        private Config.TaskUnit _unit = new Config.TaskUnit();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unit">任务控制单元</param>
        public TaskResultLog(ref Config.TaskUnit unit) {
            this.BindController();
            this.Text = unit.TaskConfig.Name;
            this.dgvResult.DataSource = unit.Results;
            this._unit = unit;
            this._unit.Log += new Config.LogEventHanlder(On_unitLog);
            this._unit.onAppendResult += new Config.OnAppendResult(On_AppendResult);
            this.Tag = unit.ConfigPath;
        }

        /// <summary>
        /// 追加日志信息
        /// </summary>
        /// <param name="src">LogEventArgs对象</param>
        public void AppendLog(object src) {
            Config.LogEventArgs e = (Config.LogEventArgs)src;
            string space = "";
            for (int i = 0; i < e.Indent; i++) {
                space += " ";
            }

            if (this.rtxLogEvent.InvokeRequired) {
                SetTextCallback callBack = new SetTextCallback(AppendLog);
                this.Invoke(callBack, new object[] { e });
            } else {
                
                this.rtxLogEvent.AppendText(space + e.Message + "\r\n");
                if (this.rtxLogEvent.Text.Length > 1) {
                    this.rtxLogEvent.Select(rtxLogEvent.Text.Length - 1, 1);
                }
                this.rtxLogEvent.ScrollToCaret();
                this.rtxLogEvent.Refresh();
            }
        }

        private void InitializeComponent() {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.rtxLogEvent = new System.Windows.Forms.RichTextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerMain.Panel1MinSize = 150;
            this.splitContainerMain.Panel2MinSize = 100;
            this.splitContainerMain.Size = new System.Drawing.Size(150, 254);
            this.splitContainerMain.SplitterDistance = 150;
            this.splitContainerMain.TabIndex = 0;
            // 
            // rtxLogEvent
            // 
            this.rtxLogEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxLogEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxLogEvent.Location = new System.Drawing.Point(0, 0);
            this.rtxLogEvent.Name = "rtxLogEvent";
            this.rtxLogEvent.Size = new System.Drawing.Size(100, 96);
            this.rtxLogEvent.TabIndex = 0;
            this.rtxLogEvent.Text = "";
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(240, 150);
            this.dgvResult.TabIndex = 0;
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        private void BindController() {
            this.InitializeComponent();

            this.splitContainerMain.Panel1.Controls.Add(dgvResult);
            this.splitContainerMain.Panel2.Controls.Add(rtxLogEvent);
            this.Controls.Add(splitContainerMain);
        }

        private void On_unitLog(object sender,Config.LogEventArgs e) {
            this.AppendLog(e);
        }

        private void On_AppendResult(System.Data.DataRow row) {
            this.dgvResult.Rows.Add(row);
        }
    }
}
