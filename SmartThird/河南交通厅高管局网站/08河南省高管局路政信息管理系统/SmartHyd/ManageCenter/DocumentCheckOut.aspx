<%@ Page Title="公文结贴" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentCheckOut.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentCheckOut" %>
<%@ Register src="Ascx/DocumentCheckOut.ascx" tagname="DocumentCheckOut" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentCheckOut ID="DocumentCheckOut1" runat="server" />
</asp:Content>
