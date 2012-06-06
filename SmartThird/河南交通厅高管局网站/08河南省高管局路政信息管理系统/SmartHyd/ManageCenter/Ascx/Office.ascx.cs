using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Office : UI.BaseUserControl
    {
        private BLL.BASE_MESSAGE bll = new BLL.BASE_MESSAGE();
        private BLL.BASE_USER userbll = new BLL.BASE_USER();
        private BLL.BASE_PLAN planbll = new BLL.BASE_PLAN();
        private BLL.BASE_AFFICHE affichebll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UserBind();//绑定用户
                //dataBindToRepeater();//绑定事务信息
                //dataBindRepeater();//绑定电子公告信息
            }
        }
        //#region 即时通讯
        ///// <summary>
        ///// 用户绑定
        ///// </summary>
        //public void UserBind()
        //{
        //    SmartHyd.Utility.UserSession userSession = (SmartHyd.Utility.UserSession)Session["user"];
        //    DataTable dt = new DataTable();
        //    string strwhere = "USERID!=" + userSession.USERID;
        //    dt = userbll.GetList(strwhere);
        //    this.CBLUser.DataSource = dt;
        //    this.CBLUser.DataTextField = "USERNAME";
        //    this.CBLUser.DataValueField = "USERID";
        //    this.CBLUser.DataBind();
        //    //foreach (DataRow dr in dt.Rows)
        //    //{
        //    //    //node = new TreeNode();
        //    //    //this.ListUser.Items.Add(node);
        //    //    //node.Value = dr["USERID"].ToString();
        //    //    //node.Text = (string)dr["USERNAME"];
        //    //    //node.ShowCheckBox = true;

        //    //    this.CBLUser.Items.Add(dr["USERNAME"].ToString());
        //    //}
        //}
        ///// <summary>
        ///// 获得通讯消息实体数据
        ///// </summary>
        ///// <returns></returns>
        //private Entity.BASE_MESSAGE GetEntity()
        //{
        //    Entity.BASE_MESSAGE model = new Entity.BASE_MESSAGE();
        //    model.MESSAGEID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
        //    model.SENDER = 0;                        //发信人编号
        //    model.MESSAGEBODY = this.Message.Value;                      //消息内容
        //    string str_username = this.TxtTouser.Text;//获取文本框中所有的用户名
        //    string[] sArray = str_username.Split(',');
        //    string username = string.Empty;
        //    //if (sArray.Length > 1)//如果有多个用户
        //    //{
        //    //    foreach (string i in sArray)
        //    //    {

        //    //    }
        //    //}
        //    //else//单个用户
        //    //{
        //    //    username = sArray[0].ToString();
        //    //}
        //    username = sArray[0].ToString();
        //    decimal touserid = Convert.ToDecimal(userbll.GetList("USERNAME='" + username + "'").Rows[0]["USERID"]);
        //    model.TOUSER = touserid;             //收信人编号
        //    model.STATE = 0;                  //消息状态（0，未读；1，已读）
        //    model.SENDDATE = DateTime.Now;                             //发送时间日期


        //    return model;
        //}
        ///// <summary>
        ///// 按钮事件：发送
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnSendMessage_Click(object sender, EventArgs e)
        //{
        //    //获取实体
        //    Entity.BASE_MESSAGE model = GetEntity();

        //    //添加数据
        //    bll.Add(model);
        //    //if (bll.Exists(model.MESSAGEID))
        //    //{
        //    //    //重新加载当前页
        //    //    Response.Redirect(Request.Url.AbsoluteUri, true);
        //    //}
        //    //else
        //    //{
        //    //    Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");
        //    //重新加载当前页
        //    Response.Redirect(Request.Url.AbsoluteUri, true);
        //    // }
        //}
        //#endregion
        //#region  事务提醒
        ////使用dataBindToRepeater()方法绑定事务数据
        //private void dataBindToRepeater()
        //{
        //    DataTable dt = new DataTable();
        //    dt = planbll.GetPlanList("1=1");

        //    AspNetPager1.RecordCount = dt.Rows.Count;

        //    PagedDataSource pds = new PagedDataSource();
        //    pds.DataSource = dt.DefaultView;
        //    pds.AllowPaging = true;
        //    pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //    pds.PageSize = AspNetPager1.PageSize;


        //    this.repList.DataSource = pds; //定义数据源
        //    this.repList.DataBind(); //绑定数据
        //}

        ///// <summary>
        ///// 按钮事件：新建事务
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnPlan_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("~/ManageCenter/Plan.aspx");
        //}
        ///// <summary>
        ///// //分页事件 
        ///// </summary>
        ///// <param name="src"></param>
        ///// <param name="e"></param>
        //protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        //{
        //    this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        //    dataBindToRepeater();
        //}
        //#endregion
        //#region  电子公告
        ////使用dataBindRepeater()方法绑定电子公告数据
        //private void dataBindRepeater()
        //{
        //    DataTable dt = new DataTable();
        //    dt = affichebll.GetAfficheList("1=1");

        //    AspNetPager2.RecordCount = dt.Rows.Count;

        //    PagedDataSource pds = new PagedDataSource();
        //    pds.DataSource = dt.DefaultView;
        //    pds.AllowPaging = true;
        //    pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
        //    pds.PageSize = AspNetPager1.PageSize;


        //    this.RptAffiche.DataSource = pds; //定义数据源
        //    this.RptAffiche.DataBind(); //绑定数据
        //}
        ///// <summary>
        ///// 按钮事件：查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnSearchAffiche_Click(object sender, EventArgs e)
        //{

        //}
        ///// <summary>
        ///// 按钮事件：新建公告
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void BtnAddAffiche_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("~/ManageCenter/Affiche.aspx");
        //}
        ///// <summary>
        ///// //分页事件 
        ///// </summary>
        ///// <param name="src"></param>
        ///// <param name="e"></param>
        //protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        //{
        //    this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
        //    dataBindRepeater();
        //}
        //#endregion





    }
}