<%@ Page Title="菜单管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="SmartHyd.ManageCenter.MenuManage" %>
<%@ Register src="Ascx/MenuManage.ascx" tagname="MenuManage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MenuManage ID="MenuManage1" runat="server" />
</asp:Content>
