<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminMgr_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>河南高速服务区网站后台管理系统</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow:hidden;
}
.STYLE3 {font-size: 12px; color: #adc9d9; }
.txtstyle{ border:1px solid #153966; font-size:12px; color:#ffffff; background-color:#87adbf;}
-->
</style></head>

<body>
    <form id="form1" runat="server">
<table width="100%"  height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td bgcolor="#1075b1">&nbsp;</td>
  </tr>
  <tr>
    <td height="608" background="images/login_03.gif"><table width="847" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="318" background="images/login_04.gif">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 84px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="381" height="84" background="images/login_06.gif">&nbsp;</td>
            <td width="162" valign="middle" background="images/login_07.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="44" height="24" valign="bottom"><div align="right"><span class="STYLE3">用户</span></div></td>
                <td width="10" valign="bottom">&nbsp;</td>
                <td height="24" colspan="2" valign="bottom">
                  <div align="left">
                    <asp:TextBox ID="txtName" runat="server" Width="100px" Height="17px" CssClass="txtstyle"></asp:TextBox>
                  </div></td>
              </tr>
              <tr>
                <td height="24" valign="bottom"><div align="right"><span class="STYLE3">密码</span></div></td>
                <td width="10" valign="bottom">&nbsp;</td>
                <td height="24" colspan="2" valign="bottom">
                
                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" Width="100px" Height="17px" CssClass="txtstyle"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="24" valign="bottom"><div align="right"><span class="STYLE3">验证码</span></div></td>
                <td width="10" valign="bottom">&nbsp;</td>
                <td width="52" height="24" valign="bottom">
                <asp:TextBox ID="txtCode" runat="server" CssClass="txtstyle" Width="50px" Height="17px"></asp:TextBox></td>
                <td width="62" valign="bottom"><div align="left"><img id="cheCode" src="../CheckCode.aspx" alt="验证码" align="absmiddle" width="49" height="17px" /></div></td>
              </tr>
              <tr></tr>
            </table>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
            <td width="26"><img src="images/login_08.gif" width="26" height="84"></td>
            <td width="67" background="images/login_09.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="25"><div align="center">
                <asp:ImageButton Width="57" Height="20" ID="imgbtn_login" runat="server" ImageUrl="~/AdminMgr/images/dl.gif" OnClick="imgbtn_login_Click" /></div></td>
              </tr>
              <tr>
                <td height="25"><div align="center">
                <asp:ImageButton Width="57" Height="20" ID="imgbtn_reset" runat="server" ImageUrl="~/AdminMgr/images/cz.gif" OnClick="imgbtn_reset_Click" />
                </div></td>
              </tr>
            </table></td>
            <td width="211" background="images/login_10.gif">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="206" background="images/login_11.gif">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td bgcolor="#152753">&nbsp;</td>
  </tr>
</table>
</form>
</body>
</html>

