<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RolesPage.aspx.cs" Inherits="SmartPoms.admin.RolesPage" %>
<%@ Register src="ascx/RolesPage.ascx" tagname="RolesPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RolesPage ID="RolesPage1" runat="server" />
</asp:Content>
