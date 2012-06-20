<%@ Page Title="装备编辑" Language="C#" AutoEventWireup="true" CodeBehind="TermEdit.aspx.cs"
    Inherits="SmartHyd.ManageCenter.TermEdit" %>

<%@ Register Src="~/Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>装备信息编辑</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Css/base.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/tongdaoa.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery.ui.datepicker-zh-CN.js"></script>
    <script type="text/javascript" src="../../Scripts/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../../Scripts/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <script src="../../Scripts/base.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(function () {
            /*向页面注册表单验证全局*/
            $("#form1").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });
            //投入时间
            $("#txtUSETIME").datepicker();
        });
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons0">
                            <img src="../../Images/addDocument.png" alt="" border="0" />&nbsp;<asp:Label ID="LabName"
                                runat="server" Text="Label"></asp:Label></span></div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="GoBack()">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
                <table class="edit" width="100%">
                    <tbody>
                        <tr height="38">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                <uc1:Department ID="Department1" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="装备类型:"></asp:Label>
                                <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input" Width="160px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="设备编号:"></asp:Label>
                                <asp:TextBox ID="txtTERMCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                        </tr>
                        <tr height="38">
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="设备名称:"></asp:Label>
                                <asp:TextBox ID="txtTERMNAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="出厂编号:"></asp:Label>
                                <asp:TextBox ID="txtSERIALCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="规格型号:"></asp:Label>
                                <asp:TextBox ID="txtFORMAT" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                        </tr>
                        <tr height="38">
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="制造厂商:"></asp:Label>
                                <asp:TextBox ID="txtBRAND" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="装备用途:"></asp:Label>
                                <asp:TextBox ID="txtUse" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="投入时间:"></asp:Label>
                                <asp:TextBox ID="txtUSETIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                        </tr>
                        <tr height="38">
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="设备状态:"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                                    <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                                    <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="备注信息:"></asp:Label>
                                <asp:TextBox ID="txtRemark" runat="server" CssClass="input"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="存放地点:"></asp:Label>
                                <asp:TextBox ID="TxtPosition" runat="server" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="重置" CssClass="BigButtonA" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
