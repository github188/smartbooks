using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Patrol : UI.BaseUserControl {
        private BLL.BASE_PATROL bll = new BLL.BASE_PATROL();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                bindDeptLog();  //绑定日志
                BindDept();     //绑定部门树
            }
        }

        private void bindDeptLog() {
            DateTime beginTime = DateTime.Now.AddDays(-90);
            DateTime endTime = DateTime.Now;
            int deptCode = 0;
            DataTable dt = new DataTable();
            dt = bll.GetDeptLog(beginTime, endTime, deptCode);

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            this.repList.DataSource = pds;
            this.repList.DataBind();
        }

        private void BindDept() {
            //获取用户所属的部门和子部门
            string userName = "";
            DataTable dt = new DataTable();
            BLL.BASE_DEPT bllDept = new BLL.BASE_DEPT();
            dt = bllDept.GetUserWhereDepartment(userName);
            ddldept.Items.Clear();
            foreach (DataRow row in dt.Rows) {
                ddldept.Items.Add(new ListItem(
                    row["DPTNAME"].ToString(),
                    row["DEPTID"].ToString()));
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindDeptLog();
        }

        private Entity.BASE_PATROL GetEntity() {
            Entity.BASE_PATROL model = new Entity.BASE_PATROL();
            model.PATROLID = Convert.ToInt32(hidPrimary.Value);     //id,主键
            model.DEPTID = Convert.ToInt32(ddldept.SelectedValue);  //巡查中队
            model.RESPUSER = txtRESPUSER.Text;                      //巡查负责人
            model.PATROLUSER = txtPATROLUSER.Text;                  //巡查人员
            model.BUSNUMBER = txtBUSNUMBER.Text;                    //巡逻车牌号
            model.MILEAGE = Convert.ToInt32(txtMILEAGE.Text);       //巡查里程
            model.WEATHER = txtWEATHER.Text;                        //天气
            model.LOG = txtLog.Text;                                //巡查处理情况
            model.WITHIN = txtWITHIN.Text;                          //移交内业处理事项
            model.NEXTWITHIN = txtNEXTWITHIN.Text;                  //移交下班处理事项
            model.GOODS = txtGOODS.Text;                            //移交器材
            model.SHIFTCAPTAIN = txtSHIFTCAPTAIN.Text;              //交班中队长
            model.ACCEPTCAPTAIN = txtACCEPTCAPTAIN.Text;            //接班中对长
            model.ACCEPTBUSNUMBER = txtACCEPTBUSNUMBER.Text;        //接班巡逻车牌号            
            model.BEGINTIME = DateTime.Parse(txtBEGINTIME.Text);    //巡查开始时间
            model.ENDTIME = DateTime.Parse(txtENDTIME.Text);        //巡查结束时间
            model.TICKTIME = DateTime.Parse(txtENDTIME.Text);       //交接班时间
            model.BUSKM = Convert.ToInt32(txtBUSKM.Text);           //接班巡逻车里程表
            model.ACCEPT = 0;               //接收人
            model.TRANSFER = 0;             //移交人

            return model;
        }

        private void SetEntity(Entity.BASE_PATROL model) {
            hidPrimary.Value = model.PATROLID.ToString();
            ddldept.SelectedValue = model.DEPTID.ToString();
            txtRESPUSER.Text = model.RESPUSER;
            txtPATROLUSER.Text = model.PATROLUSER;
            txtBUSNUMBER.Text = model.BUSNUMBER;
            txtMILEAGE.Text = model.MILEAGE.ToString();
            txtWEATHER.Text = model.LOG;
            txtLog.Text = model.LOG;
            txtWITHIN.Text = model.WITHIN;
            txtNEXTWITHIN.Text = model.NEXTWITHIN;
            txtGOODS.Text = model.GOODS;
            txtSHIFTCAPTAIN.Text = model.SHIFTCAPTAIN;
            txtACCEPTCAPTAIN.Text = model.ACCEPTCAPTAIN;
            txtACCEPTBUSNUMBER.Text = model.ACCEPTBUSNUMBER;
            txtBEGINTIME.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            txtENDTIME.Text = model.ENDTIME.ToString("yyyy-MM-dd");
            txtBUSKM.Text  =  model.BUSKM.ToString();     
                      
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_PATROL model = GetEntity();
            bll.Add(model);
            Response.Redirect("Patrol.aspx", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_PATROL());
        }
    }
}