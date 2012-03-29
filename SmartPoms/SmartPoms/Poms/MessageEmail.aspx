<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="MessageEmail.aspx.cs" Inherits="SmartPoms.Poms.MessageEmail" ValidateRequest="false" %>

<%@ Register Src="Ascx/MessageEmail.ascx" TagName="MessageEmail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>邮件通知--网络舆情监控平台</title>
    <script type="text/javascript" charset="utf-8" src="../Scripts/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../Scripts/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            //加载编辑器
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_MessageEmail1_txtEmailContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                            'subscript', 'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image',
                            'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'map', 'code', 'pagebreak',
                            'link', 'unlink', '|'],
                    width: "100%",
                    height: "350px",
                    resizeMode: 1
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageEmail ID="MessageEmail1" runat="server" />
</asp:Content>