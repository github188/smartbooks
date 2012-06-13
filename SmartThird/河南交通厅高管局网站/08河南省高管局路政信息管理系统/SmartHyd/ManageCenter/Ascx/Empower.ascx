<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Empower.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Empower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; font-size:12px;">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="">系统管理&gt;&gt;</a>用户授权</span></div>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <!--6.7用户授权开始-->
                <table border="1" width="100%" class="Table">
                    <tr>
                        <td style="font-size:12px;">
                            当前授权用户：<span style="font-weight:bold;color:#045185;"><asp:Label ID="LabUser" runat="server" Text=""></asp:Label></span>
                            ，该用户可被授予以下权限中的一项
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size:12px;">
                            <asp:RadioButton ID="RadioButton1" runat="server" ValidationGroup="role" 
                                GroupName="role" />
                            系统管理员（拥有系统最高权限）
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size:12px;">
                            <asp:RadioButton ID="RadioButton2" runat="server" ValidationGroup="role" 
                                GroupName="role" />管理员（拥有添加，删除，编辑的权限）
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size:12px;">
                            <asp:RadioButton ID="RadioButton3" runat="server" ValidationGroup="role" 
                                GroupName="role" />普通用户（拥有对下级或子单位收文，发文的权限）
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size:12px;">
                            <asp:RadioButton ID="RadioButton4" runat="server" ValidationGroup="role" 
                                Checked="True" GroupName="role" />浏览用户（拥有查看权限）
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="font-size:12px;">
                            <asp:Button ID="BtnEmp" runat="server" Text="授权"  CssClass="BigButtonA" OnClick="BtnEmp_Click" />
                            &nbsp;
                            <input id="Button2" type="button" value="返回" class="BigButtonA" onclick="javascript:history.go(-1);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
