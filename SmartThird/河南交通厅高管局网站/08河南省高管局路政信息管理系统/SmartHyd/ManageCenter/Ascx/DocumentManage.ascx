<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/TreeView.ascx" TagName="TreeView" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">公文管理</a></li>
    </ul>
    <!--公文管理开始-->
    <div id="tabs-1">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<span class="big3">发文管理</span>--%>
                <!--公文分类-->
                <table class="TableList" width="100%">
                    <tbody>
                        <tr class="TableHeader">
                            <td width="250">
                                档案分类
                            </td>
                            <td>
                                公文列表
                            </td>
                        </tr>
                        <tr>
                            <!--档案分类-->
                            <td nowrap="nowrap" valign="top">
                                <uc1:TreeView ID="TreeView1" runat="server" TreeEnum="DocuemntClass" />
                                <!--分类按钮工具栏-->
                                <div>
                                    <asp:Button ID="btnDocumentType" runat="server" Text="添加" 
                                        CssClass="BigButtonA" onclick="btnDocumentType_Click" />
                                </div>
                            </td>
                            <!--档案列表-->
                            <td nowrap="nowrap" valign="top">
                                <span class="big3">操作:</span>
                                <asp:Button ID="Button1" runat="server" Text="编辑" CssClass="BigButtonA" />
                                <asp:Button ID="Button2" runat="server" Text="删除" CssClass="BigButtonA" />
                                <asp:Button ID="Button3" runat="server" Text="结贴" CssClass="BigButtonA"/>
                                <asp:Button ID="Button4" runat="server" Text="详情" CssClass="BigButtonA" />
                                <asp:Button ID="Button5" runat="server" Text="生成" CssClass="BigButtonA" />
                                <!--发文列表-->
                                <table class="TableList" width="100%">
                                    <tbody>
                                        <!--标题行-->
                                        <tr class="TableHeader" align="center">
                                            <td>
                                                选择
                                            </td>
                                            <td>
                                                公文标题
                                            </td>
                                            <td width="180">
                                                公文字号
                                            </td>
                                            <td width="150">
                                                日期时间
                                            </td>
                                            <td width="75">
                                                考核分值
                                            </td>
                                            <td width="75">
                                                公文状态
                                            </td>
                                        </tr>
                                        <!--项集合-->
                                        <asp:Repeater ID="reppublishlist" runat="server" OnItemCommand="reppublishlist_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="TableLine1" align="center">
                                                    <td>
                                                        <asp:CheckBox runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <a href='DocumentReply.aspx?id=<%#Eval("id") %>'><%#Eval("title")%></a>
                                                    </td>
                                                    <td>
                                                        <%#Eval("sendcode")%>
                                                    </td>
                                                    <td>
                                                        <%#Eval("TIMESTAMP")%>
                                                    </td>
                                                    <td>
                                                        <%#Eval("score")%>
                                                    </td>
                                                    <td>
                                                        <%#Eval("status")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <!--分页控件-->
                                        <tr class="TableControl" align="center">
                                            <td colspan="6">
                                                <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                                                    PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                                                    TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager2_PageChanging" CssClass="anpager"
                                                    CurrentPageButtonClass="cpb">
                                                </webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--公文管理结束-->
</div>
