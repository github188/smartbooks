<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RatingDissemination.aspx.cs" Inherits="SmartPoms.Poms.RatingDissemination" %>
<%@ Register src="Ascx/RatingDissemination.ascx" tagname="RatingDissemination" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按传播范围评测--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RatingDissemination ID="RatingDissemination1" runat="server" />
</asp:Content>
