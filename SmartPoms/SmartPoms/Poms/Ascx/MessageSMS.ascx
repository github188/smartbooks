<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageSMS.ascx.cs" Inherits="SmartPoms.Poms.Ascx.MessageSMS" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="发送短信" Width="95%">    
    <table>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="手机号码" ></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPhones" runat="server" 
                    TextMode="MultiLine" Width="400" Height="35">
                </asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" 
                    ErrorMessage="RegularExpressionValidator" 
                    ControlToValidate="txtPhones" 
                    ValidationExpression="[0-9,]+">多个手机号码之间用,号隔开
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="短信内容"></asp:Label></td>
            <td><asp:TextBox ID="txtSmsContent" runat="server" TextMode="MultiLine" Width="400" Height="75"></asp:TextBox></td>
            <td><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSend" runat="server" Text="发送" onclick="btnSend_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
