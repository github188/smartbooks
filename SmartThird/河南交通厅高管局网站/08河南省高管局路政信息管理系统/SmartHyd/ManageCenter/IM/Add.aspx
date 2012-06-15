<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.IM.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新建消息</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：网络办公 > 即时通讯 > 新建消息 </span>
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
                    新建消息
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   接收:
                </td>
                <td nowrap="nowrap" class="TableData" align="left">
                    <asp:TextBox ID="txtAccept" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   正文:
                </td>
                <td nowrap="nowrap" class="TableData">
                    <asp:TextBox ID="txtContent" runat="server" Width="100%" Height="120" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData" width="30">
                   选项:
                </td>
                <td nowrap="nowrap" class="TableData">
                    <asp:CheckBox ID="chkSMSAlert" runat="server" Text="短信提醒" />
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap" colspan="2">
                    <asp:Button ID="btnSend" runat="server" Text="发送" CssClass="Button" 
                        onclick="btnSend_Click"  />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" 
                        onclick="btnCancel_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
