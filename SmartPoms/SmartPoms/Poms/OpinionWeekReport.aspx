<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OpinionWeekReport.aspx.cs" Inherits="SmartPoms.Poms.OpinionWeekReport" %>
<%@ Register src="Ascx/OpinionWeekReport.ascx" tagname="OpinionWeekReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>舆情周报--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OpinionWeekReport ID="OpinionWeekReport1" runat="server" />
</asp:Content>
