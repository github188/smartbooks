<%@ Page Language="C#" AutoEventWireup="true" CodeFile="header.aspx.cs" Inherits="management_header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ͷ������-·����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body class="header_bg">
    <form id="form1" runat="server">
    <div id="header">
        <div id="logo"></div>
        <div id="header_nav">
           <div class="left">��ӭ������,<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>��<img src="images/date.jpg" width="18" height="18" align="absmiddle" />��ǰ����:<asp:Label
               ID="lblDate" runat="server" Text="Label"></asp:Label></div>
           <div class="right">
           <img src="images/return.jpg" width="18" height="18" align="absmiddle" /><a href="javascript:history.go(-1);">����</a>
           <img src="images/forward.jpg" width="18" height="18" align="absmiddle"/><a href="javascript:history.go(1);">ǰ��</a>
           <img src="images/Security.jpg" width="18" height="18" align="absmiddle"/><a href="EditPwd.aspx" target="mainFrame" >�޸�����</a>
           <img src="images/exit.jpg" width="18" height="18" align="absmiddle"/><a href="loginout.aspx?action=login" target="_top">�˳�ϵͳ</a>
           <img src="images/globe.jpg" width="18" height="18" align="absmiddle"/><a href="loginout.aspx?action=index" target="_top">��վ��ҳ</a>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
