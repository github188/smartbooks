<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Empower.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Empower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ui id="menu">
       <li><a href="#tabs_1">用户授权</a></li>
    </ui>
    <div id="tabs_1">
        <table class="table" width="100%" align="center">
            <asp:Repeater ID="RptAffiche" runat="server">
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
                                <asp:CheckBox ID="CheckSingle" runat="server" />
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
                                <a href="javascript:Rolelist()">分配角色</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="2">
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
     <!--dialog窗口开始-->
        <div id="dialog" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="title" class="title">权限列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                    <tr>
                        <td colspan="2">
                            分配用户角色
                        </td>
                    </tr>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:TreeView ID="TvRole" runat="server">
                        </asp:TreeView>
                    </td>
                </tr>
                   <tr>
                        <td colspan="2">
                            请选择角色菜单
                        </td>
                    </tr>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:TreeView ID="Tvmenu" runat="server">
                        </asp:TreeView>
                    </td>
                </tr>
                   <tr>
                        <td colspan="2">
                            请选择菜单动作
                        </td>
                    </tr>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:TreeView ID="TvAction" runat="server">
                        </asp:TreeView>
                    </td>
                </tr>
            </table>
            <form name="form1" method="post" action="">
            <div id="send_body" class="body">
            </div>
            <div id="footer" class="footer">
             <%--   <input type="hidden" name="dept_str" id="dept_str" />
                <input type="hidden" name="sid" id="sid" />
                <input class="BigButton" type="submit" value="确定" />
                <input class="BigButton" type="button" value="关闭" />--%>
                <asp:Button ID="BtnEmp" runat="server" Text="授权" OnClick="BtnEmp_Click" />
            </div>
            </form>
        </div>
        <!--dialog窗口结束-->
</div>
