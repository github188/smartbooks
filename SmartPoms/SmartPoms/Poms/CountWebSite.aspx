<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountWebSite.aspx.cs" Inherits="SmartPoms.Poms.CountWebSite" %>
<%@ Register src="Ascx/CountWebSite.ascx" tagname="CountWebSite" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按网站统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CountWebSite ID="CountWebSite1" runat="server" />
</asp:Content>
