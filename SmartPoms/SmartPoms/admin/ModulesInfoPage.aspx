<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ModulesInfoPage.aspx.cs" Inherits="SmartPoms.admin.ModulesInfoPage" %>
<%@ Register src="ascx/ModulesInfoPage.ascx" tagname="ModulesInfoPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ModulesInfoPage ID="ModulesInfoPage1" runat="server" />
</asp:Content>
