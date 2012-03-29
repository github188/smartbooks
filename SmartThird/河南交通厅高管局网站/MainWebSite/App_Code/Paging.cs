using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Wuqi.Webdiyer;

/// <summary>
/// Pageing 的摘要说明
/// </summary>
public class Paging
{
    public Paging()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 绑定分页数据
    /// </summary>
    /// <param name="dt">DataTable对象</param>
    /// <param name="anp">AspNetPager对象</param>
    public static void BindPageData(DataTable dt,Repeater rpt, AspNetPager AspNetPager1)
    {
        AspNetPager1.RecordCount = dt.Rows.Count;
        if (dt.Rows.Count >= 0)
        {
            PagedDataSource ps = new PagedDataSource();
            DataView dv = new DataView(dt);
            ps.DataSource = dv;
            ps.AllowPaging = true;
            ps.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            ps.PageSize = AspNetPager1.PageSize;
            rpt.DataSource = ps;
            rpt.DataBind();
        }
    }
}
