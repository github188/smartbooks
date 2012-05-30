<%@ Page Title="系统管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="SysManager.aspx.cs" Inherits="SmartHyd.ManageCenter.SysManager" %>
<%@ Register src="Ascx/SysManager.ascx" tagname="SysManager" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SysManager ID="SysManager1" runat="server" />
</asp:Content>
