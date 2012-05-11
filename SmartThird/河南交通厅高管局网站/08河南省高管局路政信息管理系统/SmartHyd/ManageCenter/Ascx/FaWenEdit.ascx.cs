using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class FaWenEdit : UI.BaseUserControl
    {
        private BLL.BASE_FAWEN bll = new BLL.BASE_FAWEN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  if ("" != Request.QueryString["fid"] || null != Request.QueryString["ftid"])
                {
                     decimal FID =Convert.ToDecimal(Request.QueryString["fid"]);
                     Entity.BASE_FAWEN model = bll.Getmodel(FID);
                     SetEntity(model);
                }
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
        /// <summary>
        /// 按钮事件：修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEdit_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 按钮事件:返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}