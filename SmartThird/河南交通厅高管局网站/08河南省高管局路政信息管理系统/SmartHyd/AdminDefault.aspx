<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="SmartHyd.AdminDefault" %>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>管理中心 - 河南省高速公路路政管理系统</title>
        <link rel="stylesheet" type="text/css" href="css/basemain.css" />
	</head>
	<frameset rows="80,*" cols="*" frameborder="no" border="0" framespacing="0">
		<frame src="AdminTop.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
		<frameset rows="*" cols="189,*" framespacing="0" frameborder="no" border="0">
			<frame src="AdminLeft.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
			<%--<frame src="ManageCenter/DocumentManage.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />--%>
            <frame src="main.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
		</frameset>
	</frameset>
	<noframes>
		<body></body>
	</noframes>
</html>
