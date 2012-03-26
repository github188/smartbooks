<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SmartPoms.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录-网络舆情监测系统</title>
    <link rel="stylesheet" href="css/baseLogin.css" type="text/css" />
    <script type="text/jscript" src="Scripts/jquery-ui-1.8.16/jquery-1.6.2.js" ></script>
    <script type="text/jscript">
        $(document).ready(function() {
            $("#captche").mouseover(function () {
                $(this).attr("src", "Api/VerificationCode.ashx");
            });

            /*居中登录面板*/
            var height = $(document.body).height();
            var width = $(document.body).width();
            //$(".container").css("left", width);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginPanel">
        <div class="container">
            <span>用户名</span>
            <asp:TextBox ID="txtUserName" runat="server" MaxLength="18"></asp:TextBox>
            <span>密&nbsp;&nbsp;&nbsp;码</span>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
            <span>验证码</span>
            <asp:TextBox ID="txtCaptche" runat="server" Width="58" MaxLength="4"></asp:TextBox>
            <img id="captche" src="Api/VerificationCode.ashx" alt="验证码"  />
            <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
            <asp:Button ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" />
            
        </div>
        <span class="version">版本
            <%=ConfigurationManager.AppSettings["Version"].ToString() %>            
       </span>
       <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
    </div>
    <div class="reflection"></div>
    </form>
</body>
</html>
