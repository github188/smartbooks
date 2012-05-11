<%@ Page Title="日程管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="SmartHyd.ManageCenter.Plan" %>

<%@ Register Src="~/ManageCenter/Ascx/Plan.ascx" TagName="Plan" TagPrefix="uc1" %>
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
    <uc1:Plan ID="Plan1" runat="server" />
</asp:Content>
