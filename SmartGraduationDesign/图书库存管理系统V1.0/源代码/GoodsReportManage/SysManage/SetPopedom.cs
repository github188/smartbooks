using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GoodsReportManage.ItemClass;  //添加引用
using System.Collections;
using System.Data.SqlClient;

namespace GoodsReportManage.SysManage
{
    public partial class SetPopedom : Form
    {
        public SetPopedom()
        {
            InitializeComponent();
        }

        WinOperationClass G_WinFormClass = new WinOperationClass();
        SqlBaseClass G_SqlClass = new SqlBaseClass();

        private void SetPopedom_Load(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "SELECT SysLoginName FROM tb_User WHERE SysLoginName is not null";
            this.listBox1.DataSource = G_SqlClass.GetDs(P_Str_cmdtxt).Tables[0];
            this.listBox1.DisplayMember = "SysLoginName";
            this.listBox1.ValueMember = "SysLoginName";

            this.listBox1.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = String.Empty;
            string P_Str_select = String.Empty;

            ArrayList arylst = new ArrayList();
            foreach (TreeNode nodes in this.treeView1.Nodes)
            {
                foreach (TreeNode node in nodes.Nodes)
                {
                    if (node.Checked)
                    {
                        arylst.Add("1");
                    }
                    else
                    {
                        arylst.Add("0");
                    }
                }
            }

            P_Str_cmdtxt = "UPDATE tb_Popedom SET EmployeeInfo=" + arylst[0].ToString() + ",CompanyInfo=" + arylst[1].ToString() + ",CustomerInfo=" + arylst[2].ToString() + "";
            P_Str_cmdtxt += ",GoodsInInfo=" + arylst[3].ToString() + ",GoodsOutInfo=" + arylst[4].ToString() + ",SellGoodsInfo=" + arylst[5].ToString() + "";
            P_Str_cmdtxt += ",ReGoodsInfo=" + arylst[6].ToString() + ",StockChangeInfo=" + arylst[7].ToString() + ",StockAlarmInfo=" + arylst[8].ToString() + "";
            P_Str_cmdtxt += ",SysUser =" + arylst[9].ToString() + ",PopedomInfo=" + arylst[10].ToString() + ",BakDataInfo=" + arylst[11].ToString() + ",ReBakDataInfo=" + arylst[12].ToString() + "";
            P_Str_cmdtxt += " WHERE SysUserName = '" + this.listBox1.SelectedValue.ToString() + "'";

            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                MessageBox.Show("权限修改成功，下次登录时修改的权限生效！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("权限修改失败！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = true;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ArrayList arylst = new ArrayList();
            string P_Str_cmdtxt = "SELECT * FROM v_UserView WHERE SysUserName = '" + this.listBox1.SelectedValue.ToString() + "'";
            DataSet P_ds = G_SqlClass.GetDs(P_Str_cmdtxt);
            SqlDataReader P_dr = G_SqlClass.GetReader(P_Str_cmdtxt);
            P_dr.Read();
            if (P_dr.HasRows)
            {
                //循环为数组付值
                for (int i = 0; i < 13; i++)
                {
                    arylst.Add(P_ds.Tables[0].Rows[0][14 + i].ToString());
                }

                ArrayList ary = new ArrayList();

                for (int j = 0; j < arylst.Count; j++)
                {
                    foreach (TreeNode nodes in this.treeView1.Nodes)
                    {
                        foreach (TreeNode node in nodes.Nodes)
                        {
                            ary.Add(node);
                        }
                    }
                }
                for (int i = 0; i < arylst.Count; i++)
                {
                    if (arylst[i].ToString() == "True")
                    {
                        ((TreeNode)ary[i]).Checked = true;
                    }
                    else
                    {
                        ((TreeNode)ary[i]).Checked = false;
                    }
                }
            }
            P_dr.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string P_Str_cmdtxt = "UPDATE tb_User SET SysLoginName=null,Pwd=null WHERE SysLoginName = '" + this.listBox1.SelectedValue.ToString() + "'";
            if (G_SqlClass.GetExecute(P_Str_cmdtxt))
            {
                string P_Str_cmdtxt1 = "DELETE FROM tb_Popedom WHERE SysUserName='"+this.listBox1.SelectedValue.ToString()+"'";
                G_SqlClass.GetExecute(P_Str_cmdtxt1);
                MessageBox.Show("用户删除成功！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("用户删除失败！", "提示对话框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}