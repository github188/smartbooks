<%@ Page Title="装备管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="Term.aspx.cs" Inherits="SmartHyd.ManageCenter.Term" %>
<%@ Register src="Ascx/Term.ascx" tagname="Term" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            /*日期控件*/
            $('#ctl00_ContentPlaceHolder1_Term1_txtUSETIME').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Term ID="Term1" runat="server" />
</asp:Content>
