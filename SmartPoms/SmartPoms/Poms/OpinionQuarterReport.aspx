<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OpinionQuarterReport.aspx.cs" Inherits="SmartPoms.Poms.OpinionQuarterReport" %>
<%@ Register src="Ascx/OpinionQuarterReport.ascx" tagname="OpinionQuarterReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>舆情季报--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OpinionQuarterReport ID="OpinionQuarterReport1" runat="server" />
</asp:Content>
