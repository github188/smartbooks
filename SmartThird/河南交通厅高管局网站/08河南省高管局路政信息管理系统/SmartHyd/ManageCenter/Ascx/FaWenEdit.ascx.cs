using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class FaWenEdit : UI.BaseUserControl
    {
        private BLL.BASE_FAWEN bll = new BLL.BASE_FAWEN();
        private BLL.BASE_FILETYPE tbll = new BLL.BASE_FILETYPE();
        private BLL.BASE_DEPT bllDept = new BLL.BASE_DEPT();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ("" != Request.QueryString["fid"] || null != Request.QueryString["fid"])
                {
                    BindType();//DropDownList数据绑定
                    BindDept();//DropDownList主办单位（部门）数据绑定
                    decimal FID = Convert.ToDecimal(Request.QueryString["fid"]);
                    Entity.BASE_FAWEN model = bll.Getmodel(FID);
                    SetEntity(model);
                }
                else
                { 
                   //模拟数据
                    BindType();//DropDownList数据绑定
                    BindDept();//DropDownList主办单位（部门）数据绑定
                    decimal FID = 1;
                    Entity.BASE_FAWEN model = bll.Getmodel(FID);
                    SetEntity(model);
                }
            }
        }
        /// <summary>
        /// 公文类型数据绑定
        /// </summary>
        private void BindType()
        {
            //获取公文类型
            DataTable dt = new DataTable();
            dt = tbll.GetFileTypeList("1=1");
            //绑定方法一：
            this.Ddl_type.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                this.Ddl_type.Items.Add(new ListItem(
                    row["FT_NAME"].ToString(),
                    row["FTID"].ToString()));
            }
            #region  绑定方法二:
            ////指定DropDownList使用的数据源

            //Ddl_type.DataSource = dt.DefaultView;

            ////指定DropDownList使用的表里的那些字段

            //Ddl_type.DataTextField = "FT_NAME"; //dropdownlist的Text的字段

            //Ddl_type.DataValueField = "FTID";//dropdownlist的Value的字段

            //Ddl_type.DataBind();
            #endregion

        }
        /// <summary>
        /// 主办单位（部门）绑定
        /// </summary>
        private void BindDept()
        {
            //获取用户所属的部门和子部门
            string userName = "";
            DataTable dt = new DataTable();
            dt = bllDept.GetUserWhereDepartment(userName, 0);
            this.DdlOrgan.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DdlOrgan.Items.Add(new ListItem(
                    row["DPTNAME"].ToString(),
                    row["DEPTID"].ToString()));
            }
        }
        /// <summary>
        /// 获得公文实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_FAWEN GetEntity()
        {
            Entity.BASE_FAWEN model = new Entity.BASE_FAWEN();
            model.FID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.F_NUMBER = this.txNumber.Text;                    //公文号
            model.F_TITLE = this.txTitle.Text;                      //公文标题
            model.F_TYPE = this.Ddl_type.SelectedValue;             //公文类型
            model.F_CONTENT = this.TxContent.Text;                  //公文内容
            model.F_ANNEX = this.FileUploadPath.FileName;           //公文附件路径
            model.F_DATE = DateTime.Now;                             //发文日期
            model.REMARK = this.TxRemark.Text;                      //备注
            model.F_ORGAN = this.DdlOrgan.SelectedValue;                      //发文单位部门
            model.F_LEVEL = "";                                     //密级
            model.F_DEGREE = "";                                    //缓急程度
            model.F_DELSTATE = 0;                                   //状态（0已保存；1已发送；2已删除）


            return model;
        }
        /// <summary>
        /// 设置公文实体数据
        /// </summary>
        /// <param name="model">公文实体</param>
        private void SetEntity(Entity.BASE_FAWEN model)
        {
            this.hidPrimary.Value = model.FID.ToString();
            this.txNumber.Text = model.F_NUMBER;                    //公文号
            this.txTitle.Text = model.F_TITLE;                      //公文标题
            this.Ddl_type.SelectedValue = model.F_TYPE;             //公文类型
            this.TxContent.Text = model.F_CONTENT;                  //公文内容
            //this.FileUploadPath.FileName=model.F_ANNEX;           //公文附件路径
            // model.F_DATE = DateTime.Now;                             //发文日期
            this.TxRemark.Text = model.REMARK;                                      //备注
            this.DdlOrgan.SelectedValue = model.F_ORGAN;                      //发文单位部门
            //model.F_LEVEL = "";                                     //密级
            //model.F_DEGREE = "";                                    //缓急程度
            //model.F_DELSTATE = 0;  


        }
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_FAWEN());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) {
            Entity.BASE_FAWEN model = GetEntity();
            if (bll.update(model))
            {
                Response.Redirect("FaWen.aspx");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
            }
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
        //发布
        public override void BtnSend_Click(object sender, EventArgs e)
        {
        }
        #endregion

    }
}