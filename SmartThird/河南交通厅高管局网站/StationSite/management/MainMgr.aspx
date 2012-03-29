<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMgr.aspx.cs" Inherits="management_MainMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <link href="Ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/ecmascript" src="Ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="Ext/ext-all.js"></script>
    <script type="text/javascript">
	Ext.onReady(function(){
	 var toppan=new Ext.Panel({region:'north',height:60,contentEl:'TopFrame'});
	 var leftpan=new Ext.Panel({
			title:'工作面板',
			collapsible:true,
			collapsed:false,
			split:true,
			region:'west',
			width:222,
			minSize:222,
			maxSize:222,
			contentEl:'LeftFrame'
		});
	 var centerpan=new Ext.Panel({
			title:'<div class="divnav" ><img src="images/nav_back.jpg"  align="absmiddle" /> <a href="javascript:history.go(-1)">后退</a> <img src="images/nav_forward.jpg"  align="absmiddle"  /> <a href="javascript:history.go(1)">前进</a> <img src="images/nav_resetPassword.jpg"   align="absmiddle"  /> <a href="loginout.aspx" target="_top">重新登录</a> <img src="images/nav_changePassword.jpg"  align="absmiddle"  /> <a href="EditPwd.aspx" target="MainFrame">修改密码</a> ',
			region:'center',
			bodyStyle:'margin-bottom:0px;',
			contentEl:'MainFrame'
		});
	 var viewport=new Ext.Viewport({
			 layout:"border",
			 items:[toppan,leftpan,centerpan]	   
	   });
	});
</script>
</head>
<body>
    <form id="form1" runat="server">
    <iframe width="100%" height="100%" frameborder="0" scrolling="no" name="TopFrame" id="TopFrame" src="top.aspx" ></iframe>
     <iframe width="100%" height="100%" frameborder="0" scrolling="auto" name="LeftFrame" id="LeftFrame" src="menu.aspx" ></iframe>
     <iframe width="100%" height="100%" frameborder="0" scrolling="auto" name="MainFrame" id="MainFrame" src="default.aspx"></iframe>
    </form>
</body>
</html>
