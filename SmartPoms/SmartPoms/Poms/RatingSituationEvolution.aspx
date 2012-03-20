<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RatingSituationEvolution.aspx.cs" Inherits="SmartPoms.Poms.RatingSituationEvolution" %>
<%@ Register src="Ascx/RatingSituationEvolution.ascx" tagname="RatingSituationEvolution" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按事态演变评测--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RatingSituationEvolution ID="RatingSituationEvolution1" runat="server" />
</asp:Content>
