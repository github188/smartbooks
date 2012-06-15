using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SmartHyd.ManageCenter.Official {
    public partial class Create : System.Web.UI.Page {
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private BLL.BASE_ARTICLE_TYPE bllType = new BLL.BASE_ARTICLE_TYPE();
        private Utility.UserSession userSession;

        //页面加载
        protected void Page_Load(object sender, EventArgs e) {
            //告诉表单如何格式化文件信息
            Page.Form.Enctype = "multipart/form-data";
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindingType();     //绑定公文分类
                BindAcceptUnit();   //绑定收文部门                
            }

            //获取编辑模式ID
            if (Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
                model = bll.GetEntity(id);
                SetEntity(model);
            }
        }

        private void BindingType() {
            DataTable dt = new DataTable();
            dt = bllType.GetList(string.Format("DEPTID={0}", userSession.DEPTID.ToString()));

            RecursiveTree(ddlTypeId, dt, 0);
        }

        private void RecursiveTree(DropDownList dropDownControl, DataTable dt, int rootId) {
            foreach (DataRow row in dt.Rows) {
                if (row["PARENT"].ToString().Equals(rootId.ToString())) {
                    dropDownControl.Items.Add(new ListItem(
                    row["TYPENAME"].ToString(),
                    row["ID"].ToString()));

                    RecursiveTree(dropDownControl, dt, Convert.ToInt32(row["ID"].ToString()));
                }
            }
        }

        //获取实体
        private Entity.BASE_ARTICLE GetEntity() {
            Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
            model.CONTENT = txtContent.Text;    //内容            
            model.ISREPLY = chkIsReply.Checked ? 0 : 1;  //允许回复            
            model.SCORE = Convert.ToInt32(txtSCORE.Text);   //分值
            model.SENDCODE = txtSendCode.Text;  //发文字号
            //model.STATUS = Convert.ToInt32(ddlStatus.SelectedValue);    //发文状态            
            model.TITLE = txtTitle.Text;        //标题
            model.TYPEID = Convert.ToInt32(ddlTypeId.SelectedValue);    //公文类别
            model.PARENTID = 0;                 //父发文编号
            model.TIMESTAMP = DateTime.Now;     //时间戳            
            model.ANNEX = "";                   //附件
            model.USERID = userSession.USERID;  //用户编号
            model.DEPTID = userSession.DEPTID;  //所属部门

            model.ID = Convert.ToInt32(hidPrimary.Value);   //主键
            model.PARENTID = Convert.ToInt32(hidParentPrimary.Value);   //父发文编号

            return model;
        }

        //设置实体
        private void SetEntity(Entity.BASE_ARTICLE model) {
            if (model != null) {
                txtContent.Text = model.CONTENT;                        //内容
                chkIsReply.Checked = model.ISREPLY.ToString().Equals("0") ? true : false;    //允许回复
                txtSCORE.Text = model.SCORE.ToString();                 //分值
                txtSendCode.Text = model.SENDCODE;                      //发文字号                
                txtTitle.Text = model.TITLE;                            //标题
                ddlTypeId.SelectedValue = model.TYPEID.ToString();      //公文类别
                hidPrimary.Value = model.ID.ToString();                 //主键
                hidParentPrimary.Value = model.PARENTID.ToString(); //父发文编号
                //ddlStatus.SelectedValue = model.STATUS.ToString();      //发文状态
                //model.TIMESTAMP = DateTime.Now;     //时间戳
                //model.USERID = userSession.USERID;  //用户编号
                //model.DEPTID = userSession.Department[0].DEPTID;    //部门
                //model.ANNEX = "";                   //附件
            }
        }

        //遍历每一个部门节点(增加公文收文单位)
        private void RecursiveSubNode(TreeNode node, int articleId) {
            if (node.Checked) {
                BLL.BASE_ARTICLE_UNIT unitBll = new BLL.BASE_ARTICLE_UNIT();
                Entity.BASE_ARTICLE_UNIT unitmodel = new Entity.BASE_ARTICLE_UNIT();
                unitmodel.ARTICLEID = articleId;
                unitmodel.DPTCODE = Convert.ToInt32(node.Value);
                unitmodel.ISREAD = 0;   //未查阅
                unitmodel.READTIME = DateTime.Now;  //发文时间
                unitBll.Add(unitmodel);

                /*短信通知*/
                if (chkSMSAlert.Checked) {
                    //给该部门负责人发送短信通知
                }
            }

            foreach (TreeNode subNode in node.ChildNodes) {
                RecursiveSubNode(subNode, articleId);
            }
        }
        
        //绑定收文单位
        private void BindAcceptUnit() {
            DataTable dt = new DataTable();
            BLL.BASE_DEPT dept = new BLL.BASE_DEPT();
            /*当前用户所属部门和子部门*/
            dt = dept.GetUserWhereDepartment(userSession.USERNAME, -1);

            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString().Equals("0")) {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = dr["DPTNAME"].ToString();
                    rootNode.Value = dr["DEPTID"].ToString();
                    rootNode.ToolTip = dr["DPTINFO"].ToString();
                    rootNode.ShowCheckBox = true;
                    rootNode.Expanded = true;

                    //递归子节点
                    RecursiveBindAcceptUnit(rootNode, dt);

                    //加入控件
                    TreeViewAcceptUnit.Nodes.Add(rootNode);
                }
            }
        }

        /// <summary>
        /// 填充部门树
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="dt">数据源</param>
        private void RecursiveBindAcceptUnit(TreeNode node, DataTable dt) {
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString().Equals(node.Value)) {
                    //添加子节点
                    TreeNode sub = new TreeNode();
                    sub.Text = dr["DPTNAME"].ToString();
                    sub.Value = dr["DEPTID"].ToString();
                    sub.ToolTip = dr["DPTINFO"].ToString();
                    sub.ShowCheckBox = true;
                    sub.Expanded = false;
                    node.ChildNodes.Add(sub);

                    //递归循环
                    RecursiveBindAcceptUnit(sub, dt);
                }
            }
        }

        //校验选择的部门树
        private bool CheckSelectDepartment() {
            bool res = false;
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                if (node.Checked) {
                    res = true;
                }
                RecursiveCheckNode(node, ref res);
            }
            return res;
        }

        //检验提交表单
        private bool CheckSubmitForm() {
            //检验标题:长度/空值
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>公文标题不能为空!</div>";
                txtTitle.Focus();
                return false;
            }

            //发文字号
            if (string.IsNullOrWhiteSpace(txtSendCode.Text)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>发文字号不能为空!</div>";
                txtSendCode.Focus();
                return false;
            }

            //内容
            if (string.IsNullOrWhiteSpace(txtContent.Text)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>公文内容不能为空!</div>";
                txtContent.Focus();
                return false;
            }

            //发文分值
            try {
                Convert.ToInt32(txtSCORE.Text);
            }
            catch {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center; float:left;'>公文分值必须为有效数字!</div>";
                txtSCORE.Focus();
                return false;
            }
            litmsg.Visible = false;
            return true;
        }

        //校验是否选择了收文单位
        private bool CheckAcceptUnit() {
            /*编辑模式不校验接收部门*/
            if (TreeViewAcceptUnit.Enabled) {
                //校验是否选择了至少一个部门
                if (!CheckSelectDepartment()) {
                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center; float:left;'>请选择至少一个公文接收的部门!</div>";
                    return false;
                }
            }
            return true;
        }

        //递归检查有无选中的节点
        private void RecursiveCheckNode(TreeNode node, ref bool isSelected) {
            if (node.Checked) {
                isSelected = true;
                return;
            }
            foreach (TreeNode sub in node.ChildNodes) {
                RecursiveCheckNode(sub, ref isSelected);
            }
        }

        /// <summary>
        /// 遍历选择部门节点
        /// </summary>
        /// <param name="node">部门节点</param>
        /// <param name="method">0.全选 1.反选 3.运营单位 4.路政大队</param>
        private void RecursiveNode(TreeNode node, int method) {
            switch (method) {
                //全选
                case 0:
                    node.Checked = true;
                    break;
                //反选
                case 1:
                    node.Checked = node.Checked ? false : true;
                    break;
                //运营单位
                case 2:
                    if (node.Depth == 1) {
                        node.Checked = true;
                    }
                    else {
                        node.Checked = false;
                    }
                    break;
                //路政大队
                case 3:
                    if (node.Depth == 2) {
                        node.Checked = true;
                    }
                    else {
                        node.Checked = false;
                    }
                    break;
            }
            foreach (TreeNode sub in node.ChildNodes) {
                RecursiveNode(sub, method);
            }
        }

        //添加公文
        private void Creates(Entity.BASE_ARTICLE model) {
            #region 上传附件
            BLL.BASE_ARTICLE_ANNEX bllAnnex = new BLL.BASE_ARTICLE_ANNEX();
            for (int index = 0; index < Request.Files.Count; index++) {
                if (!string.IsNullOrEmpty(Request.Files[index].FileName)) {
                    Entity.BASE_ARTICLE_ANNEX annex = new Entity.BASE_ARTICLE_ANNEX();
                    annex.SERVERNAME = Guid.NewGuid().ToString();       //服务器存储文件名                    
                    annex.SOURCENAME = Path.GetFileName(Request.Files[index].FileName); //原文件名称
                    annex.EXTENSION = Path.GetExtension(Request.Files[index].FileName); //文件扩展名
                    annex.STATUS = 0;                                   //存储状态:0正常
                    annex.UPAUTHOR = userSession.USERID;                //上传者用户ID
                    annex.UPTIME = DateTime.Now;                        //文件上传时间
                    annex.SERVERPATH = string.Format("Document/{0}/", DateTime.Now.ToString("yyyyMMdd"));

                    //判断服务器存储目录路径是否存在
                    if (!Directory.Exists(Server.MapPath("~/") + annex.SERVERPATH)) {
                        Directory.CreateDirectory(Server.MapPath("~/") + annex.SERVERPATH);
                    }

                    //保存附件（服务器存储路径）
                    Request.Files[index].SaveAs(Server.MapPath("~/") + annex.SERVERPATH + annex.SERVERNAME + annex.EXTENSION);

                    //加入数据库
                    bllAnnex.Add(annex);

                    //公文附件示例：12,56,87,96,56
                    model.ANNEX += bllAnnex.GetMaxId().ToString() + ",";
                }
            }
            #endregion
                        
            //保存公文到数据库
            bll.Add(model);

            /*回复模式不需要添加收文单位*/
            if (hidParentPrimary.Value.Equals("0")) {
                //获取出刚添加的公文ID编号
                string where = string.Format("TITLE='{0}'", model.TITLE);
                int id = Convert.ToInt32(bll.GetList(where).Rows[0]["ID"].ToString());

                //增加公文接收部门记录                
                foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                    RecursiveSubNode(node, id);
                }
            }
        }

        //更新公文
        private void Update(Entity.BASE_ARTICLE model) {
            /*
             * 说明:发送到单位不能更改，附件不更改。
             */

            bll.Update(model);
        }

        #region 按钮事件
        //提交操作
        protected void btnSubmit_Click(object sender, EventArgs e) {
            litmsg.Visible = false;

            //检验提交表单
            if (!CheckSubmitForm()) {
                return;
            }
            /*收文单位*/
            if (!CheckAcceptUnit()) {
                return;
            }

            //获取实体
            Entity.BASE_ARTICLE model;
            model = this.GetEntity();

            /*大于等于0编辑模式，小于0新建模式*/
            if (model.ID < 0) {
                /*新建或着回复模式*/
                this.Creates(model);
            }
            else {
                this.Update(model); //编辑公文
            }

            /*跳转到发件箱*/
            Response.Redirect("~/ManageCenter/Official/BeenSent.aspx", true);
        }
        //存草稿
        protected void btnSave_Click(object sender, EventArgs e) {
            litmsg.Visible = false;

            //检验提交表单,不校验收文单位
            if (!CheckSubmitForm()) {
                return;
            }

            //获取实体
            Entity.BASE_ARTICLE model;
            model = this.GetEntity();

            //存草稿
            model.STATUS = 2;

            if (model.ID < 0) {
                bll.Add(model);/*添加新草稿*/
            }
            else {
                bll.Update(model);/*修改草稿*/
            }
            Response.Redirect("DraftsBox.aspx", true);
        }
        //打印
        protected void btnPrint_Click(object sender, EventArgs e) {

        }
        //取消
        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("Accept.aspx", true);
        }
        #endregion

        #region 树节点选择
        //收文单位节点选择状态改变
        protected void TreeViewAcceptUnit_SelectedNodeChanged(object sender, EventArgs e) {

        }
        //全选
        protected void lnkSelectAll_Click(object sender, EventArgs e) {
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                RecursiveNode(node, 0);
            }
        }
        //反选
        protected void lnkSelectNoAll_Click(object sender, EventArgs e) {
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                RecursiveNode(node, 1);
            }
        }
        //选择运营单位
        protected void lnkSelectUnit_Click(object sender, EventArgs e) {
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                RecursiveNode(node, 2);
            }
        }
        //选择路政大队
        protected void lnkSelectGroup_Click(object sender, EventArgs e) {
            foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                RecursiveNode(node, 3);
            }
        }
        #endregion
    }
}