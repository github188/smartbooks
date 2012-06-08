<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManage" %>

<%@ Register Src="Ascx/UserManage.ascx" TagName="UserManage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Css/patrol.css" rel="stylesheet" type="text/css" />

    <script type="text/jscript">
        $(function () {
            /*设置input元素样式*/
            $('input').css("class", "input");

            /*日期控件*/
            $('#ctl00_ContentPlaceHolder1_UserManage1_txtBIRTHDAY').datepicker();
                        
            /*重置表单*/
            $("#ctl00_ContentPlaceHolder1_UserManage1_btnCancel").click(function () {
                validator.resetForm();
            });
        });


        //tab效果通用函数
        function nTabs(tabObj, obj, n) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < n; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "actived";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                }
            }
        }




    </script>
    <style type="text/css">
        .treeViewStyle{ height:100%; overflow-y:scroll; color:#000000; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserManage ID="UserManage1" runat="server" />
</asp:Content>
