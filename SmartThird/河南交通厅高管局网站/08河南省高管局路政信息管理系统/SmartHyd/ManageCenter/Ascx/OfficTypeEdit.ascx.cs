using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class OfficTypeEdit : UI.BaseUserControl
    {
        private BLL.BASE_FILETYPE bll = new BLL.BASE_FILETYPE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ("" != Request.QueryString["ftid"] || null != Request.QueryString["ftid"])
                {
                     decimal FTID =Convert.ToDecimal(Request.QueryString["ftid"]);
                     Entity.BASE_FILETYPE model = bll.Getmodel(FTID);
                     SetEntity(model);
                }
               
            }
        }
        /// <summary>
        /// 获得公文类型实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_FILETYPE GetEntity()
        {
            Entity.BASE_FILETYPE model = new Entity.BASE_FILETYPE();
            model.FTID = Convert.ToInt32(hidPrimary.Value);
            model.FT_NAME = this.TxtTypeName.Text;            //类型名称
            model.FT_PREFIX = this.TxtPrefix.Text;           //默认文号前缀
            model.FT_SUFFIX = this.TxtSuffix.Text;           //默认文号后缀
            model.FT_DESCRIBE = this.TxtDescribe.Text;      //备注
            model.FT_DEPT = this.category.Value;            //所属类别
            model.FT_STATE = 0;                             //状态：0正常；1已删除


            return model;
        }
        /// <summary>
        /// 设置公文类型实体数据
        /// </summary>
        /// <param name="model">公文类型实体</param>
        private void SetEntity(Entity.BASE_FILETYPE model)
        {
            this.hidPrimary.Value = model.FTID.ToString();    //id编号
            this.TxtTypeName.Text = model.FT_NAME;            //类型名称
            this.TxtPrefix.Text = model.FT_PREFIX;           //默认文号前缀
            this.TxtSuffix.Text = model.FT_SUFFIX;           //默认文号后缀
            this.TxtDescribe.Text = model.FT_DESCRIBE;      //备注
            this.category.Value = model.FT_DEPT;             //所属分类

        }
        /// <summary>
        /// 按钮事件：修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (bll.update(GetEntity()) == true)
            {
                Response.Redirect("FaWen.aspx#tabs-3");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
            }
        }
      
        /// <summary>
        /// 按钮事件：返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FaWen.aspx#tabs-3");
        }
    }
}