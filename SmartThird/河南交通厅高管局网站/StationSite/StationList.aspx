<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StationList.aspx.cs" Inherits="StationList" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省内所有收费站一览表</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .sheader{line-height:40px; border-bottom:1px solid #000; font-size:14px; font-weight:bold;}
       .sheader span{padding-left:10px;}
       ul{ list-style:none;width:100%;}
       li{ list-style:none; width:140px; height:30px; font-size:12px; text-align:left;float:left;text-indent:20px;}
     </style>
</head>
<body style=" background:url(images/bg.gif) repeat; ">
    <form id="form1" runat="server">
    <div style="width:600px; margin:0 auto; ">
    <p style="line-height:40px; font-size:16px; font-weight:bold; text-align:center;">河南省内所有收费站一览表</p>
    
    <%
        DataTable dtCity = DBHelper.GetDataSet("select CI_ID,CI_Name from S_CityInfo");
        if (dtCity != null) {
            for (int i = 0; i < dtCity.Rows.Count; i++)
            {
                string strCI_ID = dtCity.Rows[i]["CI_ID"].ToString();
                string strCI_Name = dtCity.Rows[i]["CI_Name"].ToString();
                %>
                  <div class="sheader"><span><%=strCI_Name %></span></div>
                <%
                DataTable dtStation = DBHelper.GetDataSet("select TS_ID,TS_Name from S_TollStation where TS_City='"+strCI_ID+"'");
                if (dtStation != null&&dtStation.Rows.Count>0) {
                   %>
                     <ul>
                      <%
                          for (int k = 0; k < dtStation.Rows.Count; k++)
                          {
                              string strTS_ID = dtStation.Rows[k]["TS_ID"].ToString();
                              string strTS_Name = dtStation.Rows[k]["TS_Name"].ToString();
                              %>
                              <li><a href="CheckToStation.aspx?stationid=<%=strTS_ID %>"><%=strTS_Name %></a></li>
                              <%
                          }
                       %>
                     </ul>
                   <%
                }
            }
        }
    %>        
        
          
    </div>  
    </form>
</body>
</html>
