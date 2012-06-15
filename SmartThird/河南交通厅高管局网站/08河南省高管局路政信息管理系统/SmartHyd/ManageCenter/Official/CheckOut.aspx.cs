using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Official {
    public partial class CheckOut : System.Web.UI.Page {
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;
        private int sendId = -1;
        private Entity.BASE_ARTICLE model;

        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                if (Request.QueryString["id"] != null) {
                    sendId = Convert.ToInt32(Request.QueryString["id"]);
                }

                //获取发文实体
                model = bll.GetEntity(sendId);

                //绑定回文列表数据
                BindingReplyList();
            }
        }

        //绑定回文列表
        private void BindingReplyList() {
            DataTable dt = new DataTable();

            dt = bll.GetReplyList(sendId);   //获取回文数据列表

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

            //绑定分页后的数据
            grvList.DataSource = pds;
            grvList.DataBind();
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindingReplyList();
        }
        
        //更新分数
        protected void grvList_RowEditing(object sender, GridViewEditEventArgs e) {
            try {
                int score = 0;
                int id = 0;
                foreach (Control ct in grvList.Rows[e.NewEditIndex].Cells[4].Controls) {
                    if (ct.GetType().Equals(typeof(TextBox))) {
                        TextBox tb = (TextBox)ct;
                        score = Convert.ToInt32(tb.Text.Trim());
                    }
                }
                foreach (Control ct in grvList.Rows[e.NewEditIndex].Cells[5].Controls) {
                    if (ct.GetType().Equals(typeof(LinkButton))) {
                        LinkButton lb = (LinkButton)ct;
                        id = Convert.ToInt32(lb.CommandArgument);
                    }
                }

                //更新分数
                bll.UpdateSocre(id, score);
            }
            catch {
            }
            finally {
                Response.Redirect(Request.Url.AbsoluteUri, true);
            }
        }
    }
}