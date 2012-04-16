<%@ WebHandler Language="C#" Class="pie" %>

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
using pie_write;
using PubClass;
using Model;
using DataAccess;

public class pie : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
      context.Response.ContentType = "image/jpeg";
      context.Response.Cache.SetCacheability(HttpCacheability.Public);
      context.Response.BufferOutput = false;
      int sid = Convert.ToInt32(context.Request["serviceid"]);
      DataSet ds = DBHelper.Get_DataSet("select SV_ZH,SV_GY,SV_SF,SV_HJ,SV_TC,SV_GL,SV_YJ,SV_ZA,SV_SS,SV_GC,SV_CS,SV_CY,SV_KF,SV_JY,SV_QX from T_ServiceVote where SV_SID="+sid);
      ds = ds == null ? new DataSet() : ds;
      int rows = ds.Tables[0].Rows.Count;
        
        //设定产生图的类型（pie or bar）
        string type = "";
        if (null == context.Request["type"])
        {
            type = "BAR";
        }
        else
        {
            type = context.Request["type"].ToString().ToUpper();
        }
        //设置图大小
        int width = 0;
        if (null == context.Request["width"])
        {
            width = 820;
        }
        else
        {
            width = Convert.ToInt32(context.Request["width"]);
        }
        int height = 0;
        if (null == context.Request["height"])
        {
            height = 500;
        }
        else
        {
            height = Convert.ToInt32(context.Request["height"]);
        }
        //设置图表标题
        string title = "服务区用户在线满意度调查结果";
        if (null != context.Request["title"])
        {
            title = context.Request["title"].ToString();
        }
        string subTitle = "截止时间"+DateTime.Now;
        if (null != context.Request["subtitle"])
        {
            subTitle = context.Request["subtitle"].ToString();
        }
          string [] qu= {
                "综合评价",
                "公益服务",
                "经营项目收费标准",
                "环境卫生状况",
                "停车场安全管理",
                "规范化管理情况",
                "夜间是否能得到有效服务",
                "治安情况",
                "硬件设施是否能满足实际需要",
                "公厕设施、卫生",
                "超市营业员服务",
                "餐饮服务",
                "客房服务",
                "加油站服务",
                "汽修服务"





            }; 
        if (0 < rows)
        {
            switch (type)
            {
                case "PIE":
                    PieChart pc = new PieChart();
                    pc.Render(title, subTitle, width, height, ds, context.Response.OutputStream);
                    break;
                case "BAR":
                    BarChart bc = new BarChart();
                    bc.Render(title, subTitle, width, height, ds, context.Response.OutputStream,qu);
                    break;
                default:
                    break;
            }
        } 
        //context.Response.OutputStream.Write(buffer, 0, count); 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}