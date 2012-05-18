<%@ Page Title="档案管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentManage.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentManage" %>
<%@ Register src="Ascx/DocumentManage.ascx" tagname="DocumentManage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/jscript">
         $(function () {
             /*编辑器*/
             var editor;
             KindEditor.ready(function (K) {
                 /*发文内容*/
                 editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_DocumentManage1_txtContent"]', {
                     items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                     width: "100%",
                     height: "120px"
                 });
             });

             /*开始、结束时间*/
             //$("#ctl00_ContentPlaceHolder1_Patrol1_txtBEGINTIME").datepicker();/
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentManage ID="DocumentManage1" runat="server" />
</asp:Content>
