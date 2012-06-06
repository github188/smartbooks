<%@ Page Title="用户授权" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="Empower.aspx.cs" Inherits="SmartHyd.ManageCenter.Empower" %>

<%@ Register Src="~/ManageCenter/Ascx/Empower.ascx" TagName="Empower" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/jscript">
  //权限列表窗口
    function Rolelist() {
        $(function () {
            var dialog = $("#dialog").dialog({
                modal: true,
                title: "权限列表窗口"
            });

        });

    }
    //授权用户模态窗口
    function SelectUser(textID, dialogid) {
        Clear(textID);
        $(function () {

            var dialog = $(dialogid).dialog({
                modal: false,
                title: "授权窗口"
            });

        });

    }
    //清空文本框
    function Clear(textID) {
        document.getElementById(textID).value = "";
    }
    function btn_submit(textID, dialogid) {

        var elem = document.getElementsByTagName("input");
        var user = document.getElementById(textID);


        for (var i = 0; i < elem.length; i++) {

            if (elem[i].type == "checkbox") {
                if (elem[i].checked == true) {
                    user.value += elem[i].nextSibling.innerText + ","; //-- nextSibling是获得当前对象的下一个对象;nodeValue 节点的值 

                }
                elem[i].checked = false; //清空选中的项
            }
        }
        $(dialogid).dialog("close"); //关闭dialog窗口；
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Empower ID="Empower1" runat="server" />
</asp:Content>
