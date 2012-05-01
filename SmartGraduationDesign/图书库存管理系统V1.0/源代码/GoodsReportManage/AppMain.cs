using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;
using GoodsReportManage.Goods;
using System.Collections;

namespace GoodsReportManage
{
    public partial class AppMain : Form
    {
        public AppMain()
        {
            InitializeComponent();
        }

        SqlBaseClass G_SqlClass = new SqlBaseClass();

        /// <summary>
        /// 根据用户权限分配显示菜单
        /// </summary>
        public void MenuIsVisible()
        {
            ArrayList arylst = new ArrayList();
            ToolStripMenuItem[] menu = new ToolStripMenuItem[] {
                this.menuEmployee,this.menuCompany,this.menuCustomer,this.menuGoodsIn,this.menuGoodsOut,this.menuSellGoods,
                this.menuGoodsBack,this.menuDepotChange,this.menuDepotAlarm,this.menuSysUser,this.menuPopedomSet,this.menuDatabak,this.menuReBakData
            };
            DataSet P_ds = G_SqlClass.GetDs("SELECT * FROM v_UserView WHERE SysLoginName = '"+ PropertyClass.SendNameValue+"'");

            for (int i = 0; i < 13; i++)
            {
                arylst.Add(P_ds.Tables[0].Rows[0][14+i].ToString());
            }
            for (int j = 0; j < arylst.Count; j++)
            {
                if (arylst[j].ToString() == "False")
                {
                    menu[j].Visible = false;
                }
                else
                {
                    menu[j].Visible = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.statusTime.Text = "当前时间：" + DateTime.Now.ToString();
        }

        private void AppMain_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.statusUser.Text = "系统操作员："+PropertyClass.SendNameValue;
            MenuIsVisible();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            WinOperationClass P_Menu = new WinOperationClass();  //声明对WinForm窗体进行操作的类对象
            P_Menu.ShowForm((ToolStripMenuItem)sender, this);   //调用类中的方法，完成对窗体中ToolStripMenuItem控件相应项的操作
        }

        private void AppMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void AppMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}