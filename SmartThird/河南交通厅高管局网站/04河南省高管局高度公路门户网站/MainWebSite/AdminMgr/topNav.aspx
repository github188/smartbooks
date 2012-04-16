<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topNav.aspx.cs" Inherits="AdminMgr_topNav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>河南省交通运输厅高速公路管理局网站后台管理</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body class="topnavbg">
    <form id="form1" runat="server">
    <div class="topnav">
    <div class="left"></div>
    <%
     MainModel.UserInfo info = (MainModel.UserInfo)Session["GsglInfo"];
%>
    <div class="right"><p>欢迎您回来,<%=info.U_Name %>!|<a href="../index.aspx" target="_top">网站首页</a>|<a href="loginout.aspx" target="_top">退出系统</a></p></div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="192px"><div class="toplineimg"></div></td>
    <td style="width: auto;border-left:0px solid #6ab56f;height:11px;background:url(images/nav_bg.gif) 0 -107px repeat-x;" >&nbsp;</td>
  </tr>
</table>

    </form>
</body>
</html>
