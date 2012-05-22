<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeView.ascx.cs" Inherits="SmartHyd.Ascx.TreeView" %>
<asp:TreeView ID="trvControl" runat="server" OnSelectedNodeChanged="trvControl_SelectedNodeChanged"
    ImageSet="XPFileExplorer" NodeIndent="15" BorderColor="#A6C9E2" 
    BorderStyle="Solid" BorderWidth="1px">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px" />
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>
