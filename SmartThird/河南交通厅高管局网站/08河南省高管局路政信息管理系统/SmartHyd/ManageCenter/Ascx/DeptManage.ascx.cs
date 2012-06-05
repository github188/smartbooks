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
                AjaxPro.Utility.RegisterTypeForAjax(typeof(SmartHyd.ManageCenter.DeptManage));//对AjaxPro在页Page_Load事件中进行运行时注册;
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"])
                {
                    dataBind(4);
                    depturl(4);
                }
                else
                {
                    decimal id = Convert.ToDecimal(Request.QueryString["deptid"]);
                    dataBind(id);
                    depturl(id);
                }
            }
        }
        
        //使用dataBindToListView()方法绑定部门数据
        
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
                        str.Append("<tr>");
                        if (dt.Rows.Count == (i + 1))
                        {
                            str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "' >" + dt.Rows[i]["DPTNAME"].ToString() + "</a>");
                            str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                            str.Append("<a href='javascript:;' onclick='childDept('" + dt.Rows[i]["DEPTID"].ToString() + "');'><img src='../../Images/del.jpg' alt='删除'</a></td>");

                        }
                        else
                        {
                            if (dt.Rows.Count == (i + 2))
                            {
                                str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "' >" + dt.Rows[i]["DPTNAME"].ToString() + "</a>");
                                str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                                str.Append("<a href='javascript:;' onclick='childDept(" + dt.Rows[i]["DEPTID"].ToString() + ");'><img src='../../Images/del.jpg' alt='删除'</a></td>");

                                str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i+1]["DEPTID"].ToString() + "' >" + dt.Rows[i+1]["DPTNAME"].ToString() + "</a>");
                                str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i+1]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                                str.Append("<a href='javascript:;' onclick='childDept(" + dt.Rows[i+1]["DEPTID"].ToString() + ");'><img src='../../Images/del.jpg' alt='删除'</a></td>");

                            }
                            else
                            {
                                str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "' >" + dt.Rows[i]["DPTNAME"].ToString() + "</a>");
                                str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                                str.Append("<a href='javascript:;' onclick='childDept(" + dt.Rows[i]["DEPTID"].ToString() + ");'><img src='../../Images/del.jpg' alt='删除'</a></td>");

                                str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i + 1]["DEPTID"].ToString() + "' >" + dt.Rows[i + 1]["DPTNAME"].ToString() + "</a>");
                                str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i + 1]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                                str.Append("<a href='javascript:;' onclick='childDept(" + dt.Rows[i + 1]["DEPTID"].ToString() + ");'><img src='../../Images/del.jpg' alt='删除'</a></td>");

                                str.Append("<td><a href='DeptManage.aspx?deptid=" + dt.Rows[i + 2]["DEPTID"].ToString() + "' >" + dt.Rows[i + 2]["DPTNAME"].ToString() + "</a>");
                                str.Append("<a href='Dept.aspx?deptid=" + dt.Rows[i + 2]["DEPTID"].ToString() + "'><img src='../../Images/edit.jpg' alt='编辑'</a>");
                                str.Append("<a href='javascript:;' onclick='childDept(" + dt.Rows[i + 2]["DEPTID"].ToString() + ");'><img src='../../Images/del.jpg' alt='删除'</a></td>");
                            }
                        }
                            str.Append("</tr>");
                        
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
        protected string getParent(TreeNode currTreeNode)
        {
            string rv = "";
            if (currTreeNode.Parent != null)
            {
                rv = currTreeNode.Parent.Text;
                rv += getParent(currTreeNode.Parent);
            }

            return rv;
        }
       /// <summary>
        /// 设置顶部导航：当前部门位置
       /// </summary>
       /// <param name="parentid"></param>
       /// <returns></returns>
        private void depturl(decimal parentid)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            
            dt = bll.GetAllDep("DEPTID=" + parentid);
            if (dt.Rows.Count > 0)
            {
                str.Append("<a href='DeptManage.aspx?deptid=" + dt.Rows[0]["DEPTID"].ToString() + "'>" + dt.Rows[0]["DPTNAME"].ToString() + "</a>&gt;");
                if (dt.Rows[0]["PARENTID"].ToString().Equals(0))
                {
                    str.Append("");
                }
                else
                {
                    depturl(Convert.ToDecimal(dt.Rows[0]["PARENTID"]));
                }
            }
            else
            {
                str.Append("<a href='DeptManage.aspx?deptid=4'>河南省交通运输厅高速公路管理局</a>&gt;");
            }
            this.deptUrl.InnerHtml += str;
            
        }
        /// <summary>
        /// 获得部门数据实体
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_DEPT GetEntity(decimal parentId)
        {
            Entity.BASE_DEPT model = new Entity.BASE_DEPT();
            model.DEPTID = Convert.ToInt32(this.hidPrimary.Value);  //id,主键
            model.DPTNAME = this.depname.Text.Trim();           //部门名称       
            model.DPTINFO = this.txtDptinfo.Text.Trim();            //部门描述
            model.PARENTID = parentId;           //上级部门
            model.STATUS = 0;                                   //状态0:正常；1：关闭

            return model;
        }
        /// <summary>
        /// 设置部门数据
        /// </summary>
        /// <param name="model">部门实体</param>
        private void SetEntity(Entity.BASE_DEPT model)
        {
            this.hidPrimary.Value = model.DEPTID.ToString();        //id,主键
            this.depname.Text = model.DPTNAME;                    //部门名称
            this.txtDptinfo.Text = model.DPTINFO;             //部门描述

            //DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            //ddr.SelectedValue = model.PARENTID.ToString();                                //上级部门
           // model.STATES;                                  //状态
        }
        /// <summary>
        /// 删除部门decimal deptid
        /// </summary>
        /// <param name="deptid"></param>
        [AjaxPro.AjaxMethod]
        public void delDept()
        {
            Response.Write("删除!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1111");
            //if (bll.del(deptid))//删除数据
            //{
            //    //重新加载当前页
            //    Response.Redirect(Request.Url.AbsoluteUri, true);
            //}
            //#region 删除数据：更新数据库数据状态
            ////获取实体
            //Entity.BASE_DEPT model = bll.GetEntity(deptid);
            //model.STATUS = 1;//设置部门状态为1：部门关闭
            //if (bll.update(model))
            //{
            //    //重新加载当前页
            //    Response.Redirect(Request.Url.AbsoluteUri, true);
            //}
            //#endregion
        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
            this.BtnDeptAdd.Text = "添加";
        }

        protected void BtnDeptAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_DEPT model = GetEntity(Convert.ToDecimal(Request.QueryString["deptid"]));

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }

        protected void BtnCancle_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = -1;
        }
       
    }
}