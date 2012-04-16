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
using DataAccess;
using Model;


public partial class ServiceItemDetail : System.Web.UI.Page
{
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isSelectedService();
            int itemid = Convert.ToInt32(Request.QueryString["itemid"]);
            dt = ServiceItemService.Get_ServiceItemView(itemid);
            Title = dt.Rows[0]["i_Title"] + "-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
        }
    }
}
