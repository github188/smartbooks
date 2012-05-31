using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Department : UI.BaseUserControl {
        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if ("" == Request.QueryString["Fid"] || null == Request.QueryString["Fid"])
                {
                    if (this.hidPrimary.Value == "-1")
                    {
                        this.LbTabName.Text = "新建部门";//设置选项卡名称
                        this.LbHeadName.Text = "新建部门";//设置标题头名称
                    }
                    else
                    {
                        this.LbTabName.Text = "编辑部门信息";//设置选项卡名称
                        this.LbHeadName.Text = "编辑部门信息";//设置标题头名称
                        decimal DEPTID = Convert.ToDecimal(this.hidPrimary.Value);
                        Entity.BASE_DEPT model = bll.GetEntity(DEPTID);
                        SetEntity(model);
                    }
                }
                else
                {
                    this.LbTabName.Text = "编辑部门信息";//设置选项卡名称
                    this.LbHeadName.Text = "编辑部门信息";//设置标题头名称
                    decimal DEPTID = Convert.ToDecimal(Request.QueryString["Fid"]);
                    Entity.BASE_DEPT model = bll.GetEntity(DEPTID);
                    SetEntity(model);
                }
                dataBindToRepeater();
            }
        }

        #region 私有方法
        //使用dataBindToRepeater()方法绑定部门数据
        private void dataBindToRepeater() {
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
        private Entity.BASE_DEPT GetEntity() {
            decimal parentId = 0;

            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            parentId=Convert.ToDecimal(ddr.SelectedValue);                                //上级部门
            if (Session["deptcode"] != null) {
                Convert.ToInt32(Session["deptcode"].ToString());
            }
            Entity.BASE_DEPT model = new Entity.BASE_DEPT();
            model.DEPTID = Convert.ToInt32(this.hidPrimary.Value);  //id,主键
            model.DPTNAME = this.TxtDeptName.Text.Trim();           //部门名称       
            model.DPTINFO = this.txtDptinfo.Text.Trim();            //部门描述
            model.PARENTID = parentId;   //上级部门
            model.STATUS = 0;                                   //状态0:正常；1：关闭

            return model;
        }
        /// <summary>
        /// 设置部门数据
        /// </summary>
        /// <param name="model">部门实体</param>
        private void SetEntity(Entity.BASE_DEPT model) {
            this.hidPrimary.Value = model.DEPTID.ToString();        //id,主键
            this.TxtDeptName.Text = model.DPTNAME;                    //部门名称
            this.txtDptinfo.Text = model.DPTINFO;             //部门描述

            //DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            //ddr.SelectedValue = model.PARENTID.ToString();                                //上级部门
            //model.STATES = 0;                                  //状态
        }
        #endregion

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e) {
            //获取实体
            Entity.BASE_DEPT model = GetEntity();

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e) {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e) {
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
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion


        #region 页面按钮事件
        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (this.hidPrimary.Value == "-1")//添加部门信息
            {
                //获取实体
                Entity.BASE_DEPT model = GetEntity();

                //添加数据
                bll.Add(model);

                //日志..............添加
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "部门管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "新建部门";                             //日志信息内容
                logmodel.OPERATORID = 17;                    //操作人编号
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);

            }
            else //修改部门信息
            {
                //获取实体
                Entity.BASE_DEPT model = GetEntity();
                bll.update(model);

                //日志..............修改
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "部门管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "编辑部门";                             //日志信息内容
                logmodel.OPERATORID = 17;                    //操作人编号
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);
            }
            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri+"#tabs-2", true);
        }
        #endregion
    }
}