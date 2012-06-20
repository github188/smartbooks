using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter
{
    public partial class TermEdit : System.Web.UI.Page
    {
        private BLL.BASE_TERM bll = new BLL.BASE_TERM();
        private BLL.BASE_TERM_TYPE typebll = new BLL.BASE_TERM_TYPE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                {
                    //添加状态页面
                    this.LabName.Text = "添加装备";
                }
                else
                {
                    //编辑状态绑定
                    this.LabName.Text = "编辑装备信息";
                    decimal Epid = Convert.ToDecimal(Request.QueryString["id"]);
                    ViewState["id"] = Request.QueryString["id"];
                    Entity.BASE_TERM model = bll.getModel(Epid);
                    SetEntity(model);
                }
                BinfTermTypeData();
            }
        }

        //绑定装备类型数据
        private void BinfTermTypeData()
        {
            DataTable dt = new DataTable();
            dt = typebll.GetAllList();
            ddlTermType.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ddlTermType.Items.Add(new ListItem(
                    dr["TYPENAME"].ToString(),
                    dr["TYPEID"].ToString()));
            }
        }
        //从页面获取实体
        private Entity.BASE_TERM GetEntity()
        {
            Entity.BASE_TERM model = new Entity.BASE_TERM();
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            model.BRAND = this.txtUSETIME.Text;//制造厂商
            model.DEPTID = Convert.ToDecimal(ddr.SelectedValue);//所属单位；
            model.FORMAT = this.txtFORMAT.Text;//规格型号
            model.REMARK = this.txtRemark.Text;//备注
            model.SAVEPOINT = this.TxtPosition.Text;//存放地点
            model.SERIALCODE = this.txtSERIALCODE.Text;//出厂编号
            model.STATUS = 0;//状态（0：正常；1：删除）
            model.TERMCODE = this.txtTERMCODE.Text;//设备编号
            model.TERMID = Convert.ToDecimal(this.hidPrimary.Value);//主键，编号
            model.TERMNAME = this.txtTERMNAME.Text;//设备名称
            model.TYPEID = Convert.ToDecimal(this.ddlTermType.SelectedValue);//装备类型
            model.USE = this.txtUse.Text;//装备用途
            model.USETIME = Convert.ToDateTime(this.txtUSETIME.Text);//投入使用时间

            return model;
        }

        //初始化实体到页面
        private void SetEntity(Entity.BASE_TERM model)
        {
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            this.txtUSETIME.Text = model.BRAND;//制造厂商
            ddr.SelectedValue = model.DEPTID.ToString();//所属单位；
            this.txtFORMAT.Text = model.FORMAT;//规格型号
            this.txtRemark.Text = model.REMARK;//备注
            this.TxtPosition.Text=model.SAVEPOINT;//存放地点
            this.txtSERIALCODE.Text = model.SERIALCODE;//出厂编号
            //model.STATUS = 0;//状态（0：正常；1：删除）
            this.txtTERMCODE.Text = model.TERMCODE;//设备编号
            this.hidPrimary.Value = model.TERMID.ToString();//主键，编号
            this.txtTERMNAME.Text = model.TERMNAME;//设备名称
            this.ddlTermType.SelectedValue = model.TYPEID.ToString();//装备类型
            this.txtUse.Text = model.USE;//装备用途
            this.txtUSETIME.Text = model.USETIME.ToString();//投入使用时间
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.BASE_TERM model = GetEntity();
            if (ViewState["id"] == null)
            {
                bll.Add(model);
            }
            else
            {
                bll.update(model);
            }
            Response.Redirect("Term.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_TERM());
        }
    }
}