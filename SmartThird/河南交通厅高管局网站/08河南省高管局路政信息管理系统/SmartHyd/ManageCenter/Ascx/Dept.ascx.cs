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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }
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
            model.PARENTID = Convert.ToDecimal(ddr.SelectedValue);//上级部门
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
        /// <summary>
        /// 公告管理分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }

        
       
        /// <summary>
        /// 按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.BASE_DEPT model = GetEntity();
            bll.Add(model);
        }
    }
}