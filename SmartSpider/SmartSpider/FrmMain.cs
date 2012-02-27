namespace SmartSpider {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml.Serialization;
    using Config;

    public partial class FrmMain : Form {
        #region 构造方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain() {
            InitializeComponent();            
        }
        #endregion

        #region 窗体控件事件
        //退出程序
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
        //单击任务节点
        private void trwTaskFolder_MouseClick(object sender, MouseEventArgs e) {
            string taskPath = trwTaskFolder.SelectedNode.Tag.ToString();
            string[] files = Directory.GetFiles(taskPath, "*.xml");
            livTaskView.Items.Clear();
            for (int i = 0; i < files.Length; i++) {
                XmlSerializer xs = new XmlSerializer(typeof(Task));
                Stream readStream = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                Task task = (Task)xs.Deserialize(readStream);
                ListViewItem livItem = new ListViewItem();
                livItem.Text = task.Name;
                livItem.Tag = files[i];
                livItem.SubItems.Add(new ListViewItem.ListViewSubItem(livItem, "0"));
                livTaskView.Items.Add(livItem);
            }
        }
        //双击，编辑任务配置
        private void livTaskView_MouseDoubleClick(object sender, MouseEventArgs e) {
            
        }
        #endregion

        #region 私有变量定义
        #endregion
    }
}
