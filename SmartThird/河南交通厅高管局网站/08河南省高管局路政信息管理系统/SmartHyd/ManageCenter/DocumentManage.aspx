<%@ Page Title="档案管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentManage.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentManage" ValidateRequest="false" %>
<%@ Register src="Ascx/DocumentManage.ascx" tagname="DocumentManage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentManage ID="DocumentManage1" runat="server" />
</asp:Content>
