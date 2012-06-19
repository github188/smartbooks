using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace SmartHyd.ManageCenter.Document {
    public partial class Add : System.Web.UI.Page {
        private Utility.UserSession userSession;
        private BLL.BASE_DOCUMENT bll = new BLL.BASE_DOCUMENT();

        protected void Page_Load(object sender, EventArgs e) {
            //告诉表单如何格式化文件信息
            Page.Form.Enctype = "multipart/form-data";
            userSession = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindType();
                txtBeginTime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtEndTime.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                //获取编辑模式ID
                if (Request.QueryString["id"] != null) {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    Entity.BASE_DOCUMENT model = new Entity.BASE_DOCUMENT();
                    model = bll.GetEntity(id);
                    SetEntity(model);
                }
            }
        }

        private void BindType() {
            DataTable dt = new DataTable();
            BLL.BASE_DOCUMENT_TYPE bllType = new BLL.BASE_DOCUMENT_TYPE();
            //get data
            dt = bllType.GetList(userSession.DEPTID);

            ddlTypeList.Items.Clear();
            RecursiveNode(ddlTypeList, dt, 0, 0);
        }

        private void RecursiveNode(DropDownList ddl, DataTable dt, decimal rootId, int indent) {
            foreach (DataRow row in dt.Rows) {
                if (row["PARENTID"].ToString().Equals(rootId.ToString())) {
                    ListItem item = new ListItem();
                    for (int i = 0; i < indent; i++) {
                        if (i % 2 == 0) {
                            item.Text += "◆";
                        }
                        else {
                            item.Text += "--";
                        }
                    }
                    item.Text += row["NAME"].ToString();
                    item.Value = row["ID"].ToString();
                    ddl.Items.Add(item);

                    RecursiveNode(ddl, dt, Convert.ToDecimal(item.Value), indent += 2);
                    indent -= 2;
                }
            }
        }

        private void SetEntity(Entity.BASE_DOCUMENT model) {
            txtBeginTime.Text = model.BEGINTIME.ToString("yyyy-MM-dd");
            txtCASEFILENUMBER.Text = model.CASEFILENUMBER;
            txtCATALOGNUMBER.Text = model.CATALOGNUMBER;
            txtEndTime.Text = model.ENDTIME.ToString("yyyy-MM-dd");
            txtFONDSNO.Text = model.FONDSNO;
            hidPrimary.Value = model.ID.ToString();
            txtNUMBEROFCOPIES.Text = model.NUMBEROFCOPIES.ToString();
            txtRETENTION.Text = model.RETENTION.ToString();
            txtTitle.Text = model.TIELE;
            ddlTypeList.SelectedValue = model.TYPECODE.ToString();
            txtUnit.Text = model.UNIT;
            txtYear.Text = model.YEAR.ToString();
        }

        private Entity.BASE_DOCUMENT GetEntity() {
            Entity.BASE_DOCUMENT model = new Entity.BASE_DOCUMENT();

            model.BEGINTIME = DateTime.Parse(txtBeginTime.Text.Trim());
            model.CASEFILENUMBER = txtCASEFILENUMBER.Text.Trim();
            model.CATALOGNUMBER = txtCATALOGNUMBER.Text.Trim();
            model.DEPTCODE = userSession.DEPTID;
            model.ENDTIME = DateTime.Parse(txtEndTime.Text.Trim());
            model.FONDSNO = txtFONDSNO.Text;
            model.ID = Convert.ToDecimal(hidPrimary.Value);
            model.NUMBEROFCOPIES = Convert.ToDecimal(txtNUMBEROFCOPIES.Text.Trim());
            model.RETENTION = Convert.ToDecimal(txtRETENTION.Text.Trim());
            model.TIELE = txtTitle.Text.Trim();
            model.TYPECODE = Convert.ToDecimal(ddlTypeList.SelectedValue);
            model.UNIT = txtUnit.Text.Trim();
            model.YEAR = Convert.ToDecimal(txtYear.Text.Trim());

            return model;
        }

        private bool CheckModel(Entity.BASE_DOCUMENT model) {
            return true;
        }

        private string UploadAnnex() {
            string resultAnnex = "";

            BLL.BASE_ANNEX bllAnnex = new BLL.BASE_ANNEX();
            for (int index = 0; index < Request.Files.Count; index++) {
                if (!string.IsNullOrEmpty(Request.Files[index].FileName)) {
                    Entity.BASE_ANNEX annex = new Entity.BASE_ANNEX();
                    annex.SERVERNAME = Guid.NewGuid().ToString();       //服务器存储文件名                    
                    annex.SRCNAME = Path.GetFileName(Request.Files[index].FileName); //原文件名称
                    annex.EXTENSION = Path.GetExtension(Request.Files[index].FileName); //文件扩展名
                    annex.STATUS = 0;                                   //存储状态:0正常
                    annex.UPAUTHOR = userSession.USERID;                //上传者用户ID
                    annex.DEPTCODE = userSession.DEPTID;                //部门编号
                    annex.UPTIME = DateTime.Now;                        //文件上传时间
                    annex.SERVERPATH = string.Format("Document/{0}/", DateTime.Now.ToString("yyyyMMdd"));

                    //判断服务器存储目录路径是否存在
                    if (!Directory.Exists(Server.MapPath("~/") + annex.SERVERPATH)) {
                        Directory.CreateDirectory(Server.MapPath("~/") + annex.SERVERPATH);
                    }

                    //保存附件（服务器存储路径）
                    Request.Files[index].SaveAs(Server.MapPath("~/") + annex.SERVERPATH + annex.SERVERNAME + annex.EXTENSION);

                    //加入数据库
                    decimal id = bllAnnex.Add(annex);

                    //公文附件示例：12,56,87,96,56
                    resultAnnex += id.ToString() + ",";
                }
            }

            return resultAnnex;
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Entity.BASE_DOCUMENT model = new Entity.BASE_DOCUMENT();
            model = GetEntity();

            if (this.CheckModel(model)) {
                model.ANNEX = this.UploadAnnex();

                if (string.IsNullOrWhiteSpace(model.ANNEX)) {
                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>至少添加一个附件文档!</div>";
                }

                if (model.ID < 0) {
                    bll.Add(model);

                    litmsg.Visible = true;
                    litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>添加成功!</div>";
                }
                else {
                    bll.Update(model);

                    Response.Redirect("List.aspx", true);
                }
            }
        }
    }
}