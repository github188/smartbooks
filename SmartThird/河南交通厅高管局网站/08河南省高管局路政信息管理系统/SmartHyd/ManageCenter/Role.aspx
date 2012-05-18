<%@ Page Language="C#" Title="角色管理" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Role.aspx.cs" Inherits="SmartHyd.ManageCenter.Role" %>

<%@ Register Src="~/ManageCenter/Ascx/Role.ascx" TagName="Role" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Role ID="Role1" runat="server" />
</asp:Content>