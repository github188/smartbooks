<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserGrant.aspx.cs" Inherits="SmartPoms.admin.UserGrant" %>
<%@ Register src="ascx/UserGrant.ascx" tagname="UserGrant" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserGrant ID="UserGrant1" runat="server" />
</asp:Content>
