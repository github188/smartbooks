<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentReply.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentReply" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <span class="big3">已发送到以下单位:</span>
        <table class="TableList" width="100%">
            <tbody>
                <tr class="TableHeader" align="center">
                    <td width="230">
                        单位名称
                    </td>                    
                    <td width="75">
                        查阅状态
                    </td>    
                    <td>
                        回文标题
                    </td>
                    <td width="170">
                        回文字号
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
                            <td>
                                <%#Eval("isread")%>
                            </td>
                            <td align="left">
                                <a href='DocumentDetail.aspx?id=<%#Eval("ID") %>'>
                                    <%#Eval("title")%>
                                </a>
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
