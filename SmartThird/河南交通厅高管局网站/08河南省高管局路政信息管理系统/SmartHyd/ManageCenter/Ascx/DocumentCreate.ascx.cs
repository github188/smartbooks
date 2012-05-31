
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SmartHyd.ManageCenter.Ascx {
    public partial class DocumentCreate : UI.BaseUserControl {        
        #region 私有字段
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private BLL.BASE_ARTICLE_TYPE bllType = new BLL.BASE_ARTICLE_TYPE();
        private Utility.UserSession userSession;
        private int inde = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e) {
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindType();     //绑定公文分类
                BindAcceptUnit();   //绑定收文部门

                //绑定公文类别
                DataTable dt = bllType.GetDeptNodeData(Convert.ToInt32(userSession.DEPTID)); //默认采用13部门
                ddlTypeId.Items.Clear();
                InitTreeNodes(ddlTypeId, 0, dt, 0);

                //获取编辑模式和ID
                if (Request.QueryString["id"] != null) {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    //获取实体
                    Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
                    model = bll.GetEntity(id);

                    //初始化实体到页面
                    SetEntity(model);
                }
            }

            //获取用户Session
            userSession = (Utility.UserSession)Session["user"];
        }

        //绑定公文类别
        private void BindType() {
            DataTable dt = new DataTable();

            ddlTypeId.Items.Clear();
            foreach (DataRow row in dt.Rows) {
                ddlTypeId.Items.Add(new ListItem(
                    row["TYPENAME"].ToString(),
                    row["ID"].ToString()));
            }
            if (ddlTypeId.Items.Count != 0) {
                ddlTypeId.SelectedIndex = 0;
            }
        }
        //获取实体
        private Entity.BASE_ARTICLE GetEntity() {            

            Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
            model.CONTENT = txtContent.Text;    //内容            
            model.ISREPLY = Convert.ToInt32(rdoIsReply.SelectedValue);  //允许回复            
            model.SCORE = Convert.ToInt32(txtSCORE.Text);   //分值
            model.SENDCODE = txtSendCode.Text;  //发文字号
            model.STATUS = Convert.ToInt32(ddlStatus.SelectedValue);    //发文状态            
            model.TITLE = txtTitle.Text;        //标题
            model.TYPEID = Convert.ToInt32(ddlTypeId.SelectedValue);    //公文类别
            model.PARENTID = 0;                 //父发文编号
            model.TIMESTAMP = DateTime.Now;     //时间戳            
            model.ANNEX = "";                   //附件
            model.USERID = userSession.USERID;  //用户编号
            model.DEPTID = userSession.DEPTID;  //所属部门
            return model;
        }
        //设置实体
        private void SetEntity(Entity.BASE_ARTICLE model) {
            if (model != null) {
                txtContent.Text = model.CONTENT;                        //内容
                rdoIsReply.SelectedValue = model.ISREPLY.ToString();    //允许回复
                txtSCORE.Text = model.SCORE.ToString();                 //分值
                txtSendCode.Text = model.SENDCODE;                      //发文字号
                ddlStatus.SelectedValue = model.STATUS.ToString();      //发文状态
                txtTitle.Text = model.TITLE;                            //标题
                ddlTypeId.SelectedValue = model.TYPEID.ToString();      //公文类别

                //model.PARENTID = 0;                 //父发文编号
                //model.TIMESTAMP = DateTime.Now;     //时间戳
                //model.USERID = userSession.USERID;  //用户编号
                //model.DEPTID = userSession.Department[0].DEPTID;    //部门
                //model.ANNEX = "";                   //附件
            }
        }
        //遍历每一个部门节点
        private void RecursiveSubNode(TreeNode node, int articleId) {
            if (node.Checked) {
                BLL.BASE_ARTICLE_UNIT unitBll = new BLL.BASE_ARTICLE_UNIT();
                Entity.BASE_ARTICLE_UNIT unitmodel = new Entity.BASE_ARTICLE_UNIT();
                unitmodel.ARTICLEID = articleId;
                unitmodel.DPTCODE = Convert.ToInt32(node.Value);
                unitmodel.ISREAD = 0;   //未查阅
                unitmodel.READTIME = DateTime.Now;  //发文时间
                unitBll.Add(unitmodel);
            }

            foreach (TreeNode subNode in node.ChildNodes) {
                RecursiveSubNode(subNode, articleId);
            }
        }
        //绑定档案分类节点
        private void InitTreeNodes(DropDownList ddl, int parentId, DataTable dt, int indent) {
            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENT"].ToString() == parentId.ToString()) {
                    inde += indent;
                    ListItem item = new ListItem();
                    for (int i = 0; i < inde; i++) {
                        item.Text += "-";
                    }
                    item.Text += dr["TYPENAME"].ToString();
                    item.Value = dr["ID"].ToString();
                    ddl.Items.Add(item);
                    InitTreeNodes(ddl, Convert.ToInt32(dr["ID"].ToString()), dt, 2);
                    inde -= 2;
                }
            }
        }
        //绑定收文单位
        private void BindAcceptUnit() {
            DataTable dt = new DataTable();
            //获取用户所属单位和下级部门
            BLL.BASE_DEPT dept = new BLL.BASE_DEPT();
            dt = dept.GetAllDep("STATUS=0");

            foreach (DataRow dr in dt.Rows) {
                if (dr["PARENTID"].ToString().Equals("0")) {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = dr["DPTNAME"].ToString();
                    rootNode.Value = dr["DEPTID"].ToString();
                    rootNode.ToolTip = dr["DPTINFO"].ToString();
                    rootNode.ShowCheckBox = true;
                    rootNode.Expanded = false;

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
        //添加公文
        protected void btnSubmit_Click(object sender, EventArgs e) {
            //校验输入
            if (CheckSelectDepartment()) {
                //获取实体
                Entity.BASE_ARTICLE model;
                model = this.GetEntity();

                #region 上传附件
                //此处实现上传附件
                string serverPath = "~/";
                if (!string.IsNullOrEmpty(fileUpAnnex.FileName)) {
                    //服务器存储路径
                    string filePath = string.Format("{0}Document\\{1}\\",
                        Server.MapPath("~/"),
                        DateTime.Now.ToString("yyyyMMdd"));

                    //服务器存储文件名
                    string fileName = string.Format("{0}.{1}",
                        Guid.NewGuid().ToString(),
                        fileUpAnnex.FileName.Substring(fileUpAnnex.FileName.Length - 3, 3));

                    //判断路径是否存在，如果不存在那么则创建这个路径
                    if (!Directory.Exists(filePath)) {
                        Directory.CreateDirectory(filePath);
                    }

                    //上传附件
                    serverPath += string.Format("Document/{0}/{1}",
                        DateTime.Now.ToString("yyyyMMdd"),
                        fileName);
                    fileUpAnnex.SaveAs(filePath + fileName);
                }
                //保存附件路径
                model.ANNEX = serverPath;
                #endregion

                //保存公文到数据库
                bll.Add(model);

                //获取出刚添加的公文ID编号
                string where = string.Format("TITLE='{0}'", model.TITLE);
                int id = Convert.ToInt32(bll.GetList(where).Rows[0]["ID"].ToString());

                //增加公文接收部门记录                
                foreach (TreeNode node in TreeViewAcceptUnit.Nodes) {
                    RecursiveSubNode(node, id);
                }

                //重新加载当前页
                Response.Redirect("DocumentManage.aspx", true);
            } else {
                Smart.Utility.Alerts.Alert("请选择至少一个公文接收的部门");
            }
        }
    }
}