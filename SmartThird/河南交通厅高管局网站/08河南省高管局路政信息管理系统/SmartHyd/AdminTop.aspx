<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTop.aspx.cs" Inherits="SmartHyd.AdminTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航头部 - 河南省高速公路路政管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/basemain.css" />
    <style type="text/css">
        body{ background-color:#065c8f;}
    </style>
</head>
<body >
 <div class="ui-hander-content">
		<!--Logo开始-->
		<%--<img alt="系统图标" src="#" class="ui-hander-logo" />--%>
        <div class="ui-hander-logo"></div>
		<!--Logo结束-->

		<!--用户信息开始-->
		<div class="ui-hander-userinfo">
			<span>张三  &lt; 安阳市路政处一大队 &gt;</span><br />
			<a href="#">系统首页</a><span> | </span>
			<a href="#">设置 </a><span> - </span>
			<a href="#">注销</a>
		</div>
		<!--用户信息结束-->
		
		<!--反馈信息开始-->
		<div class="ui-hander-feedback">
			<a>反馈建议</a> | 
			<a>帮助中心</a> | 
			<a>退出</a>
		</div>
		<!--反馈信息结束-->
		
		<!--文本搜索框开始-->
		<input type="text" class="ui-hander-searchbox" value="全文搜索..." />	
		<!--文本搜索框结束-->

        <form id="form1" runat="server"></form>
    </div>
	</body>
</html>
