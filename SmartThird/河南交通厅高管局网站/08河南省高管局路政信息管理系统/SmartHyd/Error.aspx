<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SmartHyd.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误提示 - 河南省高速公路路政管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/base.css" />
    <link rel="stylesheet" type="text/css" href="css/tongdaoa.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css" />
    <script type="text/javascript" src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="Scripts/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tab">
        <ul>
            <li><a href="#tabs-1">提示信息</a></li>
        </ul>
        <div id="tabs-1">
            <div style="width: 100%; float: left;">
                非常抱歉，您访问的页面出现错误了,我们已经记录了该页面的相关信息！<br />
                <h3>详细信息：</h3>
                <asp:TextBox ID="txtErrorMessage" runat="server" CssClass="input" Width="100%">
                </asp:TextBox>
            </div>
            <div style="float:left; width: 100%; margin-bottom:15px;">
                <h3>您的信息：</h3>
                请求地址:<%=Request.UserHostAddress %><br />
                代理信息:<%=Request.UserAgent %>
                <h3>尝试操作：</h3>
                ◆重新刷新该页面。<br />
                ◆点击“返回”按钮，返回上一页。<br />
                ◆退出系统登录，然后重新登录系统。<br />
                <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" CssClass="BigButtonA" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
