using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching.admin
{
    public partial class docsType : System.Web.UI.Page
    {
        BLL.Base_NewsType type = new BLL.Base_NewsType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
                BindRootType();
            }
        }
        private void Bind()
        {
            this.dlAdmin.DataSource = type.GetAllList();
            dlAdmin.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string serach = this.txtserach.Text.Trim().ToString();
            this.dlAdmin.DataSource = type.GetList(string.Format("NewsTypeName like '%{0}%'", serach));
            this.dlAdmin.DataBind();
        }

        private void bindDataSource()
        {
            DataTable dt = new DataTable();
            dt = type.GetAllList().Tables[0];

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.dlAdmin.DataSource = pds;
            this.dlAdmin.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDataSource();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                Entity.Base_NewsType model = new Entity.Base_NewsType();
                model.NewsTypeId = Convert.ToInt32(txtnum.Text.Trim());
                model.NewsTypeName = txtTypeName.Text.Trim();
                model.Remarks = txtRemarks.Text.Trim();
                model.ParentId = Convert.ToInt32(rdoParentTree.SelectedValue);
                if (model.NewsTypeId < 0)
                {
                    //添加
                    if (type.Add(model) > 0)
                    {
                        Response.Redirect("docsType.aspx");
                    }
                    else
                    {
                        lblmsg.Text = "添加失败";
                    }
                }
                else
                {
                    //修改
                    if (type.Update(model))
                    {
                        Response.Redirect("docsType.aspx");
                    }
                    else
                    {
                        lblmsg.Text = "修改失败";
                    }
                }
            }
        }

        private bool CheckInput()
        {
            lblmsg.Text = "";
            if (string.IsNullOrEmpty(txtTypeName.Text))
            {
                txtTypeName.Focus();
                lblmsg.Text = "分类名称不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(txtRemarks.Text))
            {
                txtRemarks.Focus();
                lblmsg.Text = "分类描述不能为空";
                return false;
            }

            return true;
        }
        private void BindRootType()
        {
            DataTable dt = type.GetList("ParentId=0").Tables[0];
            rdoParentTree.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                rdoParentTree.Items.Add(new ListItem(r["NewsTypeName"].ToString(),
                    r["NewsTypeId"].ToString()));
            }
            if (rdoParentTree.Items.Count != 0)
            {
                rdoParentTree.SelectedIndex = 0;
            }
        }
    }
}