<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OpinionYearReport.aspx.cs" Inherits="SmartPoms.Poms.OpinionYearReport" %>
<%@ Register src="Ascx/OpinionYearReport.ascx" tagname="OpinionYearReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>舆情年报--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OpinionYearReport ID="OpinionYearReport1" runat="server" />
</asp:Content>
