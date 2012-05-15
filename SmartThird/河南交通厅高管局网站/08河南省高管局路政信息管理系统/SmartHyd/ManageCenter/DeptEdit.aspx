<%@ Page Title="编辑部门信息" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="DeptEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.DeptEdit" %>
<%@ Register Src="~/ManageCenter/Ascx/DeptEdit.ascx" TagName="DeptEdit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:DeptEdit ID="DeptEdit1" runat="server" />
</asp:Content>
