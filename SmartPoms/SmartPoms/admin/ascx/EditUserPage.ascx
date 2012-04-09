<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUserPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.EditUserPage" %>
<asp:Panel ID="TitlePanel" runat="server" GroupingText="用户详细信息" Width="95%">
    <div id="strinfo" runat="server" class="mbox pbox" visible="false">
    </div>
    <table border="0" cellpadding="0" cellspacing="5" class="table">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="用户名称："></asp:Label>
            </td>
            <td style="white-space: nowrap;">
                <asp:TextBox ID="txt_name" runat="server" Style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="所属分组："></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="GroupList" runat="server" Style="width: 200px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="用户角色："></asp:Label>
            </td>
            <td>
                <asp:ListBox ID="RoleList" runat="server" Style="width: 200px;" SelectionMode="Multiple">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="电子邮件："></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_email" runat="server" Style="width: 200px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="账号状态："></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="StateList" runat="server" Style="width: 200px;">
                    <asp:ListItem Value="0">禁止登录</asp:ListItem>
                    <asp:ListItem Value="1">允许登录</asp:ListItem>
                    <asp:ListItem Value="2">锁定</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="注册时间："></asp:Label>
            </td>
            <td>
                <asp:Label ID="Lab_time1" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <br />
                <asp:Button ID="Btn_ok" class="button" runat="server" Text="确认修改" OnClick="Btn_ok_Click" /><asp:Label
                    ID="uid" runat="server" Text="" Style="display: none;"></asp:Label>
                <input id="Button1" type="button" value=" 返 回 " class="button" onclick=" history.go(-1);" />
            </td>
        </tr>
    </table>
</asp:Panel>
