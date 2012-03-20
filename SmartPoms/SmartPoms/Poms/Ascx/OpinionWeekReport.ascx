<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpinionWeekReport.ascx.cs" Inherits="SmartPoms.Poms.Ascx.OpinionWeekReport" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="查看舆情周报" Width="95%" Height="95%">
    <asp:Panel ID="Panel2" runat="server" Width="600">
        <asp:Label ID="Label1" runat="server" Text="请选择年份："></asp:Label>
        <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlYears_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Label ID="Label2" runat="server" Text="请选择周："></asp:Label>
        <asp:DropDownList ID="ddlWeeks" runat="server">
        </asp:DropDownList>

        <asp:Button ID="btnDownload" runat="server" Text="下载" 
            onclick="btnDownload_Click" />
    </asp:Panel>    
</asp:Panel>