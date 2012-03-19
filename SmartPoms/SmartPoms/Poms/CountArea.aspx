<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CountArea.aspx.cs" Inherits="SmartPoms.Poms.CountArea" %>
<%@ Register src="Ascx/CountArea.ascx" tagname="CountArea" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>按区域统计--网络舆情监控平台</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:CountArea ID="CountArea1" runat="server" />
    
</asp:Content>
