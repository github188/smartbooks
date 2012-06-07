using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace SmartHyd.ManageCenter.UserManager {
    public partial class UserEdit : System.Web.UI.Page {
        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (null == Request.QueryString["deptid"] || "" == Request.QueryString["deptid"]) {
                    //部门编号为空：提示并返回
                } else {
                    if (null == Request.QueryString["userid"] || "" == Request.QueryString["userid"]) {
                        this.LabName.Text = "添加用户";
                    } else {
                        this.LabName.Text = "编辑用户";
                        int userid = Convert.ToInt32(Request.QueryString["userid"]);
                        Entity.BASE_USER model = bll.GetUser(userid);
                        SetEntity(model);
                    }
                }
            }
        }
        private Entity.BASE_USER GetEntity() {
            Entity.BASE_USER model = new Entity.BASE_USER();

            model.USERID = Convert.ToDecimal(this.hidPrimary.Value);                //主键，用户ID编号
            model.BIRTHDAY = DateTime.Parse(txtBIRTHDAY.Text);
            model.DEGREE = txtDEGREE.Text;
            DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            model.DEPTID = Convert.ToInt32(ddr.SelectedValue);
            model.FACE = txtFACE.Text;                    //政治面貌
            model.IDNUMBER = txtIDNUMBER.Text;              //身份证号码
            model.JOBNUMBER = txtJOBNUMBER.Text;            //工作账号
            model.PHONE = txtPhone.Text;                    //联系电话
            model.PROF = txtPROF.Text;                        //专业
            model.REMARK = txtRemark.Text;                   //备注
            model.SEX = Convert.ToInt32(ddlSex.SelectedValue);    //性别        
            model.USERNAME = txtUserName.Text;         //用户账号
            model.USERPWD = Smart.Security.MD5.MD5Encrypt(txtPassword.Text).ToUpper();          //用户密码
            model.STSTUS = 0;                        //状态
            model.PARENTID = 0;                      //用户父ID编号（用于多个子账户）
            model.PHOTO = this.fileupPhoto.FileName; //人员照片
            model.REALNAME = this.TxtRealName.Text;   //真实姓名

            return model;
        }

        private void SetEntity(Entity.BASE_USER model) {
            this.hidPrimary.Value = model.USERID.ToString();
            txtBIRTHDAY.Text = model.BIRTHDAY.ToString("yyyy-MM-dd");
            txtDEGREE.Text = model.DEGREE;
            txtFACE.Text = model.FACE;
            txtIDNUMBER.Text = model.IDNUMBER;
            txtJOBNUMBER.Text = model.JOBNUMBER;
            txtPhone.Text = model.PHONE;
            txtPROF.Text = model.PROF;
            txtRemark.Text = model.REMARK;
            txtUserName.Text = model.USERNAME;
            txtPassword.Text = model.USERPWD;
            this.TxtRealName.Text = model.REALNAME;
        }

        /// <summary>
        /// 上传用户照片
        /// </summary>
        /// <returns>照片存储在服务器的相对路径</returns>
        private string UpLoadPhoto() {
            string serverSavePath = "Images/FaceImage/";

            string tempFileName = string.Format("{0}{1}",
                Guid.NewGuid().ToString(),
                Path.GetExtension(fileupPhoto.FileName));
            this.fileupPhoto.SaveAs(string.Format("{0}//{1}", Server.MapPath("~/Images/FaceImage"), tempFileName));

            return serverSavePath + tempFileName;
        }

        /// <summary>
        /// 校验用户提交的表单
        /// </summary>
        /// <returns>check result</returns>
        private bool CheckUserSubmitFrom() {
            //用户名校验
            if (this.txtUserName.Text.Trim() == "") {
                Smart.Utility.Alerts.Alert("请填写用户名.");
                return false;
            }
            //check file is null
            if (!fileupPhoto.HasFile) {
                Smart.Utility.Alerts.Alert("图片不能为空.");
                return false;
            }

            //check upload file extension name.
            ArrayList exts = new ArrayList();
            exts.Add(".png");
            exts.Add(".jpg");
            exts.Add(".gif");
            exts.Add(".jpeg");
            if (!exts.Contains(Path.GetExtension(fileupPhoto.FileName))) {
                Smart.Utility.Alerts.Alert("只允许上传 *.png *.jpg *.gif *.jpeg 格式的图片");
                return false;
            }

            //check file size
            if (fileupPhoto.PostedFile.ContentLength > 3145728) {
                Smart.Utility.Alerts.Alert("只允许上传3MB以内的图片文件.");
                return false;
            }

            return true;
        }
        /// <summary>
        /// 按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (CheckUserSubmitFrom()) {
                if (null == Request.QueryString["userid"] || "" == Request.QueryString["userid"]) {
                    //添加用户
                    Entity.BASE_USER model = GetEntity();
                    model.PHOTO = UpLoadPhoto();
                    bll.Add(model);

                    //日志..............添加
                    LogAdd("用户管理", "添加用户");

                    //重新加载当前页
                    Response.Redirect(Request.Url.AbsoluteUri, true);


                } else {
                    //修改用户
                    Entity.BASE_USER model = GetEntity();
                    model.PHOTO = UpLoadPhoto();
                    bll.Update(model);

                    //日志..............添加
                    LogAdd("用户管理", "修改用户");

                    //重新加载当前页
                    Response.Redirect(Request.Url.AbsoluteUri, true);
                }
            }
        }
        /// <summary>
        /// 日志添加
        /// </summary>
        /// <param name="logtype">日志类型</param>
        /// <param name="description">日志信息内容</param>
        private void LogAdd(string logtype, string description) {
            Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = logtype;                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = description;                             //日志信息内容
            logmodel.OPERATORID = 1;                    //操作人
            logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
            logbll.Add(logmodel);
        }
    }
}