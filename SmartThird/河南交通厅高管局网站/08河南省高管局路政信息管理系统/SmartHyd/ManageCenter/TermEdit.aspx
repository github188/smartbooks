<%@ Page Title="装备编辑" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="TermEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.TermEdit" %>

<%@ Register Src="~/ManageCenter/Ascx/TermEdit.ascx" TagName="TermEdit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:TermEdit ID="TermEdit1" runat="server" />
</asp:Content>
