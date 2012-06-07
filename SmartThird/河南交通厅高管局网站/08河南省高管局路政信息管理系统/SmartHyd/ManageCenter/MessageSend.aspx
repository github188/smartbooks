<%@ Page Title="发送消息" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="MessageSend.aspx.cs" Inherits="SmartHyd.ManageCenter.MessageSend" %>

<%@ Register Src="~/ManageCenter/Ascx/MessageSend.ascx" TagName="MessageSend" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        //选择收信人
        function SelectUser() {
            $(function () {

                var dialog = $("#dialog").dialog({
                    modal: false,
                    title: "收信人列表窗口"
                });

            });

        }
        //清空文本框
        function ClearUser() {
            document.getElementById('ctl00_ContentPlaceHolder1_Chat1_TxtTouser').value = "";
        }
        function btn_submit() {
            var elem = document.getElementsByTagName("input");
            var user = document.getElementById('ctl00_ContentPlaceHolder1_Chat1_TxtTouser');

            for (var i = 0; i < elem.length; i++) {

                if (elem[i].type == "checkbox") {
                    if (elem[i].checked == true) {
                        user.value += elem[i].nextSibling.innerText + ","; //-- nextSibling是获得当前对象的下一个对象
                    }
                }
            }
            $("#dialog").dialog("close"); //关闭dialog窗口；
        }
        function CheckSend(evt) {
            if (evt.data.getKey() == 10 && CheckForm())
                document.form1.submit();
        }
 

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MessageSend ID="MessageSend1" runat="server" />
</asp:Content>

