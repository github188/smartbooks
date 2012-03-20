using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Smart.Spider.Client
{
    public partial class frmMain : Form
    {
        private TaskUnit[] task;

        public frmMain()
        {
            InitializeComponent();
            task = new TaskUnit[10000];

            LoadUrl();  //加载监控地址
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(StartTask));
            t.Start();
            Thread.Sleep(1);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(StopTask));
            t.Start();
            Thread.Sleep(1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartTask()
        {
            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] != null)
                {
                    task[i].Time.Start();
                }
            }
            //this.btnStart.Enabled = false;
            //this.btnPause.Enabled = true;
        }

        private void StopTask()
        {
            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] != null)
                {
                    task[i].Time.Stop();
                }
            }
            //this.btnStart.Enabled = true;
            //this.btnPause.Enabled = false;
        }

        private void LoadUrl()
        {            
            DataTable dt = new DataTable();
            string select = "select UrlAddress from Base_Urls";
            //1.从数据库加载1000条Url地址
            dt = Smart.DBUtility.SqlServerHelper.Query(select).Tables[0];

            //循环实例化任务单元
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < 9999)
                {
                    task[i] = new TaskUnit(dt.Rows[i]["UrlAddress"].ToString());
                }
                else
                {
                    return;
                }
            }
        }
    }
}