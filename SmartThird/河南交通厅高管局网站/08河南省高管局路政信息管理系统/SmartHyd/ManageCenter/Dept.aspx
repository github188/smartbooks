<%@ Page Title="部门管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Dept.aspx.cs" Inherits="SmartHyd.ManageCenter.Department" %>

<%@ Register Src="~/ManageCenter/Ascx/Dept.ascx" TagName="Dept" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/jscript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Dept ID="Dept1" runat="server" />
</asp:Content>