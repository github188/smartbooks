<%@ Page Title="涉路工程" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="RoadProject.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadProject" %>

<%@ Register Src="~/ManageCenter/Ascx/RoadProject.ascx" TagName="RoadProject" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {

            /*编辑器*/
            var editor;
            KindEditor.ready(function (k) {
                //申请许可事项及内容  编辑器
                editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_RoadProject1_txtContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "300px"
                });
                //申请材料目录 编辑器
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_RoadProject1_TxtMATERIALS"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "100px"
                });
              
            });
            /*时间*/
            $("#ctl00_ContentPlaceHolder1_RoadProject1_TxtTime").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:RoadProject ID="RoadProject1" runat="server" />
</asp:Content>