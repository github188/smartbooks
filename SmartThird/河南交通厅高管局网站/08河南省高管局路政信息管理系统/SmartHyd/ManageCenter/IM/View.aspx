<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="SmartHyd.ManageCenter.IM.View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看消息</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：网络办公 > 即时通讯 > 查看消息 </span>
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
                    查看消息
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   姓名:
                </td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:Literal ID="litSendName" runat="server"></asp:Literal>
                 </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   时间:
                </td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:Literal ID="litTIme" runat="server"></asp:Literal>
                 </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   正文:
                </td>
                <td nowrap="nowrap" class="TableData">
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap" colspan="2">
                    <asp:Button ID="btnReply" runat="server" Text="回复" CssClass="Button" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
