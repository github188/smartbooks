<%@ Page Title="收文管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentReply.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentReply" %>
<%@ Register src="Ascx/DocumentReply.ascx" tagname="DocumentReply" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentReply ID="DocumentReply1" runat="server" />
</asp:Content>
