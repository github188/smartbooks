using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Observed : System.Web.UI.UserControl {
        private BLL.BASE_OBSERVED bll = new BLL.BASE_OBSERVED();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindDeptLog();  //绑定日志
                BindDept();     //绑定部门树
                SetEntity(new Entity.BASE_OBSERVED());
            }
        }
        //绑定后数据
        private void BindDeptLog() {
            //初始化参数
            DateTime beginTime = DateTime.Now.AddDays(-5);
            DateTime endTime = DateTime.Now;
            int deptCode = 0;
            DataTable dt = new DataTable();

            //根据指定时间范围，获取某个部门下的电子巡逻日志数据
            dt = bll.GetDeptLog(beginTime, endTime, deptCode);

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();
        }
        //绑定部门
        private void BindDept() {
            //获取用户所属的部门和子部门
            string userName = "";
            DataTable dt = new DataTable();
            BLL.BASE_DEPT bllDept = new BLL.BASE_DEPT();
            dt = bllDept.GetUserWhereDepartment(userName, 0);
            ddldept.Items.Clear();
            foreach (DataRow row in dt.Rows) {
                ddldept.Items.Add(new ListItem(
                    row["DPTNAME"].ToString(),
                    row["DEPTID"].ToString()));
            }
        }
        //获取实体
        private Entity.BASE_OBSERVED GetEntity() {
            Entity.BASE_OBSERVED model = new Entity.BASE_OBSERVED();
            model.DEPTID = Convert.ToInt32(ddldept.SelectedValue);
            model.PATROLUSER = txtPATROLUSER.Text.Trim();
            model.BEGINTIME = DateTime.Parse(txtBEGINTIME.Text.Trim());
            model.ENDDATE = DateTime.Parse(txtENDTIME.Text.Trim());
            model.LOG = txtLog.Text.Trim();
            model.WEATHER = txtWEATHER.Text.Trim();


            return model;
        }
        //将实体赋值到页面
        private void SetEntity(Entity.BASE_OBSERVED model) {
            ddldept.SelectedValue = model.DEPTID.ToString();
            txtPATROLUSER.Text = model.PATROLUSER;
            txtBEGINTIME.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            txtENDTIME.Text = model.ENDDATE.ToString("yyyy-MM-dd");
            txtLog.Text = model.LOG;
            txtWEATHER.Text = model.WEATHER;
        }
        //分页按钮事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindDeptLog();
        }

        //提交
        protected void btnSubmit_Click(object sender, EventArgs e) {
        }
        //重置
        protected void btnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_OBSERVED());
        }
    }
}