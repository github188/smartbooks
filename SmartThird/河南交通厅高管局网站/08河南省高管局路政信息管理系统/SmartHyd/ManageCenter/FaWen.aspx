<%@ Page Title="发文管理" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    CodeBehind="FaWen.aspx.cs" Inherits="SmartHyd.ManageCenter.FilesManage.FaWen" %>

<%@ Register Src="~/ManageCenter/Ascx/FaWen.ascx" TagName="FaWen" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {

            /*发文内容编辑器*/

            var editor;
            KindEditor.ready(function (k) {
                editor = k.create('textarea[id="ctl00_ContentPlaceHolder1_FaWen1_TxContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                        'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                        'subscript', 'superscript', 'clearhtml'],
                    width: "100%",
                    height: "350px"
                });
            });
        });



        //清空公文
        function clean_type(tid, count) {
            if (count == 0) {
                var msg = "该发文类型未包含公文，无需清空。";
                alert(msg);
            } else {
                var msg = "确定要清空该类型的全部发文吗？";
                if (window.confirm(msg))
                    window.location = "/general/document/index.php/setting/type/clean/" + tid;
            }
        }
        //删除
        function delete_type(tid, count) {
            if (count > 0) {
                var msg = "该发文类型已包含公文，不可删除！\n若要删除请先点击清空。";
                alert(msg);
            } else {
                var msg = "确定删除该发文类型吗？";
                if (window.confirm(msg))
                    window.location = "/general/document/index.php/setting/type/delete/" + tid;
            }
        }
        //编辑公文类型
        function edit_type(tid, count) {
            if (count > 0) {
                var msg = "该发文类型已包含公文，编辑可能会造成文件损坏，确定继续进行编辑吗？";
                if (window.confirm(msg))
                    window.location = "OfficTypeEdit.aspx?ftid=" + tid;
            }
            else
                window.location = "OfficTypeEdit.aspx?ftid=" + tid;

        }
        //公文在线编辑
        function edit_fawen(fid) {
            window.location = "FaWenEdit.aspx?fid" + fid;
        }
        //跳转到指定选项卡
        function trans_tabs(tabindex) {
            alert(tabindex);
            var c = $("ul#menu li");   //选项卡的集合
            //var api = $("#tabs-3").tabs(); //先通过获取tab容器获取tab
            $(function () {
                $("#tab").tabs();
                $(this).click(function () {
                    $("#tab>ul>li>a:eq(" + tabindex + ")").click();
                    return false;
                });

            });

        }

        //全选
        function selectall(chkcontrol) {
            var chkall = chkcontrol;
            State = chkall.checked;
            elem = document.getElementsByTagName("input");
            for (i = 0; i < elem.length; i++) {
                if (elem[i].type == "checkbox" && elem[i] != chkall.id) {
                    if (elem[i].checked != State) {
                        elem[i].click();
                    }
                }
            }
        }

        function all_done() {
            var sid = get_checked();
            if (sid == "") {
                alert("请选择一份公文进行操作！");
                return;
            }

            send_doc(sid);
        }
        function check_form() {
            var v = true;
            var vsid = $("sid").value;

            var checkedNodes = zTree.getCheckedNodes();
            if (checkedNodes == "") {
                alert("请选择发送部门！");
                return false;
            }
            jQuery.each(checkedNodes, function (i, n) {
                //alert(n.innerHTML);
                var vid = n.id;
                var vname = n.name;
                if (jQuery("#print_" + vid).attr("value") == "") {
                    alert(vname + "未填写可打印份数！");
                    v = false;
                    return false;
                }
                $("dept_str").value += vid + ",";
            });
            //	alert($("dept_str").value);
            return v;
        }
        //发送公文
        function send_doc(sid) {
            $(function () {

                var dialog = $("#dialog").dialog({
                    modal:true,
                    title: "发送公文窗口"
                });

            });
            
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FaWen ID="FaWen1" runat="server" />
</asp:Content>
