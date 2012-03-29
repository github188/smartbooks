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
using System.Drawing;
using Model;
using DataAccess;

public partial class AdminMgr_ServiceNewsMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isLoginCheck();
            if (Request.QueryString["tid"] != null)
            {
               int tid = Convert.ToInt32(Request.QueryString["tid"]);
               ViewState["tid"] = tid;
                binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
                switch (tid) { 
                    case 1:
                        _ChangBtnColor(btnYZXW,tid);
                        break;
                    case 3:
                        _ChangBtnColor(btnGLZD,tid);
                        break;
                    case 5:
                        _ChangBtnColor(btnWMCJ,tid);
                        break;
                    case 7:
                        _ChangBtnColor(btnYZWH,tid);
                        break;
                    case 8:
                        _ChangBtnColor(btnXXYD, tid);
                        break;
                } 
            }
        }
    }
    void binddata(int sid, int tid)
    {
        DataTable dt = ServiceNewService.GetNewsViewByType(sid, tid);
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            GridView1.DataSource = ps;
            GridView1.DataBind();
        }
    }
    private void _ChangBtnColor(Button btn,int tid) {
        btnYZXW.ForeColor = Color.Black;
        btnGLZD.ForeColor = Color.Black;
        btnWMCJ.ForeColor=Color.Black;
        btnYZWH.ForeColor=Color.Black;
        btn.ForeColor=Color.Red;
        linkAddTitle.NavigateUrl = "AddServiceNewsInfo.aspx?action=add&tid="+tid;
    }
    protected void btnYZXW_Click(object sender, EventArgs e)
    {
       int tid = 1;
       ViewState["tid"] = tid;
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
        _ChangBtnColor(btnYZXW, tid);
    }
    protected void btnGLZD_Click(object sender, EventArgs e)
    {
       int tid = 3;
       ViewState["tid"] = tid;
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
        _ChangBtnColor(btnGLZD, tid);
    }
    protected void btnWMCJ_Click(object sender, EventArgs e)
    {
       int tid = 5;
       ViewState["tid"] = tid;
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
        _ChangBtnColor(btnWMCJ, tid);
    }
    protected void btnYZWH_Click(object sender, EventArgs e)
    {
        int tid = 7;
        ViewState["tid"] = tid;
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
        _ChangBtnColor(btnYZWH, tid);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["tid"]));
    } 
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delRecord")
        {
            int nid = Convert.ToInt32(e.CommandArgument);
            ServiceNewService.Delete_News(nid);
            binddata(((UserInfo)Session["ServiceUser"]).U_SID, Convert.ToInt32(ViewState["tid"]));
        }
    }
    protected void btnXXYD_Click(object sender, EventArgs e)
    {
       int  tid = 8;
       ViewState["tid"] = tid;
        binddata(((UserInfo)Session["ServiceUser"]).U_SID, tid);
        _ChangBtnColor(btnXXYD, tid);
    }
}
