<%@ Page Title="新建公文" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="DocumentCreate.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentCreate" %>
<%@ Register src="Ascx/DocumentCreate.ascx" tagname="DocumentCreate" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/jscript">
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*发文内容*/
                editor = K.create('textarea[id="id="ctl00_ContentPlaceHolder1_DocumentCreate1_txtContent""]', {
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
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_PublishDocument1_TreeViewAcceptUnit
        {
            overflow:scroll;
            width:270px;
            height:100%;
            float:right;
            border:1px solid #A6C9E2;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DocumentCreate ID="DocumentCreate1" runat="server" />
</asp:Content>
