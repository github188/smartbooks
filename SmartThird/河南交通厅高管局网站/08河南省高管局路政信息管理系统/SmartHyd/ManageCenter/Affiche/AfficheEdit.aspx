<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfficheEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.Affiche.AfficheEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>电子公告编辑</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/base.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/base.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery.ui.datepicker-zh-CN.js"></script>
    <script type="text/javascript" src="../../Scripts/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../../Scripts/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(function () {
            /*公告内容编辑器*/
            var editor;
            KindEditor.ready(function (k) {
                editor = k.create('textarea[id="TxtContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "350px"
                });
            });
            /*时间*/
            $("#TxtTime").datepicker();
            /*向页面注册表单验证全局*/
            $("#form1").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });
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
        function show_reader(NOTIFY_ID) {
            URL = "show_reader.php?NOTIFY_ID=" + NOTIFY_ID;
            myleft = (screen.availWidth - 500) / 2;
            window.open(URL, "read_notify", "height=500,width=700,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=150,left=" + myleft + ",resizable=yes");
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
                URL = "delete_all.php";
                window.location = URL;
            }
        }

    

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" width="100%" cellspacing="0" cellpadding="3" class="TableBlock">
            <thead>
                <tr class="TableHeader">
                    <th colspan="3" align="center">
                        <asp:Label ID="LbHeadName" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp; 公告标题：
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtTitle" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <font color="red">*</font>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                        <%--<input type="text" name="SUBJECT" id="SUBJECT" runat="server" size="55" maxlength="200" class="BigInput"
                        value="请输入公告标题..." style="color: #8896A0" 
                         onmouseover="if(document.getElementById('SUBJECT').value=='请输入公告标题...')document.getElementById('SUBJECT').style.color='#000000';"
                        onmouseout="if(document.getElementById('SUBJECT').value=='请输入公告标题...')document.getElementById('SUBJECT').style.color='#8896A0';" onfocus="if(document.getElementById('SUBJECT').value=='请输入公告标题...'){document.getElementById('SUBJECT').value='';document.getElementById('SUBJECT').style.color='#000000';}"/>
                        <font color="red">(*)</font> <a id="font_color_link" href="javascript:;" class="dropdown"
                                onclick="showMenu(this.id, 1);" hidefocus="true"><span>设置标题颜色</span></a>&nbsp;&nbsp;
                        <div id="font_color_link_menu" style="display: none;">--%>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;发布时间：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtTime" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;内容简介：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtContent" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;事务提醒：
                    </td>
                    <td class="TableData">
                        <input type="checkbox" name="SMS_REMIND" id="SMS_REMIND" checked="checked" /><label
                            for="SMS_REMIND">发送事务提醒消息</label>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr class="TableControl">
                    <td colspan="2" align="center" nowrap="nowrap">
                        <input type="hidden" name="PUBLISH" value="" />
                        <input type="hidden" name="SUBJECT_COLOR" value="" />
                        <input type="hidden" name="OP" value="" />
                        <input type="hidden" name="OP1" value="" />
                        <input type="hidden" name="TOP_FLAG" value="0" />
                        <asp:Button ID="Btn_Send" runat="server" Text="发布" class="BigButton" OnClick="Btn_Send_Click" />
                        <asp:Button ID="Btn_Save" runat="server" Text="保存" class="BigButton" OnClick="Btn_Save_Click" />
                        <asp:Button ID="BtnBack" runat="server" Text="返回" class="BigButton" OnClientClick="GoBack()"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
