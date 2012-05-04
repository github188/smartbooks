<%@ Page Title="人工巡逻" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="Patrol.aspx.cs" Inherits="SmartHyd.ManageCenter.Patrol"%>

<%@ Register src="Ascx/Patrol.ascx" tagname="Patrol" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Patrol ID="Patrol1" runat="server" />
</asp:Content>
