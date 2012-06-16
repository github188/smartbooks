using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SmartHyd.ManageCenter.RoadTerm {
    public partial class RoadTermAdd : System.Web.UI.Page {
        private BLL.BASE_ROAD_TERM bll = new BLL.BASE_ROAD_TERM();
        private BLL.BASE_ROAD_TERM_TYPE bllRoadType = new BLL.BASE_ROAD_TERM_TYPE();
        private Utility.UserSession session;

        protected void Page_Load(object sender, EventArgs e) {
            session = (Utility.UserSession)Session["user"];

            if (!IsPostBack) {
                BindingRoadType();      //绑定路产设备类型数据

                txtREGTIME.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtCOMPTIME.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        //从页面获取实体
        private Entity.BASE_ROAD_TERM GetEntity() {
            Entity.BASE_ROAD_TERM model = new Entity.BASE_ROAD_TERM();
            litmsg.Visible = false;
            try {
                model.COMPTIME = DateTime.Parse(txtCOMPTIME.Text.Trim());   //竣工时间
                model.DEPTID = Convert.ToInt32(Session["deptcode"].ToString());   //部门编号
                model.ID = Convert.ToInt32(hidPrimary.Value);   //id
                model.LINENAME = txtLINENAME.Text.Trim();   //公路名称            
                model.REGTIME = DateTime.Parse(txtREGTIME.Text.Trim()); //登记时间
                model.REMARK = txtREMARK.Text.Trim();   //备注
                model.ROADNAME = txtRoadName.Text.Trim();
                model.STAKEK = Convert.ToInt32(txtSTAKEK.Text.Trim());  //k
                model.STAKEM = Convert.ToInt32(txtSTAKEM.Text.Trim());  //m
                model.STATUS = Convert.ToInt32(ddlStatus.SelectedValue);    //status
                model.SUMMARY = txtSUMMARY.Text.Trim(); //位置描述
                model.TYPEID = Convert.ToInt32(ddlTermType.SelectedValue);  //设备类型
                model.ROADNAME = txtRoadName.Text.Trim();   //设备名称

                model.PHOTO = "";   //设备照片
                return model;
            }
            catch (Exception ex) {
                litmsg.Visible = true;
                litmsg.Text = string.Format("<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>{0}</div>", ex.Message);
                throw ex;
            }
        }

        //初始化实体到页面
        private void SetEntity(Entity.BASE_ROAD_TERM model) {
            txtCOMPTIME.Text = model.COMPTIME.ToString();   //竣工时间
            hidPrimary.Value = model.ID.ToString(); //id
            txtLINENAME.Text = model.LINENAME;  //公路名称
            txtREGTIME.Text = model.REGTIME.ToString(); //登记时间
            txtREMARK.Text = model.REMARK;  //备注
            txtRoadName.Text = model.ROADNAME;  //设备名称
            txtSTAKEK.Text = model.STAKEK.ToString();   //k
            txtSTAKEM.Text = model.STAKEM.ToString();   //m
            ddlStatus.SelectedValue = model.STATUS.ToString();  //status
            txtSUMMARY.Text = model.SUMMARY;    //位置描述
            ddlTermType.SelectedValue = model.TYPEID.ToString();   //设备类型

            //model.DEPTID = Convert.ToInt32(Department1.SelectedValue);   //部门编号
        }

        //绑定路产设备类型数据
        private void BindingRoadType() {
            DataTable dt = new DataTable();

            //获取路产设备类型数据
            dt = bllRoadType.GetAllList();

            ddlTermType.Items.Clear();
            foreach (DataRow dr in dt.Rows) {
                ddlTermType.Items.Add(new ListItem(
                    dr["TYPENAME"].ToString(),
                    dr["TYPEID"].ToString()));
            }
        }

        //submit 
        protected void btnSubmit_Click(object sender, EventArgs e) {
            //校验逻辑放在客户端用js实现
            litmsg.Visible = false;

            Entity.BASE_ROAD_TERM model = GetEntity();
            //上传图片
            model.PHOTO = UpLoadPic();

            bll.Add(model);


            //刷新页面
            litmsg.Visible = true;
            litmsg.Text = "<div style='font-size:16px; font-family:微软雅黑; color:red;font-weight:bold; text-align:center;'>添加成功</div>";

            SetEntity(new Entity.BASE_ROAD_TERM());
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>服务器存储相对路径</returns>
        private string UpLoadPic() {
            string serverPath = "";
            if (!string.IsNullOrEmpty(fileupPhoto.FileName)) {
                //服务器存储路径
                string filePath = string.Format("{0}Images\\RoadImage\\{1}\\",
                    Server.MapPath("~/"),
                    DateTime.Now.ToString("yyyyMMdd"));

                //服务器存储文件名
                string fileName = string.Format("{0}.{1}",
                    Guid.NewGuid().ToString(),
                    fileupPhoto.FileName.Substring(fileupPhoto.FileName.Length - 3, 3));

                //判断路径是否存在，如果不存在那么则创建这个路径
                if (!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }

                //上传附件
                serverPath += string.Format("Images/RoadImage/{0}/{1}",
                    DateTime.Now.ToString("yyyyMMdd"),
                    fileName);
                fileupPhoto.SaveAs(filePath + fileName);
            }

            return serverPath;
        }
    }
}