<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chat.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Chat" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
<ul>
     <li><a href="#tabs-1">发送消息</a></li>
     <li><a href="#tabs-2">消息列表</a></li>
</ul>
<!--发送消息开始-->
<div id="tabs-1">
    <table class="TableHeader" width="600">
        <tr>
            <td class="left">
            </td>
            <td>
                发送消息
            </td>
            <td class="right">
            </td>
        </tr>
    </table>
    <table class="TableBlock no-top-border" width="600">
        <tr class="TableData">
            <td>
                收信人：
            </td>
            <td>
                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1"/>
                <asp:TextBox ID="TxtTouser" runat="server" CssClass="input"></asp:TextBox>
               <%--   <textarea cols="55" name="TO_NAME" rows="2" class="BigStatic" wrap="yes"></textarea>
              <a href="javascript:;" class="orgAdd" onclick="SelectUser('2','TO_UID', 'TO_NAME', '', '', '1')">
                    添加</a> <a href="javascript:;" class="orgClear" onclick="ClearUser('TO_UID', 'TO_NAME')">
                        清空</a>--%>
            </td>
        </tr>
       <%-- <tr class="TableData">
            <td>
                发送时间：
            </td>
            <td>
                <input type="text" id="SEND_TIME" name="SEND_TIME" size="20" maxlength="19" class="BigInput"/>
                为空则即时发送
            </td>
        </tr>--%>
        <tr class="TableData">
            <td colspan="2">
                <textarea id="Message" name="CONTENT" rows="8" cols="60" runat="server"></textarea>
            </td>
        </tr>
        <tr class="TableFooter">
            <td colspan="2" align="center">
                <div style="position: relative; width: 100%;">
                    <span id="words_count"></span>
                    <input type="hidden" value="" name="SMS_ID_REPLAY"/>
                </div>
            </td>
        </tr>
    </table>
    </div>
    <!--发送消息结束-->
    <!--消息列表开始-->
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
                                发送人
                            </td>
                            <td>
                                消息 
                            </td>
                            <td>
                               发送时间
                            </td>
                            <td>
                                状态
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="TableLine1">
                        <td>
                            <asp:CheckBox ID="CheckSingle" runat="server" />
                            <asp:Label ID="MESSAGEID" runat="server" Text='<%#Eval("MESSAGEID") %>' Visible="false"></asp:Label>
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        </td>
                        <td>
                            <%# getUserName(Convert.ToInt32(Eval("SENDER")))%>
                        </td>
                        <td>
                           <%# Eval("MESSAGEBODY")%>
                        </td>
                        <td>
                             <%# Eval("SENDDATE")%>
                        </td>
                        <td>
                            <%# TransState((decimal)Eval("STATE"))%>
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
    </div>
    <!--消息列表结束-->
</div>
