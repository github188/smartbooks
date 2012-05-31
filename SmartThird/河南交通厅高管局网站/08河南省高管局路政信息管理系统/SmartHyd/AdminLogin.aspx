<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SmartHyd.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录 - 河南省高速公路路政管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/basemain.css" />
    <script type="text/javascript" src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            /*鼠标经过验证码自动刷新*/
            $('#code').click(function () {
                $(this).attr("src", "ashx/VerificationCode.ashx");
            });
        });
    </script>
</head>
<body class="ui-body" scroll="no">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <!--执法徽标开始-->
    <img class="ui-logobox" src="images/ui-login-logo.png" alt="执法徽标">
    <!--执法徽标结束-->
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <!--登录框开始-->
    <div class="ui-loginpanel">
        <!--登录框内容容器开始-->
        <div class="ui-loginpanel-container">
            <div class="ui-loginpanel-containerelement">
                <span>用户名:</span>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="ui-loginpanel-container-input" MaxLength="18">
                </asp:TextBox>
            </div>
            <div class="ui-loginpanel-containerelement">
                <span>密 码:</span>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="ui-loginpanel-container-input" MaxLength="18"
                    TextMode="Password">
                </asp:TextBox>
            </div>
            <div class="ui-loginpanel-containerelement">
                <span>验证码:</span>
                <asp:TextBox ID="txtCode" runat="server" CssClass="ui-loginpanel-container-cache" MaxLength="4">
                </asp:TextBox>
                <img class="ui-loginpanel-container-cache-img" src="ashx/VerificationCode.ashx" id="code">
            </div>
            <div class="ui-loginpanel-container-button-element" width="150">
                <span></span>
                <asp:Button ID="btnSubmit" runat="server" Text="登录" 
                    CssClass="ui-loginpanel-container-button" 
                    onclick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="重置" 
                    CssClass="ui-loginpanel-container-button" 
                    onclick="btnReset_Click"/>
            </div>
            <div class="ui-loginpanel-container-alert">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
        	</div>
        </div>
        <!--登录框内容容器结束-->
    </div>
    <!--登录框结束-->
    

    </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
<!--[if IE 6]>
<script src="Scripts/DD_belatedPNG_0.0.8a.js" type=text/javascript></script>
<script type=text/javascript>
	DD_belatedPNG.fix('img');
</script>
<![endif]-->
