<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NegativeReported.aspx.cs" Inherits="SmartPoms.Poms.NegativeReported" %>
<%@ Register src="Ascx/NegativeReported.ascx" tagname="NegativeReported" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>负面报道--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NegativeReported ID="NegativeReported1" runat="server" />
</asp:Content>
