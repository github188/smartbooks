<%@ Page Title="导入数据" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="SmartHyd.ManageCenter.ImportData" %>
<%@ Register src="Ascx/ImportData.ascx" tagname="ImportData" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/jscript">
        $(function () {
            $('#progressbar').progressbar({
                value: 0
            });

            function updateprogressbar(size, count, per) {
                $('title').text(size + '|' + count + '|' + per);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ImportData ID="ImportData1" runat="server" />
</asp:Content>
