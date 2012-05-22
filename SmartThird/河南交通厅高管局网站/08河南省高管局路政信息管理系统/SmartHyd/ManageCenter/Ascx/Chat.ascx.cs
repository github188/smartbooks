using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Chat : UI.BaseUserControl
    {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }
        //使用dataBindToRepeater()方法绑定部门数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptList.DataSource = pds; //定义数据源
            this.RptList.DataBind(); //绑定数据
        }
        /// <summary>
        /// 获得通讯消息实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_MESSAGE GetEntity()
        {
            Entity.BASE_MESSAGE model = new Entity.BASE_MESSAGE();
            model.MESSAGEID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.SENDER = 1;                    //发信人编号
            model.MESSAGEBODY = this.Message.Value;                      //消息内容
            decimal touserid = Convert.ToDecimal(userbll.GetList("USERNAME='" + this.TxtTouser.Text+"'").Rows[0]["USERID"]);
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
            string username=userbll.GetUser(userid).USERNAME;
            return username;
        }
        /// <summary>
        /// 状态转为文字
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string TransState(decimal state)
        {
            if (state == 0)
            {
                return "未读";
            }
            else
            {
                return "已读";
            }

        }
        //发布
        public override void BtnSend_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_MESSAGE model = GetEntity();

            //添加数据
            bll.Add(model);
            //if (bll.Exists(model.MESSAGEID))
            //{
            //    //重新加载当前页
            //    Response.Redirect(Request.Url.AbsoluteUri, true);
            //}
            //else
            //{
            //    Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
                //重新加载当前页
                Response.Redirect(Request.Url.AbsoluteUri, true);
           // }
           
        }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
    }
}