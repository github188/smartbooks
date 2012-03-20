using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartPoms.Poms.Ascx {
    public partial class NegativeReported : System.Web.UI.UserControl {
        //负面报道ＩＤ
        private int eventid = 2;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                this.txtBeginDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                this.txtEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                BindDataSource();
            }
        }

        private void BindDataSource() {
            SmartPoms.BLL.Service.ArticleService article = new BLL.Service.ArticleService();
            this.dgvComments.DataSource = article.GetEventArticle(this.txtBeginDate.Text, this.txtEndDate.Text, eventid);
            this.dgvComments.DataBind();
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