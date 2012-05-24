using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Role : UI.BaseUserControl
    {
        private BLL.BASE_ROLE bll = new BLL.BASE_ROLE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ("" == Request.QueryString["rid"] || null == Request.QueryString["rid"])
            {
                if (this.hidPrimary.Value == "-1")
                {
                    //this.LbTabName.Text = "添加角色";//设置选项卡名称
                    //this.LbHeadName.Text = "添加角色";//设置标题头名称
                }
                else
                {
                    //this.LbTabName.Text = "编辑角色";//设置选项卡名称
                    //this.LbHeadName.Text = "编辑角色";//设置标题头名称
                    int RoleID = Convert.ToInt32(this.hidPrimary.Value);
                    Entity.BASE_ROLE model = bll.GetEntity(RoleID);
                    SetEntity(model);
                }
            }
            else
            {
                //this.LbTabName.Text = "编辑角色";//设置选项卡名称
                //this.LbHeadName.Text = "编辑角色";//设置标题头名称
                int RoleID = Convert.ToInt32(Request.QueryString["rid"]);
                Entity.BASE_ROLE model = bll.GetEntity(RoleID);
                SetEntity(model);
            }
            dataBindToRepeater();
        }

        //使用dataBindToRepeater()方法绑定角色数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.repList.DataSource = pds; //定义数据源
            this.repList.DataBind(); //绑定数据
        }
        /// <summary>
        /// 获得角色实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_ROLE GetEntity()
        {
            Entity.BASE_ROLE model = new Entity.BASE_ROLE();
            model.ROLEID = Convert.ToDecimal(this.hidPrimary.Value);//id ，主键
            model.ROLENAME = this.TxtRoleName.Text; //角色名称
            model.ROLEINFO = this.txtdesc.Text; //角色描述
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        private void SetEntity(Entity.BASE_ROLE model)
        {
            this.TxtRoleName.Text = model.ROLENAME;
            this.txtdesc.Text = model.ROLEINFO;
        }

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_ROLE model = GetEntity();

            //添加数据
            bll.Add(model);
          
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri + "#tabs-2", true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_ROLE());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) {
            //获取实体
            Entity.BASE_ROLE model = GetEntity();

            //修改数据
            if (bll.update(model))
            {
                //重新加载当前页
                Response.Redirect("Role.aspx#tabs-2");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
            }
        }
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
       

        /// <summary>
        /// //分页事件 角色分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion
    }
}