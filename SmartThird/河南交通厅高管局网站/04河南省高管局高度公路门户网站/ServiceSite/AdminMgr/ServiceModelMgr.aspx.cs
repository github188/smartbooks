using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;
using DataAccess;

public partial class AdminMgr_ServiceModelMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            BindModelData();
            BindGVData(Convert.ToInt32(ddlSearch.SelectedValue));
        }
    }
    private void BindModelData() {
        DataTable dt = ServiceModelService.Get_ParentModelList();

        ddlSearch.DataSource = dt;
       

        ddlSearch.DataValueField = "M_ID";
        ddlSearch.DataTextField = "M_Name";

       
        ddlSearch.DataBind();
    }
    private void BindGVData(int parentID) {
        DataTable dt = ServiceModelService.Get_SonModelListByParent(parentID);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGVData(Convert.ToInt32(ddlSearch.SelectedValue));
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int mid = Convert.ToInt32(e.CommandArgument);
            ServiceModelService.Delete_ServiceModel(mid);
            BindGVData(Convert.ToInt32(ddlSearch.SelectedValue));
        }
    }
}
