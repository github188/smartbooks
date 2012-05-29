<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="management_menu" %>

<%@ Import Namespace="RoadEntity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>左侧导航-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function ExchangeItem(itemIndex, itemContIndex) {
            if (document.getElementById(itemContIndex).style.display == "none") {
                document.getElementById(itemIndex).className = "menu_hover";
                document.getElementById(itemContIndex).style.display = "block"
            } else if (document.getElementById(itemContIndex).style.display == "block") {
                document.getElementById(itemIndex).className = "menu_default";
                document.getElementById(itemContIndex).style.display = "none"
            }
        }
        function ExchangeSubItem(itemIndex, subItemCount, subItemIndex) {
            for (var i = 1; i <= subItemCount; i++) {
                if (i == subItemIndex) {
                    document.getElementById(itemIndex + i).className = "subitem_hover";
                } else {
                    document.getElementById(itemIndex + i).className = "subitem_default";
                }
            }
        }
    </script>
</head>
<body class="menu_bg">
    <form id="form1" runat="server">
    <div id="menu_box">
        <%
            UserInfo info = (UserInfo)Session["RoadUser"];
            if (info.U_IsSuper == 1)
            {
        %>
        <div class="menu_default" id="item1" onclick='ExchangeItem("item1","itemcontainer1")'>
            路政单位信息管理</div>
        <div class="menu_container" id="itemcontainer1" style="display: none;">
            <div class="subitem_default" id="item11" onclick='ExchangeSubItem("item1",2,1)'>
                <a href="RoadDepartMgr.aspx" target="mainFrame">路政单位列表</a></div>
            <div class="subitem_default" id="item12" onclick='ExchangeSubItem("item1",2,2)'>
                <a href="AddRoadDepart.aspx" target="mainFrame">添加路政单位</a></div>
        </div>
        <div class="menu_default" id="item2" onclick='ExchangeItem("item2","itemcontainer2")'>
            路政单位用户管理</div>
        <div class="menu_container" id="itemcontainer2" style="display: none;">
            <div class="subitem_default" id="item21" onclick='ExchangeSubItem("item2",2,1)'>
                <a href="UserMgr.aspx" target="mainFrame">用户列表</a></div>
            <div class="subitem_default" id="item22" onclick='ExchangeSubItem("item2",2,2)'>
                <a href="AddUser.aspx" target="mainFrame">添加用户</a></div>
        </div>
        <div class="menu_default" id="item3" onclick='ExchangeItem("item3","itemcontainer3")'>
            系统设置</div>
        <div class="menu_container" id="itemcontainer3" style="display: none;">
            <div class="subitem_default" id="item31" onclick='ExchangeSubItem("item3",3,1)'>
                <a href="EditPwd.aspx" target="mainFrame">修改密码</a></div>
            <div class="subitem_default" id="item32" onclick='ExchangeSubItem("item3",3,2)'>
                <a href="loginout.aspx?action=login" target="_top">退出系统</a></div>
            <div class="subitem_default" id="item33" onclick='ExchangeSubItem("item3",3,3)'>
                <a href="loginout.aspx?action=index" target="_top">网站首页</a></div>
        </div>
        <%
}
           else if (info.U_IsSuper == 0)
           { 
        %>
        <div class="menu_default" id="item4" onclick='ExchangeItem("item4","itemcontainer4")'>
            路政单位信息管理</div>
        <div class="menu_container" id="itemcontainer4" style="display: none;">
            <div class="subitem_default" id="item41" onclick='ExchangeSubItem("item4",1,1)'>
                <a href="EditRoadDepart.aspx" target="mainFrame">编辑信息</a></div>
        </div>
        <div class="menu_default" id="item5" onclick='ExchangeItem("item5","itemcontainer5")'>
            路政动态</div>
        <div class="menu_container" id="itemcontainer5" style="display: none;">
            <div class="subitem_default" id="item51" onclick='ExchangeSubItem("item5",3,1)'>
                <a href="ArticleMgr.aspx?tid=1" target="mainFrame">工作动态</a></div>
            <div class="subitem_default" id="item52" onclick='ExchangeSubItem("item5",3,2)'>
                <a href="ArticleMgr.aspx?tid=2" target="mainFrame">路政法规</a></div>
            <div class="subitem_default" id="item53" onclick='ExchangeSubItem("item5",3,3)'>
                <a href="ArticleMgr.aspx?tid=3" target="mainFrame">单位荣誉</a></div>
            <div class="subitem_default" id="item54" onclick='ExchangeSubItem("item5",3,4)'>
                <a href="ArticleMgr.aspx?tid=4" target="mainFrame">公告公示</a></div>
        </div>
        <div class="menu_default" id="item6" onclick='ExchangeItem("item6","itemcontainer6")'>
            系统设置</div>
        <div class="menu_container" id="itemcontainer6" style="display: none;">
            <div class="subitem_default" id="item61" onclick='ExchangeSubItem("item6",4,1)'>
                <a href="EditPwd.aspx" target="mainFrame">修改密码</a></div>
            <div class="subitem_default" id="item62" onclick='ExchangeSubItem("item6",4,2)'>
                <a href="loginout.aspx?action=login" target="_top">退出系统</a></div>
            <div class="subitem_default" id="item63" onclick='ExchangeSubItem("item6",4,3)'>
                <a href="loginout.aspx?action=index" target="_top">网站首页</a></div>
            <div class="subitem_default" id="item64" onclick='ExchangeSubItem("item6",4,4)'>
                <a href="../DOC/download.rar">操作说明书</a></div>
        </div>
        <%
}
        %>
    </div>
    </form>
</body>
</html>
