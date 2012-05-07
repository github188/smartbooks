<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="SmartTeaching.admin.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航菜单</title>
    <link href="../css/Manage.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css"
        rel="stylesheet" type="text/css" />
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/admin.js"></script>
</head>
<body style="width: 100%; padding:0px; margin:0px;">
    <form id="form1" runat="server">
    <img src="../Images/MenuTop.jpg" width="100%" />
    <img src="../images/menu_topline.gif" width="100%"/>

    <div id="navmenu">
        <h3>
            <a>文章信息管理</a></h3>
        <div>
            <a href="newsAdd.aspx" target="main" runat="server" id="addnews">添加文章</a> 
            <a href="newsList.aspx" target="main" runat="server" id="newsmgr">文章管理</a>
            <a href="docsType.aspx" target="main" runat="server" id="newstype">文章分类管理</a>
        </div>
        <h3>
            <a>教学互动管理</a></h3>
        <div>
            <a href="bbsDiscuss.aspx" target="main" runat="server" id="msg">我的消息</a>
        </div>
        <h3>
            <a>角色信息管理</a></h3>
        <div>
            <a href="roleAdd.aspx" target="main" runat="server" id="rolemgr">添加角色</a> 
            <a href="roleList.aspx" target="main" runat="server" id="addrole">角色管理</a>
        </div>
        <h3>
            <a>用户信息管理</a></h3>
        <div>
            <a href="userAdd.aspx" target="main" runat="server" id="adduser">添加用户</a> 
            <a href="userList.aspx" target="main" runat="server" id="usermgr">用户管理</a>
        </div>
    </div>
    </form>
</body>
</html>
