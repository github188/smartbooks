<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="SmartHyd.ManageCenter.ControlArea.View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看违章信息</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：路产管理 > 查看违章信息 </span>
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
            <td colspan="2">
                查看违章信息
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                违章名称:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:Label ID="lblAreaName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                高速公路:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                <asp:Label ID="lblLineName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                桩号位置:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:Label ID="lblPoint" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                位置描述:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:Label ID="lblPointSummary" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                时间信息:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="登记时间"></asp:Label>
                <asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="竣工时间"></asp:Label>
                <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                现场照片:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:Literal ID="litPic" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                详细描述:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:TextBox ID="txtDETAILED" runat="server" TextMode="MultiLine" Height="75" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                现状描述:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:TextBox ID="txtSTATUS" runat="server" TextMode="MultiLine" Height="75" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                备注信息:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:TextBox ID="txtREMARK" runat="server" TextMode="MultiLine" Height="75" Width="99%"></asp:TextBox>
            </td>
        </tr>
        <!--操作按钮-->
        <tr class="TableControl" align="center">
            <td colspan="2" nowrap="nowrap">
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="Button" 
                    onclick="btnDel_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="返回" CssClass="Button" 
                    onclick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
