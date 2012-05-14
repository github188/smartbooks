using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SmartHyd.ManageCenter.Ascx
{
    public partial class RoadProject : UI.BaseUserControl
    {
        private BLL.BASE_LICENSE_ACCEPT bll = new BLL.BASE_LICENSE_ACCEPT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingData();
            }
        }
        //绑定行政许可申请书分页数据
        private void BindingData()
        {
            DataTable dt = new DataTable();
            dt = bll.GetList("1=1");       

            //初始化分页数据
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //绑定分页后的数据
            repList.DataSource = pds;
            repList.DataBind();


            
        }
        private Entity.BASE_LICENSE_ACCEPT GetEntity()
        {
            Entity.BASE_LICENSE_ACCEPT model = new Entity.BASE_LICENSE_ACCEPT();
            model.REQUISITIONID = Convert.ToInt32(hidPrimary.Value);     //id,主键
            model.REQUISITIONNAME = this.TxtName.Text;                      //申请人及法定代表人名称
            model.ADDRESS = this.TxtAddress.Text;                       //申请人住址
            model.TEL = this.TEL_NO.Text;                            //电话
            model.PHONE = this.MOBIL_NO.Text;                         //手机
            model.EMAIL = this.TxtEmail.Text;                        //邮箱
            model.POST = this.TxtPost.Text;                                //邮编
            model.REQUISITIONCONTENT = this.txtContent.Text;                          //申请许可事项及内容
            model.DEPUTY = this.TxtDEPUTY.Text;                      //委托代理人
            model.MATERIALS = this.TxtMATERIALS.Text;                            //申请材料目录
            model.MARK = this.Txtremark.Text;                        //备注
            model.CREATDATE = DateTime.Parse(this.TxtTime.Text);            //申请日期
            model.AUDITOR = "";                                      //审核人           
            model.AUDIT_STATE = 0;                               //审核状态(0:未审核)；
            model.FILE_PATH = this.FulRoad.FileName;             //附件路径
            model.AUDIT_DESC = "";                           //审核意见
            model.AUDIT_REPLY = "";                          //意见回复

            return model;
        }

        private void SetEntity(Entity.BASE_LICENSE_ACCEPT model)
        {
            hidPrimary.Value = model.REQUISITIONID.ToString() ;     //id,主键
             this.TxtName.Text=model.REQUISITIONNAME;                      //申请人及法定代表人名称
            this.TxtAddress.Text=model.ADDRESS;                       //申请人住址
            this.TEL_NO.Text=model.TEL;                            //电话
            this.MOBIL_NO.Text=model.PHONE;                         //手机
            this.TxtEmail.Text=model.EMAIL ;                        //邮箱
            this.TxtPost.Text=model.POST ;                                //邮编
            this.txtContent.Text=model.REQUISITIONCONTENT ;                          //申请许可事项及内容
            this.TxtDEPUTY.Text=model.DEPUTY ;                  //委托代理人
            this.TxtMATERIALS.Text=model.MATERIALS ;                            //申请材料目录
            this.Txtremark.Text= model.MARK;              //备注
            this.TxtTime.Text=model.CREATDATE.ToString();            //申请日期
            //model.AUDITOR = "";                      //审核人           
            //model.AUDIT_STATE = 0;                //审核状态(0:未审核)；
            //model.FILE_PATH = this.FulRoad.FileName;        //附件路径
            //model.AUDIT_DESC = "";              //审核意见
            //model.AUDIT_REPLY = "";            //意见回复

        }
        /// <summary>
        ///按钮事件：提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entity.BASE_LICENSE_ACCEPT model =GetEntity();
            bll.Add(model);

            //刷新页面
            //Response.Redirect(Request.Url.AbsoluteUri, true);
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindingData();
        }
    }
}