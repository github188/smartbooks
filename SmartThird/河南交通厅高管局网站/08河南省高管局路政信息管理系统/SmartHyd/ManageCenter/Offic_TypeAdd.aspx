<%@ Page Title="公文类型管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    CodeBehind="Offic_TypeAdd.aspx.cs" Inherits="SmartHyd.ManageCenter.Offic_Type" %>

<%@ Register Src="~/ManageCenter/Ascx/Offic_TypeAdd.ascx" TagName="OfficType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        function mysubmit() {
            if ($("*[id$=TxtTypeName]").val() == "") {
                alert("公文类型名称不能为空！");
                $("*[id$=TxtTypeName]")._focus();
                return false;
            }
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OfficType ID="Offic_Type1" runat="server" />
</asp:Content>
