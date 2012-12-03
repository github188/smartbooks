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
using RoadEntity;
using RoadService;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
          RoadDepart depart=(RoadDepart)Session["roadinfo"];//获取一个路政单位的实体信息
          this.Title = "网站首页门户网站";

          DataTable dtLZFG = NewsInfoService.Get_NewsViewList(depart.RD_ID, 2, 7);//2代表类型是路政法规
          rptLZFG.DataSource = dtLZFG;//路政法规
          rptLZFG.DataBind();

          DataTable dtGZDT = NewsInfoService.Get_NewsViewList(depart.RD_ID, 1, 7);//1代表是工作动态
          rptGZDT.DataSource = dtGZDT;//工作动态
          rptGZDT.DataBind();

          DataTable dtDWRY = NewsInfoService.Get_NewsViewList(depart.RD_ID, 3, 0);//3代表是单位荣誉
          rptRongYu.DataSource = dtDWRY;//单位荣誉
          rptRongYu.DataBind();

          DataTable dtGGGS = NewsInfoService.Get_NewsViewList(depart.RD_ID,4,7);
          rptGGGS.DataSource = dtGGGS;
          rptGGGS.DataBind();

         
        }
    }
}
