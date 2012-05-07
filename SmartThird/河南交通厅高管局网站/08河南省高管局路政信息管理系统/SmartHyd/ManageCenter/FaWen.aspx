<%@ Page Title="发文管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="FaWen.aspx.cs" Inherits="SmartHyd.ManageCenter.FilesManage.FaWen" %>
<%@ Register src="~/ManageCenter/Ascx/FaWen.ascx" tagname="FaWen" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/jscript">
    $(function () {
        alert('hi');
        var editor;
        kindeditor.ready(function (k) {
            editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_FaWen1_TxContent"]', {
                items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                width: "100%",
                height: "350px"
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FaWen ID="FaWen1" runat="server" />
</asp:Content>
