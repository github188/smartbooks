<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminError.aspx.cs" Inherits="SmartPoms.AdminError" %>
<%@ Register src="Ascx/AdminError.ascx" tagname="AdminError" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AdminError ID="AdminError1" runat="server" />
</asp:Content>
