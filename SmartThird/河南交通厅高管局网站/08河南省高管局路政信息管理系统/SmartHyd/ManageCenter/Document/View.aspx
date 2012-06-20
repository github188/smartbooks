<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="SmartHyd.ManageCenter.Document.View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看档案</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function GoBack() {
            history.go(-1);
        }

        $(function () {
            /*向页面注册表单验证全局*/
            $("#form1").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });

            var value = $('#hidAnnex').attr('value');

            $.get('../../Ashx/Annex.ashx',
                { id: value },
                function (data) {
                    rs = eval(data);
                    $.each(rs, function (i, o) {
                        var html = '<a href="../../' + o.SERVERPATH + o.SERVERNAME + o.EXTENSION + '" style="margin:5px;">' + o.SRCNAME + '</a>';
                        $('#annex').append(html);
                    });
                }
            );
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" border="0" />当前位置：档案管理 > 查看档案 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <!--首选行-->
        <tr class="TableHeader">
            <td>
                查看档案
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td nowrap="nowrap" class="TableData" width="60">
                            卷内标题:
                        </td>
                        <td nowrap="nowrap" class="TableData" colspan="5">
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            <asp:HiddenField ID="hidAnnex" runat="server" Value="" />
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="input {required:true}" Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" width="60">
                            单位:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtUnit" runat="server" CssClass="input {required:true}" Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            年度:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtYear" runat="server" CssClass="input {required:true}" Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            保管期限:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtRETENTION" runat="server" CssClass="input {required:true}" Width="200"
                                Text="10">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none; ">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" width="60">
                            全宗号:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtFONDSNO" runat="server" CssClass="input {required:true}" Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            目录号:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtCATALOGNUMBER" runat="server" CssClass="input {required:true}"
                                Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            案卷号:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtCASEFILENUMBER" runat="server" CssClass="input {required:true}"
                                Width="200">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" width="60">
                            起始时间:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtBeginTime" runat="server" CssClass="input Wdate" Width="120"
                                onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            截止时间:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtEndTime" runat="server" CssClass="input Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td nowrap="nowrap" class="TableData" width="60">
                            卷内册数:
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:TextBox ID="txtNUMBEROFCOPIES" runat="server" CssClass="input {required:true}"
                                Width="200" Text="0">
                            </asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0"
                    id="annexContainer">
                    <tr class="TableHeader">
                        <td nowrap="nowrap">
                            附件信息
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" id="annex">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!--操作按钮-->
        <tr class="TableControl" align="center">
            <td nowrap="nowrap">
            </td>
        </tr>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
