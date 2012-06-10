<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermAdd.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermAdd" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路产设备列表页</title>
    <link rel="stylesheet" type="text/css" href="../../Css/tongdaoa.css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        /*打开/闭合查询条件设置面板*/
        function showConditionPanel() {
            if ($("#search_condition_panel").css("display") == "none") {
                $("#search_condition_panel").css("display", "block");
            } else {
                $("#search_condition_panel").css("display", "none");
            }
        }

        /*查询前 数据验证*/
        function DataValidate() {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td style="height: 24px;">
                        <div id="menu">
                            <div class="OperateNote">
                                <span id="buttons">
                                    <img src="../../Images/branch.png" alt="" border="0" />当前位置：路产设备管理 > 新增路产</span></div>
                        </div>
                    </td>
                </tr>
                <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
                    <td>
                        <table class="edit" width="100%">
                            <tbody>
                                <tr height="38">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                        <uc1:Department ID="Department1" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="设备类型:"></asp:Label>
                                        <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="设备状态:"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                                            <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                                            <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr height="38">
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                                        <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                                        <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="20"></asp:TextBox>
                                        <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                                        <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="20"></asp:TextBox>
                                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="位置描述:"></asp:Label>
                                        <asp:TextBox ID="txtSUMMARY" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                        </div>
                                    </td>
                                </tr>
                                <tr height="38">
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="登记时间:"></asp:Label>
                                        <asp:TextBox ID="txtREGTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="竣工时间:"></asp:Label>
                                        <asp:TextBox ID="txtCOMPTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                                        <asp:TextBox ID="txtREMARK" runat="server" CssClass="input"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr height="38">
                                    <td colspan="3">
                                        <asp:Label ID="Label9" runat="server" Text="设备照片:"></asp:Label>
                                        <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" />
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript">
    //tab效果通用函数
    function nTabs(tabObj, obj, n) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        for (i = 0; i < n; i++) {
            if (tabList[i].id == obj.id) {
                document.getElementById(tabObj + "_Title" + i).className = "actived";
            } else {
                document.getElementById(tabObj + "_Title" + i).className = "normal";
            }
        }
    }

</script>
