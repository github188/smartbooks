
namespace SmartPomsApp.poms.ascx {
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using SmartPoms.ServiceInterfaces;
    using Smart.ServiceFactory;

    public partial class NegativeReported : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                bindDateSource();
            }
        }

        protected void bindDateSource() {
            ITopicService topicService = ComponentFactory<ITopicService>.GetBLLPlugin();
            DataTable dt = topicService.getArticle(0, 10, "2011-01-01", "2013-01-01", 1);
            foreach (DataRow r in dt.Rows) {
                //截摘要长度
                string conn = r["DETAIL"].ToString();
                if (conn.Length > 80) {
                    conn = conn.Substring(0, 79);
                    r["DETAIL"] = conn;
                }

                //标题着重关键字显示
                if (r["TITLE"].ToString().Contains("国家")) {
                    r["TITLE"] = r["TITLE"].ToString().Replace("国家", "<em>国家</em>");
                }
            }
            this.ddlViewList.DataSource = dt;
            this.ddlViewList.DataBind();
        }
    }
}