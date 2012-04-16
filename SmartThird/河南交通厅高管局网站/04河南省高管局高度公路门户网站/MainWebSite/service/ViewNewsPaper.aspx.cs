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
using MainService;
using MainModel;
using System.Drawing;

public partial class service_ViewNewsPaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            int nid = Convert.ToInt32(Request.QueryString["nid"]);
            NewsPaper paper = NewsPaperService.Get_NewsPaperModel(nid);
            lblPosition.Text = paper.N_Title;
            lblPosition.Font.Bold = true;
            lblPosition.ForeColor = Color.Red;
            CLinkButtonColor(btnPage1);
            NewsImg.ImageUrl = "../newspaper/" + paper.N_AImg ;
            ViewState["paper"] = paper;
        }
    }
    protected void btnPage1_Click(object sender, EventArgs e)
    {
        NewsPaper paper = (NewsPaper)ViewState["paper"];
        NewsImg.ImageUrl = "../newspaper/" + paper.N_AImg;
        CLinkButtonColor(btnPage1);
    }
    protected void btnPage2_Click(object sender, EventArgs e)
    {
        NewsPaper paper = (NewsPaper)ViewState["paper"];
        NewsImg.ImageUrl = "../newspaper/" + paper.N_BImg;
        CLinkButtonColor(btnPage2);
    }
    protected void btnPage3_Click(object sender, EventArgs e)
    {
        NewsPaper paper = (NewsPaper)ViewState["paper"];
        NewsImg.ImageUrl = "../newspaper/" + paper.N_CImg;
        CLinkButtonColor(btnPage3);
    }
    protected void btnPage4_Click(object sender, EventArgs e)
    {
        NewsPaper paper = (NewsPaper)ViewState["paper"];
        NewsImg.ImageUrl = "../newspaper/" + paper.N_DImg;
        CLinkButtonColor(btnPage4);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewsPaper paper = (NewsPaper)ViewState["paper"];
        if (DropDownList1.Text == "第A01版")
        {
            NewsImg.ImageUrl = "../newspaper/" + paper.N_AImg;
            CLinkButtonColor(btnPage1);
        }
        else if (DropDownList1.Text == "第A02版")
        {
            NewsImg.ImageUrl = "../newspaper/" + paper.N_BImg;
            CLinkButtonColor(btnPage2);
        }
        else if (DropDownList1.Text == "第A03版")
        {
            NewsImg.ImageUrl = "../newspaper/" + paper.N_CImg;
            CLinkButtonColor(btnPage3);
        }
        else if (DropDownList1.Text == "第A04版")
        {
            NewsImg.ImageUrl = "../newspaper/" + paper.N_DImg;
            CLinkButtonColor(btnPage4);
        }
    }
    private void CLinkButtonColor(LinkButton btn) {
        btnPage1.ForeColor = Color.White;
        btnPage1.Font.Bold = false;
        btnPage2.ForeColor = Color.White;
        btnPage2.Font.Bold = false;
        btnPage3.ForeColor = Color.White;
        btnPage3.Font.Bold = false;
        btnPage4.ForeColor = Color.White;
        btnPage4.Font.Bold = false;
        btn.ForeColor = Color.Red;
        btn.Font.Bold = true;
        DropDownList1.Text = btn.Text;
    }
}
