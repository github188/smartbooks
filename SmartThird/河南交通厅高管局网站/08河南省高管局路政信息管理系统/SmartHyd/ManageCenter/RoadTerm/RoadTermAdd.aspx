<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermAdd.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermAdd" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路产设备添加</title>
    <link rel="stylesheet" type="text/css" href="../../Css/tongdaoa.css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery.ui.datepicker-zh-CN.js"></script>    
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
    <%--<script type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>--%>
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
            width: 150px;
            font-size: 12px;
        }
    </style>
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

            /*时间*/
            $("#txtREGTIME").datepicker();
            $("#txtCOMPTIME").datepicker();
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
                                <asp:Label ID="Label8" runat="server" Text="设备名称:"></asp:Label>
                                <asp:TextBox ID="txtRoadName" runat="server" CssClass="input {required:true}" MaxLength="50"></asp:TextBox>
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
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
                                <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="20"
                                    Text="0"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                                <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="20"
                                    Text="0"></asp:TextBox>
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
                            <td colspan="2">
                                <asp:Label ID="Label9" runat="server" Text="设备照片:"></asp:Label>
                                <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" />
                                <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                </div>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="设备状态:"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                                    <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                                    <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="3" style="text-align: center;">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="重置" CssClass="BigButtonA" OnClick="btnCancel_Click"  Visible="false"/>
                            </td>
                        </tr>
                    </tfoot>
                </table>
                <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>

            </td>
        </tr>
    </table>
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
