using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class ImportData : UI.BaseUserControl {
        private BLL.BASE_BUS_OVERRUN bll = new BLL.BASE_BUS_OVERRUN();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                /*
                 * 绑定页面控件数据
                 */
                BindData();
            }
        }

        #region 页面功能按钮事件(必须重写基类虚方法，否则按钮的事件是无效的)
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e) {}
        //删除
        public override void BtnDelete_Click(object sender, EventArgs e) {}
        //重置
        public override void BtnCancel_Click(object sender, EventArgs e) { }
        //修改
        public override void BtnUpdate_Click(object sender, EventArgs e) { }
        //查看
        public override void BtnView_Click(object sender, EventArgs e) { }
        //查询
        public override void BtnSearch_Click(object sender, EventArgs e) { }
        //导入
        public override void BtnImport_Click(object sender, EventArgs e) {
            //导入数据
            if (ImportDataAccess()) {
                Smart.Utility.Alerts.Alert("数据导入成功!");

                //当前页面重新加载，并切换到数据预览选项卡
                Response.Redirect(Request.Url.AbsoluteUri + "#tabs-2", true);
            }
        }
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
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e) {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        #region 私有方法定义
        /// <summary>
        /// 绑定装备分页数据
        /// </summary>
        private void BindData() {
            DataTable dt = new DataTable();
            //获取数据，默认查询起始时间：（当前时间减去1小时），截止时间：（当前时间）
            dt = bll.GetPreviewData(DateTime.Now.AddHours(-1), DateTime.Now);

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

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <returns>导入成功true，否则false</returns>
        private bool ImportDataAccess() {
            //校验文件格式
            if (CheckUploadFileName()) {
                //设置数据库保存文件名称
                string filename = string.Format("{0}Temp\\{1}",
                    Server.MapPath("~/"),
                    Guid.NewGuid().ToString().ToUpper());

                //保存文件到服务器
                fileUpAccessDB.SaveAs(filename);

                //连接Access数据库查询数据
                string oleDBConnectionString = string.Format("Provider=Microsoft.Jet.Oledb.4.0; Data Source={0};",
                    filename);

                //从Access获取导入数据
                DataTable dtSource = new DataTable();
                dtSource = bll.GetImportData("TEMP_OVERLOADRATE_DETAIL", oleDBConnectionString);

                //写入数据到Oracle
                bll.ImportData(dtSource);

                //加密、压缩、删除临时文件等

                return true;
            }            
            return false;
        }

        /// <summary>
        /// 校验上传的文件名称
        /// </summary>
        /// <returns>校验成功true,否则false</returns>
        private bool CheckUploadFileName() {
            if (string.IsNullOrEmpty(fileUpAccessDB.FileName)) {
                Smart.Utility.Alerts.Alert("请选择一个Office Access 2003数据库文件。");
                return false;
            }
            if (fileUpAccessDB.FileName.Length > 4) {
                string fileExt = fileUpAccessDB.FileName.Substring(fileUpAccessDB.FileName.Length - 4, 4);
                if (!fileExt.ToUpper().Equals(".MDB")) {
                    Smart.Utility.Alerts.Alert("文件格式不正确，请选择一个Office Access 2003数据库文件(*.mdb)。");
                    return false;
                }
            } else {
                Smart.Utility.Alerts.Alert("文件格式不正确，请选择一个Office Access 2003数据库文件(*.mdb)。");
                return false;
            }

            return true;
        }
        #endregion
    }
}