using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.UserManager {
    public partial class UnitCenter : System.Web.UI.Page {

        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_DEPT deptbll = new BLL.BASE_DEPT();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
               
                BindAcceptUnit();//绑定单位部门
            }
        }


        //绑定单位部门
        private void BindAcceptUnit() {
            DataTable dt = new DataTable();
            //获取用户所属单位和下级部门


            dt = deptbll.GetAllDep("STATUS=0");

            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString().Equals("0")) {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = dr["DPTNAME"].ToString();
                    rootNode.Value = dr["DEPTID"].ToString();
                    rootNode.ToolTip = dr["DPTINFO"].ToString();
                    //rootNode.ShowCheckBox = false;//设置复选框是否显示
                    rootNode.Target = "UserFrame";
                    rootNode.Expanded = true;
                    rootNode.NavigateUrl = "UserCenter.aspx?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下用户

                    //递归子节点
                    RecursiveBindAcceptUnit(rootNode, dt);

                    //加入控件
                    TreeViewAcceptUnit.Nodes.Add(rootNode);
                }
            }
        }



        /// <summary>
        /// 填充部门树
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="dt">数据源</param>
        private void RecursiveBindAcceptUnit(TreeNode node, DataTable dt) {
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString().Equals(node.Value)) {
                    //添加子节点
                    TreeNode sub = new TreeNode();
                    sub.Text = dr["DPTNAME"].ToString();
                    sub.Value = dr["DEPTID"].ToString();
                    sub.ToolTip = dr["DPTINFO"].ToString();
                    //sub.ShowCheckBox = false;//设置复选框是否显示
                    sub.Target = "UserFrame";
                    sub.Expanded = false;
                    sub.NavigateUrl = "UserCenter.aspx?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下用户
                    node.ChildNodes.Add(sub);

                    //递归循环
                    RecursiveBindAcceptUnit(sub, dt);
                }
            }
        }
        //校验选择的部门树
        private bool CheckSelectDepartment() {
            bool res = false;
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                if (node.Checked) {
                    res = true;
                }
                RecursiveCheckNode(node, ref res);
            }
            return res;
        }
        //递归检查有无选中的节点
        private void RecursiveCheckNode(TreeNode node, ref bool isSelected) {
            if (node.Checked) {
                isSelected = true;
                return;
            }
            foreach (TreeNode sub in node.ChildNodes) {
                RecursiveCheckNode(sub, ref isSelected);
            }
        }

        protected void TreeViewAcceptUnit_SelectedNodeChanged(object sender, EventArgs e) {

            hfdUnitCode.Value = TreeViewAcceptUnit.SelectedNode.Value;
            hfdUnitName.Value = TreeViewAcceptUnit.SelectedNode.Text;

        }
        /// <summary>
        /// 按钮事件：添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, ImageClickEventArgs e) {

            string dptid = hfdUnitCode.Value;

            if (hfdUnitName.Value == "" || hfdUnitCode.Value == "") {
                AjaxAlert(UpdatePanel1, "请选中添加单位的上级节点");
                return;
            } else {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "window.showModalDialog('UnitEdit.aspx?action=add&parentId=" + hfdUnitCode.Value + "&p=" + DateTime.Now.Millisecond + "','单位信息添加','dialogWidth=400px;dialogHeight=200px;menubars=0;status=0');window.location.href='UnitCenter.aspx';", true);
            }
        }
        /// <summary>
        /// 按钮事件：编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, ImageClickEventArgs e) {

            if (hfdUnitName.Value=="" || hfdUnitCode.Value == "") {
                AjaxAlert(UpdatePanel1, "请选择要编辑单位的节点！");
                return;
            }
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "window.showModalDialog('UnitEdit.aspx?action=update&unitid=" + hfdUnitCode.Value + "&p=" + DateTime.Now.Millisecond + "','单位信息编辑','dialogWidth=400px;dialogHeight=200px;menubars=0;status=0');window.location.href='UnitCenter.aspx';", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e) {
           //单位删除
            string unitId = hfdUnitCode.Value;//单位编号
            if (hfdUnitName.Value == "" || hfdUnitCode.Value == "")
            {
                AjaxAlert(UpdatePanel1, "请选择要删除单位的节点！");
                return;
            }
            else {
                this.btnDelete.Attributes.Add("onclick ", "return confirm( '你确定要删除该单位？ ') ");
                //提示确认删除该记录；判断该记录下是否有子单位：先删除子单位；删除后该记录下用户不可用
                delDept(Convert.ToDecimal(unitId));//执行删除
            }
           // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "window.showModalDialog('UnitEdit.aspx?action=del&unitid=" + hfdUnitCode.Value + "&p=" + DateTime.Now.Millisecond + "','单位信息删除','dialogWidth=550px;dialogHeight=200px;menubars=0;status=0');window.location.href='UnitCenter.aspx';", true);
      

        }
        /// <summary>
        ///删除部门信息
        /// </summary>
        public void delDept(decimal deptid)
        {
            if (deptbll.del(deptid))//删除数据
            {
                //重新加载当前页
                Response.Redirect(Request.Url.AbsoluteUri, true);
            }
            //#region 删除数据：更新数据库数据状态
            ////获取实体
            //Entity.BASE_DEPT model = bll.GetEntity(deptid);
            //model.STATUS = 1;//设置部门状态为1：部门关闭
            //if (bll.update(model))
            //{
            //    //重新加载当前页
            //    Response.Redirect(Request.Url.AbsoluteUri, true);
            //}
            //#endregion
        }
        public void AjaxAlert(UpdatePanel uPanel, string strMsg) {
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');", true);
        }

        protected void TreeViewAcceptUnit_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e) {

            if (TreeViewAcceptUnit.CheckedNodes.Count > 1) {
                AjaxAlert(UpdatePanel1, "上级单位只能有一个！");
                return;
            } else {
                if (e.Node.Checked) {
                    hfdUnitCode.Value = e.Node.Value;
                    hfdUnitName.Value = e.Node.Text;
                }
            }
        }
    }
}