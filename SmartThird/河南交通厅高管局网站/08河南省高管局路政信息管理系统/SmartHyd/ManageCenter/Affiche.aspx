﻿<%@ Page Title="公告管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Affiche.aspx.cs" Inherits="SmartHyd.ManageCenter.Affiche" %>
<%@ Register Src="~/ManageCenter/Ascx/Affiche.ascx" TagName="Affiche" TagPrefix="uc1" %>
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
    

        function open_notify(NOTIFY_ID, FORMAT) {
            URL = "../show/read_notify.php?IS_MANAGE=1&NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 780) / 2;
            mytop = 100
            mywidth = 780;
            myheight = 500;
            if (FORMAT == "1") {
                myleft = 0;
                mytop = 0
                mywidth = screen.availWidth - 15;
                myheight = screen.availHeight - 60;
            }
            window.open(URL, "read_news", "height=" + myheight + ",width=" + mywidth + ",status=1,toolbar=no,menubar=no,location=no,scrollbars=yes,top=" + mytop + ",left=" + myleft + ",resizable=yes");
        }

        function open_urladdress(NOTIFY_ID) {
            URL = "../show/url_address.php?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 780) / 2;
            window.open(URL, "read_notify", "height=500,width=780,status=1,toolbar=no,menubar=no,location=no,scrollbars=yes,top=100,left=" + myleft + ",resizable=yes");
        }

        function show_reader(NOTIFY_ID) {
            URL = "show_reader.php?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 500) / 2;
            window.open(URL, "read_notify", "height=500,width=700,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=150,left=" + myleft + ",resizable=yes");
        }

        function show_toobject(NOTIFY_ID) {
            URL = "show_object.php?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 500) / 2;
            window.open(URL, "read_notify", "height=250,width=600,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=150,left=" + myleft + ",resizable=yes");
        }
        function delete_notify(notify_id) {
            msg = '删除后将不可恢复，确认要删除该条公告吗？';
            if (window.confirm(msg))
                window.location = "delete.php?DELETE_STR=" + notify_id + "&start=0";
        }
        function delete_all() {
            msg = '确认要删除所有公告通知吗？\n删除后将不可恢复，确认删除请输入大写字母“OK”';
            if (window.prompt(msg, "") == "OK") {
                URL = "delete_all.php";
                window.location = URL;
            }
        }

        function order_by(field, asc_desc) {
            window.location = "index1.php?start=0&TYPE=0&FIELD=" + field + "&ASC_DESC=" + asc_desc;
        }

        function change_type(type) {
            window.location = "index1.php?start=0&TYPE=" + type + "&FIELD=&ASC_DESC=";
        }
        function check_all() {
            for (i = 0; i < document.all("email_select").length; i++) {
                if (document.all("allbox").checked)
                    document.all("email_select").item(i).checked = true;
                else
                    document.all("email_select").item(i).checked = false;
            }

            if (i == 0) {
                if (document.all("allbox").checked)
                    document.all("email_select").checked = true;
                else
                    document.all("email_select").checked = false;
            }
        }

        function check_one(el) {
            if (!el.checked)
                document.all("allbox").checked = false;
        }
        function delete_mail() {
            delete_str = "";
            for (i = 0; i < document.all("email_select").length; i++) {

                el = document.all("email_select").item(i);
                if (el.checked) {
                    val = el.value;
                    delete_str += val + ",";
                }
            }

            if (i == 0) {
                el = document.all("email_select");
                if (el.checked) {
                    val = el.value;
                    delete_str += val + ",";
                }
            }

            if (delete_str == "") {
                alert("要删除公告通知，请至少选择其中一条。");
                return;
            }

            msg = '确认要删除所选公告通知吗？';
            if (window.confirm(msg)) {
                url = "delete.php?DELETE_STR=" + delete_str + "&start=0";
                location = url;
            }
        }

        function cancel_top(flag) {
            delete_str = "";
            for (i = 0; i < document.all("email_select").length; i++) {

                el = document.all("email_select").item(i);
                if (el.checked) {
                    val = el.value;
                    delete_str += val + ",";
                }
            }

            if (i == 0) {
                el = document.all("email_select");
                if (el.checked) {
                    val = el.value;
                    delete_str += val + ",";
                }
            }

            if (delete_str == "") {
                if (flag == 0)
                    alert("要取消公告通知置顶，请至少选择其中一条。");
                else
                    alert("要设置公告通知置顶，请至少选择其中一条。");
                return;
            }
            if (flag == 0)
                msg = '确认要取消所选公告通知的置顶吗？';
            else
                msg = '确认要将所选的公告通知设置为置顶吗？';
            if (window.confirm(msg)) {
                if (flag == 0)
                    url = "notop.php?DELETE_STR=" + delete_str + "&start=0";
                else
                    url = "settop.php?DELETE_STR=" + delete_str + "&start=0";
                location = url;
            }
        }

        function my_affair(NOTIFY_ID) {
            myleft = (screen.availWidth - 250) / 2;
            mytop = (screen.availHeight - 200) / 2;
            URL = "note.php?NOTIFY_ID=" + NOTIFY_ID;
            window.open(URL, "", "height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=auto,resizable=no,top=" + mytop + ",left=" + myleft);
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Affiche ID="Affiche1" runat="server" />
</asp:Content>
