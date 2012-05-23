<%@ Page Title="档案类别管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentTypeManage.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentTypeManage" %>
<%@ Register src="Ascx/DocumentTypeManage.ascx" tagname="DocumentTypeManage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentTypeManage ID="DocumentTypeManage1" runat="server" />
</asp:Content>
