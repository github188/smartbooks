using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Configuration;

using SmartHyd.BLL;

namespace SmartHyd.ManageCenter.UserManager
{
    public partial class UserEdit : System.Web.UI.Page
    {
        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string _action = Request.QueryString["action"];
                string _deptName = Request.QueryString["deptname"];
                string _deptId = Request.QueryString["deptid"];

                switch (_action) {
                    case "add":
                        this.LabName.Text = "添加单位用户信息";
                        ViewState["action"] = "ADD";
                        txtUnit.Text = _deptName;
                        hfdUnitId.Value = _deptId;
                        break;
                    case "update":
                        this.LabName.Text = "编辑单位用户信息";
                        ViewState["action"] = "EDIT";
                        string _userId = Request.QueryString["userid"];
                        txtUnit.Text = new BASE_DEPT().GetEntity(decimal.Parse(_deptId)).DPTNAME;
                        hfdUnitId.Value = _deptId;
                        int userid = Convert.ToInt32(_userId);
                        ViewState["USERID"] = userid.ToString();
                        Entity.BASE_USER model = bll.GetUser(userid);
                        SetEntity(model);
                        break;
                }
            }
        }
        #endregion

        #region 初始化信息实体
        /// <summary>
        /// 初始化信息实体
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_USER GetEntity()
        {
            Entity.BASE_USER model = new Entity.BASE_USER();

            #region 不需要字段
            //model.USERID = Convert.ToDecimal(this.hidPrimary.Value);  //主键，用户ID编号
            //model.BIRTHDAY = DateTime.Parse(txtBIRTHDAY.Text);
            //model.DEGREE = txtDEGREE.Text;
            //DropDownList ddr = (DropDownList)this.Department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            //model.FACE = txtFACE.Text;                    //政治面貌
            //model.IDNUMBER = txtIDNUMBER.Text;              //身份证号码
            //model.PROF = txtPROF.Text;                        //专业
            //model.SEX = Convert.ToInt32(ddlSex.SelectedValue);    //性别        
            //model.PHOTO = this.fileupPhoto.FileName; //人员照片
            #endregion

            model.DEPTID = Convert.ToInt32(hfdUnitId.Value);
            model.JOBNUMBER = txtJOBNUMBER.Text;            //工作证号
            model.PHONE = txtPhone.Text;                    //联系电话
            model.REMARK = txtRemark.Text;                   //备注
            model.USERNAME = txtUserName.Text;         //用户账号
            model.USERPWD = Smart.Security.Encrypter.Encrypt(txtPassword.Text, ConfigurationManager.AppSettings["EncryptKey"]);          //用户密码
            model.STSTUS = 0;                        //状态
            model.PARENTID = 0;                      //用户父ID编号（用于多个子账户）
            model.REALNAME = this.TxtRealName.Text;   //真实姓名

            return model;
        }
        #endregion

        #region 修改时页面控件数据绑定
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        private void SetEntity(Entity.BASE_USER model) {
            #region 多余字段
            //txtBIRTHDAY.Text = model.BIRTHDAY.ToString("yyyy-MM-dd");
            //txtDEGREE.Text = model.DEGREE;
            //txtFACE.Text = model.FACE;
            //txtIDNUMBER.Text = model.IDNUMBER;
            //txtPROF.Text = model.PROF;
            #endregion

            this.hidPrimary.Value = model.USERID.ToString();
            txtJOBNUMBER.Text = model.JOBNUMBER;
            txtPhone.Text = model.PHONE;
            txtRemark.Text = model.REMARK;
            txtUserName.Text = model.USERNAME;
            txtPassword.Text = Smart.Security.Encrypter.Decrypt(model.USERPWD, ConfigurationManager.AppSettings["EncryptKey"]);
            TxtRealName.Text = model.REALNAME;
        }
        #endregion

        #region 上传用户照片
        /// <summary>
        /// 上传用户照片
        /// </summary>
        /// <returns>照片存储在服务器的相对路径</returns>
        private string UpLoadPhoto()
        {
            string serverSavePath = "Images/FaceImage/";
            string tempFileName = "";
            //tempFileName = string.Format("{0}{1}",
            //    Guid.NewGuid().ToString(),
            //    Path.GetExtension(fileupPhoto.FileName));
            //this.fileupPhoto.SaveAs(string.Format("{0}//{1}", Server.MapPath("~/Images/FaceImage"), tempFileName));

            return serverSavePath + tempFileName;
        }
        #endregion 

        #region 校验用户提交的表单
        /// <summary>
        /// 校验用户提交的表单
        /// </summary>
        /// <returns>check result</returns>
        private bool CheckUserSubmitFrom()
        {
            //用户名校验
            if (this.txtUserName.Text.Trim() == "")
            {
                Smart.Utility.Alerts.Alert("请填写用户名.");
                return false;
            }

            if (txtPassword.Text.Trim() == "") {
                AjaxAlert(this.UpdatePanel1,"请填写密码.");
                return false;
            }

            if (TxtRealName.Text.Trim() == "") {
                AjaxAlert(this.UpdatePanel1,"请填写用户真实姓名.");
                return false;
            }

            if (txtPhone.Text.Trim() == "") {
                AjaxAlert(this.UpdatePanel1,"请填写用户手机号码.");
                return false;
            }


            #region 照片上传验证（暂不需要，保留，备用）
            //check file is null
            //if (!fileupPhoto.HasFile)
            //{
            //    Smart.Utility.Alerts.Alert("图片不能为空.");
            //    return false;
            //}

            //check upload file extension name.
            //ArrayList exts = new ArrayList();
            //exts.Add(".png");
            //exts.Add(".jpg");
            //exts.Add(".gif");
            //exts.Add(".jpeg");
            //if (!exts.Contains(Path.GetExtension(fileupPhoto.FileName)))
            //{
            //    Smart.Utility.Alerts.Alert("只允许上传 *.png *.jpg *.gif *.jpeg 格式的图片");
            //    return false;
            //}

            //check file size
            //if (fileupPhoto.PostedFile.ContentLength > 3145728)
            //{
            //    Smart.Utility.Alerts.Alert("只允许上传3MB以内的图片文件.");
            //    return false;
            //}
            #endregion

            return true;
        }
        #endregion

        #region 按钮事件：提交(保存/修改)
        /// <summary>
        /// 按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (CheckUserSubmitFrom()) {
                string _action = ViewState["action"].ToString();

                if (_action == "ADD") {//添加用户

                    Entity.BASE_USER model = GetEntity();
                    //model.PHOTO = UpLoadPhoto();
                    bll.Add(model);

                    //日志添加
                    LogAdd("用户管理", "添加用户");

                    //重新加载当前页
                    //Response.Redirect(Request.Url.AbsoluteUri, true);

                    //添加完成后页面跳转
                    AjaxAlertAndRedirect(UpdatePanel1, "用户信息添加成功", "UserCenter.aspx?deptid=" + hfdUnitId.Value + "&deptName=" + txtUnit.Text);

                } else {//修改用户

                    Entity.BASE_USER model = GetEntity();

                    model.USERID = Convert.ToInt32(ViewState["USERID"].ToString());

                    //model.PHOTO = UpLoadPhoto();
                    if (bll.Update(model)) {

                        //日志添加
                        LogAdd("用户管理", "修改用户");

                        //重新加载当前页
                        //Response.Redirect(Request.Url.AbsoluteUri, true);

                        //添加完成后页面跳转
                        AjaxAlertAndRedirect(UpdatePanel1, "用户信息修改成功", "UserCenter.aspx?deptid=" + hfdUnitId.Value + "&deptName=" + txtUnit.Text);
                    } else {
                        AjaxAlert(this.UpdatePanel1,"用户信息修改失败");
                    }
                }
            }
        }
        #endregion

        #region 日志添加
        /// <summary>
        /// 日志添加
        /// </summary>
        /// <param name="logtype">日志类型</param>
        /// <param name="description">日志信息内容</param>
        private void LogAdd(string logtype, string description)
        {
            Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = logtype;                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = description;                             //日志信息内容
            logmodel.OPERATORID = 1;                    //操作人
            logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
            logbll.Add(logmodel);
        }
        #endregion

        #region Ajax无刷新js脚本弹出提示对话框
        /// <summary>
        /// Ajax无刷新js脚本弹出提示对话框
        /// </summary>
        /// <param name="uPanel"></param>
        /// <param name="strMsg"></param>
        public  void AjaxAlert(UpdatePanel uPanel, string strMsg) {
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');", true);
        }
        #endregion

        #region Ajax无刷新js脚本弹出提示对话框并重定向到新页面
        /// <summary>
        /// Ajax无刷新js脚本弹出提示对话框并重定向到新页面
        /// </summary>
        /// <param name="uPanel"></param>
        /// <param name="strMsg"></param>
        /// <param name="toURL"></param>
        public  void AjaxAlertAndRedirect(UpdatePanel uPanel, string strMsg, string toURL) {
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');window.location.href='" + toURL + "';", true);
        }
        #endregion
    }
}