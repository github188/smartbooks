namespace InstantTranslation
{
    partial class InstantTranslation
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstantTranslation));
            this.rtxText = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tolMenuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tolMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxText
            // 
            this.rtxText.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rtxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxText.ForeColor = System.Drawing.Color.Black;
            this.rtxText.Location = new System.Drawing.Point(0, 0);
            this.rtxText.Name = "rtxText";
            this.rtxText.Size = new System.Drawing.Size(445, 89);
            this.rtxText.TabIndex = 0;
            this.rtxText.Text = "Hi";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "即时翻译";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolMenuShow,
            this.tolMenuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // tolMenuShow
            // 
            this.tolMenuShow.Name = "tolMenuShow";
            this.tolMenuShow.Size = new System.Drawing.Size(124, 22);
            this.tolMenuShow.Text = "显示/隐藏";
            this.tolMenuShow.Click += new System.EventHandler(this.tolMenuShow_Click);
            // 
            // tolMenuExit
            // 
            this.tolMenuExit.Name = "tolMenuExit";
            this.tolMenuExit.Size = new System.Drawing.Size(124, 22);
            this.tolMenuExit.Text = "退出";
            this.tolMenuExit.Click += new System.EventHandler(this.tolMenuExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InstantTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 89);
            this.Controls.Add(this.rtxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 121);
            this.MinimumSize = new System.Drawing.Size(451, 121);
            this.Name = "InstantTranslation";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "English - China";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InstantTranslation_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxText;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tolMenuShow;
        private System.Windows.Forms.ToolStripMenuItem tolMenuExit;
        private System.Windows.Forms.Timer timer1;
    }
}

