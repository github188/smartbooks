<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OverView.aspx.cs" Inherits="management_OverView" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
    <link href="../style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <%
    int nid = Convert.ToInt32(Request.QueryString["nid"]);
    DataTable dt = NewsInfoService.Get_NewsView(nid);
    string strTitle = dt.Rows[0]["N_Title"].ToString();
    string strType = dt.Rows[0]["T_Name"].ToString();
    string strFrom = dt.Rows[0]["N_From"].ToString();
    string strDate = PubClass.Tool.Get_ShortDate(dt.Rows[0]["N_Date"].ToString());
    string strContent = dt.Rows[0]["N_Content"].ToString();
    if (strContent.IndexOf("<$$>") > 0) {
        strContent = strContent.Substring(strContent.IndexOf("<$$>")+4);
    }
   %>
    
    <!--main begin-->
	<div id="mainbody">
        <div class="pages">
        		<h1><%=strTitle%></h1>
                <p class="page_date">文章来源：<%=strFrom %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布日期：<%=strDate %> </p>
                <div class="page_con">
                	<%=strContent %>
                	<%
                        if (dt.Rows[0]["N_ImgPath"].ToString().Trim().Length > 0) { 
                     %>
                       <div style=" margin:5px auto; text-align:center;">
                         <img  src="../NewsImg/<%=dt.Rows[0]["N_ImgPath"].ToString() %>"/>
                       </div>
                     <%
                        }
                	%>
                   
                </div>
        </div>    
    </div>
    <!--main end-->
    
    
    </form>
</body>
</html>
