<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatrolEdit.aspx.cs" Inherits="SmartHyd.Patrol.PatrolEdit" %>

<%@ Register Src="~/Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>巡逻信息编辑</title>
    <link href="../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Css/base.css" />
    <link rel="stylesheet" type="text/css" href="../Css/tongdaoa.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css" />
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery.ui.datepicker-zh-CN.js"></script>
    <script type="text/javascript" src="../Scripts/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../Scripts/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <script src="../Scripts/base.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(function () {
            /*向页面注册表单验证全局*/
            $("#aspnetForm").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });
        });

        function GoBack() {
            history.go(-1);
        }
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*巡查处理情况*/
                editor = K.create('textarea[id="txtLog"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "120px"
                });

                /*移交内业处理事项*/
                editor = K.create('textarea[id="txtWITHIN"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });

                /*移交下班处理事项*/
                editor = K.create('textarea[id="txtNEXTWITHIN"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });

                /*移交器材*/
                editor = K.create('textarea[id="txtGOODS"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "50px"
                });
            });

            /*开始、结束时间*/
            $("#txtBEGINTIME").datepicker();
            $("#txtENDTIME").datepicker();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="menu">
        <div class="OperateNote">
            <span id="buttons0">
                <img src="../Images/addDocument.png" alt="" border="0" />&nbsp;<asp:Label ID="LabName"
                    runat="server" Text=""></asp:Label></span></div>
        <div class="ReturnPreview">
            <span id="buttons1" onclick="GoBack()">
                <img src="../Images/back.png" alt="" border="0" />返回上一页面</span></div>
    </div>
    <table class="edit" width="100%">
        <tbody>
            <tr height="38">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="巡查中队:"></asp:Label>
                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    <uc1:Department ID="Department1" runat="server" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="负责人员:"></asp:Label>
                    <asp:TextBox ID="txtRESPUSER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="巡查人员:"></asp:Label>
                    <asp:TextBox ID="txtPATROLUSER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
            </tr>
            <tr height="38">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="车牌号码:"></asp:Label>
                    <asp:TextBox ID="txtBUSNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="巡查里程:"></asp:Label>
                    <asp:TextBox ID="txtMILEAGE" runat="server" CssClass="input {required:true}" Text="1000"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="天气情况:"></asp:Label>
                    <asp:TextBox ID="txtWEATHER" runat="server" CssClass="input {required:true}" Text="晴天"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label7" runat="server" Text="巡查处理情况:"></asp:Label>
                    <asp:TextBox ID="txtLog" runat="server" CssClass="input" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label8" runat="server" Text="移交内业处理事项:"></asp:Label>
                    <asp:TextBox ID="txtWITHIN" runat="server" CssClass="input" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label9" runat="server" Text="移交下班处理事项:"></asp:Label>
                    <asp:TextBox ID="txtNEXTWITHIN" runat="server" CssClass="input" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label10" runat="server" Text="移交下班器材:"></asp:Label>
                    <asp:TextBox ID="txtGOODS" runat="server" CssClass="input" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr height="38">
                <td>
                    <asp:Label ID="Label11" runat="server" Text="交班中队:"></asp:Label>
                    <asp:TextBox ID="txtSHIFTCAPTAIN" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="接班中队:"></asp:Label>
                    <asp:TextBox ID="txtACCEPTCAPTAIN" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="车牌号码:"></asp:Label>
                    <asp:TextBox ID="txtACCEPTBUSNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
            </tr>
            <tr height="38">
                <td>
                    <asp:Label ID="Label14" runat="server" Text="开始时间:"></asp:Label>
                    <asp:TextBox ID="txtBEGINTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="结束时间:"></asp:Label>
                    <asp:TextBox ID="txtENDTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="里程表数:"></asp:Label>
                    <asp:TextBox ID="txtBUSKM" runat="server" CssClass="input {required:true}" Text="1000"></asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                    </div>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="重置" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
