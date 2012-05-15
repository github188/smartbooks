<%@ Page Title="日志管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="SysLog.aspx.cs" Inherits="SmartHyd.ManageCenter.SysLog" %>

<%@ Register Src="~/ManageCenter/Ascx/SysLog.ascx" TagName="SysLog" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SysLog ID="SysLog1" runat="server" />
</asp:Content>
