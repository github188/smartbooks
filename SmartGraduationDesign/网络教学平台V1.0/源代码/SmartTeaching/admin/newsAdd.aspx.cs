using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class newsAdd : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTypes();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                Entity.Base_News model = new Entity.Base_News();
                model.NewsTitle = txtTitle.Text.Trim();
                model.Summary = txtSummary.Text.Trim();
                model.NewsContent = txtContent.Text.Trim();

                model.UserId = 0;
                model.NewsTypeId = Convert.ToInt32(ddlNewaType.SelectedValue);
                model.CreateDate = DateTime.Now;
                string filename = "";
                string filepath = "";
                int filesize = 0;

                if (fileup.HasFile)
                {
                    UpFile(out filename, out filepath, out filesize);
                }

                model.FileName = filename;
                model.FilePath = filepath;
                model.FileSize = filesize;

                if (bll.Add(model) > 0)
                {
                    Response.Redirect("newsList.aspx", true);
                }
                else
                {
                    lblmsg.Text = "添加失败";
                }
            }
        }

        private bool CheckInput()
        {
            lblmsg.Text = "";

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                lblmsg.Text = "标题不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(txtSummary.Text))
            {
                lblmsg.Text = "摘要不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtContent.Text))
            {
                lblmsg.Text = "摘要不能为空";
                return false;
            }

            return true;
        }

        private void BindTypes()
        {
            DataTable dt = new DataTable();
            BLL.Base_NewsType types = new BLL.Base_NewsType();
            dt = types.GetAllList().Tables[0];
            ddlNewaType.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                ddlNewaType.Items.Add(new ListItem(
                    r["NewsTypeName"].ToString(),
                    r["NewsTypeId"].ToString()));
            }
        }

        private void UpFile(out string fileName, out string filepath, out int fileSize)
        {
            fileName = fileup.FileName;
            fileSize = fileup.FileBytes.Length;
            filepath = Server.MapPath("~/upload/") + fileup.FileName;            
            fileup.SaveAs(filepath);
        }
    }
}