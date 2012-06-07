using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHyd.Entity;

namespace SmartHyd.ManageCenter.UserManager {
    public partial class UnitEdit : System.Web.UI.Page {

        private BLL.BASE_DEPT bll = new BLL.BASE_DEPT();
        private BLL.BASE_LOG logbll = new BLL.BASE_LOG();

        public int _OPTFLAG = 0;//表新增单位信息

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                string strAction = Request.QueryString["action"].ToString();
                ViewState["strAction"] = strAction;
                if (strAction == "update") {
                    string strUnitId = Request.QueryString["unitid"].ToString();
                    ViewState["strUnitId"] = strUnitId;
                    hidPrimary.Value = strUnitId;


                    decimal DEPTID = Convert.ToDecimal(Request.QueryString["unitid"]);
                    Entity.BASE_DEPT model = bll.GetEntity(DEPTID);
                    SetEntity(model);

                } else if (strAction == "add") {
                    string parentId = Request.QueryString["parentId"].ToString();
                    ViewState["parentId"] = parentId;
                   
                }
            }
        }
        

        #region 
        /// <summary>
        /// 获得部门数据实体
        /// </summary>
        /// <returns></returns>
        private Entity.BASE_DEPT GetEntity(decimal parentId) {
            Entity.BASE_DEPT model = new Entity.BASE_DEPT();
            model.DEPTID = Convert.ToInt32(this.hidPrimary.Value);  //id,主键
            model.DPTNAME = this.TxtDeptName.Text.Trim();           //部门名称       
            model.DPTINFO = this.txtDptinfo.Text.Trim();            //部门描述

            model.PARENTID = parentId;   //上级部门
           
            model.STATUS = 0;                                   //状态0:正常；1：关闭

            return model;
        }
        /// <summary>
        /// 设置部门数据
        /// </summary>
        /// <param name="model">部门实体</param>
        private void SetEntity(Entity.BASE_DEPT model) {

            this.TxtDeptName.Text = model.DPTNAME;                    //部门名称
            this.txtDptinfo.Text = model.DPTINFO;             //部门描述
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e) {
            if (ViewState["strAction"].ToString() == "add")//添加部门信息
            {
                //获取实体
                Entity.BASE_DEPT model = GetEntity(Convert.ToDecimal(ViewState["parentId"].ToString()));

                //添加数据
                int flag = bll.Add(model);

                //日志..............添加
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "部门管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "新建部门";                             //日志信息内容
                logmodel.OPERATORID = 17;                    //操作人编号
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);

                if (flag > 0) {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('操作成功');window.close();", true);
                } else {
                    AjaxAlert(UpdatePanel1, "操作失败，请检查数据录入是否规范！");
                }

            } else //修改部门信息
            {
                //获取实体
                Entity.BASE_DEPT model = GetEntity(0);//编辑时对上级编号不做修改
                bool flag=bll.update(model);

                //日志..............修改
                Entity.BASE_LOG logmodel = new Entity.BASE_LOG();
                logmodel.LOGID = -1;                        //id,主键
                logmodel.LOGTYPE = "部门管理";                     //日志类型
                logmodel.CREATEDATE = DateTime.Now;                   //日志创建时间
                logmodel.DESCRIPTION = "编辑部门";                             //日志信息内容
                logmodel.OPERATORID = 17;                    //操作人编号
                logmodel.IPADDRESS = Smart.Utility.IpAddress.GetLocationIpAddress();                 //ip地址
                logbll.Add(logmodel);

                if (flag) {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('操作成功');window.close();", true);
                } else {
                    AjaxAlert(UpdatePanel1, "操作失败，请检查数据录入是否规范！");
                }
            }
        }

        public void AjaxAlert(UpdatePanel uPanel, string strMsg) {
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "", "alert('" + strMsg + "');", true);
        }
    }
}