<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountMedia.aspx.cs" Inherits="SmartPoms.Poms.CountMedia" %>
<%@ Register src="Ascx/CountMedia.ascx" tagname="CountMedia" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按媒体统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CountMedia ID="CountMedia1" runat="server" />
</asp:Content>
