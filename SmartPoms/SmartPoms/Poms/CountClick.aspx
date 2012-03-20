<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountClick.aspx.cs" Inherits="SmartPoms.Poms.CountClick" %>
<%@ Register src="Ascx/CountClick.ascx" tagname="CountClick" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按点击统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CountClick ID="CountClick1" runat="server" />
</asp:Content>
