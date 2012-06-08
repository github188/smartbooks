<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chat.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Chat" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
    <tr>
        <td style="height: 24px;">
            <div id="menu">
                <div class="OperateNote">
                    <span id="buttons">
                        <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="">网络办公&gt;&gt;</a>即时通讯</span></div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <a href="../Chat.aspx?state=0">未读消息</a>&nbsp;&nbsp;<a href="../Chat.aspx?state=1">已读消息</a>
        </td>
    </tr>
    <tr>
        <td>
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
                                <td>
                                    操作
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
                            <td>
                                <a href="">
                                    <image src="" alt="">查看</image>
                                </a><a href="MessageSend.aspx?sendid=<%#Eval("SENDER")%>">
                                    <image src="" alt="">回复</image>
                                </a><a href="">
                                    <image src="" alt="">删除</image>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
    PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
</webdiyer:AspNetPager>
