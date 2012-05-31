<%@ Page Title="网络办公" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    CodeBehind="Office.aspx.cs" Inherits="SmartHyd.ManageCenter.Office" %>

<%@ Register Src="Ascx/Office.ascx" TagName="Office" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {

            /*消息框编辑器*/
            var editor;
            KindEditor.ready(function (k) {
                editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_Office1_Message"]', {
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
            $("#ctl00_ContentPlaceHolder1_Office1_TxtDate").datepicker();
        });
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
            document.getElementById('ctl00_ContentPlaceHolder1_Office1_TxtTouser').value = "";
        }
        function btn_submit() {
            var elem = document.getElementsByTagName("input");
            var user = document.getElementById('ctl00_ContentPlaceHolder1_Office1_TxtTouser');

            for (var i = 0; i < elem.length; i++) {

                if (elem[i].type == "checkbox") {
                    if (elem[i].checked == true) {
                        user.value += elem[i].nextSibling.innerText + ","; //-- nextSibling是获得当前对象的下一个对象
                    }
                }
            }
            $("#dialog").dialog("close"); //关闭dialog窗口；
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Office ID="Office1" runat="server" />
</asp:Content>
