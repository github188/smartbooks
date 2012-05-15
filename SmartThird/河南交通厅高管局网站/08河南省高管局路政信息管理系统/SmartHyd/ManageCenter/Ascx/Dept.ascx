<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dept.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Department" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建部门</a></li>
        <li><a href="#tabs-2">部门列表</a></li>
    </ul>
    <!--新建部门开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="2">
                        新建部门
                    </th>
                </tr>
            </thead>
            <tbody >
                <tr height="38" >
                    <td align="center">
                        <asp:Label ID="Lbdeptname" runat="server" Text="部门名称:"></asp:Label>
                        </td>
                        <td>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtDeptName" runat="server" CssClass="input  {required:true,minlength:3,maxlength:12}"></asp:TextBox>
                         <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td align="center">
                        <asp:Label ID="Lbdept" runat="server" Text="上级部门:"></asp:Label>
                        </td>
                        <td>
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                </tr>
                <tr height="38">
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Text="部门描述:"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="txtDptinfo" runat="server" CssClass="input" Height="81px" TextMode="MultiLine"
                            Width="641px"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <%--<tfoot>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" />
                    </td>
                </tr>
            </tfoot>--%>
        </table>
    </div>
    <!--新建部门结束-->
    <!--部门列表开始-->
    <div id="tabs-2">
    <table class="table" width="100%" align="center">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                部门名称
                            </th>
                            <th>
                                上级部门
                            </th>
                            <th>
                                部门描述
                            </th>
                            <th>
                                状态
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
                                <asp:Label ID="DEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("DPTNAME")%>
                            </td>
                            <td>
                                <%# Eval("PARENTID")%>
                            </td>
                            <td>
                                <%# Eval("DPTINFO")%>
                            </td>
                            <td>
                                <%# Eval("STATUS")%>
                            </td>
                            <td>
                                <a href="DeptEdit.aspx?fid=<%# Eval("DEPTID")%>">编辑</a> 
                               <%-- <a href="" id="delhref" runat="server"> 删除</a>
                                 onclick="javascript:delete_notify(<%# Eval("AFFICHEID")%>)"--%>
                                    
                                   
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
    <!--部门列表结束-->
</div>
