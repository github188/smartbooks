

namespace SmartHyd.ManageCenter.Ascx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Collections;
    using System.Web.UI;
    using System.Data;
    using System.IO;
    using System.Web.UI.WebControls;

    public partial class UserManage : UI.BaseUserControl
    {
        private BLL.BASE_USER bll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserList();

                SetEntity(new Entity.BASE_USER());
            }
        }

        private void BindUserList()
        {
            DataTable dt = new DataTable();
            dt = bll.GetAllUser();
            //dt = bll.GetList("1=1");
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

        private Entity.BASE_USER GetEntity()
        {
            Entity.BASE_USER model = new Entity.BASE_USER();

            model.USERID = 0;                //主键，用户ID编号
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

            return model;
        }

        private void SetEntity(Entity.BASE_USER model)
        {
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
        }

        /// <summary>
        /// 上传用户照片
        /// </summary>
        /// <returns>照片存储在服务器的相对路径</returns>
        private string UpLoadPhoto()
        {
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
        private bool CheckUserSubmitFrom()
        {
            //check file is null
            if (!fileupPhoto.HasFile)
            {
                Smart.Utility.Alerts.Alert("图片不能为空.");
                return false;
            }

            //check upload file extension name.
            ArrayList exts = new ArrayList();
            exts.Add(".png");
            exts.Add(".jpg");
            exts.Add(".gif");
            exts.Add(".jpeg");
            if (!exts.Contains(Path.GetExtension(fileupPhoto.FileName)))
            {
                Smart.Utility.Alerts.Alert("只允许上传 *.png *.jpg *.gif *.jpeg 格式的图片");
                return false;
            }

            //check file size
            if (fileupPhoto.PostedFile.ContentLength > 3145728)
            {
                Smart.Utility.Alerts.Alert("只允许上传3MB以内的图片文件.");
                return false;
            }

            return true;
        }
        #region 删除用户：Update()修改用户；DelUser()从用户表中删除用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool Update(Entity.BASE_USER model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 从用户表中根据用户编号删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private bool DelUser(decimal userId)
        {
            return bll.Del(userId);
        }
        #endregion
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CheckUserSubmitFrom())
            {
                Entity.BASE_USER model = GetEntity();
                model.PHOTO = UpLoadPhoto();
                bll.Add(model);

                //日志..............添加
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "用户管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "添加用户";                             //日志信息内容
                logmodel.OPERATORID = 1;                    //操作人
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);

                //重新加载当前页
                Response.Redirect(Request.Url.AbsoluteUri + "#tabs-2", true);
            }
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_USER());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) {
        
        }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public override void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public override void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public override void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public override void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public override void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public override void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public override void BtnGrant_Click(object sender, EventArgs e) { }

        /// <summary>
        /// //分页事件 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindUserList();
        }
        #endregion

        //修改标志：20120530 王亚 添加用户
        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (CheckUserSubmitFrom()) {
                Entity.BASE_USER model = GetEntity();
                model.PHOTO = UpLoadPhoto();
                bll.Add(model);

                //日志..............添加
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "用户管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "添加用户";                             //日志信息内容
                logmodel.OPERATORID = 1;                    //操作人
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);

                //重新加载当前页
                Response.Redirect(Request.Url.AbsoluteUri + "#tabs-2", true);
            }
        }
    }
}