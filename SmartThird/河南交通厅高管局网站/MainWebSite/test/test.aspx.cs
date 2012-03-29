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
using MainModel;
using MainService;

public partial class test_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileFunction.DataToExcel(NewsInfoService.Get_NewsInfoViewList(21), new string[] { "编号","标题","内容" }, "数据导出报表", "1234567");
        //GridView1.DataSource = NewsInfoService.Get_NewsInfoViewList(21);
        //GridView1.DataBind();
        //GridView1.Columns[2].Visible = true;
    }
}
