<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="SmartTeaching.admin.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航菜单</title>
    <link href="../css/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/admin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
        <img src="../Images/MenuTop.jpg" /><br />
        <img src="../images/menu_topline.gif"/>

        <div class="Menu">文章信息管理</div>
        <div class="MenuNote" style="display: block;">
            <img src="../images/menu_topline.gif" />
            <ul class="MenuUL">
                <li><a href="newsAdd.aspx" target="main">添加文章</a></li>
                <li><a href="newsList.aspx" target="main">文章管理</a></li>
                <li><a href="newsType.aspx" target="main">文章分类管理</a></li>
            </ul>
        </div>

        <div class="Menu">教学资料管理</div>
        <div class="MenuNote" style="display: block;">
            <img src="../images/menu_topline.gif" />
            <ul class="MenuUL">
                <li><a href="docsAdd.aspx" target="main">添加资料</a></li>
                <li><a href="docsList.aspx" target="main">资料管理</a></li>
                <li><a href="docsType.aspx" target="main">资料分类管理</a></li>
            </ul>
        </div>

        <div class="Menu">教学互动管理</div>
        <div class="MenuNote" style="display: block;">
            <img src="../images/menu_topline.gif" />
            <ul class="MenuUL">
                <li><a href="bbsDiscuss.aspx" target="main">交流讨论</a></li>
                <li><a href="bbsFq.aspx" target="main">常见问题</a></li>
            </ul>
        </div>

        <div class="Menu">角色信息管理</div>
        <div class="MenuNote" style="display: block;">
            <img src="../images/menu_topline.gif" />
            <ul class="MenuUL">
                <li><a href="roleAdd.aspx" target="main">添加角色</a></li>
                <li><a href="roleList.aspx" target="main">添加角色</a></li>
            </ul>
        </div>

        <div class="Menu">用户信息管理</div>
        <div class="MenuNote" style="display: block;">
            <img src="../images/menu_topline.gif" />
            <ul class="MenuUL">
                <li><a href="userAdd.aspx" target="main">添加用户</a></li>
                <li><a href="userList.aspx" target="main">用户管理</a></li>
            </ul>
        </div>

    </div>
    </form>
</body>
</html>
