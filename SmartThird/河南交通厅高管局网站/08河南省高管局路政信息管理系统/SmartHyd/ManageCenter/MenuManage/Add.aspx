<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.MenuManage.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加菜单</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：菜单管理 > 添加菜单 </span>
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
                <td>
                    新建公文分类
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    <table class="TableList" width="100%">
                        <tbody>
                            <!--首选行-->
                            <tr class="TableHeader">
                                <td colspan="2" align="left" style="text-align: left;">
                                    添加菜单
                                </td>
                            </tr>
                            <!--菜单名称-->
                            <tr>
                                <td nowrap="nowrap" class="TableData" width="70">
                                    菜单名称:
                                </td>
                                <td class="TableData">
                                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                    <asp:TextBox ID="txtMenuName" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                                        Width="350">
                                    </asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <!--菜单地址-->
                            <tr>
                                <td nowrap="nowrap" class="TableData" width="70">
                                    菜单地址:
                                </td>
                                <td class="TableData">
                                    <asp:TextBox ID="txtMenuUrl" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                                        Width="350" Text="ManageCenter/">
                                    </asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <!--菜单描述-->
                            <tr>
                                <td nowrap="nowrap" class="TableData">
                                    菜单描述:
                                </td>
                                <td class="TableData">
                                    <asp:TextBox ID="txtSummary" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                                        Height="81px" TextMode="MultiLine" Width="350">
                                    </asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <!--菜单图标-->
                            <tr>
                                <td nowrap="nowrap" class="TableData">
                                    菜单图标:
                                </td>
                                <td class="TableData">
                                    <asp:TextBox ID="txtMenuIco" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                                        Width="350" Text="Images/sale_manage.png">
                                    </asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <!--父菜单编号-->
                            <tr>
                                <td nowrap="nowrap" class="TableData">
                                    父级菜单:
                                </td>
                                <td class="TableData">
                                    <asp:DropDownList ID="ddlMenuParentNode" runat="server" CssClass="input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <!--状态-->
                            <tr>
                                <td nowrap="nowrap" class="TableData">
                                    状态:
                                </td>
                                <td class="TableData">
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="input">
                                        <asp:ListItem Text="正常" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="关闭" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <!--submit button-->
                            <tr class="TableControl" align="center">
                                <td colspan="2" nowrap="nowrap" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap">
                    <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="Button" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
