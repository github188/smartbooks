<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="report_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>述职述廉述学报告用户登录</title>
    <style type="text/css">
	body{ font-size:12px;}
	.btns{ background-image:url(images/shuzhi_btn.jpg); background-repeat:no-repeat; border:none; padding:0; margin:0; width:61px; height:24px; padding-top:3px;}
	.bor{ border:1px #09C solid;}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <div style="background:url(images/shuzhi_b.jpg) no-repeat; height:182px; width:400px; margin:0 auto; margin-top:200px; overflow:hidden;">
        <p style=" width:240px; margin:0 auto; margin-top:70px;">用户名：<asp:TextBox ID="txtName" runat="server" CssClass="bor" Height="15px" Width="145px"></asp:TextBox></p>
        <p style=" width:240px; margin:0 auto; margin-top:10px;">密&nbsp;&nbsp; &nbsp;码：<asp:TextBox ID="txtPwd" runat="server" CssClass="bor" TextMode="Password" Width="145px" Height="15px"></asp:TextBox></p>
        <p style=" width:160px; margin:0 auto; margin-top:20px;">
            <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="btns" OnClick="btnLogin_Click" />&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="btns" OnClick="btnReset_Click" />
            </p>
         <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
    </form>
</body>
</html>
