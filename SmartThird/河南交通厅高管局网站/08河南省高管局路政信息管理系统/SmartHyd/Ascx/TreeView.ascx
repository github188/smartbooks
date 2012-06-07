<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeView.ascx.cs" Inherits="SmartHyd.Ascx.TreeView" %>
<asp:TreeView ID="trvControl" 
    runat="server" 
    OnSelectedNodeChanged="trvControl_SelectedNodeChanged"
    ImageSet="Inbox"    
    CssClass="treeview">
    <HoverNodeStyle Font-Underline="True" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
        NodeSpacing="0px" VerticalPadding="0px" />
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>

<%--ImageUrl="~/Images/notify_open.gif" --%>
