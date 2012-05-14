<%@ Page Title="违章管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="SmartHyd.ManageCenter.Area" %>

<%@ Register src="Ascx/Area.ascx" tagname="Area" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*详细描述*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Area1_txtDETAILED"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "120px"
                });

                /*现状描述*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Area1_txtSTATUS"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "120px"
                });
            });

            /*开始、结束时间*/
            $("#ctl00_ContentPlaceHolder1_Area1_txtREGTIME").datepicker();
            $("#ctl00_ContentPlaceHolder1_Area1_txtCOMPTIME").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Area ID="Area1" runat="server" />
</asp:Content>
