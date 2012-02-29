using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SmartSpider.Utility {
    public class TaskResultLog : TabPage {
        private SplitContainer splitContainerMain = new SplitContainer();
        private RichTextBox rtxLogEvent = new RichTextBox();
        private DataGridView dgvResult = new DataGridView();
        private Config.TaskUnit _unit;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="title">选项卡标题</param>
        /// <param name="dataResult">采集结果表结构</param>
        /// <param name="unit">任务控制单元</param>
        public TaskResultLog(string title, DataTable dataResult, ref Config.TaskUnit unit) {
            this.BindController();
            this.Text = title;
            this.dgvResult.DataSource = dataResult;
            this._unit = unit;
            this._unit.Log +=new Config.LogEventHanlder(OnUnitLog);
        }
        
        /// <summary>
        /// 追加日志信息
        /// </summary>
        /// <param name="loginfo">日志信息</param>
        /// <param name="indent">空格字符数</param>
        public void AppendLog(string loginfo, int indent) {
            string space = "";
            for (int i = 0; i < indent; i++) {
                space += " ";
            }
            this.rtxLogEvent.AppendText(space + loginfo + "\r\n");
            this.rtxLogEvent.Select(rtxLogEvent.Text.Length - 1, 1);
            this.rtxLogEvent.ScrollToCaret();
            this.rtxLogEvent.Refresh();
        }

        /// <summary>
        /// 追加一行数据
        /// </summary>
        /// <param name="row">数据行</param>
        public void AppendRow(DataGridViewRow row) {
            if (dgvResult.ColumnCount != 0) {
                dgvResult.Rows.Add(row);
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

        private void OnUnitLog(object sender, Config.LogEventArgs e) {
            string space = "";
            for (int i = 0; i < e.Indent; i++) {
                space += " ";
            }
            this.rtxLogEvent.AppendText(space + e.Message + "\r\n");
        }
    }
}
