using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHyd.Entity;
namespace SmartHyd.ManageCenter.Ascx
{
    public partial class FaWen : System.Web.UI.UserControl
    {
        //SmartHyd.OracleDAL.BASE_FAWEN f_dal = new SmartHyd.OracleDAL.BASE_FAWEN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dataBindToRepeater();
            }
        }
        //使用dataBindToRepeater()方法绑定数据
        private void dataBindToRepeater()
        {
           

            //if (f_dal.GetList("1=1").Tables[0].Rows.Count==0)
            //{
               
            //}
            //this.fawenList.DataSource = f_dal.GetList("1=1"); //定义数据源
            this.fawenList.DataBind(); //绑定数据
        }
        //发送
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        //保存
        protected void Button1_Click(object sender, EventArgs e)
        {
            BASE_FAWEN f_entity=new BASE_FAWEN();
            
           // f_dal.Add(f_entity)
        }
        
    }
}