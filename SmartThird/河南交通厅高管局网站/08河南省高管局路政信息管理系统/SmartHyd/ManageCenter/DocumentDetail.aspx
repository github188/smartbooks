<%@ Page Title="公文详情" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentDetail.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentDetail" %>
<%@ Register src="Ascx/DocumentDetail.ascx" tagname="DocumentDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentDetail ID="DocumentDetail1" runat="server" />
</asp:Content>
