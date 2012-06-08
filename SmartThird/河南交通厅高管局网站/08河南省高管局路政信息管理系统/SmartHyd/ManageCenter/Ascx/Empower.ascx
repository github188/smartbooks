<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Empower.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Empower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
<div id="tab">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
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
                        <td>
                            当前授权用户：<asp:Label ID="LabUser" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RadioButton1" runat="server" ValidationGroup="role" 
                                GroupName="role" />
                            系统管理员（拥有系统最高权限）
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RadioButton2" runat="server" ValidationGroup="role" 
                                GroupName="role" />管理员（拥有添加，删除，编辑的权限）
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RadioButton3" runat="server" ValidationGroup="role" 
                                GroupName="role" />普通用户（拥有对下级或子单位收文，发文的权限）
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="RadioButton4" runat="server" ValidationGroup="role" 
                                Checked="True" GroupName="role" />浏览用户（拥有查看权限）
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="BtnEmp" runat="server" Text="授权" CssClass="BigButtonA" OnClick="BtnEmp_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
