using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SmartHyd.ManageCenter.Official {
    public partial class ReplySource : System.Web.UI.Page {
        private Entity.BASE_ARTICLE srcModel;
        private BLL.BASE_ARTICLE bll = new BLL.BASE_ARTICLE();
        private Utility.UserSession userSession;

        protected void Page_Load(object sender, EventArgs e) {
            //告诉表单如何格式化文件信息
            Page.Form.Enctype = "multipart/form-data";

            //init session
            if (Session["user"] != null) {
                userSession = (Utility.UserSession)Session["user"];
            }

            //get send id
            if (Request.QueryString["id"] != null) {
                srcModel = bll.GetEntity(Convert.ToInt32(Request.QueryString["id"]));

                txtTitle.Text = srcModel.TITLE + "的回复";
                txtContent.Text = string.Format("<p></p><p>引用“{0}”</p>", srcModel.CONTENT);

                hidSrcCode.Value = srcModel.ID.ToString();
                hnkSourceTitle.Text = srcModel.TITLE;
                hnkSourceTitle.NavigateUrl = string.Format("~/ManageCenter/Official/Detail.aspx?id={0}",
                    srcModel.ID.ToString());
            }
        }

        private Entity.BASE_ARTICLE GetModel() {
            Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
            model.ANNEX = "";
            model.CONTENT = txtContent.Text.Trim();
            model.DEPTID = userSession.DEPTID;
            model.ISREPLY = 1;
            model.PARENTID = srcModel.ID;
            model.SCORE = 0;
            model.SENDCODE = srcModel.SENDCODE;
            model.STATUS = 0;
            model.TIMESTAMP = DateTime.Now;
            model.TITLE = txtTitle.Text.Trim();
            model.TYPEID = 0;
            model.USERID = userSession.USERID;

            return model;
        }

        private bool CheckModel(Entity.BASE_ARTICLE model) {
            if (string.IsNullOrWhiteSpace(model.TITLE)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>标题不能为空!</div>";
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.CONTENT)) {
                litmsg.Visible = true;
                litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;float:left;'>内容不能为空!</div>";
                txtContent.Focus();
                return false;
            }

            return true;
        }

        private Entity.BASE_ARTICLE UpLoadAnnex(Entity.BASE_ARTICLE model) {
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

            return model;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {

            Entity.BASE_ARTICLE model = new Entity.BASE_ARTICLE();
            model = GetModel();

            if (CheckModel(model)) {
                //上传附件
                model = UpLoadAnnex(model);

                //reply
                bll.Add(model);


                //短信提醒
                if (chkSMSAlert.Checked) {
                    //获取发文userid的phone
                    //send ...
                }

                //跳转到收文页面
                Response.Redirect("~/ManageCenter/Official/Accept.aspx", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e) {

        }
    }
}