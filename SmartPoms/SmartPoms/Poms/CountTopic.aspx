<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountTopic.aspx.cs" Inherits="SmartPoms.Poms.CountTopic" %>
<%@ Register src="Ascx/CountTopic.ascx" tagname="CountTopic" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按专题统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CountTopic ID="CountTopic1" runat="server" />
</asp:Content>
