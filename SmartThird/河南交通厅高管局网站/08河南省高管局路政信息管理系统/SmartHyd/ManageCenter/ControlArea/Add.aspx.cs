using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SmartHyd.ManageCenter.ControlArea {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession session;
        private BLL.BASE_AREA bll = new BLL.BASE_AREA();
        private BLL.BASE_AREA_TYPE bllType = new BLL.BASE_AREA_TYPE();

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindType();

                txtREGTIME.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtCOMPTIME.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void BindType() {
            DataTable dt = new DataTable();
            dt = bllType.GetAllList();

            if (dt != null && dt.Rows.Count > 0) {
                ddlType.Items.Clear();
                foreach (DataRow row in dt.Rows) {
                    ddlType.Items.Add(new ListItem(row["TYPENAME"].ToString(), row["TYPEID"].ToString()));
                }
            }
        }

        private Entity.BASE_AREA GetModel() {
            Entity.BASE_AREA m = new Entity.BASE_AREA();
            m.DEPTID = Convert.ToInt32(Session["deptcode"].ToString());
            m.TYPEID = Convert.ToInt32(ddlType.SelectedValue);
            m.LINENAME = txtLINENAME.Text;
            m.AREANAME = txtAREANAME.Text;
            m.STAKEK = Convert.ToInt32(txtSTAKEK.Text);
            m.STAKEM = Convert.ToInt32(txtSTAKEM.Text);
            m.SUMMARY = txtSUMMARY.Text;
            m.REGTIME = DateTime.Parse(txtREGTIME.Text);
            m.COMPTIME = DateTime.Parse(txtCOMPTIME.Text);
            m.OWNER = txtOWNER.Text;
            m.DETAILED = txtDETAILED.Text;
            m.STATUS = txtSTATUS.Text;
            m.REMARK = txtREMARK.Text;
            return m;
        }

        private void SetModel(Entity.BASE_AREA model) {
            ddlType.SelectedValue = model.TYPEID.ToString();
            txtLINENAME.Text = model.LINENAME;
            txtAREANAME.Text = model.AREANAME;
            txtSTAKEK.Text = model.STAKEK.ToString();
            txtSTAKEM.Text = model.STAKEM.ToString();
            txtSUMMARY.Text = model.SUMMARY;
            txtREGTIME.Text = model.REGTIME.ToString("yyyy-MM-dd");
            txtCOMPTIME.Text = model.COMPTIME.ToString("yyyy-MM-dd");
            txtOWNER.Text = model.OWNER;
            txtDETAILED.Text = model.DETAILED;
            txtSTATUS.Text = model.STATUS;
            txtREMARK.Text = model.REMARK;
        }

        private bool CheckModel(Entity.BASE_AREA model) {
            if (model == null) {
                return false;
            }


            return true;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>服务器存储相对路径</returns>
        private string UpLoadPic() {
            string serverPath = "";
            if (!string.IsNullOrEmpty(fileupPhoto.FileName)) {
                //服务器存储路径
                string filePath = string.Format("{0}Images\\AreaImage\\{1}\\",
                    Server.MapPath("~/"),
                    DateTime.Now.ToString("yyyyMMdd"));

                //服务器存储文件名
                string fileName = string.Format("{0}.{1}",
                    Guid.NewGuid().ToString(),
                    fileupPhoto.FileName.Substring(fileupPhoto.FileName.Length - 3, 3));

                //判断路径是否存在，如果不存在那么则创建这个路径
                if (!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }

                //上传附件
                serverPath += string.Format("Images/AreaImage/{0}/{1}",
                    DateTime.Now.ToString("yyyyMMdd"),
                    fileName);
                fileupPhoto.SaveAs(filePath + fileName);
            }

            return serverPath;
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            Entity.BASE_AREA model = new Entity.BASE_AREA();
            model = GetModel();

            if (CheckModel(model)) {

                model.PHOTO = UpLoadPic();

                bll.Add(model);


                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>添加成功!</div>";

                SetModel(new Entity.BASE_AREA());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("List.aspx", true);
        }
    }
}