<%@ Page Title="路产设备" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="RoadTerm.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm" %>
<%@ Register src="Ascx/RoadTerm.ascx" tagname="RoadTerm" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RoadTerm ID="RoadTerm1" runat="server" />
</asp:Content>