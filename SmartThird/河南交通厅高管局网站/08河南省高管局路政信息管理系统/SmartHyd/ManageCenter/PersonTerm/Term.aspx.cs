using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.PersonTerm
{
    public partial class Term : System.Web.UI.Page
    {
        private BLL.BASE_TERM bll = new BLL.BASE_TERM();
        private BLL.BASE_TERM_TYPE typebll = new BLL.BASE_TERM_TYPE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTermData();
                BinfTermTypeData();//绑定装备类型
            }
        }


        //绑定装备分页数据
        private void BindTermData()
        {
            DataTable dt = new DataTable();
            int deptId = 2; //当前用户所属部门编号
            dt = bll.GetTermList(deptId);
            if (dt != null && dt.Rows.Count > 0)
            {
                //初始化分页数据
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;

                //绑定分页后的数据
                gv_patrollist.DataSource = pds;
                gv_patrollist.DataBind();
            }
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关装备数据!</div>"; 
            
            }
        }
        //绑定装备类型数据
        private void BinfTermTypeData()
        {
            DataTable dt = new DataTable();
            dt = typebll.GetAllList();
            DdrType.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DdrType.Items.Add(new ListItem(
                    dr["TYPENAME"].ToString(),
                    dr["TYPEID"].ToString()));
            }
        }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindTermData();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            BindTermData();
        }

        protected void gv_patrollist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                /*跳转到编辑页面*/
                case "edit":
                    Response.Redirect("TermEdit.aspx?id=" + id.ToString(), true);
                    break;
                /*跳转到详情页面*/
                case "view":
                    Response.Redirect("TermEdit.aspx?id=" + id.ToString(), true);
                    break;
                /*执行删除操作*/
                case "del":
                    del(id);
                    break;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="?"></param>
        private void del(decimal id)
        {
            if (bll.del(id))
            {
                Response.Redirect("Term.aspx");
            }
            //Entity.BASE_PATROL model = bll.GetModel(id);
            //model.STATE = 1;
            //if (bll.update(model))
            //{
            //    Response.Redirect("Term.aspx");
            //}
        }
    }
}