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

public partial class CertificateList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            CommonFunction.isSelectedService();
            Title = "ISO国际标准化认证证书-" + ((ServiceInfo)Session["serviceinfo"]).S_Name + "门户网站";
            rptISO.DataSource = ServiceNewService.Get_AllNews(((ServiceInfo)Session["serviceinfo"]).S_ID, 0, 9);
            rptISO.DataBind();
        }
    }
}
