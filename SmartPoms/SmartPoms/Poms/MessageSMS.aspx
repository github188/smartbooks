<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MessageSMS.aspx.cs" Inherits="SmartPoms.Poms.MessageSMS" %>
<%@ Register src="Ascx/MessageSMS.ascx" tagname="MessageSMS" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>短信通知--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageSMS ID="MessageSMS1" runat="server" />
</asp:Content>
