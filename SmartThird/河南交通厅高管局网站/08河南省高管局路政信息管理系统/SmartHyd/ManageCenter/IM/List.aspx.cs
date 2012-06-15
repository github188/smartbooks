using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.IM {
    public partial class List : System.Web.UI.Page {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private Utility.UserSession userSession;

        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindMyMessage();
            }
        }

        private void BindMyMessage() {
            DataTable dt = new DataTable();

            dt = bll.GetMyMessage(Convert.ToInt32(userSession.USERID));

            if (dt != null && dt.Rows.Count > 0) {
                foreach (DataRow row in dt.Rows) {
                    if (row["MESSAGEBODY"].ToString().Length > 32) {
                        row["MESSAGEBODY"] = row["MESSAGEBODY"].ToString().Substring(0, 50) + "...>>点击查看详情";
                    }
                }
            }

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            grvList.DataSource = null;
            grvList.DataBind();

            grvList.DataSource = pds;
            grvList.DataBind();

            /*查询结果提示信息*/
            if (dt == null || dt.Rows.Count <= 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>没有公文数据!</div>";
            }
            else {
                litmsg.Visible = false;
            }
        }

        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e) {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            string url;
            switch (e.CommandName) {
                case "view":
                    url = string.Format("View.aspx?id={0}", id.ToString());
                    Response.Redirect(url, true);
                    break;
                case "reply":
                    url = string.Format("Add.aspx?id={0}", id.ToString());
                    Response.Redirect(url, true);
                    break;
            }
        }
    }
}