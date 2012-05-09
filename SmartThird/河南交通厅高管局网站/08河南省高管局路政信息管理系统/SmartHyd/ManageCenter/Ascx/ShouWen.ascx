<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShouWen.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Shouwen" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">收文管理</a></li>
        <li><a href="#tabs-2">收文批复</a></li>
    </ul>
    <!--收文管理开始-->
    <div id="tabs-1">
        <table class="table">
            <asp:Repeater ID="RptShouwen" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="Checkallshouwen" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                原号
                            </th>
                            <th>
                                来文机关
                            </th>
                            <th>
                                来文时间
                            </th>
                            <th>
                                办理进度
                            </th>
                            <th>
                                办理结果
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
                                <asp:CheckBox ID="CheckSingleShouwen" runat="server" />
                                <asp:Label ID="SID" runat="server" Text='<%#Eval("SID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("S_TITLE")%>
                            </td>
                            <td>
                                <%# Eval("S_NUMBERS")%>
                            </td>
                            <td>
                                <%# Eval("S_ORGAN")%>
                            </td>
                            <td>
                                <%# Eval("S_FROMDATE")%>
                            </td>
                             <td>
                                <%# Eval("S_HANDLEPROGRESS")%>
                            </td>
                            <td>
                                <%# Eval("S_RESULT")%>
                            </td>
                            <td>
                                <a href="<%# Eval("SID")%>">编辑</a> <a href="<%# Eval("SID")%>">删除</a>
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
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" 
            onpagechanging="AspNetPager1_PageChanging" >
        </webdiyer:AspNetPager>
    </div>
    <!--收文管理结束-->
    <!--收文批复开始-->
    <div id="tabs—2">
    <table>
       <tr><td>dgsdf fgd ss</td></tr>
    </table>
    </div>
    <!--收文批复开始-->
</div>
