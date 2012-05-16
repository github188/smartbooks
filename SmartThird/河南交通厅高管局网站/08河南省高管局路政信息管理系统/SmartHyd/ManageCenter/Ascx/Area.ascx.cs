using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class Area : UI.BaseUserControl {
        private BLL.BASE_AREA bll = new BLL.BASE_AREA();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                /*
                 * 绑定页面控件数据
                 */
                BindData();

                /*
                 * 初始化页面控件默认值
                 */
                SetEntity(new Entity.BASE_AREA());
            }
        }
        
        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_AREA model = GetEntity();

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e)
        {
        }
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e)
        {
            SetEntity(new Entity.BASE_AREA());

            Smart.Utility.Alerts.Alert("test");
        }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        public override void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        public override void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        public override void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        public override void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        public override void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        public override void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        public override void BtnGrant_Click(object sender, EventArgs e) { }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        #region 私有方法定义
        //从页面获取实体
        private Entity.BASE_AREA GetEntity() {
            Entity.BASE_AREA model = new Entity.BASE_AREA();
            model.AREANAME = txtAREANAME.Text;
            model.COMPTIME = DateTime.Parse(txtCOMPTIME.Text);
            //model.DEPTID =    //所属部门
            model.DETAILED = txtDETAILED.Text;
            model.ID = Convert.ToInt32(hidPrimary.Value);
            model.LINENAME = txtLINENAME.Text;
            model.OWNER = txtOWNER.Text;
            //model.PHOTO =     //现场照片
            model.REGTIME = DateTime.Parse(txtREGTIME.Text);
            model.REMARK = txtREMARK.Text;
            model.STAKEK = Convert.ToInt32(txtSTAKEK.Text);
            model.STAKEM = Convert.ToInt32(txtSTAKEM.Text);
            model.STATUS = txtSTATUS.Text;
            model.SUMMARY = txtSUMMARY.Text;
            model.TYPEID = Convert.ToInt32(ddlType.SelectedValue);

            return model;
        }
        //初始化实体到页面
        private void SetEntity(Entity.BASE_AREA model) {

            txtAREANAME.Text = model.AREANAME;
            txtCOMPTIME.Text = model.COMPTIME.ToString("yyyy-MM-dd");
            txtDETAILED.Text = model.DETAILED;
            hidPrimary.Value = model.ID.ToString();
            txtLINENAME.Text = model.LINENAME;
            txtOWNER.Text = model.OWNER;
            txtREGTIME.Text = model.REGTIME.ToString("yyyy-MM-dd");
            txtREMARK.Text = model.REMARK;
            txtSTAKEK.Text = model.STAKEK.ToString();
            txtSTAKEM.Text = model.STAKEM.ToString();
            txtSTATUS.Text = model.STATUS;
            txtSUMMARY.Text = model.SUMMARY;
            ddlType.SelectedValue = model.TYPEID.ToString();
            imgPhoto.ImageUrl = model.PHOTO;

            //model.DEPTID =    //所属部门
        }
        //绑定装备分页数据
        private void BindData() {
            DataTable dt = new DataTable();
            //获取部门编号

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
        #endregion
    }
}