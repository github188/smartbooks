<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="adminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录--网络舆情监控平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow: hidden;
        }
        .STYLE3
        {
            font-size: 12px;
            color: #adc9d9;
        }
        .loginfrombutton
        {
            width: 100px; 
            height: 17px;
            background-color: #87adbf;
            border: solid 1px #153966;
            font-size: 12px;
            color: #283439;
        }
    </style>
    <script src="content/scripts/jquery-1.4.1.js" type="text/javascript"></script>
</head>
<body>
    <form id="formLogin" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td bgcolor="#1075b1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="608" background="images/login_03.gif">
                <table width="847" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="318" background="images/login_04.gif">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="84">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="381" height="84" background="images/login_06.gif">
                                    </td>
                                    <td width="162" valign="middle" background="images/login_07.gif">
                                        <span>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                        </span>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="44" height="24" valign="bottom">
                                                    <div align="right">
                                                        <span class="STYLE3">用户名</span></div>
                                                </td>
                                                <td width="10" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td height="24" colspan="2" valign="bottom">
                                                    <div align="left">
                                                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="18" CssClass="loginfrombutton">
                                                        </asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" valign="bottom">
                                                    <div align="right">
                                                        <span class="STYLE3">密&nbsp;&nbsp;码</span></div>
                                                </td>
                                                <td width="10" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td height="24" colspan="2" valign="bottom">
                                                    <asp:TextBox ID="txtUserPwd" runat="server" MaxLength="18" 
                                                        CssClass="loginfrombutton" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="24" valign="bottom">
                                                    <div align="right">
                                                        <span class="STYLE3">验证码</span></div>
                                                </td>
                                                <td width="10" valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td width="52" height="24" valign="bottom">
                                                    <asp:TextBox ID="txtCaptche" runat="server" MaxLength="4" CssClass="loginfrombutton" Width="50">
                                                    </asp:TextBox>
                                                </td>
                                                <td width="62" valign="bottom">
                                                    <div align="left">
                                                        <img src="images/yzm.gif" width="38" height="15"></div>
                                                </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td width="26">
                                        <img src="images/login_08.gif" width="26" height="84">
                                    </td>
                                    <td width="67" background="images/login_09.gif">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="25">
                                                    <div align="center">
                                                        <asp:ImageButton ID="imgBtnLogin" runat="server" 
                                                            ImageUrl="~/images/dl.gif" width="57" height="20" 
                                                            onclick="imgBtnLogin_Click" ToolTip="登录" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25">
                                                    <div align="center">
                                                        <asp:ImageButton ID="imgBtnReset" runat="server" 
                                                            ImageUrl="~/images/cz.gif" width="57" height="20" 
                                                            onclick="imgBtnReset_Click" ToolTip="重置" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="211" background="images/login_10.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" background="images/login_11.gif">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#152753">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
