<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Affiche.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Affiche" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">公告管理</a></li>
        <li><a href="#tabs-2">新建公告</a></li>
    </ul>
    <!--公告管理开始-->
    <div id="tabs-1">
            <table class="table" width="95%" align="center">             <asp:Repeater ID="RptAffiche" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="CheckallAffiche" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                发布人
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                创建时间
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
                                <asp:CheckBox ID="CheckSingleAffiche" runat="server" />
                                <asp:Label ID="AFFICHEID" runat="server" Text='<%#Eval("AFFICHEID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("AFFICHER")%>
                            </td>
                            <td>
                                <%# Eval("AFFICHETITLE")%>
                            </td>
                            <td>
                                <%# Eval("AFFICHEDATE")%>
                            </td>
                             <td>
                                <%# Eval("STATES")%>
                            </td>
                            <td>
                                <a href="<%# Eval("AFFICHEID")%>">编辑</a> <a href="<%# Eval("AFFICHEID")%>">删除</a>
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
                onpagechanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--公告管理结束-->
    <!--新建公告开始-->
    <div id="tabs-2">
       daf
    </div>
    <!--新建公告结束-->
</div>
