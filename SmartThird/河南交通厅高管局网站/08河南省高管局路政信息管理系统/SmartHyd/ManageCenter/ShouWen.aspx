<%@ Page Title="收文管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="ShouWen.aspx.cs" Inherits="SmartHyd.ManageCenter.FilesManage.Shouwen" %>
<%@ Register src="~/ManageCenter/Ascx/Shouwen.ascx" tagname="Shouwen" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Shouwen ID="Shouwen1" runat="server" />
</asp:Content>
