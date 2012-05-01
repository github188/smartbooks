using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTeaching
{
    public partial class master : System.Web.UI.MasterPage
    {
        BLL.Base_News bll = new BLL.Base_News();
        BLL.Base_NewsType bllType = new BLL.Base_NewsType();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string u = txtusername.Text;
            string p = txtpwd.Text;
            p = Smart.Security.MD5.MD5Encrypt(p).ToUpper();
            BLL.Base_User user = new BLL.Base_User();
            DataSet ds = new DataSet();
            ds = user.GetList(string.Format("UserName='{0}' and Userpwd='{1}'", u, p));

            //跳转到主页面
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                Session["username"] = u;
                Session["pwd"] = p;
                Session["ssid"] = Session.SessionID;
                Session["uid"] = ds.Tables[0].Rows[0]["UserId"];
                Session["roleid"] = ds.Tables[0].Rows[0]["RoleId"];

                Response.Cookies.Add(new HttpCookie("username", u));
                Response.Cookies.Add(new HttpCookie("pwd", p));
                Response.Cookies.Add(new HttpCookie("ssid", "3"));
                Response.Cookies.Add(new HttpCookie("roleid", ds.Tables[0].Rows[0]["RoleId"].ToString()));
                Response.Cookies.Add(new HttpCookie("uid", ds.Tables[0].Rows[0]["UserId"].ToString()));
            }
        }

        private void BindData()
        {
            //常见问题
            topMessage.DataSource = bll.GetList(5, "NewsTypeId=45", "CreateDate DESC");
            topMessage.DataBind();

            //获取角色roleid
            int RoleId = 13; //默认匿名用户
            try
            {
                RoleId = Convert.ToInt32(Session["roleid"].ToString());
            }
            catch { }
            BLL.Base_UserRole userRole = new BLL.Base_UserRole();
            DataTable dt = new DataTable();

            //根据用户角色获取模块
            dt = userRole.GetList(string.Format("RoleId={0}", RoleId)).Tables[0];
            string where = " and NewsTypeId in (";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < dt.Rows.Count - 2)
                {
                    where += dt.Rows[i]["NewsTypeId"].ToString() + ",";
                }
                else
                {
                    where += dt.Rows[i]["NewsTypeId"].ToString();
                }
            }
            where += " ) ";

            //绑定根节点
            repRootTree.DataSource = bllType.GetList("ParentId=0" + where);
            repRootTree.DataBind();
        }

        protected void repRootTree_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("repSubTree") as Repeater;
                DataRowView row = (DataRowView)e.Item.DataItem;

                //获取角色roleid
                int RoleId = 13; //默认匿名用户
                try
                {
                    RoleId = Convert.ToInt32(Session["roleid"].ToString());
                }
                catch { }
                BLL.Base_UserRole userRole = new BLL.Base_UserRole();
                DataTable dt = new DataTable();

                //根据用户角色获取模块
                dt = userRole.GetList(string.Format("RoleId={0}", RoleId)).Tables[0];
                string where = " and NewsTypeId in (";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i < dt.Rows.Count - 2)
                    {
                        where += dt.Rows[i]["NewsTypeId"].ToString() + ",";
                    }
                    else
                    {
                        where += dt.Rows[i]["NewsTypeId"].ToString();
                    }
                }
                where += " ) ";

                rep.DataSource = bllType.GetList(string.Format("ParentId={0}" + where, row["NewsTypeId"].ToString()));
                rep.DataBind();
            }
        }
    }
}