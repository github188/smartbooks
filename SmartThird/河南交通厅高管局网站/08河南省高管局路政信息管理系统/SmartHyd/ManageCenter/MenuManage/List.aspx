<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SmartHyd.ManageCenter.MenuManage.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
                    <table class="TableList" width="100%" style="margin-bottom: 20px;">
                        <tbody>
                            <tr class="TableHeader" align="center">
                                <td>
                                    菜单图标
                                </td>
                                <td>
                                    菜单名称
                                </td>
                                <td>
                                    菜单说明
                                </td>
                                <td>
                                    菜单状态
                                </td>
                            </tr>
                            <asp:Repeater ID="repList" runat="server">
                                <ItemTemplate>
                                    <tr class="TableLine1" align="center">
                                        <td>
                                            <img src='../<%#Eval("ICON")%>' />
                                        </td>
                                        <td>
                                            <a href='../<%#Eval("MENUURL")%>'>
                                                <%#Eval("MENUNAME")%></a>
                                        </td>
                                        <td>
                                            <%#Eval("MENUINFO")%>
                                        </td>
                                        <td>
                                            <%#Eval("STATUS").ToString().Equals("0")? "正常":"关闭" %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                        PageSize="10" CssClass="anpager" CurrentPageButtonClass="cpb">
                    </webdiyer:AspNetPager>
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
