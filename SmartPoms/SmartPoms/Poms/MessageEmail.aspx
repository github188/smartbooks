<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MessageEmail.aspx.cs" Inherits="SmartPoms.Poms.MessageEmail" %>
<%@ Register src="Ascx/MessageEmail.ascx" tagname="MessageEmail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>邮件通知--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageEmail ID="MessageEmail1" runat="server" />
</asp:Content>
