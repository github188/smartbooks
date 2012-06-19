<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.DocumentType.Add" %>


<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新建档案分类</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/messages_cn.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-validation-1.9.0/jquery.metadata.js"></script>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：档案分类 > 新建档案分类 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td colspan="2">
                    新建档案分类
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" width="30">分类名称:</td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    <asp:TextBox ID="txtName" runat="server" CssClass="input {required:true}" Width="200">
                    </asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" width="30">分类描述:</td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="input {required:true}" Width="200" Height="75" TextMode="MultiLine">
                    </asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" width="30">父级分类:</td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:DropDownList ID="ddlParentType" runat="server" CssClass="input" Width="210">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" width="30">共享特性:</td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:DropDownList ID="ddlShare" runat="server" CssClass="input" Width="210">
                        <asp:ListItem Selected="True" Value="0">仅允许本单位查看</asp:ListItem>
                        <asp:ListItem Value="1">允许上级单位查看</asp:ListItem>
                        <asp:ListItem Value="2">允许下级单位查看</asp:ListItem>
                        <asp:ListItem Value="3">允许上下单位查看</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" width="30">分类排序:</td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:TextBox ID="txtSort" runat="server" CssClass="input {required:true}" Width="30" Text="1">
                    </asp:TextBox>
                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                </td>
            </tr>


            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="Button" 
                        onclick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button"  Visible="false"/>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
