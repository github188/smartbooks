<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminTop.aspx.cs" Inherits="menber_adminTop" Title="页眉--网络舆情监控平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-size:9px;
            color:Black;
        }
        .STYLE1
        {
            font-size: 12px;
            color: #000000;
        }
        .STYLE5
        {
            font-size: 12;
        }
        .STYLE7
        {
            font-size: 12px;
            color: #FFFFFF;
        }
        .jq-page-top-username
        {
            margin:0; padding:0; width:52px; height:17px; display:block; background-image:url('images/user.gif'); background-position:left;
            color:#3B6375; line-height:17px; float:left; margin-left:5px; padding-left:17px; overflow:hidden; font-size:9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="57" background="images/main_03.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="378" height="57" background="images/main_01.gif">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="281" valign="bottom">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="33" height="27">
                                        <img src="images/main_05.gif" width="33" height="27" />
                                    </td>
                                    <td width="248" background="images/main_06.gif">
                                        <table width="225" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="17">
                                                    <div align="right">
                                                        <img src="images/pass.gif" width="69" height="17" />
                                                    </div>
                                                </td>
                                                <td>
                                                    <span class="jq-page-top-username">用户信息</span>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <img src="images/quit.gif" width="69" height="17" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="40" background="images/main_10.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="194" height="40" background="images/main_07.gif">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="21">
                                        <img src="images/main_13.gif" width="19" height="14" />
                                    </td>
                                    <td width="35" class="STYLE7">
                                        <div align="center">
                                            首页</div>
                                    </td>
                                    <td width="21" class="STYLE7">
                                        <img src="images/main_15.gif" width="19" height="14" />
                                    </td>
                                    <td width="35" class="STYLE7">
                                        <div align="center">
                                            后退</div>
                                    </td>
                                    <td width="21" class="STYLE7">
                                        <img src="images/main_17.gif" width="19" height="14" />
                                    </td>
                                    <td width="35" class="STYLE7">
                                        <div align="center">
                                            前进</div>
                                    </td>
                                    <td width="21" class="STYLE7">
                                        <img src="images/main_19.gif" width="19" height="14" />
                                    </td>
                                    <td width="35" class="STYLE7">
                                        <div align="center">
                                            刷新</div>
                                    </td>
                                    <td width="21" class="STYLE7">
                                        <img src="images/main_21.gif" width="19" height="14" />
                                    </td>
                                    <td width="35" class="STYLE7">
                                        <div align="center">
                                            帮助</div>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="248" background="images/main_11.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="16%">
                                        <span class="STYLE5"></span>
                                    </td>
                                    <td width="75%">
                                        <div align="center">
                                            <span class="STYLE7">服务器时间：<%=DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss") %></span></div>
                                    </td>
                                    <td width="9%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="30" background="images/main_31.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="8" height="30">
                            <img src="images/main_28.gif" width="8" height="30" />
                        </td>
                        <td width="147" background="images/main_29.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="24%">
                                        &nbsp;
                                    </td>
                                    <td width="43%" height="20" valign="bottom" class="STYLE1">
                                        管理菜单
                                    </td>
                                    <td width="33%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="39">
                            <img src="images/main_30.gif" width="39" height="30" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="20" valign="bottom">
                                        <span class="STYLE1">当前用户：<%=Session["username"]%></span>
                                    </td>
                                    <td valign="bottom" class="STYLE1">
                                        <div align="right">
                                            <img src="images/sj.gif" width="6" height="7" />
                                            当前IP：<%=Request.UserHostAddress %>&nbsp;&nbsp;
                                            <img src="images/sj.gif" width="6" height="7" />
                                            授权单位:<%=ConfigurationManager.AppSettings["Authorize"]%>&nbsp;&nbsp;
                                            <img src="images/sj.gif" width="6" height="7" />
                                            产品名称:<%=ConfigurationManager.AppSettings["Product"]%>&nbsp;&nbsp;
                                            <img src="images/sj.gif" width="6" height="7" />
                                            发型版本:<%=ConfigurationManager.AppSettings["Version"] %>&nbsp;&nbsp;
                                            <img src="images/sj.gif" width="6" height="7" />
                                            技术支持:<%=ConfigurationManager.AppSettings["Company"] %>&nbsp;&nbsp;
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="17">
                            <img src="images/main_32.gif" width="17" height="30" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>