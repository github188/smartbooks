<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoadDepartList.aspx.cs" Inherits="RoadDepartList" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南省内所有路政单位一览表</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .sheader{height40px; line-height40px; border-bottom:1px solid #000; font-size:14px; font-weight:bold;margin-top:15px;}
       .sheader span{padding-left:10px;}
       ul{ list-style:none;width:100%;}
       li{width:198px; height:30px;line-height:30px; font-size:12px; text-align:left;float:left;text-indent:10px;}
     </style>
</head>
<body style=" background:url(images/bg.gif) repeat;">
    <form id="form1" runat="server">
    <div style="width:600px; margin:0 auto;">
        <p style="font-size:16px; font-weight:bold; text-align:center; height:50px; line-height:50px;">河南省内所有路政单位一览表</p>
        
        
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
                DataTable dtRoad = DBHelper.GetDataSet("select RD_ID,RD_Name from R_RoadDepart where RD_City='"+strCI_ID+"'");
                if (dtRoad != null && dtRoad.Rows.Count > 0)
                {
                   %>
                     <ul>
                      <%
                          for (int k = 0; k < dtRoad.Rows.Count; k++)
                          {
                              string strRD_ID = dtRoad.Rows[k]["RD_ID"].ToString();
                              string strRD_Name = dtRoad.Rows[k]["RD_Name"].ToString();
                              %>
                              <li><a href="CheckToRoad.aspx?roadid=<%=strRD_ID %>"><%=strRD_Name%></a></li>
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
