<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManage" %>

<%@ Register Src="Ascx/UserManage.ascx" TagName="UserManage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            /*设置input元素样式*/
            $('input').css("class", "input");

            /*日期控件*/
            $('#ctl00_ContentPlaceHolder1_UserManage1_txtBIRTHDAY').datepicker();

            /*向页面注册表单验证*/
            $("#aspnetForm").validate({                
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));                    
                }
            });
            /*重置表单*/
            $("#ctl00_ContentPlaceHolder1_UserManage1_btnCancel").click(function () {
                validator.resetForm();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserManage ID="UserManage1" runat="server" />
</asp:Content>
