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

                /*
                 * 初始化页面权限功能按钮
                 */
                InitFunction();
            }
        }
        
        #region 页面功能按钮事件
        //添加
        protected void BtnAdd_Click(object sender, EventArgs e) {
            //获取实体
            Entity.BASE_AREA model = GetEntity();

            //添加数据
            bll.Add(model);

            //重新加载当前页
            Response.Redirect(Request.Url.AbsoluteUri, true);
        }
        //删除
        protected void BtnDelete_Click(object sender, EventArgs e) {
        }
        //重置
        protected void BtnCancel_Click(object sender, EventArgs e) {
            SetEntity(new Entity.BASE_AREA());

            this.Alert("错误提示", "测试提示框");
        }
        //修改
        protected void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        protected void BtnView_Click(object sender, EventArgs e) { }
        //查询
        protected void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        protected void BtnImport_Click(object sender, EventArgs e) { }
        //导出
        protected void BtnExport_Click(object sender, EventArgs e) { }
        //打印
        protected void BtnPrint_Click(object sender, EventArgs e) { }
        //移动
        protected void BtnMove_Click(object sender, EventArgs e) { }
        //下载
        protected void BtnDownload_Click(object sender, EventArgs e) { }
        //备份
        protected void BtnBackup_Click(object sender, EventArgs e) { }
        //审核
        protected void BtnVerify_Click(object sender, EventArgs e) { }
        //授权
        protected void BtnGrant_Click(object sender, EventArgs e) { }
        //分页事件
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        #region 私有方法定义
        //初始化页面功能模板
        private void InitFunction() {
            this.BtnAdd.Click += new EventHandler(BtnAdd_Click);        //添加
            this.BtnDelete.Click += new EventHandler(BtnDelete_Click);  //删除
            this.BtnCancel.Click += new EventHandler(BtnCancel_Click);   //重置
            this.BtnUpdate.Click += new EventHandler(BtnUpdate_Click);   //修改
            this.BtnView.Click += new EventHandler(BtnView_Click);   //查看
            this.BtnSearch.Click += new EventHandler(BtnSearch_Click);    //查询
            this.BtnImport.Click += new EventHandler(BtnImport_Click);   //导入
            this.BtnExport.Click += new EventHandler(BtnExport_Click);   //导出
            this.BtnPrint.Click += new EventHandler(BtnPrint_Click); //打印
            this.BtnMove.Click += new EventHandler(BtnMove_Click);    //移动
            this.BtnDownload.Click += new EventHandler(BtnDownload_Click); //下载
            this.BtnBackup.Click += new EventHandler(BtnBackup_Click);   //备份
            this.BtnVerify.Click += new EventHandler(BtnVerify_Click);//审核
            this.BtnGrant.Click += new EventHandler(BtnGrant_Click); //授权
        }
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