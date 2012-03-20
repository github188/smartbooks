<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountComment.aspx.cs" Inherits="SmartPoms.Poms.CountComment" %>
<%@ Register src="Ascx/CountComment.ascx" tagname="CountComment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按评论统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CountComment ID="CountComment1" runat="server" />
</asp:Content>
