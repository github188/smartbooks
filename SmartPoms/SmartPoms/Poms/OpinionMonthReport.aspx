<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OpinionMonthReport.aspx.cs" Inherits="SmartPoms.Poms.OpinionMonthReport" %>
<%@ Register src="Ascx/OpinionMonthReport.ascx" tagname="OpinionMonthReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>舆情月报--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OpinionMonthReport ID="OpinionMonthReport1" runat="server" />
</asp:Content>
