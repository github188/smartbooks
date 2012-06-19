using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Affiche
{
    public partial class Affiche : System.Web.UI.Page
    {
        private BLL.BASE_AFFICHE bll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (null == Request.QueryString["Action"] || "" == Request.QueryString["Action"])
                {
                    dataBindToRepeater("1=1");//绑定电子公告数据
                }
                else
                {
                    if (null == Request.QueryString["id"] || "" == Request.QueryString["id"])
                    {
                        //提示未选择要删除的项
                        // Response.Redirect();
                    }
                    else
                    {
                        //执行删除操作
                        DEl(Convert.ToDecimal(Request.QueryString["id"]));
                        dataBindToRepeater("1=1");//绑定电子公告数据
                    }
                }
            }
        }
        //使用dataBindToRepeater()方法绑定电子公告数据
        private void dataBindToRepeater(string sqlwhere)
        {
            DataTable dt = new DataTable();
            dt = bll.GetAfficheList(sqlwhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                AspNetPager1.RecordCount = dt.Rows.Count;

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                this.RptAffiche.DataSource = pds; //定义数据源
                this.RptAffiche.DataBind(); //绑定数据
            }
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关事务记录!</div>";
            }
        }
        /// <summary>
        /// 状态转为文字
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string TransState(decimal state)
        {
            if (state == 0)
            {
                return "已读";
            }
            else
            {
                return "未读";
            }

        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="AFFICHEID"></param>
        private void updateState(decimal AFFICHEID)
        {
            Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
            model.STATES = 2;//设置状态为已删除
            if (bll.update(model))
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('删除失败！');</script>");
            }
        }
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="AFFICHEID"></param>
        protected void DEl(decimal AFFICHEID)
        {
            if (bll.del(AFFICHEID))
            {
                Response.Write("<script type='text/javascript'>alert('删除成功！');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('删除失败！');</script>");
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            string sqlwhere = string.Empty;

            if ("" == this.txt_title.Text)
            {
                if ("" == this.txtTime.Text)
                {
                    sqlwhere = "1=1";
                }
                else
                {
                    sqlwhere = " AFFICHEDATE=to_date('" + this.txtTime.Text + "','yyyy-MM-dd')";
                }
            }
            else
            {
                if ("" == this.txtTime.Text)
                {
                    sqlwhere = "AFFICHETITLE='" + this.txt_title.Text + "'";
                }
                else
                {
                    sqlwhere = "AFFICHETITLE='" + this.txt_title.Text + "' AND AFFICHEDATE=to_date('" + this.txtTime.Text + "','yyyy-MM-dd')";
                }
            }

            dataBindToRepeater(sqlwhere);
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater("1=1");
        }
    }
}