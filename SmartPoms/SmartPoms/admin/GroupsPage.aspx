<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GroupsPage.aspx.cs" Inherits="SmartPoms.admin.GroupsPage" %>
<%@ Register src="ascx/GroupsPage.ascx" tagname="GroupsPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GroupsPage ID="GroupsPage1" runat="server" />
</asp:Content>
