<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManage" %>
<%@ Register src="Ascx/UserManage.ascx" tagname="UserManage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserManage ID="UserManage1" runat="server" />
</asp:Content>
