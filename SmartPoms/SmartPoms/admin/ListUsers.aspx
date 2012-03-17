<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="SmartPoms.admin.ListUsers" %>
<%@ Register src="ascx/ListUsers.ascx" tagname="ListUsers" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ListUsers ID="ListUsers1" runat="server" />
</asp:Content>
