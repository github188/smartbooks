using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class DeptManage : UI.BaseUserControl
    {
        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(DeptManage));//对AjaxPro在页Page_Load事件中进行运行时注册;
                if (null != Request.QueryString["id"] || "" != Request.QueryString["id"])
                {
                    decimal id = Convert.ToDecimal(Request.QueryString["id"]);
                    dataBind(id);
                    depturl(id);
                }
                else
                {
                    dataBind(13);
                    depturl(13);
                }
            }
        }
        
        //使用dataBindToListView()方法绑定部门数据
        [AjaxPro.AjaxMethod]
        protected void dataBind(decimal parentid)
        {
            DataTable dt = new DataTable();
            dt = bll.GetAllDep("parentid=" + parentid + " order by DeptID");
            StringBuilder str = new StringBuilder();
            str.Append("<table width='100%' bolder='1'>");
            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i % 3 == 0)
                    {
                        if (i % 3 < 2)
                        {
                            str.Append("<tr>");
                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i]["DEPTID"].ToString() + "');'>" + dt.Rows[i]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");


                            str.Append("</tr>");
                        }
                        else if (i % 3 < 3)
                        {
                            str.Append("<tr>");
                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i]["DEPTID"].ToString() + "');'>" + dt.Rows[i]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");

                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i+1]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i + 1]["DEPTID"].ToString() + "');'>" + dt.Rows[i + 1]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");

                            str.Append("</tr>");
                        }
                        else
                        {
                            str.Append("<tr>");
                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i]["DEPTID"].ToString() + "');'>" + dt.Rows[i]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");

                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i+1]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i + 1]["DEPTID"].ToString() + "');'>" + dt.Rows[i + 1]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");

                            str.Append("<td><a href='DeptManage.aspx?id=" + dt.Rows[i+2]["DEPTID"].ToString() + "' onclick='javascript:childDept('" + dt.Rows[i + 2]["DEPTID"].ToString() + "');'>" + dt.Rows[i + 2]["DPTNAME"].ToString() + "</a><a href=''><img src='' alt='编辑'</a><a href=''><img src='' alt='删除'</a></td>");

                            str.Append("</tr>");
                        }
                    }
                }
            else
            {
                str.Append("<tr><td>暂无相关数据！</td></tr>");
            }
            str.Append("");
            str.Append("</table>");
            this.deptbind.InnerHtml += str;
        }
        [AjaxPro.AjaxMethod]
        private void depturl(decimal parentid)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            dt = bll.GetAllDep("DEPTID=" + parentid);
            if (dt.Rows.Count == 1)
            {
                str.Append("<a href='DeptManage.aspx?id=" + dt.Rows[0]["DEPTID"].ToString() + "'>" + dt.Rows[0]["DPTNAME"].ToString() + "</a>&gt;");
            }
            else
            {
                str.Append("");
            }
            this.deptUrl.InnerHtml += str;
            while (parentid==0)
            {
                depturl(parentid);
            }
            
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

        }
       
    }
}