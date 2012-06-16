<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Affiche.aspx.cs" Inherits="SmartHyd.ManageCenter.Affiche.Affiche" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>电子公告</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
    <script type="text/jscript">
        $(function () {

            /*公告内容编辑器*/

            var editor;
            KindEditor.ready(function (k) {
                editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_Affiche1_TxtContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "350px"
                });
            });
            /*时间*/
            $("#ctl00_ContentPlaceHolder1_Affiche1_TxtTime").datepicker();
        });


        //按人员发布显示/隐藏
        function changeRange() {
            if (document.getElementById("rang_role").style.display == "none") {
                document.getElementById("rang_role").style.display = "";
                document.getElementById("rang_user").style.display = "";
                document.getElementById("href_txt").innerText = "隐藏按人员或角色发布";
            }
            else {
                document.getElementById("rang_role").style.display = "none";
                document.getElementById("rang_user").style.display = "none";
                document.getElementById("href_txt").innerText = "按人员或角色发布";
            }
        }
        //按钮点击：添加（按部门）
        function SelectDept() {
            $(function () {
                var dialog = $("#dialog").dialog({
                    modal: true,
                    title: "部门选项窗口"
                });

            });

        }

        function open_notify(NOTIFY_ID, FORMAT) {
            URL = "../show/read_notify.aspx?IS_MANAGE=1&NOTIFY_ID=" + NOTIFY_ID;
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
            URL = "../show/url_address.aspx?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 780) / 2;
            window.open(URL, "read_notify", "height=500,width=780,status=1,toolbar=no,menubar=no,location=no,scrollbars=yes,top=100,left=" + myleft + ",resizable=yes");
        }

        function show_reader(NOTIFY_ID) {
            URL = "show_reader.aspx?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 500) / 2;
            window.open(URL, "read_notify", "height=500,width=700,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=150,left=" + myleft + ",resizable=yes");
        }

        function show_toobject(NOTIFY_ID) {
            URL = "show_object.aspx?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 500) / 2;
            window.open(URL, "read_notify", "height=250,width=600,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=150,left=" + myleft + ",resizable=yes");
        }
        //删除公告
        //        function delete_notify(notify_id) {
        //            msg = '删除后将不可恢复，确认要删除该条公告吗？';
        //            if (window.confirm(msg))
        //            window.location = "Affiche.aspx";
        //        }
        function delete_all() {
            msg = '确认要删除所有公告通知吗？\n删除后将不可恢复，确认删除请输入大写字母“OK”';
            if (window.prompt(msg, "") == "OK") {
                URL = "delete_all.aspx";
                window.location = URL;
            }
        }

        function order_by(field, asc_desc) {
            window.location = "index1.aspx?start=0&TYPE=0&FIELD=" + field + "&ASC_DESC=" + asc_desc;
        }

        function change_type(type) {
            window.location = "index1.aspx?start=0&TYPE=" + type + "&FIELD=&ASC_DESC=";
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
                url = "delete.aspx?DELETE_STR=" + delete_str + "&start=0";
                location = url;
            }
        }


        function my_affair(NOTIFY_ID) {
            myleft = (screen.availWidth - 250) / 2;
            mytop = (screen.availHeight - 200) / 2;
            URL = "note.aspx?NOTIFY_ID=" + NOTIFY_ID;
            window.open(URL, "", "height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=auto,resizable=no,top=" + mytop + ",left=" + myleft);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
            <tr>
                <td style="height: 24px;">
                    <div id="menu">
                        <div class="OperateNote">
                            <span id="buttons">
                                <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="">网络办公&gt;&gt;</a>电子公告</span></div>
                        <ul>
                            <li id="menu_Title0" class="normal"><a href="AfficheEdit.aspx" target="sysFrame">
                                <span id="Span1">
                                    <img src="../../Images/add.png" alt="" border="0" />新建公告 </span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr id="search_condition_panel" style="height: 24px; border-bottom: 1px solid #8cb2e2;">
                <td>
                    <table id="PatrolSearch0" width="480px" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="24" align="right">
                                <span id="PatrolSearch1">标题：</span>
                            </td>
                            <td height="24">
                                <asp:TextBox ID="txt_title" runat="server" Width="120"></asp:TextBox>
                            </td>
                            <td height="24" align="right">
                                <span id="PatrolSearch2">时间：</span>
                            </td>
                            <td height="24">
                                <asp:TextBox ID="txt_endTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            </td>
                            <td width="80" height="24" align="center">
                                <asp:Button ID="btn_ok" runat="server" Text="" CssClass="btn_search" OnClick="btn_ok_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table class="TableBlock" width="100%" cellspacing="0" cellpadding="3" align="center">
                        <asp:Repeater ID="RptAffiche" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr class="TableHeader">
                                        <th>
                                            <asp:CheckBox ID="CheckallAffiche" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                                        </th>
                                        <th>
                                            标题
                                        </th>
                                        <th>
                                            发布人
                                        </th>
                                        <th>
                                            创建时间
                                        </th>
                                        <th>
                                            状态
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:CheckBox ID="CheckSingleAffiche" runat="server" />
                                            <asp:Label ID="AFFICHEID" runat="server" Text='<%#Eval("AFFICHEID") %>' Visible="false"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <a href="">
                                                <%# Eval("AFFICHETITLE")%></a>
                                        </td>
                                        <td align="center">
                                            <%# Eval("AFFICHER")%>
                                        </td>
                                        <td align="center">
                                            <%# Eval("AFFICHEDATE")%>
                                        </td>
                                        <td align="center">
                                            <%# Eval("STATES")%>
                                        </td>
                                        <td align="center">
                                            <a href="AfficheEdit.aspx?aid=<%# Eval("AFFICHEID")%>">编辑</a> <a href="" id="delhref">
                                                删除</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tfoot>
                                    <tr>
                                        <td colspan="6">
                                            <%--分页--%>
                                        </td>
                                    </tr>
                                </tfoot>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
