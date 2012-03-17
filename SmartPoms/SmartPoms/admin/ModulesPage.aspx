<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ModulesPage.aspx.cs" Inherits="SmartPoms.admin.ModulesPage" %>
<%@ Register src="ascx/ModulesPage.ascx" tagname="ModulesPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ModulesPage ID="ModulesPage1" runat="server" />
</asp:Content>
