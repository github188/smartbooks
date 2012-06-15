using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.Patrol {
    public partial class ElectronicPatrol : System.Web.UI.Page {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindDeptLog();
                BindAcceptUnit();
            }
        }

        //绑定后数据
        private void BindDeptLog() {
            //初始化参数
            DateTime beginTime = DateTime.Now.AddDays(-5);
            DateTime endTime = DateTime.Now;
            int deptCode = 4;
           // int state = 0;
           string patroluser=string.Empty;
            DataTable dt = new DataTable();

            //根据指定时间范围，获取某个部门下的电子巡逻日志数据
            //dt = bll.GetDeptLog(beginTime, endTime, deptCode,state);
            //获取全部电子巡逻日志
            dt = bll.GetLogObserved("b.deptid=" + deptCode + " AND b.state=0");
            if (dt != null && dt.Rows.Count > 0) {
                //初始化分页数据
                AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                pds.PageSize = AspNetPager1.PageSize;


                //绑定分页后的数据

                this.gv_electroniclist.DataSource = pds;
                this.gv_electroniclist.DataBind();
            }
            else {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>"; 
            }
        }
        /// <summary>
        /// 绑定单位信息
        /// </summary>
        private void BindAcceptUnit()
        {
            DataTable dt = new DataTable();
            //获取用户所属单位和下级部门
            BLL.BASE_DEPT dept = new BLL.BASE_DEPT();
            dt = dept.GetAllDep("STATUS=0");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PARENTID"].ToString().Equals("0"))
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = dr["DPTNAME"].ToString();
                    rootNode.Value = dr["DEPTID"].ToString();
                    rootNode.ToolTip = dr["DPTINFO"].ToString();
                    rootNode.ShowCheckBox = false;
                    rootNode.Expanded = true;
                    rootNode.Target = "PatrolFrame";
                    rootNode.NavigateUrl = "ArtificialPatrol.aspx?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下巡逻日志


                    //递归子节点
                    RecursiveBindAcceptUnit(rootNode, dt);

                    //加入控件
                    TreeViewAcceptUnit.Nodes.Add(rootNode);
                }
            }
        }

        /// <summary>
        /// 填充部门树
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="dt">数据源</param>
        private void RecursiveBindAcceptUnit(TreeNode node, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PARENTID"].ToString().Equals(node.Value))
                {
                    //添加子节点
                    TreeNode sub = new TreeNode();
                    sub.Text = dr["DPTNAME"].ToString();
                    sub.Value = dr["DEPTID"].ToString();
                    sub.ToolTip = dr["DPTINFO"].ToString();
                    sub.ShowCheckBox = false;
                    sub.Expanded = false;
                    sub.Target = "PatrolFrame";
                    sub.NavigateUrl = "ArtificialPatrol.aspx?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下巡逻日志

                    node.ChildNodes.Add(sub);

                    //递归循环
                    RecursiveBindAcceptUnit(sub, dt);
                }
            }
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindDeptLog();
        }


        /// <summary>
        /// 电子巡逻日志查询
        /// </summary>
        protected void btn_ok_Click(object sender, EventArgs e) {
            string strwhere = string.Empty;
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            //按单位查询
            if(this.txt_vehicleLicense.Text==""&&this.txt_startTime.Text==""&&this.txt_endTime.Text=="")
            {
                strwhere = "b.deptid =" + ddr.SelectedValue;
            }
            //按单位+巡逻人查询
            if (this.txt_startTime.Text==""&&this.txt_endTime.Text=="")
            {
                strwhere = "b.deptid =" + ddr.SelectedValue+"and  b.patroluser='"+this.txt_vehicleLicense.Text+"'";
            }
            //按单位+巡逻人+时间查询
            if (this.txt_vehicleLicense.Text!=""&&this.txt_startTime.Text!=""&&this.txt_endTime.Text!="")
            {
                 strwhere = "b.deptid =" + ddr.SelectedValue+"and  b.patroluser='"+this.txt_vehicleLicense.Text+"' and b.begintime >= TO_DATE ('"+this.txt_startTime.Text+"', 'yyyy-mm-dd')  and b.enddate <= TO_DATE ('"+this.txt_endTime.Text+"', 'yyyy-mm-dd')";
            }
            DataTable dt = new DataTable();
            dt = bll.GetLogObserved(strwhere);
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

                this.gv_electroniclist.DataSource = pds;
                this.gv_electroniclist.DataBind();
            }
            else
            {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>无相关巡逻记录!</div>";
            }

        }

        protected void gv_electroniclist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                /*跳转到编辑页面*/
                case "edit":
                    Response.Redirect("ElectronicEdit.aspx?id=" + id.ToString(), true);
                    break;
                /*跳转到详情页面*/
                case "view":
                    Response.Redirect("ElectronicDetail.aspx?id=" + id.ToString(), true);
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
                Response.Redirect("ElectronicPatrol.aspx");
            }
            //Entity.BASE_OBSERVED model = bll.GetModel(id);
            //model.STATE = 1;
            //if (bll.update(model))
            //{
            //    Response.Redirect("ElectronicPatrol.aspx");
            //}
        }
    }
}