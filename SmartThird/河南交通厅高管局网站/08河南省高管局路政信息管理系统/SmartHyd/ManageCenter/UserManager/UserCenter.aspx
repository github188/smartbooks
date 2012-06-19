<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManager.UserCenter" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link href="../../Css/tongdaoa.css" type="text/css" rel="Stylesheet"/>
    <link href="../../Css/patrol.css" type="text/css" rel="Stylesheet" />
    <script src="../../Scripts/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #006699">
                <thead>
                    <tr>
                        <td colspan="6" style="height: 22px; line-height: 22px; text-align: left; background-color: #FFFFFF;
                            border-bottom: 4px double #F09B17">
                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/add_user.png" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repList" runat="server">
                        <HeaderTemplate>
                            <tr class="TableHeader" align="center">
                                <td>
                                    <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                                </td>
                                <td>
                                    登录账号
                                </td>
                                <td>
                                    工作证号
                                </td>
                                <td>
                                    真实姓名
                                </td>
                                <td>
                                    联系电话
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="TableLine1" align="center">
                                <td style="background-color: #ffffff;">
                                    <asp:CheckBox ID="CheckSingle" runat="server" />
                                </td>
                                <td style="background-color: #ffffff;">
                                    <%# Eval("username")%>
                                </td>
                                <td style="background-color: #ffffff;">
                                    <%# Eval("jobnumber")%>
                                </td>
                                <td style="background-color: #ffffff;">
                                    <%# Eval("realname")%>
                                </td>
                                <td style="background-color: #ffffff;">
                                    <%# Eval("PHONE")%>
                                </td>
                                <td style="background-color: #ffffff;">
                                    <a href="UserEdit.aspx?action=update&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">编辑</a>&nbsp;
                                    <a href="../../ManageCenter/Empower.aspx?userid=<%# Eval("userid")%>&name=<%# Eval("username")%>">授权</a>&nbsp;
                                    <a href="UserCenter.aspx?action=del&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">删除
                                    </a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td>
                            <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hfdUnitName" runat="server" />
                            <asp:HiddenField ID="hfdUnitID" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
            </webdiyer:AspNetPager>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
