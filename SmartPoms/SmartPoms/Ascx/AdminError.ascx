<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminError.ascx.cs" Inherits="SmartPoms.Ascx.AdminError" %>

<asp:Panel ID="panelError" runat="server">
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label><br />
    <asp:Button ID="btnGoHome" runat="server" Text="返回" onclick="btnGoHome_Click" />
</asp:Panel>


