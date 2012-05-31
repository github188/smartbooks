<%@ Page Title="系统管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="SysManager.aspx.cs" Inherits="SmartHyd.ManageCenter.SysManager" %>

<%@ Register Src="Ascx/SysManager.ascx" TagName="SysManager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            $("#ctl00_ContentPlaceHolder1_SysManager1_TxtDate").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SysManager ID="SysManager1" runat="server" />
</asp:Content>
