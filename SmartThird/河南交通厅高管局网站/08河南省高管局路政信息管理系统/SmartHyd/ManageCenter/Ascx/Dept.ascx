<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dept.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Department" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">
        <asp:Label ID="LbTabName" runat="server" Text=""></asp:Label>
        </a></li>
        <li><a href="#tabs-2">
        <asp:Label ID="LbTabName1" runat="server" Text="部门列表"></asp:Label>
        </a></li>
    </ul>
    <!--新建部门开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2">
                       <asp:Label ID="LbHeadName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <!--部门名称-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        部门名称:
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtDeptName" runat="server" CssClass="input  {required:true,minlength:1,maxlength:50}"
                            Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--上级部门-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        上级部门:
                    </td>
                    <td class="TableData">
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                </tr>
                <!--部门描述-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        部门描述:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtDptinfo" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                            Height="81px" TextMode="MultiLine" Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>

                <!--按钮栏-->
                <tr class="TableControl" align="center">
                    <td colspan="2" nowrap="nowrap">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建部门结束-->
    <!--部门列表开始-->
    <div id="tabs-2">
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
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            CssClass="anpager" CurrentPageButtonClass="cpb" >
        </webdiyer:AspNetPager>
    </div>
    <!--部门列表结束-->
</div>
