using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching
{
    public partial class Default : System.Web.UI.Page
    {
        BLL.Base_News bll = new BLL.Base_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            //教学团队
            jiaoxuetuandui.DataSource = bll.GetList(10, "NewsTypeId in ( select a.newstypeid from base_newstype a where a.parentid = 2)", "CreateDate DESC");
            jiaoxuetuandui.DataBind();

            //教学大纲
            jiaoxuedagang.DataSource = bll.GetList(10, "NewsTypeId in ( select a.newstypeid from base_newstype a where a.parentid = 3)", "CreateDate DESC");
            jiaoxuedagang.DataBind();

            //教学教案
            jiaoxuejiaoan.DataSource = bll.GetList(10, "NewsTypeId in ( select a.newstypeid from base_newstype a where a.parentid = 4)", "CreateDate DESC");
            jiaoxuejiaoan.DataBind();

            //学习园地
            xuexiyuandi.DataSource = bll.GetList(10, "NewsTypeId in ( select a.newstypeid from base_newstype a where a.parentid = 7)", "CreateDate DESC");
            xuexiyuandi.DataBind();
        }
    }
}