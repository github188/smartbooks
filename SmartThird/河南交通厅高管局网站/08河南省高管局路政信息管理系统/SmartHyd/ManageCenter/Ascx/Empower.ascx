<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Empower.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Empower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">用户列表</a></li>
        <li><a href="#tabs-2">用户授权</a></li>
    </ul>
    <!--用户列表开始-->
    <div id="tabs-1">
        <table class="edit" width="100%" align="center" cellpadding="0">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                用户名
                            </th>
                            <%-- <th>
                                角色
                            </th>--%>
                            <th>
                                所属部门
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckSingle" runat="server"/>
                                <asp:Label ID="LBUSERID" runat="server" Text='<%#Eval("USERID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("USERNAME")%>
                            </td>
                            <%--  <td>
                               <%#GetRole((decimal)Eval("USERID"))%>
                            </td>--%>
                            <td>
                                <%#GetDept((decimal)Eval("DEPTID"))%>
                            </td>
                            <td>
                             <%--    <a href="javascript:Rolelist()">分配角色</a>--%>
                               <a href="#tabs-2">授权</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="4">
                                <%--分页--%>
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--用户列表结束-->
    <!--用户授权开始-->
    <div id="tabs-2">
        <table width="95%" class="TableBlock" align="center">
            <tr>
                <td colspan="2" class="TableHeader">
                    请选择用户角色
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableData" align="center">
                    <asp:RadioButtonList ID="RBLRole" runat="server">
                    </asp:RadioButtonList>
                    <%--<asp:TreeView ID="TvRole" runat="server">
                        </asp:TreeView>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableHeader">
                    请选择角色菜单
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableData" align="center">
                    <asp:TreeView ID="Tvmenu" runat="server">
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableHeader">
                    请选择菜单动作
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableData" align="center">
                    <asp:TreeView ID="TvAction" runat="server">
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td><%--<asp:Button ID="BtnEmp" runat="server" Text="授权" OnClick="BtnEmp_Click" />--%></td>
            </tr>
        </table>
    </div>
    <!--用户授权结束-->
   
</div>
