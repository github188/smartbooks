<%@ Page Title="即时通讯" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Chat.aspx.cs" Inherits="SmartHyd.ManageCenter.Chat" %>

<%@ Register Src="~/ManageCenter/Ascx/Chat.ascx" TagName="Chat" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/jscript" src="../Scripts/Module.js"></script>
<script type="text/jscript">
    $(function () {

        /*消息框编辑器*/

        var editor;
        KindEditor.ready(function (k) {
            editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_Chat1_Message"]', {
                items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                width: "100%",
                height: "350px"
            });
        });
        /*时间*/
        $("#SEND_TIME").datepicker();
    });


    function CheckForm() {
        var textLength = getEditorText('CONTENT').length;
        var htmlLength = getEditorHtml('CONTENT').length;

        if (document.form1.TO_UID.value == "") {
            alert("请添加收信人！");
            return (false);
        }

        if (textLength == 0 && getEditorHtml('CONTENT') == "") {
            alert("内容不能为空！");
            return (false);
        }

        if (textLength > 3000 || htmlLength > 5000) {
            alert("消息文字过长，建议粘贴内容时清除掉word格式或者使用Email发送！");
            return (false);
        }

        var a = CKEDITOR.instances["CONTENT"].document.getElementsByTag("a");
        var count = a.count();
        for (var i = 0; i < count; i++) {
            if (!a.getItem(i).getAttribute("target")) {
                a.getItem(i).setAttribute("target", "_blank");
            }
        }

        return (true);
    }

    function CheckSend(evt) {
        if (evt.data.getKey() == 10 && CheckForm())
            document.form1.submit();
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Chat ID="Chat1" runat="server" />
</asp:Content>
