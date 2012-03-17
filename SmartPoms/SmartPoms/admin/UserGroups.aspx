<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserGroups.aspx.cs" Inherits="SmartPoms.admin.UserGroups" %>
<%@ Register src="ascx/UserGroups.ascx" tagname="UserGroups" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserGroups ID="UserGroups1" runat="server" />
</asp:Content>
