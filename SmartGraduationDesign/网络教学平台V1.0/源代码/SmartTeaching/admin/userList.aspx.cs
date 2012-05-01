using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class userList : System.Web.UI.Page
    {
        BLL.Base_User user = new BLL.Base_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            this.dlAdmin.DataSource = user.GetAllList();
            dlAdmin.DataBind();
        }
        protected void lklDelete_Click(object sender, EventArgs e)
        {
            int Productid = Convert.ToInt32(((LinkButton)(sender)).CommandArgument.ToString());
            user.Delete(Productid);
            Response.Redirect("userList.aspx");
        }
        protected void lklUpdate_Click(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(((LinkButton)(sender)).CommandArgument.ToString());
            Response.Redirect("userAdd.aspx?id=" + ProductID);
        }
        protected void ImageBind()
        {
            try
            {
                PagedDataSource PDS = new PagedDataSource();
                int curpage = Convert.ToInt32(this.labNowPageNum.Text);
                DataTable dt = user.GetAllList().Tables[0];
                PDS.DataSource = dt.DefaultView;
                PDS.AllowPaging = true;//判断是否启用分页功能
                PDS.PageSize = 15; //设置分页的大小
                PDS.CurrentPageIndex = curpage - 1;//获得当前页的页码
                this.lklFirst.Enabled = true;
                this.lklBack.Enabled = true;
                this.lklNext.Enabled = true;
                this.lklLast.Enabled = true;
                if (curpage == 1)
                {
                    this.lklFirst.Enabled = false;//不显示首页
                    this.lklBack.Enabled = false;//不显示上一页
                }
                if (this.labNowPageNum.Text == this.labAllPageNum.Text)
                {
                    if (this.labAllPageNum.Text == "1")
                    {
                        this.lklFirst.Enabled = false;
                        this.lklBack.Enabled = false;
                        this.lklLast.Enabled = false;
                        this.lklNext.Enabled = false;
                    }
                    else
                    {
                        this.lklFirst.Enabled = true;
                        this.lklBack.Enabled = true;
                        this.lklLast.Enabled = false;
                        this.lklNext.Enabled = false;
                    }
                }
                this.labAllPageNum.Text = Convert.ToString(PDS.PageCount);//获得总页码数      
                this.dlAdmin.DataSource = PDS;
                this.dlAdmin.DataBind();
            }
            catch
            {

            }
        }
        protected void lklFirst_Click(object sender, EventArgs e)
        {
            this.labNowPageNum.Text = "1";
            this.ImageBind();
        }
        protected void lklLast_Click(object sender, EventArgs e)
        {
            this.labNowPageNum.Text = this.labAllPageNum.Text;
            this.ImageBind();
        }
        protected void lklBack_Click(object sender, EventArgs e)
        {
            this.labNowPageNum.Text = Convert.ToString(Convert.ToInt32(this.labNowPageNum.Text) + 1);
            this.ImageBind();
        }
        protected void lklNext_Click(object sender, EventArgs e)
        {
            this.labNowPageNum.Text = Convert.ToString(Convert.ToInt32(this.labNowPageNum.Text) + 1);
            this.ImageBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string serach = this.txtserach.Text.Trim().ToString();
            this.dlAdmin.DataSource = user.GetList(string.Format("UserName like '%{0}%'", serach));
            this.dlAdmin.DataBind();
        }
    }
}