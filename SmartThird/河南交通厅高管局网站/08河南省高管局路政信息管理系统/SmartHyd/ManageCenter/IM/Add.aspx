<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.IM.Add" %>

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
                    <!--发送消息开始-->
<div id="message">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td style="height: 24px;">
                        <div id="Div1">
                            <div class="OperateNote">
                                <span id="Span1">
                                    <img src="../../Images/branch.png" border="0" />当前位置：网络办公&gt;&gt;即时通讯</span></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="TableHeader" width="600">
                            <tr>
                                <td class="left">
                                </td>
                                <td>
                                    发送消息
                                </td>
                                <td class="right">
                                </td>
                            </tr>
                        </table>
                        <table class="TableBlock no-top-border" width="600">
                            <tr class="TableData">
                                <td>
                                    收信人：
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                    <asp:TextBox ID="TxtTouser" runat="server" CssClass="input"></asp:TextBox>
                                    <%--   <textarea cols="55" name="TO_NAME" rows="2" class="BigStatic" wrap="yes"></textarea>
              <a href="javascript:;" class="orgAdd" onclick="SelectUser('2','TO_UID', 'TO_NAME', '', '', '1')">
                    添加</a> <a href="javascript:;" class="orgClear" onclick="ClearUser('TO_UID', 'TO_NAME')">
                        清空</a>--%>
                                </td>
                            </tr>
                            <%-- <tr class="TableData">
            <td>
                发送时间：
            </td>
            <td>
                <input type="text" id="SEND_TIME" name="SEND_TIME" size="20" maxlength="19" class="BigInput"/>
                为空则即时发送
            </td>
        </tr>--%>
                            <tr class="TableData">
                                <td colspan="2">
                                    <textarea id="Message" name="CONTENT" rows="8" cols="60" runat="server"></textarea>
                                </td>
                            </tr>
                            <tr class="TableFooter">
                                <td colspan="2" align="center">
                                    <div style="position: relative; width: 100%;">
                                        <span id="words_count"></span>
                                        <input type="hidden" value="" name="SMS_ID_REPLAY" />
                                        <asp:Button ID="Btn_Send" runat="server" Text="发送" OnClick="Btn_Send_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--dialog窗口开始-->
    <div id="overlay">
    </div>
    <div id="dialog" class="ModalDialog" style="display: none">
        <div class="header">
            <span id="title" class="title">收信人列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
        <table width="95%" class="table" align="center">
            <thead>
                <tr>
                    <td class="TableContent">
                        请选择收信人
                    </td>
                </tr>
            </thead>
            <tr>
                <td colspan="2" class="TableData">
                    <asp:CheckBoxList ID="CBLUser" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <input type="button" id="btnsubmit" value="确定" onclick="javascript:btn_submit()" />
    </div>
    <!--dialog窗口结束-->
</div>
<!--发送消息结束-->

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
