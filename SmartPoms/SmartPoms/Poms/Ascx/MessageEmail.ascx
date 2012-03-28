<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageEmail.ascx.cs" Inherits="SmartPoms.Poms.Ascx.MessageEmail" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="发送邮件">
    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="接收地址" ></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmailAddress" runat="server" 
                    TextMode="MultiLine" Width="400" Height="35">
                </asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" 
                    ErrorMessage="RegularExpressionValidator" 
                    ControlToValidate="txtEmailAddress" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">请输入正确的Email地址
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="邮件内容"></asp:Label></td>
            <td><asp:TextBox ID="txtEmailContent" runat="server" TextMode="MultiLine" Width="400" Height="75"></asp:TextBox></td>
            <td><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSend" runat="server" Text="发送" onclick="btnSend_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>