<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentReply.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentReply" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">收文列表</a></li>
    </ul>
    <!--回文列表开始-->
    <div id="tabs-1">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span class="big3">收文列表</span>
                <table class="TableList" width="100%">
                    <tbody>
                        <tr class="TableHeader" align="center">
                            <td width="230">
                                部门名称
                            </td>
                            <td>
                                收文标题
                            </td>
                            <td width="75">
                                查阅状态
                            </td>
                            <td width="170">
                                查阅时间
                            </td>
                            <td width="170">
                                收文字号
                            </td>
                            <td width="170">
                                回复时间
                            </td>
                        </tr>
                        <!--回文列表-->
                        <asp:Repeater ID="repReplyList" runat="server">
                            <ItemTemplate>
                                <tr class="TableLine1" align="center">
                                    <td align="left">
                                        <%#Eval("dptname")%>
                                    </td>
                                    <td align="left">
                                        <a href='DocumentDetail.aspx?id=<%#Eval("articleid") %>'>
                                            <%#Eval("title")%>
                                        </a>
                                    </td>
                                    <td>
                                        <%#Eval("isread")%>
                                    </td>
                                    <td>
                                        <%#Eval("readtime")%>
                                    </td>
                                    <td>
                                        <%#Eval("sendcode")%>
                                    </td>
                                    <td>
                                        <%#Eval("TIMESTAMP")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                    PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                    TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging" CssClass="anpager"
                    CurrentPageButtonClass="cpb">
                </webdiyer:AspNetPager>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!--回文列表结束-->
</div>
