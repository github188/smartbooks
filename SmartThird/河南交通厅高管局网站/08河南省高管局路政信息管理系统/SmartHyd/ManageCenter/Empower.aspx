<%@ Page Title="用户授权" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Empower.aspx.cs" Inherits="SmartHyd.ManageCenter.Empower" %>

<%@ Register Src="~/ManageCenter/Ascx/Empower.ascx" TagName="Empower" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Empower ID="Empower1" runat="server" />
</asp:Content>
