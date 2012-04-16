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

public partial class CheckToService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            if (Request.QueryString["serviceid"] != null)
            {
                int ServiceId = Convert.ToInt32(Request.QueryString["serviceid"]);
                ServiceInfo serviceinfo = ServiceInfoService.Get_ServiceInfo(ServiceId);
                if (serviceinfo != null)
                {
                    Session["serviceinfo"] = serviceinfo;
                    Response.Redirect("index.aspx");
                }
                else {
                    Response.Redirect("ServiceList.aspx");
                }
            }
            else {
                Response.Redirect("ServiceList.aspx");
            }
        }
    }
}
