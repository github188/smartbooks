<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermAdd.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermAdd" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路产设备添加</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
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
            $("#roadForm").validate({
                errorPlacement: function (error, element) {
                    error.appendTo(element.siblings("div:first"));
                }
            });
        });
    </script>
</head>
<body>
    <form id="roadForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" alt="" border="0" />当前位置：路产设备管理 > 新增路产</span></div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="GoBack()" style="cursor: pointer;">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
        <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
            <td>
                <table class="TableBlock" width="100%">
                    <tr>
                        <td colspan="3" nowrap="nowrap" class="TableHeader">
                            新增路产
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            <uc1:Department ID="Department1" runat="server" />
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label3" runat="server" Text="设备类型:"></asp:Label>
                            <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input" Width="162">
                            </asp:DropDownList>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label11" runat="server" Text="设备状态:"></asp:Label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input" Width="162">
                                <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                                <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                            <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}" Width="162"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label8" runat="server" Text="设备名称:"></asp:Label>
                            <asp:TextBox ID="txtRoadName" runat="server" CssClass="input {required:true}" MaxLength="50"
                                Width="162"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                            <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="20"
                                Text="0"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                            <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="20"
                                Text="0"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label4" runat="server" Text="登记时间:"></asp:Label>
                            <asp:TextBox ID="txtREGTIME" runat="server" CssClass="Wdate input" Width="162" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label5" runat="server" Text="竣工时间:"></asp:Label>
                            <asp:TextBox ID="txtCOMPTIME" runat="server" CssClass="Wdate input" Width="162" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label2" runat="server" Text="位置描述:"></asp:Label>
                            <asp:TextBox ID="txtSUMMARY" runat="server" CssClass="input {required:true}" Width="162"></asp:TextBox>
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap" class="TableData">
                            <asp:Label ID="Label9" runat="server" Text="设备照片:"></asp:Label>
                            <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" />
                            <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                            </div>
                        </td>
                        <td nowrap="nowrap" class="TableData" colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                            <asp:TextBox ID="txtREMARK" runat="server" CssClass="input" Width="400"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center;" nowrap="nowrap" class="TableControl">
                            <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="Button" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
