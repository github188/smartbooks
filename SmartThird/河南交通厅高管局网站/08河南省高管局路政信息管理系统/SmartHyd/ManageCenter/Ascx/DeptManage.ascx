<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DeptManage" %>
<div id="contents">
    <table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+1">系统管理&gt;&gt;</font></a>
                <a href="../ManageCenter/DeptManage.aspx"><font size="+1">部门管理&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td>
                <div id="deptUrl" runat="server"><span>当前部门：</span>
                </div>
            </td>
            <td>
                <asp:Button ID="Btn_Add" runat="server" Text="新增" CssClass="BigButtonA" OnClick="Btn_Add_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="1">
        <tr>
            <td colspan="2">
                <div id="deptbind" runat="server">
                </div>
            </td>
        </tr>
        <tr >
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table width="100%" border="1" cellspacing="0" cellpadding="0" align="center" id="Table1">
                            <tr>
                                <td>
                                    <h1>
                                    </h1>
                                    <table width="100%" cellspacing="1" align="center" id="dbSingle">
                                        <tr>
                                            <td>
                                                部门名称：
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                                <asp:TextBox ID="depname" CssClass="input" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="depname"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                部门描述：
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDptinfo" CssClass="input" runat="server" Height="55px" TextMode="MultiLine" Width="154px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellspacing="1" align="center" id="btm">
                                        <tr>
                                            <td align="center">
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="BtnDeptAdd" runat="server" Text="添加" CssClass="BigButtonA" OnClick="BtnDeptAdd_Click" />
                                                <asp:Button ID="BtnCancle" runat="server" CausesValidation="False" Text="取消" CssClass="BigButtonA" OnClick="BtnCancle_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</div>
