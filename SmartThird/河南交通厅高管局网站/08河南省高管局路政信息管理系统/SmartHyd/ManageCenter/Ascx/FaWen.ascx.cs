using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHyd.Entity;
using System.Data;
namespace SmartHyd.ManageCenter.Ascx
{
    public partial class FaWen : UI.BaseUserControl
    {
        private BLL.BASE_FAWEN bll = new BLL.BASE_FAWEN();
        private BLL.BASE_FILETYPE tbll = new BLL.BASE_FILETYPE();
        private BLL.BASE_DEPT bllDept = new BLL.BASE_DEPT();
        private BLL.BASE_LOG model = new BLL.BASE_LOG();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    dataBindToRepeater();//公文数据绑定
                    TypeBindToRepeater("1=1");//公文类型数据绑定
                    BindType();//DropDownList数据绑定
                    GetTree();//（单位）部门树形绑定
                    this.BtnSearch.Attributes.Add("onclick", "trans_tabs(2);");
             
           }
        }
        #region 公文管理
        //使用dataBindToRepeater()方法绑定公文数据
        private void dataBindToRepeater()
        {
            DataTable dt = new DataTable();
            dt = bll.GetFaWenList("1=1");

            AspNetPager1.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;


            this.RptFawen.DataSource = pds; //定义数据源
            this.RptFawen.DataBind(); //绑定数据
        }

  
        /// <summary>
        /// 公文类型数据绑定
        /// </summary>
        private void BindType()
        {
            //获取公文类型
            DataTable dt = new DataTable();
            dt = tbll.GetFileTypeList("1=1");
            //绑定方法一：
            this.Ddl_type.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                this.Ddl_type.Items.Add(new ListItem(
                    row["FT_NAME"].ToString(),
                    row["FTID"].ToString()));
            }
            #region  绑定方法二:
            ////指定DropDownList使用的数据源

            //Ddl_type.DataSource = dt.DefaultView;

            ////指定DropDownList使用的表里的那些字段

            //Ddl_type.DataTextField = "FT_NAME"; //dropdownlist的Text的字段

            //Ddl_type.DataValueField = "FTID";//dropdownlist的Value的字段

            //Ddl_type.DataBind();
            #endregion

        }
        /// <summary>
        /// 部门树绑定
        /// </summary>
        public void GetTree()
        {
            DataTable dt = new DataTable();

            //填充DataTable
            dt = bllDept.GetAllDep("1=1");

            //调用方法生成Tree
            GetTreeInfo(this.TvDept.Nodes, dt, 0);

        }


        /// <summary>
        /// 递归遍历部门树形
        /// </summary>
        /// <param name="nodes">树节点</param>
        /// <param name="data">数据源</param>
        /// <param name="parentId"></param>
        public static void GetTreeInfo(TreeNodeCollection nodes, DataTable data, int parentId)
        {

            //创建DataTable查询条件，根据Parentid查询
            string fliter = String.Format("PARENTID={0}", parentId);

            //查询DataTable
            DataRow[] drArr = data.Select(fliter);
            TreeNode node;

            //循环添加TreeNode
            foreach (DataRow dr in drArr)
            {
                node = new TreeNode();
                nodes.Add(node);
                node.Text = (string)dr["DPTNAME"];
                node.ShowCheckBox = true;
                GetTreeInfo(node.ChildNodes, data, Convert.ToInt32(dr["DEPTID"]));
                data.Rows.Remove(dr);
            }

        }
        

        #endregion
        #region 公文拟稿
        /// <summary>
        /// 获得公文实体数据
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_FAWEN GetEntity()
        {
            Entity.BASE_FAWEN model = new Entity.BASE_FAWEN();
            model.FID = Convert.ToInt32(this.hidPrimary.Value);     //id,主键
            model.F_NUMBER = this.txNumber.Text;                    //公文号
            model.F_TITLE = this.txTitle.Text;                      //公文标题
            model.F_TYPE = this.Ddl_type.SelectedValue;             //公文类型
            model.F_CONTENT = this.TxContent.Text;                  //公文内容
            model.F_ANNEX = this.FileUploadPath.FileName;           //公文附件路径
            model.F_DATE = DateTime.Now;                             //发文日期
            model.REMARK = this.TxRemark.Text;                      //备注
            DropDownList ddr = (DropDownList)this.department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            model.F_ORGAN = ddr.SelectedValue;                      //发文单位部门
            model.F_LEVEL = "";                                     //密级
            model.F_DEGREE = "";                                    //缓急程度
            model.F_DELSTATE = 0;                                   //状态（0已保存；1已发送；2已删除）


            return model;
        }
        /// <summary>
        /// 设置公文实体数据
        /// </summary>
        /// <param name="model">公文实体</param>
        private void SetEntity(Entity.BASE_FAWEN model)
        {
            this.hidPrimary.Value = model.FID.ToString();
            this.txNumber.Text = model.F_NUMBER;                    //公文号
            this.txTitle.Text = model.F_TITLE;                      //公文标题
            this.Ddl_type.SelectedValue = model.F_TYPE;             //公文类型
            this.TxContent.Text = model.F_CONTENT;                  //公文内容
            //this.FileUploadPath.FileName=model.F_ANNEX;           //公文附件路径
            // model.F_DATE = DateTime.Now;                             //发文日期
            this.TxRemark.Text = model.REMARK;                                      //备注
            DropDownList ddr = (DropDownList)this.department1.FindControl("ddlDepartment");//找到用户控件中的子控件
            ddr.SelectedValue = model.F_ORGAN;                      //发文单位部门
            //model.F_LEVEL = "";                                     //密级
            //model.F_DEGREE = "";                                    //缓急程度
            //model.F_DELSTATE = 0;  

        }
        //添加
        public override void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取实体
            Entity.BASE_FAWEN model = GetEntity();

            //添加数据
            bll.Add(model);
            if (bll.Exists(model.FID))
            {
                Response.Redirect("FaWen.ascx#tabs-1");
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this,typeof(Page),"提示"，"alert('请检查数据是否填写完整！')；"，true);

                // ClientScript.RegisterStartupScript(this.GetType(), "tishi", "<script type=\"text/javascript\">alert('请检查数据是否填写完整！');</script>");
                Response.Write("<script type='text/javascript'>alert('请检查数据是否填写完整！');</script>");

                Response.Redirect("FaWen.ascx#tabs-2");
            }
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
            SetEntity(new Entity.BASE_FAWEN());

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
            dataBindToRepeater();
        }
       
        #endregion
        #region 公文类型管理
        //使用TypeBindToRepeater()方法绑定公文类型数据
        private void TypeBindToRepeater(string strwhere)
        {
            DataTable dt = new DataTable();
            dt = tbll.GetFileTypeList(strwhere);
            this.AspNetPager2.RecordCount = dt.Rows.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager2.PageSize;

            this.RptType.DataSource = pds; //定义数据源
            this.RptType.DataBind(); //绑定数据
        }


        /// <summary>
        /// 查询  公文类型搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click1(object sender, EventArgs e)
        {
            TypeSearch();
        }
        /// <summary>
        /// 根据条件搜索公文类型
        /// </summary>
        private void TypeSearch()
        {
            string TxtTypeName = this.TxtTypeName.Text;//类型名称
            string FT_DEPT = this.category.Value;  //所属分类
            string strWhere = string.Empty;
            if ("" == TxtTypeName || null == TxtTypeName && "" == FT_DEPT || null == FT_DEPT)
            {
                strWhere = "1=1";
            }

            else if ("" != TxtTypeName || null != TxtTypeName && "" != FT_DEPT || null != FT_DEPT)
            {
                strWhere = "FT_NAME='" + TxtTypeName + "' and FT_DEPT='" + FT_DEPT + "'";

            }
            else if ("" == TxtTypeName || null == TxtTypeName && "" != FT_DEPT || null != FT_DEPT)
            {
                strWhere = "FT_DEPT='" + FT_DEPT + "'";

            }
            else if ("" != TxtTypeName || null != TxtTypeName && "" == FT_DEPT || null == FT_DEPT)
            {
                strWhere = "FT_NAME='" + TxtTypeName + "'";

            }
            TypeBindToRepeater(strWhere);

        }
        /// <summary>
        /// 新建公文类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnNewType_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficTypeAdd.aspx");
        }

        /// <summary>
        /// 公文类型分页事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager2.CurrentPageIndex = e.NewPageIndex;
            TypeBindToRepeater("1=1");
        }
        #endregion

       

       
      

       

    }
}