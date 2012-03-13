
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
            IKeywordService wordService = ComponentFactory<IKeywordService>.GetBLLPlugin();
            DataTable dtWord = wordService.getTopicKeywords(0);
            DataTable dt = topicService.getArticle(0, 10, "2011-01-01", "2013-01-01", 0);
            foreach (DataRow r in dt.Rows) {
                //截摘要长度
                string conn = r["DETAIL"].ToString();
                if (conn.Length > 80) {
                    conn = conn.Substring(0, 79);
                    r["DETAIL"] = conn;
                }
                string wordTextTemp = "";
                foreach (DataRow wordRow in dtWord.Rows) {
                    //标题着重关键字显示
                    wordTextTemp = wordRow["WORDNAME"].ToString();
                    if (r["TITLE"].ToString().Contains(wordTextTemp)) {
                        r["TITLE"] = r["TITLE"].ToString().Replace(wordTextTemp, string.Format("<em>{0}</em>", wordTextTemp));
                    }

                    //摘要着重关键字显示
                    if (r["DETAIL"].ToString().Contains(wordTextTemp)) {
                        r["DETAIL"] = r["DETAIL"].ToString().Replace(wordTextTemp, string.Format("<em>{0}</em>", wordTextTemp));
                    }
                }
            }
            this.ddlViewList.DataSource = dt;
            this.ddlViewList.DataBind();
        }
    }
}