<%@ Page Title="电子巡逻" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="Observed.aspx.cs" Inherits="SmartHyd.ManageCenter.Observed" %>

<%@ Register Src="Ascx/Observed.ascx" TagName="Observed" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*巡查处理情况*/
                editor = K.create('textarea[id="ctl00_ContentPlaceHolder1_Observed1_txtLog"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "120px"
                });
            });

            /*开始、结束时间*/
            $("#ctl00_ContentPlaceHolder1_Observed1_txtBEGINTIME").datepicker();
            $("#ctl00_ContentPlaceHolder1_Observed1_txtENDTIME").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Observed ID="Observed1" runat="server" />
</asp:Content>
