<%@ Page Title="收文管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="ShouWen.aspx.cs" Inherits="SmartHyd.ManageCenter.FilesManage.Shouwen" %>

<%@ Register Src="~/ManageCenter/Ascx/Shouwen.ascx" TagName="Shouwen" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {

            /*发文内容编辑器*/

            var editor;
            KindEditor.ready(function (k) {
                editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_Shouwen1_TxContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "350px"
                });
            });
            /*时间*/
            $("#ctl00_ContentPlaceHolder1_Shouwen1_TxtFromTime").datepicker();
            $("#ctl00_ContentPlaceHolder1_Shouwen1_TxtHandTime").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Shouwen ID="Shouwen1" runat="server" />
</asp:Content>
