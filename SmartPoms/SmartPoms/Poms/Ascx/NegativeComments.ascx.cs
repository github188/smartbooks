
namespace SmartPoms.Poms.Ascx {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class NegativeComments : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            txtBeginDate.Text = Request.Form["ctl00$ContentPlaceHolder1$NegativeComments1$txtBeginDate"];
            txtEndDate.Text = Request.Form["ctl00$ContentPlaceHolder1$NegativeComments1$txtEndDate"];

            if (!IsPostBack) {
                txtBeginDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                BindDataSource();
            }
        }

        private void BindDataSource() {
            /*获取参数*/
            string beginDate = txtBeginDate.Text;
            string endDate = txtEndDate.Text;
            string[] siteName = txtSiteName.Text.Split(',');
            string[] keys = txtKeywordList.Text.Split(',');
            int sortType = Convert.ToInt32(rdoSortResult.SelectedValue);

            /*查询数据*/
            SmartPoms.BLL.Service.ArticleService article = new BLL.Service.ArticleService();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = article.GetEventArticle(beginDate, endDate, siteName, keys, sortType);
            this.dgvComments.DataSource = dt;
            this.dgvComments.DataBind();

            /*绑定查询结果*/
            this.panelResult.GroupingText = string.Format("共查询到 {0} 条记录", dt.Rows.Count.ToString());
        }

        protected void dgvComments_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            this.dgvComments.PageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            if (CheckInput()) {
                this.BindDataSource();
            }
        }

        private bool CheckInput() {
            this.lblError.Text = "";
            try {
                Convert.ToDateTime(this.txtBeginDate.Text);
            } catch {
                this.lblError.Text = "开始时间格式错误。";
                return false;
            }
            try {
                Convert.ToDateTime(this.txtEndDate.Text);
            } catch {
                this.lblError.Text = "结束时间格式错误。";
                return false;
            }

            return true;
        }
    }
}