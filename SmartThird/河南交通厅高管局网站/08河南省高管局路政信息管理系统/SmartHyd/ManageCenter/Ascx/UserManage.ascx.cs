using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class UserManage : UI.BaseUserControl {
        private BLL.BASE_USER bll = new BLL.BASE_USER();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindUserList();
            }
        }

        private void BindUserList() {
            DataTable dt = new DataTable();
            dt = bll.GetAllUser();

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
        }

        private Entity.BASE_USER GetEntity() {
            Entity.BASE_USER model = new Entity.BASE_USER();

            model.BIRTHDAY = DateTime.Parse(txtBIRTHDAY.Text);
            model.DEGREE = txtDEGREE.Text;
            model.DEPTID = Convert.ToInt32(ddldept.SelectedValue);
            model.FACE = txtFACE.Text;
            model.IDNUMBER = txtIDNUMBER.Text;
            model.JOBNUMBER = txtJOBNUMBER.Text;            
            model.PHONE = txtPhone.Text;            
            model.PROF = txtPROF.Text;
            model.REMARK = txtRemark.Text;
            model.SEX = Convert.ToInt32(ddlSex.SelectedValue);            
            model.USERNAME = txtUserName.Text;
            model.USERPWD = txtPassword.Text;
            model.STSTUS = 0;
            model.USERID = 0;
            model.PARENTID = 0;
            model.PHOTO = "";

            return model;
        }

        private void SetEntity(Entity.BASE_USER model) {            
            txtBIRTHDAY.Text = model.BIRTHDAY.ToString("yyyy-MM-dd");
            txtDEGREE.Text =model.DEGREE;
            txtFACE.Text = model.FACE;
            txtIDNUMBER.Text = model.IDNUMBER;
            txtJOBNUMBER.Text = model.JOBNUMBER;
            txtPhone.Text = model.PHONE;
            txtPROF.Text = model.PROF;
            txtRemark.Text = model.REMARK;
            txtUserName.Text = model.USERNAME;
            txtPassword.Text = model.USERPWD;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {

        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_USER());
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindUserList();
        }
    }
}