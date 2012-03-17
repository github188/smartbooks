<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AuthorityPage.aspx.cs" Inherits="SmartPoms.admin.AuthorityPage" %>
<%@ Register src="ascx/AuthorityPage.ascx" tagname="AuthorityPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AuthorityPage ID="AuthorityPage1" runat="server" />
</asp:Content>
