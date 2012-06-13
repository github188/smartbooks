﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SmartHyd.ManageCenter.OfficialType.Index" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>公文类别管理</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#navigation a").click(function () {
                $(this).addClass("navselected").siblings("a").removeClass("navselected");
            });
        });
    
    </script>
</head>
<body>
    <table cellspacing="0" cellpadding="0" class="content" width="100%" height="100%">
        <tr>
            <td valign="top" width="120" id="navigation" height="100%">
                <a class="nav" target="main" href="List.aspx">分类管理</a>
                <a class="nav" target="main" href="Create.aspx">新建分类</a>
            </td>
            <td valign="top" height="100%">
                <iframe name="main" id="main" frameborder="0" width="100%" height="100%" src="List.aspx"
                    scrolling="auto"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
