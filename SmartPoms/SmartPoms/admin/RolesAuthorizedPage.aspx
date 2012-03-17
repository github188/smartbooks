<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RolesAuthorizedPage.aspx.cs" Inherits="SmartPoms.admin.RolesAuthorizedPage" %>
<%@ Register src="ascx/RolesAuthorizedPage.ascx" tagname="RolesAuthorizedPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RolesAuthorizedPage ID="RolesAuthorizedPage1" runat="server" />
</asp:Content>
