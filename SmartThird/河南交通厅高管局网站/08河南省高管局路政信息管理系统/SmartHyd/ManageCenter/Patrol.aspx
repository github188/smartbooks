<%@ Page Title="人工巡逻" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="Patrol.aspx.cs" Inherits="SmartHyd.ManageCenter.Patrol"%>

<%@ Register src="Ascx/Patrol.ascx" tagname="Patrol" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/jscript">
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*巡查处理情况*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Patrol1_txtLog"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "120px"
                });

                /*移交内业处理事项*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Patrol1_txtWITHIN"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });

                /*移交下班处理事项*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Patrol1_txtNEXTWITHIN"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });

                /*移交器材*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Patrol1_txtGOODS"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });
            });

            /*开始、结束时间*/
            $("#ctl00_ContentPlaceHolder1_Patrol1_txtBEGINTIME").datepicker();
            $("#ctl00_ContentPlaceHolder1_Patrol1_txtENDTIME").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Patrol ID="Patrol1" runat="server" />
</asp:Content>
