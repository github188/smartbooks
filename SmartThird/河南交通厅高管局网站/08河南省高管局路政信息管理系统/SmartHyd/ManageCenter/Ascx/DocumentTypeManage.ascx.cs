using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {

    public partial class DocumentTypeManage : UI.BaseUserControl {
        private BLL.BASE_ARTICLE_TYPE bll = new BLL.BASE_ARTICLE_TYPE();
        private Utility.UserSession userSession;
        private int inde = 0;
        private int deptCode = 0;   //部门ID编号

        #region 方法定义
        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //按分类浏览部门下档案分类数据
            Department2.OnSelectedNodeChanged +=new SmartHyd.Ascx.OnSelectedNodeChanged(Department2_OnSelectedNodeChanged);

            userSession = (Utility.UserSession)Session["user"];
            deptCode = Convert.ToInt32(userSession.DEPTID);

            if (!IsPostBack) {
                BindData();

                //绑定档案分类节点
                DataTable dt = bll.GetDeptNodeData(Convert.ToInt32(userSession.DEPTID));
                ddlParentNode.Items.Clear();
                ddlParentNode.Items.Add(new ListItem("根节点分类", "0"));
                InitTreeNodes(ddlParentNode, 0, dt, 0);
            }
        }

        //绑定档案分类节点
        private void InitTreeNodes(DropDownList ddl, int parentId, DataTable dt, int indent) {
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENT"].ToString() == parentId.ToString()) {
                    inde += indent;
                    ListItem item = new ListItem();
                    for (int i = 0; i < inde; i++) {
                        item.Text += "-";
                    }
                    item.Text += dr["TYPENAME"].ToString();
                    item.Value = dr["ID"].ToString();
                    ddl.Items.Add(item);
                    InitTreeNodes(ddl, Convert.ToInt32(dr["ID"].ToString()), dt, 2);
                    inde -= 2;
                }
            }
        }

        //绑定数据(分类节点)
        private void BindData() {
            DataTable dt = new DataTable();
            dt = bll.GetDeptNodeData(deptCode);

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            
            this.RptList.DataSource = pds; //定义数据源
            this.RptList.DataBind(); //绑定数据
        }
        //获取实体
        private Entity.BASE_ARTICLE_TYPE GetEntity() {
            Entity.BASE_ARTICLE_TYPE model = new Entity.BASE_ARTICLE_TYPE();
            int dptcode = -1;   //默认不属于任何部门
            if (Session["deptcode"] != null) {
                dptcode = Convert.ToInt32(Session["deptcode"].ToString());
            } else {
                throw new Exception("请选择所属的部门");                
            }

            //父级节点
            if (ddlParentNode.Items.Count != 0) {
                model.PARENT = Convert.ToInt32(ddlParentNode.SelectedValue);    //选择节点
            } else {
                model.PARENT = 0;   //0:根节点
            }
            
            model.DEPTID = dptcode;   //所属部门
            model.ID = 0;       //主键            
            model.SORT = Convert.ToInt32(txtSort.Text); //排序
            model.STATUS = Convert.ToInt32(ddlState.SelectedValue); //状态
            model.SUMMARY = txtSummary.Text.Trim();     //描述
            model.TYPENAME = txtTypeName.Text.Trim();   //类别描述

            return model;
        }
        //设置实体
        private void SetEntity(Entity.BASE_ARTICLE_TYPE model) {
            Session["deptcode"] = model.DEPTID;            
            hidPrimary.Value = model.ID.ToString();
            txtSort.Text = model.SORT.ToString();            
            txtSummary.Text = model.SUMMARY;
            txtTypeName.Text = model.TYPENAME;
            //model.STATUS
            //model.PARENT.ToString();
        }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        //添加
        public void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_ARTICLE_TYPE model;
            model = this.GetEntity();

            bll.Add(model);

            //重新加载当前页,请切换到浏览选项卡
            Response.Redirect("DocumentTypeManage.aspx?#tabs-2", true);
        }

        //分页按钮事件
        protected void RptList_ItemCommand(object source, RepeaterCommandEventArgs e) {
            switch (e.CommandName) {                
                //删除
                case "delete":
                    bll.Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    break;
            }

            Response.Redirect("DocumentTypeManage.aspx", true);
        }
        //按部门浏览分类数据
        private void Department2_OnSelectedNodeChanged(object sender, object value) {
            deptCode = Convert.ToInt32(value);
            BindData();
        }
    }
}