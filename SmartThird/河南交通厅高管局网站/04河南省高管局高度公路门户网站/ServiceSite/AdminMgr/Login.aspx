<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminMgr_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区管理系统后台登陆</title>
    <style type="text/css">
    body{ font-size:12px; border-width:0px; margin:0px; padding:0px}
    .InputBorderStyle{ border:1px solid #B8C9D6; height:16px;}
	.tdBg{ background-image:url(images/login.jpg); background-repeat:no-repeat;}
	.leftTdBg{ background-image:url(images/login04.jpg); background-repeat:repeat-x}
	.rightTdBg{ background-image:url(images/login02.jpg); background-repeat:repeat-x}
	.inputBorder{ border:1px solid #999999}
	.btnBg{ background-image:url(images/login.gif); width:95px; height:34px; border-width:0px; margin:0px; padding:0px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
      <table width="100%" height="613" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="180" >&nbsp;</td>
          <td width="1003" height="613" rowspan="3" class="tdBg">
		  
		  
              
		  
		  
		  <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
		  <table width="1003" border="0" cellpadding="0" cellspacing="0" >
              <tr>
                <td width="44%" height="40">&nbsp;</td>
                <td width="56%">&nbsp;<asp:TextBox ID="txtName" runat="server" CssClass="InputBorderStyle" Width="155px"></asp:TextBox></td>
              </tr>
              <tr>
                <td height="40">&nbsp;</td>
                <td>&nbsp;<asp:TextBox ID="txtPwd" runat="server" CssClass="InputBorderStyle" Width="155px" TextMode="Password"></asp:TextBox></td>
              </tr>
              <tr>
                <td height="40">&nbsp;</td>
                <td>&nbsp;<asp:TextBox ID="txtCode" runat="server" CssClass="InputBorderStyle" Width="100px"></asp:TextBox>&nbsp;<img id="cheCode" src="../CheckCode.aspx" alt="验证码" align="absmiddle" /></td>
              </tr>
              <tr>
                <td height="40">&nbsp;<asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                <td>&nbsp;<asp:Button ID="btnLogin" runat="server" CssClass="btnBg" OnClick="btnLogin_Click" /></td>
              </tr>
            </table>
			
			
			</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td height="190" class="leftTdBg">&nbsp;</td>
          <td  class="rightTdBg">&nbsp;</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table>
    </form>
</body>
</html>
