<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WeiBo.aspx.cs" Inherits="SmartPoms.Poms.WeiBo" %>

<%@ Register Src="Ascx/WeiBo.ascx" TagName="WeiBo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript" src="../Scripts/json2.js"></script>
    <script type="text/javascript" language="javascript">        
        $(document).ready(function () {
            sinLogin();
        });

        function sinLogin() {
            $.get(
            'http://api.t.sina.com.cn/statuses/public_timeline.xml?source=1256981038',
            '',
            function(data){
                alert(data);
            },
            'GET');
        }
    </script>
    <!--引入样式-->
    <link type="text/css" rel="stylesheet" href="http://tjs.sjs.sinajs.cn/t3/style/css/common/card.css" />
    <style type="text/css">
        .weiboScrollBox
        {
            width: 300px;
            height: 300px;
            overflow: auto;
            margin: 2px;
            padding: 4px;
            border: solid 1px #094590;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WeiBo ID="WeiBo1" runat="server" />
</asp:Content>
