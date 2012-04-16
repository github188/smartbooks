using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MainService;

/// <summary>
/// Property 的摘要说明
/// </summary>
public class Property
{
    public Property()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static bool HaveImg(int oid)
    {
        bool result=false;
        DataTable dt = NewsInfoService.Get_NewsInfo(oid);
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["N_ImgPath"].ToString() != "")
            {
                result = true;
            }
        }
        return result;
    }
}
