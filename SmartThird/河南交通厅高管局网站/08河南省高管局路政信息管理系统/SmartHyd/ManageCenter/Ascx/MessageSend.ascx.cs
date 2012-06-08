using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class MessageSend :  UI.BaseUserControl
    {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        /// <summary>
        /// 获得通讯消息实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_MESSAGE GetEntity()
        {
            Entity.BASE_MESSAGE model = new Entity.BASE_MESSAGE();
            model.MESSAGEID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.SENDER = 0;                        //发信人编号
            model.MESSAGEBODY = this.Message.Value;                      //消息内容
            decimal touserid = Convert.ToDecimal(userbll.GetList("USERNAME='" + this.TxtTouser.Text + "'").Rows[0]["USERID"]);
            model.TOUSER = touserid;             //收信人编号
            model.STATE = 0;                  //消息状态（0，未读；1，已读）
            model.SENDDATE = DateTime.Now;                             //发送时间日期


            return model;
        }
        /// <summary>
        /// 根据用户编号获取用户名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        protected string getUserName(int userid)
        {
            string username = string.Empty;

            if (userbll.GetUser(userid) == null)
            {
                username = "该用户不存在";
            }
            else
            {
                username = userbll.GetUser(userid).USERNAME;
            }
            return username;
        }

        /// <summary>
        /// 用户绑定
        /// </summary>
        public void UserBind()
        {
            SmartHyd.Utility.UserSession userSession = (SmartHyd.Utility.UserSession)Session["user"];
            DataTable dt = new DataTable();
            string strwhere = "USERID!=" + userSession.USERID;
            dt = userbll.GetList(strwhere);
            this.CBLUser.DataSource = dt;
            this.CBLUser.DataTextField = "USERNAME";
            this.CBLUser.DataValueField = "USERID";
            this.CBLUser.DataBind();
        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_MESSAGE model = GetEntity();

            //添加数据
            bll.Add(model);
          
            //重新加载当前页
            Response.Redirect("Chat.aspx", true);
        }
    }
}