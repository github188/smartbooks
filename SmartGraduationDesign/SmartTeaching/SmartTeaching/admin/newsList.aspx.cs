using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class newsList : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        protected void lklDelete_Click(object sender, EventArgs e)
        {
            int Productid = Convert.ToInt32(((LinkButton)(sender)).CommandArgument.ToString());
            bll.Delete(Productid);
            Response.Redirect("newsList.aspx");
        }
        protected void lklUpdate_Click(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(((LinkButton)(sender)).CommandArgument.ToString());
            Response.Redirect("newsAdd.aspx?id=" + ProductID);
        }
       

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string serach = this.txtserach.Text.Trim().ToString();
            this.dlAdmin.DataSource = bll.GetList(string.Format("NewsTitle like '%{0}%'", serach));
            this.dlAdmin.DataBind();
        }


        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }

        private void bindDataSource()
        {
            DataTable dt = new DataTable();
            dt = bll.GetAllList().Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.dlAdmin.DataSource = pds;
            this.dlAdmin.DataBind();
        }
    }
}