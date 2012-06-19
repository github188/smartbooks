using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Affiche
{
    public partial class AfficheEdit : System.Web.UI.Page
    {
        private BLL.BASE_AFFICHE bll = new BLL.BASE_AFFICHE();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();
        private Utility.UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = (Utility.UserSession)Session["user"];
            if (!IsPostBack)
            {
                if ("" == Request.QueryString["aid"] || null == Request.QueryString["aid"])
                {
                    if (this.hidPrimary.Value == "-1")
                    {

                        this.LbHeadName.Text = "新建电子公告";//设置标题头名称
                        this.TxtTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else
                    {

                        this.LbHeadName.Text = "编辑电子公告";//设置标题头名称
                        decimal AFFICHEID = Convert.ToDecimal(this.hidPrimary.Value);
                        Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
                        SetEntity(model);
                    }
                }
                else
                {

                    this.LbHeadName.Text = "编辑电子公告";//设置标题头名称
                    decimal AFFICHEID = Convert.ToDecimal(Request.QueryString["aid"]);
                    Entity.BASE_AFFICHE model = bll.Getmodel(AFFICHEID);
                    SetEntity(model);
                }
            }
        }
        #region 公告数据添加
        /// <summary>
        /// 获得公告实体数据
        /// </summary>
        /// <param name="states">公告状态</param>
        /// <returns></returns>
        private Entity.BASE_AFFICHE GetEntity(decimal states)
        {
            Entity.BASE_AFFICHE model = new Entity.BASE_AFFICHE();
            model.AFFICHEID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.AFFICHETITLE = this.TxtTitle.Text;                      //公告标题
            model.AFFICHER = userSession.USERNAME;                                     //公告发布人
            model.AFFICHEDATE = DateTime.Parse(this.TxtTime.Text);         //公告发布时间
            model.AFFICHECONTENTS = this.TxtContent.Text;                  //公告内容
            model.STATES = states;                                              //公告状态0:已保存；1：已发布；2：已删除；

            return model;
        }
        /// <summary>
        /// 设置公告数据
        /// </summary>
        /// <param name="model">公告实体</param>
        private void SetEntity(Entity.BASE_AFFICHE model)
        {
            this.hidPrimary.Value = model.AFFICHEID.ToString();        //id,主键
            this.TxtTitle.Text = model.AFFICHETITLE;                    //公告标题
            model.AFFICHER = userSession.USERNAME;                                //公告发布人
            this.TxtTime.Text = model.AFFICHEDATE.ToString("yyyy-MM-dd");             //公告发布时间
            this.TxtContent.Text = model.AFFICHECONTENTS;                  //公告内容
            //model.STATES = 0;                                   //公告状态0:已保存；1：已发布；2：已删除；

        }
        #endregion
        /// <summary>
        /// 按钮事件：保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_AFFICHE model = GetEntity(0);

            //添加数据
            bll.Add(model);
            //日志..............添加
            Entity.BASE_LOG logmodel = new Entity.BASE_LOG();

            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = "电子公告";                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = "添加公告";                             //日志信息内容
            logmodel.OPERATORID = userSession.USERID;                    //操作人
            logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
            logbll.Add(logmodel);
            /*日志结束***********/
            Response.Redirect("Affiche.aspx", true);
        }
        /// <summary>
        /// 按钮事件：发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_AFFICHE model = GetEntity(1);

            //添加数据
            bll.Add(model);
            //日志..............添加
            Entity.BASE_LOG logmodel = new Entity.BASE_LOG();

            logmodel.LOGID = -1;                        //id,主键
            logmodel.LOGTYPE = "电子公告";                     //日志类型
            logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
            logmodel.DESCRIPTION = "发布公告";                             //日志信息内容
            logmodel.OPERATORID = userSession.USERID;                    //操作人
            logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
            logbll.Add(logmodel);
            /*日志结束***********/
            Response.Redirect("Affiche.aspx", true);
        }

        //protected void BtnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Affiche.aspx", true);
        //}
    }
}