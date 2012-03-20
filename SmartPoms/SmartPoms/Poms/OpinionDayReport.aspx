<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OpinionDayReport.aspx.cs" Inherits="SmartPoms.Poms.OpinionDayReport" %>
<%@ Register src="Ascx/OpinionDayReport.ascx" tagname="OpinionDayReport" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>舆情日报--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OpinionDayReport ID="OpinionDayReport1" runat="server" />
</asp:Content>
