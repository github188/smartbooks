<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceList.aspx.cs" Inherits="ServiceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省内所有服务区一览表</title>
     <link href="style/service.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
       .sheader{line-height:40px; border-bottom:1px solid #000; font-size:14px; font-weight:bold;}
       .sheader span{padding-left:10px;}
       ul{ list-style:none;width:100%;}
       li{ list-style:none; width:120px; height:30px; font-size:12px; text-align:center;float:left;}
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:600px; margin:0 auto;">
    <p style="line-height:40px; font-size:16px; font-weight:bold; text-align:center;">河南省服务区一览表</p>

    
    <div class="sheader"><span>五星级服务区</span></div>
    <%
        System.Data.DataTable dt_5Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='★★★★★' order by S_QuarterRank asc");
        if (dt_5Star != null) {
            %>
            <ul>
               <%
                   for (int i = 0; i < dt_5Star.Rows.Count; i++)
                   {
                       string S_Name = dt_5Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_5Star.Rows[i]["S_ID"]);
                       %>
                        <li><a href="CheckToService.aspx?serviceid=<%=S_ID %>"><%=S_Name %></a></li>
                       <%
                   }
               %>
            </ul>
            <%
            
        }
    %>
    
    
    
    
     <div class="sheader"><span>四星级服务区</span></div>
    <%
        System.Data.DataTable dt_4Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='★★★★' order by S_QuarterRank asc");
        if (dt_4Star != null) {
            %>
            <ul>
               <%
                   for (int i = 0; i < dt_4Star.Rows.Count; i++)
                   {
                       string S_Name = dt_4Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_4Star.Rows[i]["S_ID"]);
                       %>
                        <li><a href="CheckToService.aspx?serviceid=<%=S_ID %>"><%=S_Name %></a></li>
                       <%
                   }
               %>
            </ul>
            <%
            
        }
    %>
    
    
    
     <div class="sheader"><span>三星级服务区</span></div>
    <%
        System.Data.DataTable dt_3Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='★★★' order by S_QuarterRank asc");
        if (dt_3Star != null) {
            %>
            <ul>
               <%
                   for (int i = 0; i < dt_3Star.Rows.Count; i++)
                   {
                       string S_Name = dt_3Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_3Star.Rows[i]["S_ID"]);
                       %>
                        <li><a href="CheckToService.aspx?serviceid=<%=S_ID %>"><%=S_Name %></a></li>
                       <%
                   }
               %>
            </ul>
            <%
            
        }
    %>
    
    
    
     <div class="sheader"><span>优秀停车区</span></div>
    <%
        System.Data.DataTable dt_TCStar = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='优秀停车区' order by S_QuarterRank asc");
        if (dt_TCStar != null) {
            %>
            <ul>
               <%
                   for (int i = 0; i < dt_TCStar.Rows.Count; i++)
                   {
                       string S_Name = dt_TCStar.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_TCStar.Rows[i]["S_ID"]);
                       %>
                        <li><a href="CheckToService.aspx?serviceid=<%=S_ID %>"><%=S_Name %></a></li>
                       <%
                   }
               %>
            </ul>
            <%
            
        }
    %>
    
    
    
     <div class="sheader"><span>三星级以下服务区</span></div>
    <%
        System.Data.DataTable dt_2Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='★★' or S_Star='★' or S_Star='' or S_Star is null  order by S_QuarterRank asc");
        if (dt_2Star != null) {
            %>
            <ul>
               <%
                   for (int i = 0; i < dt_2Star.Rows.Count; i++)
                   {
                       string S_Name = dt_2Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_2Star.Rows[i]["S_ID"]);
                       %>
                        <li><a href="CheckToService.aspx?serviceid=<%=S_ID %>"><%=S_Name %></a></li>
                       <%
                   }
               %>
            </ul>
            <%
            
        }
    %>
    
     
    
    
    </div>  
    </form>
</body>
</html>
