<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NegativeComments.aspx.cs" Inherits="SmartPoms.Poms.NegativeComments" %>
<%@ Register src="Ascx/NegativeComments.ascx" tagname="NegativeComments" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>负面评论--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NegativeComments ID="NegativeComments1" runat="server" />
</asp:Content>
