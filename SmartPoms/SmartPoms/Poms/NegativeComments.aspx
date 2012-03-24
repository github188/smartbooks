<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="NegativeComments.aspx.cs" Inherits="SmartPoms.Poms.NegativeComments" %>

<%@ Register Src="Ascx/NegativeComments.ascx" TagName="NegativeComments" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>负面评论--网络舆情监控平台</title>
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.16/ui/jquery-ui-1.8.16.custom.js"></script>
    <script type="text/jscript" src="../Scripts/jquery-ui-timepicker-addon.js"></script>
    <link rel="stylesheet" type="text/css" href='../Scripts/jquery-ui-1.8.16/themes/ui-lightness/jquery-ui-1.8.16.custom.css' />
    <style type="text/css">
        #paramOption
        {
            width: 100%;
            float: left;
            border:none;
        }
        #paramOption input
        {
            margin:0px;
            padding-left:10px;
        }
        #paramOption textarea
        {
            margin:0px;
            padding-left:10px;
        }
        #ctl00_ContentPlaceHolder1_NegativeComments1_txtKeywordList
        {
            height:35px;
            line-height:35px;
            font-size:18px;
            color:#4D4D4C;
            border: 1px solid #9DADC5;
        }
        #ctl00_ContentPlaceHolder1_NegativeComments1_txtSiteName
        {
            height:35px;
            line-height:35px;
            font-size:18px;
            color:#4D4D4C;
            border: 1px solid #9DADC5;
        }
    </style>
    <script type="text/jscript" language="javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_NegativeComments1_txtBeginDate").datetimepicker();
            $("#ctl00_ContentPlaceHolder1_NegativeComments1_txtEndDate").datetimepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NegativeComments ID="NegativeComments1" runat="server" />
</asp:Content>
