using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Department : UI.BaseUserControl
    {
        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }
        #region 私有方法
        //使用dataBindToRepeater()方法绑定部门数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetAllDep("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptList.DataSource = pds; //定义数据源
            this.RptList.DataBind(); //绑定数据
        }
       /// <summary>
       /// 获得部门数据实体
       /// </summary>
       /// <returns></returns>
        private Entity.BASE_DEPT GetEntity()
        {
            Entity.BASE_DEPT model = new Entity.BASE_DEPT();
            model.DEPTID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.DPTNAME = this.TxtDeptName.Text;                      //部门名称
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            model.PARENTID = Convert.ToDecimal(ddr.SelectedIndex);//上级部门
            model.DPTINFO = this.txtDptinfo.Text;         //部门描述
            model.STATUS = 0;                                              //状态0:正常；1：关闭

            return model;
        }
        /// <summary>
        /// 设置部门数据
        /// </summary>
        /// <param name="model">部门实体</param>
        private void SetEntity(Entity.BASE_DEPT model)
        {
            this.hidPrimary.Value = model.DEPTID.ToString();        //id,主键
            this.TxtDeptName.Text = model.DPTNAME;                    //部门名称
            
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            ddr.SelectedValue = model.PARENTID.ToString();                                //上级部门
            this.txtDptinfo.Text = model.DPTINFO;             //部门描述

            //model.STATES = 0;                                  //状态

        }
        #endregion
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_DEPT model = GetEntity();

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_DEPT());

            Smart.Utility.Alerts.Alert("test");
        }
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
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion
       
    }
}