using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching
{
    public partial class newsDetail : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Entity.Base_News model = new Entity.Base_News();
                    model = bll.GetModel(id);

                    Page.Title = model.NewsTitle;
                    litNewsContent.Text = model.NewsContent;
                    litNewsTitle.Text = model.NewsTitle;
                    ltlCreateDate.Text = model.CreateDate.ToString();
                    litSummary.Text = model.Summary;
                }
                catch
                {
                }
            }
        }
    }
}