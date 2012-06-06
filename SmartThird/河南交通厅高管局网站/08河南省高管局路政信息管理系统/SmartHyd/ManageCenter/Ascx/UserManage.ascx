<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+1">系统管理&gt;&gt;</font></a>
                <a href="../ManageCenter/UserManage.aspx"><font size="+1">用户管理&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <div id="content">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td width="15%">
                        部门
                    </td>
                    <td colspan="2">
            用户
                    </td>
                </tr>
                <tr>
                    <td rowspan="8" valign="top">
                        <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeview">
                        </asp:TreeView>
                    </td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <td>
                                <table class="TableList" width="100%">
                                    <tbody>
                                        <asp:Repeater ID="repList" runat="server">
                                            <HeaderTemplate>
                                                <tr class="TableHeader" align="center">
                                                    <td>
                                                        <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                                                    </td>
                                                    <td>
                                                        操作
                                                        <td>
                                                            工作证号
                                                        </td>
                                                        <td>
                                                            登录账号
                                                        </td>
                                                        <td>
                                                            真实姓名
                                                        </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="TableLine1" align="center">
                                                    <td>
                                                        <asp:CheckBox ID="CheckSingle" runat="server" />
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <image src="../../Images/edit_big.jpg" alt="编辑"></image>
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <%# Eval("jobnumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("username")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("username")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="labEmpty" runat="server" Text="该部门下暂无用户" Visible="<%#repList.Items.Count==0 %>"></asp:Label>
                                                    </td>
                                                </tr>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                                    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                                    PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
                                </webdiyer:AspNetPager>
                            </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </tr>
            </tbody>
        </table>
    </div>
</div>
