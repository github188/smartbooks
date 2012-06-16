<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.ControlArea.Add" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加控制区违章信息</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <style type="text/css">
        /*通用input元素样式--文本框*/
        .input
        {
            border: #C1C1C1 1px solid;
            background-color: #FBFBFB;
            color: #444;
            padding: 4px 5px 4px;
            float: left;
        }
        .input:hover
        {
            background-color: #FFC;
            border: 1px solid #d5ae4f;
        }
        span, input
        {
            float: left;
            padding: 4px 5px 4px;
        }
        body
        {
            font-size: 12px;
            font-family: Verdana,arial,sans-serif;
            padding: 0px;
            margin: 0px;
        }
        /*验证元素提示框*/
        .validate
        {
            float: left;
            width: 55px;
            font-size: 12px;
            color: Red;
            height: 28px;
            line-height: 28px;
            margin-left: 4px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            /*向页面注册表单验证全局*/
            $("#form1").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });
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
                            <img src="../../Images/branch.png" border="0" />当前位置：违章管理 > 添加控制区违章信息 </span>
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
                添加控制区违章信息
            </td>
        </tr>
        <tr nowrap="nowrap" class="TableData">
            <td>
                <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            <uc1:Department ID="Department1" runat="server" />
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label3" runat="server" Text="分类名称:"></asp:Label>
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="input">
                            </asp:DropDownList>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                            <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label13" runat="server" Text="违章名称:"></asp:Label>
                            <asp:TextBox ID="txtAREANAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                            <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="50"
                                Text="0"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                            <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="50"
                                Text="0"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label2" runat="server" Text="位置描述:"></asp:Label>
                            <asp:TextBox ID="txtSUMMARY" runat="server" CssClass="input {required:true}"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label4" runat="server" Text="登记时间:"></asp:Label>
                            <asp:TextBox ID="txtREGTIME" runat="server" CssClass="Wdate input" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label5" runat="server" Text="竣工时间:"></asp:Label>
                            <asp:TextBox ID="txtCOMPTIME" runat="server" CssClass="Wdate input" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label8" runat="server" Text="物主名称:"></asp:Label>
                            <asp:TextBox ID="txtOWNER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" colspan="3">
                            <asp:Label ID="Label9" runat="server" Text="现场照片:"></asp:Label>
                            <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" Width="400" />
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label11" runat="server" Text="详细描述:"></asp:Label>
                            <asp:TextBox ID="txtDETAILED" runat="server" CssClass="input {required:true}" TextMode="MultiLine"
                                Width="400"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label12" runat="server" Text="现状描述:"></asp:Label>
                            <asp:TextBox ID="txtSTATUS" runat="server" CssClass="input {required:true}" TextMode="MultiLine"
                                Width="400"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData" colspan="3">
                            <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                            <asp:TextBox ID="txtREMARK" runat="server" CssClass="input" TextMode="MultiLine"
                                Width="400"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!--操作按钮-->
        <tr align="center">
            <td colspan="3" nowrap="nowrap" class="TableControl">
                <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="Button" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" OnClick="btnCancel_Click" Visible="false" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
