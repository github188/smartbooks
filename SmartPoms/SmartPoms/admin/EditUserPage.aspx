<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditUserPage.aspx.cs" Inherits="SmartPoms.admin.EditUserPage" %>
<%@ Register src="ascx/EditUserPage.ascx" tagname="EditUserPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EditUserPage ID="EditUserPage1" runat="server" />
</asp:Content>
