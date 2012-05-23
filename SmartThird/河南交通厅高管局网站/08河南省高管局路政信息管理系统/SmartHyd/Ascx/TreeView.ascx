<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeView.ascx.cs" Inherits="SmartHyd.Ascx.TreeView" %>
<asp:TreeView ID="trvControl" runat="server" OnSelectedNodeChanged="trvControl_SelectedNodeChanged"
    ImageSet="XPFileExplorer" 
    BorderStyle="Solid" BorderWidth="1px" CssClass="treeview" 
    BorderColor="#A6C9E2" NodeIndent="15" Height="500px" Width="250">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px" 
        ImageUrl="~/Images/notify_open.gif" />
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" BackColor="#B5B5B5" />
</asp:TreeView>
