<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="menber_adminLogin" Title="用户登录--网络舆情监控平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        &nbsp;
                                    </td>
                                    <td width="162" valign="middle" background="images/login_07.gif">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="44" height="24" valign="bottom">
                                                    <div align="right">
                                                        <span class="STYLE3">用户</span></div>
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
                                                        <span class="STYLE3">密码</span></div>
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
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>