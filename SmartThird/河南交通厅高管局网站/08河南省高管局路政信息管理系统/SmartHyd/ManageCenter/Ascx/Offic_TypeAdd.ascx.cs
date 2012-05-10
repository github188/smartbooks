using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Offic_Type : UI.BaseUserControl
    {
        private BLL.BASE_FILETYPE bll = new BLL.BASE_FILETYPE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BtnSave.Attributes.Add("onclick ", "return mysubmit()");

            }
        }
        /// <summary>
        /// 新建类型保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Entity.BASE_FILETYPE model = new Entity.BASE_FILETYPE();
            model.FTID = Convert.ToInt32(hidPrimary.Value);
            model.FT_NAME = this.TxtTypeName.Text;            //类型名称
            model.FT_PREFIX = this.TxtPrefix.Text;           //默认文号前缀
            model.FT_SUFFIX = this.TxtSuffix.Text;           //默认文号后缀
            model.FT_DESCRIBE = this.TxtDescribe.Text;      //备注
            model.FT_DEPT = this.category.Value;            //所属类别
            model.FT_STATE = 0;                             //状态：0正常；1已删除
            bll.Add(model);
            Response.Redirect("FaWen.aspx#tabs-3");

        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FaWen.aspx#tabs-3");
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.TxtTypeName.Text="";            //类型名称
            this.TxtPrefix.Text="";           //默认文号前缀
            this.TxtSuffix.Text="";           //默认文号后缀
            this.TxtDescribe.Text="";      //备注
            this.category.Value="0";  
        }
    }
}