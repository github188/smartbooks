<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysManager.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.SysManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">部门管理</a></li>
        <li><a href="#tabs-2">用户管理</a></li>
        <li><a href="#tabs-3">用户授权</a></li>
        <li><a href="#tabs-4">日志管理</a></li>
    </ul>
    <!--部门管理开始-->
    <div id="tabs-1">
        <!--按钮栏-->
        <div>
            <asp:Button ID="btnAddDept" runat="server" Text="新建部门" CssClass="BigButtonA" 
                OnClick="btnAddDept_Click" style="width: 78px" />
            <asp:Button ID="btnSearchDept" runat="server" Text="查询" CssClass="BigButtonA" OnClick="btnSearchDept_Click" />
        </div>
        <!--部门列表开始-->
        <table class="TableList" width="100%">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <tbody>
                        <tr class="TableHeader" align="center">
                            <td>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </td>
                            <td>
                                部门名称
                            </td>
                            <td>
                                上级部门
                            </td>
                            <td>
                                部门描述
                            </td>
                            <td>
                                状态
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="TableLine1">
                        <td align="center">
                            <asp:CheckBox ID="CheckSingle" runat="server" />
                            <asp:Label ID="DEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        </td>
                        <td align="center">
                            <%# Eval("DPTNAME")%>
                        </td>
                        <td align="center">
                            <%# Eval("PARENTID")%>
                        </td>
                        <td align="center">
                            <%# Eval("DPTINFO")%>
                        </td>
                        <td align="center">
                            <%# Eval("STATUS")%>
                        </td>
                        <td align="center">
                            <a href="Dept.aspx?Fid=<%# Eval("DEPTID")%>">编辑</a>
                            <%-- <a href="" id="delhref" runat="server"> 删除</a>
                                 onclick="javascript:delete_notify(<%# Eval("AFFICHEID")%>)"--%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
        <!--部门列表结束-->
    </div>
    <!--部门管理结束-->
    <!--用户管理开始-->
    <div id="tabs-2">
        <!--用户列表开始-->
        <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="repList" runat="server">
                    <HeaderTemplate>
                        <tr class="TableHeader" align="center">
                            <td>
                                所属部门
                            </td>
                            <td>
                                工作证号
                            </td>
                            <td>
                                登录账号
                            </td>
                            <td>
                                联系电话
                            </td>
                            <td>
                                用户性别
                            </td>
                            <td>
                                政治面貌
                            </td>
                            <td>
                                最高学历
                            </td>
                            <td>
                                所学专业
                            </td>
                            <td>
                                出生年月
                            </td>
                            <td>
                                身份证号
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td>
                                <%# Eval("dptname") %>
                            </td>
                            <td>
                                <%# Eval("jobnumber")%>
                            </td>
                            <td>
                                <%# Eval("username")%>
                            </td>
                            <td>
                                <%# Eval("phone")%>
                            </td>
                            <td>
                                <%# Eval("sex")%>
                            </td>
                            <td>
                                <%# Eval("face")%>
                            </td>
                            <td>
                                <%# Eval("DEGREE")%>
                            </td>
                            <td>
                                <%# Eval("prof")%>
                            </td>
                            <td>
                                <%# Eval("birthday")%>
                            </td>
                            <td>
                                <%# Eval("idnumber")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager2_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
        <!--用户列表结束-->
    </div>
    <!--用户管理结束-->
    <!--用户授权开始-->
    <div id="tabs-3">
    </div>
    <!--用户授权结束-->
    <!--日志管理开始-->
    <div id="tabs-4">
        <!--日志列表开始-->
        <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="RptListLog" runat="server">
                    <HeaderTemplate>
                        <tr class="TableHeader" align="center">
                            <td>
                                日志编号
                            </td>
                            <td>
                                日志类型
                            </td>
                            <td>
                                创建时间
                            </td>
                            <td>
                                日志内容
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td>
                                <%# Eval("LOGID")%>
                            </td>
                            <td>
                                <%# Eval("LOGTYPE")%>
                            </td>
                            <td>
                                <%# Eval("CREATEDATE")%>
                            </td>
                            <td>
                                <%# Eval("DESCRIPTION")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager3" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager3_PageChanging">
        </webdiyer:AspNetPager>
        <!--日志列表结束-->
    </div>
    <!--日志管理结束-->
</div>
