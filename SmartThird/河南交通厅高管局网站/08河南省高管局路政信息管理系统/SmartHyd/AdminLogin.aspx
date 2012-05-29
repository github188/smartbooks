<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SmartHyd.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理中心 - 河南省高速公路路政管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/basemain.css" />
</head>
<body class="ui-body" scroll="no">
    <!--执法徽标开始-->
    <img class="ui-logobox" src="images/ui-login-logo.png">
    <!--执法徽标结束-->
    <form id="form1" runat="server">
    <!--登录框开始-->
    <div class="ui-loginpanel">
        <!--登录框内容容器开始-->
        <div class="ui-loginpanel-container">
            <div class="ui-loginpanel-containerelement">
                <span>用户名:</span>
                <input class="ui-loginpanel-container-input" type="text" maxlength="18" />
            </div>
            <div class="ui-loginpanel-containerelement">
                <span>密 码:</span>
                <input class="ui-loginpanel-container-input" type="password" maxlength="18" />
            </div>
            <div class="ui-loginpanel-containerelement">
                <span>验证码:</span>
                <input class="ui-loginpanel-container-cache" type="text" maxlength="8" />
                <img class="ui-loginpanel-container-cache-img" src="#">
            </div>
            <div class="ui-loginpanel-container-button-element" width="150">
                <span></span>
                <input class="ui-loginpanel-container-button" type="button" value="登录" />
                <input class="ui-loginpanel-container-button" type="button" value="重置" />
            </div>
        </div>
        <!--登录框内容容器结束-->
    </div>
    <!--登录框结束-->
    </form>
</body>
</html>
<!--[if IE 6]>
<script src="Scripts/DD_belatedPNG_0.0.8a.js" type=text/javascript></script>
<script type=text/javascript>
	DD_belatedPNG.fix('img');
</script>
<![endif]-->
