<%@ Page Title="网络办公" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Office.aspx.cs" Inherits="SmartHyd.ManageCenter.Office" %>


<%@ Register src="Ascx/Office.ascx" tagname="Office" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Office ID="Office1" runat="server" />
</asp:Content>