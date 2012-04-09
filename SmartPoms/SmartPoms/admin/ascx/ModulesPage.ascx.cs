using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartPoms.admin.ascx {
    public partial class ModulesPage : System.Web.UI.UserControl {
        private DataTable ModuleTable;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (!Code.SessionBox.CheckUserSession()) {
                    Response.Redirect("~/AdminLogin.aspx");
                } else {
                    //初始化模块权限
                    Code.UserHandle.InitModule("admin_ModulesPage");
                    if (Code.UserHandle.ValidationHandle(Code.Tag.Browse))//是否有浏览权限
                    {
                        initTree();
                    } else {
                        Session["ErrorNum"] = "0";
                        Response.Redirect("~/AdminError.aspx");
                    }
                }
            }
        }

        //初始化模块菜单
        protected void initTree() {
            BLL.BASE_MODULE bll = new BLL.BASE_MODULE();
            TreeNode node = new TreeNode();
            ModuleTable = bll.GetModuleTypeList("").Tables[0];  //取得所有数据得到DataTable 
            LoadNode(Treeview1.Nodes[0].ChildNodes, "0"); //建立节点 
        }

        protected void LoadNode(TreeNodeCollection node, string MtID) {
            DataView dvList = new DataView(ModuleTable);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            TreeNode nodeTemp;
            foreach (DataRowView dv in dvList) {
                nodeTemp = new TreeNode();
                nodeTemp.Value = dv["ModuleTypeID"].ToString() + ",0";
                nodeTemp.Text = dv["ModuleTypeName"].ToString();  //节点名称 
                nodeTemp.NavigateUrl = "~/admin/ModulesInfoPage.aspx?id=" + dv["ModuleTypeID"].ToString() + "&type=0";  //节点链接地址 
                nodeTemp.Target = "ContentPanel";
                nodeTemp.ImageUrl = "~/images/treeico/open.gif";
                node.Add(nodeTemp);  //加入节点                 

                this.LoadNode(nodeTemp.ChildNodes, nodeTemp.Value.Split(',')[0]);  //递归 

                //增加子模块分类
                BLL.BASE_MODULE bll = new BLL.BASE_MODULE();
                DataSet Module = bll.GetModuleList("ModuleTypeID=" + dv["ModuleTypeID"].ToString());
                foreach (DataRow child_dr in Module.Tables[0].Rows) {
                    TreeNode ChildNode = new TreeNode(child_dr["ModuleName"].ToString());
                    ChildNode.Value = child_dr["ModuleID"].ToString() + ",1";
                    ChildNode.Expanded = false;
                    ChildNode.NavigateUrl = "~/admin/ModulesInfoPage.aspx?id=" + child_dr["ModuleID"].ToString() + "&type=1";  //节点链接地址 
                    ChildNode.Target = "ContentPanel";
                    ChildNode.ImageUrl = "~/images/treeico/folder.gif";
                    nodeTemp.ChildNodes.Add(ChildNode);
                }
            }
        }
    }
}