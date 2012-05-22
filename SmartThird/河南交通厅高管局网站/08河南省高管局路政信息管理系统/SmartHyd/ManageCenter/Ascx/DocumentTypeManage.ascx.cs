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

        #region 方法定义
        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindData();
                userSession = (Utility.UserSession)Session["user"];

                //绑定档案分类节点
                //DataTable dt = bll.GetDeptNodeData(Convert.ToInt32(userSession.DEPTID));
                DataTable dt = bll.GetDeptNodeData(13);
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
            int deptCode = 13;   //当前登录用户部门编号

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

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e) {
            Entity.BASE_ARTICLE_TYPE model;
            model = this.GetEntity();

            bll.Add(model);

            //重新加载当前页,请切换到浏览选项卡
            Response.Redirect(Request.Url.AbsoluteUri + "#tabs-2", true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e) { }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e) { }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public override void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public override void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public override void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public override void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public override void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public override void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public override void BtnGrant_Click(object sender, EventArgs e) { }
        #endregion
    }
}