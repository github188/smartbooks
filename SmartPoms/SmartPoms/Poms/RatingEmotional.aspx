<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RatingEmotional.aspx.cs" Inherits="SmartPoms.Poms.RatingEmotional" %>
<%@ Register src="Ascx/RatingEmotional.ascx" tagname="RatingEmotional" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按情感色彩评测--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RatingEmotional ID="RatingEmotional1" runat="server" />
</asp:Content>
