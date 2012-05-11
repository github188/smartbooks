using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class Shouwen : UI.BaseUserControl
    {
        private BLL.BASE_SHOUWEN bll = new BLL.BASE_SHOUWEN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBindToRepeater();
            }
        }
        #region 收文管理
        //使用dataBindToRepeater()方法绑定收文数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetShouWenList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptShouwen.DataSource = pds; //定义数据源
            this.RptShouwen.DataBind(); //绑定数据
        }

 
        /// <summary>
        /// 收文管理分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            dataBindToRepeater();
        }
        #endregion
        /// <summary>
        /// 获得收文实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_SHOUWEN GetEntity()
        {
            Entity.BASE_SHOUWEN model = new Entity.BASE_SHOUWEN();
            model.SID = Convert.ToInt32(this.hidPrimary.Value);          //id,主键
            model.S_NUMBERS = this.txNumber.Text;                        //原号
            model.S_ORGAN = this.TxtOrgan.Text;                          //来文机关
            model.S_FROMDATE = DateTime.Parse(this.TxtFromTime.Text);    //来文时间
            model.S_TITLE = this.txTitle.Text;                           //来文标题
            model.S_HANDLINGTIME = DateTime.Parse(this.TxtHandTime.Text);           //承办时间
            model.S_DEP_ORGAN = this.TxtRelateOrgan.Text;                                 //涉及相关运营管理单位
            model.S_HANDLEPROGRESS = this.TxtProgress.Text;                          //办理进度
            model.S_RESULT = this.TxtResult.Text;                       //办理结果
            model.S_APPLICANT = this.TxtApplicant.Text;                 //申请人
            model.S_HANDLER = this.TxtHandler.Text;                     //相关单位承办人
            model.REMARKS = this.TxtRemark.Text;                        //备注
           // model.F_LEVEL = "";                                      //密级
           // model.F_DEGREE = "";                                     //缓急程度
           // model.F_DELSTATE = 0;                                    //状态（0已保存；1已发送；2已删除）


            return model;
        }
        /// <summary>
        /// 设置收文实体数据
        /// </summary>
        /// <param name="model">收文实体</param>
        private void SetEntity(Entity.BASE_SHOUWEN model)
        {
            this.hidPrimary.Value = model.SID.ToString();          //id,主键
            this.txNumber.Text=model.S_NUMBERS ;                        //原号
            this.TxtOrgan.Text=model.S_ORGAN ;                          //来文机关
            this.TxtFromTime.Text=model.S_FROMDATE.ToString();    //来文时间
             this.txTitle.Text=model.S_TITLE;                           //来文标题
            this.TxtHandTime.Text= model.S_HANDLINGTIME.ToString();           //承办时间
            this.TxtRelateOrgan.Text=model.S_DEP_ORGAN ;                                 //涉及相关运营管理单位
            this.TxtProgress.Text=model.S_HANDLEPROGRESS ;                          //办理进度
             this.TxtResult.Text=model.S_RESULT;                       //办理结果
            this.TxtApplicant.Text=model.S_APPLICANT ;                 //申请人
            this.TxtHandler.Text=model.S_HANDLER ;                     //相关单位承办人
            this.TxtRemark.Text=model.REMARKS ;                        //备注
            // model.F_LEVEL = "";                                      //密级
            // model.F_DEGREE = "";                                     //缓急程度
            // model.F_DELSTATE = 0;                                    //状态（0已保存；1已发送；2已删除）

        }
    }
}