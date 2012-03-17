<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConfigPage.aspx.cs" Inherits="SmartPoms.admin.ConfigPage" %>
<%@ Register src="ascx/ConfigPage.ascx" tagname="ConfigPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ConfigPage ID="ConfigPage1" runat="server" />
</asp:Content>
