<%@ Page Language="C#" Title="用户编辑" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="UserEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.UserEdit" %>


<%@ Register Src="Ascx/UserEdit.ascx" TagName="UserEdit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            /*设置input元素样式*/
            $('input').css("class", "input");

            /*日期控件*/
            $('#ContentPlaceHolder1_UserEdit1_txtBIRTHDAY').datepicker();

            /*重置表单*/
            $("#ctl00_ContentPlaceHolder1_UserManage1_btnCancel").click(function () {
                validator.resetForm();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserEdit ID="UserEdit1" runat="server" />

</asp:Content>
