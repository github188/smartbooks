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
using PubClass;
using Model;
using DataAccess;

public partial class NewsDetailInfo : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isSelectedService();
            int nid = Convert.ToInt32(Request.QueryString["nid"]);
            dt = ServiceNewService.Get_ServiceNewsViewById(nid);
            Title = dt.Rows[0]["N_Title"] + "-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
        }
    }
}
