using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class bbsDiscuss :   System.Web.UI.Page
    {
        BLL.Base_BBS bllBbs = new BLL.Base_BBS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
                BindUserList();
            }
        }

        private void BindUserList()
        {
            BLL.Base_User blluser = new BLL.Base_User();
            DataTable dt = blluser.GetAllList().Tables[0];
            chkUserList.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                chkUserList.Items.Add(new ListItem(
                    r["UserName"].ToString(),
                    r["UserId"].ToString()));
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }

        private void bindDataSource()
        {
            try
            {
                int uid = Convert.ToInt32(Session["uid"].ToString());
                string sec = string.Format("select a.username,b.newscontent,b.createdate from base_user a, base_bbs b where a.userid = b.userid and b.userid = {0}",
                    uid.ToString());
                DataTable dt = new DataTable();
                dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];


                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                this.dlAdmin.DataSource = pds;
                this.dlAdmin.DataBind();
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                lblmsg.Text = "消息内容不能为空";
                return;
            }

            //add message 
            int uid = Convert.ToInt32(Session["uid"].ToString());
            for (int i = 0; i < chkUserList.Items.Count; i++)
            {
                if (chkUserList.Items[i].Selected)
                {
                    Entity.Base_BBS model = new Entity.Base_BBS();
                    model.UserId = uid;
                    model.ToUserId = Convert.ToInt32(chkUserList.Items[i].Value);
                    model.NewsContent = txtMessage.Text.Trim();
                    model.CreateDate = DateTime.Now;
                    model.NewsId = 0;

                    bllBbs.Add(model);
                }
            }
        }

        
    }
}