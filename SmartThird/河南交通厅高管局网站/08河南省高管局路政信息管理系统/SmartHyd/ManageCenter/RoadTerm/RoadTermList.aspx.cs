using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.RoadTerm {
    public partial class RoadTermList : System.Web.UI.Page {
        private BLL.BASE_ROAD_TERM bll = new BLL.BASE_ROAD_TERM();
        private BLL.BASE_ROAD_TERM_TYPE bllRoadType = new BLL.BASE_ROAD_TERM_TYPE();
        private Utility.UserSession session;
        
        //加载
        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                txtBeginTime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");    //开始时间
                txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");                  //结束时间

                BindingRoadType();  //绑定设备类型
                BingrRoadList();    //绑定数据列表
            }
        }

        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BingrRoadList();
        }

        //绑定设备列表
        private void BingrRoadList() {
            DataTable dt = new DataTable();

            int typeCode = Convert.ToInt32(ddlTermType.SelectedValue);
            int deptCode = Convert.ToInt32(Session["deptcode"]);
            DateTime beginTime = DateTime.Parse(txtBeginTime.Text.Trim());
            DateTime endTime = DateTime.Parse(txtEndTime.Text.Trim());

            //获取部门下数据
            dt = bll.GetDepartmentRoad(beginTime, endTime, typeCode, deptCode);

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //清空现有数据源
            dgvRoadList.DataSource = null;
            dgvRoadList.DataBind();

            //绑定分页后的数据
            dgvRoadList.DataSource = pds;
            dgvRoadList.DataBind();
            
            litmsg.Visible = false;
            if (dt == null || dt.Rows.Count == 0) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>查询无数据!</div>";
            }
        }

        //绑定路产设备类型数据
        private void BindingRoadType() {
            DataTable dt = new DataTable();

            //获取路产设备类型数据
            dt = bllRoadType.GetAllList();

            ddlTermType.Items.Clear();
            foreach (DataRow dr in dt.Rows) {
                ddlTermType.Items.Add(new ListItem(
                    dr["TYPENAME"].ToString(),
                    dr["TYPEID"].ToString()));
            }
        }

        //查询
        protected void btnSubmit_Click(object sender, EventArgs e) {
            BingrRoadList();
        }
    }
}