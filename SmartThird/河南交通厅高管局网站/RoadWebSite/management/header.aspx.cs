using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RoadEntity;

public partial class management_header : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunction.isLoginCheck("timeout.aspx");
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int weeks = getWeekDay(year, month, day);
            string strDate = year + "年" + month + "月" + day + "日    ";
            switch (weeks)
            {
                case 1:
                    strDate += "星期一";
                    break;
                case 2:
                    strDate += "星期二";
                    break;
                case 3:
                    strDate += "星期三";
                    break;
                case 4:
                    strDate += "星期四";
                    break;
                case 5:
                    strDate += "星期五";
                    break;
                case 6:
                    strDate += "星期六";
                    break;
                case 7:
                    strDate += "星期日";
                    break;
            }
            lblDate.Text = strDate;
            UserInfo info = (UserInfo)Session["RoadUser"];
            if (info.U_IsSuper == 1) {
                lblUser.Text = info.U_LoginName + "[" + info.U_TrueName + "][系统管理员]";
            }
            else if (info.U_IsSuper == 0) {
                lblUser.Text = info.U_LoginName + "[" + info.U_TrueName + "][" + info.U_RoadDepart.RD_Name + "]";
            }
            

        }
    }
    /// <summary>根据日期，获得星期几</summary>
    /// <param name="y">年</param> 
    /// <param name="m">月</param> 
    /// <param name="d">日</param> 
    /// <returns>星期几，1代表星期一；7代表星期日</returns>
    public static int getWeekDay(int y, int m, int d)
    {
        if (m == 1) m = 13;
        if (m == 2) m = 14;
        int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7 + 1;
        return week;
    }
}
