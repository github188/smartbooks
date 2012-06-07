<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chat.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Chat" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<style type="text/css">
    form
    {
        padding: 0px;
        margin: 0px;
    }
    table
    {
        border-collapse: collapse;
    }
    
    #menu .OperateNote
    {
        float: left;
        width: auto;
        font-weight: bold;
        font-size: 12px;
        font-family: 微软雅黑;
        color: #065c8f;
        padding-left: 5px;
    }
    
    #buttons *
    {
        vertical-align: middle;
        text-align: center;
    }
    
    #buttons *
    {
        vertical-align: middle;
    }
    img
    {
        border: 0px;
    }
    
    #menu ul
    {
        margin: 0;
        padding-top: 2px;
        height: 20px;
        float: right;
    }
    
    #menu .normal
    {
        display: block;
        text-align: center;
        color: #065c8f;
        font-weight: bold;
        background: url('../../images/btn_hover1.png') no-repeat;
        width: 80px;
        height: 20px;
        line-height: 20px;
        overflow: hidden;
        font-size: 12px;
        text-decoration: none;
    }
    #menu ul li
    {
        width: 80px;
        line-height: 20px;
        float: left;
        margin-left: 5px;
        margin-right: 30px;
    }
    
    ul li
    {
        margin: 0;
        padding: 0;
        border: 0;
        list-style: none;
    }
    #menu .normal a
    {
        display: block;
        text-align: center;
        color: #065c8f;
        font-size: 12px;
        font-weight: bold;
        background: url('../../images/btn_hover1.png') no-repeat;
        width: 80px;
        height: 20px;
        line-height: 20px;
        overflow: hidden;
        text-decoration: none;
    }
    
    a:link
    {
        color: #0466cb;
        text-decoration: none;
    }
    
    a
    {
        outline: none;
    }
    a img
    {
        border: 0px;
    }
    
    #PatrolSearch
    {
        font-size: 12px;
        font-weight: bold;
    }
    .txtboxstyle
    {
        border: none;
        border-bottom: 1px solid #065c8f;
        border-top: 1px solid #065c8f;
        border-left: 1px solid #065c8f;
        border-right: 1px solid #065c8f;
    }
    
    .controlstyle
    {
        width: 100%;
    }
    
    .btn_search
    {
        border-style: none;
        border-color: inherit;
        border-width: medium;
        width: 70px;
        height: 24px;
        line-height: 24px;
        background: url('../../Images/btn_search.gif') no-repeat;
        margin: 0px;
        padding: 0px;
        cursor: hand;
    }
    
    .anpager
    {
        margin-top: 10px;
        font-size: 12px;
    }
    .anpager a
    {
        background: #FFFFFF none repeat scroll 0 0;
        border: 1px solid #CCCCCC;
        color: #1F3A87;
        margin: 5px 4px 0 0;
        padding: 4px 5px 0;
        text-decoration: none;
    }
    .anpager .cpb
    {
        background: #1F3A87 none repeat scroll 0 0;
        border: 1px solid #CCCCCC;
        color: #FFFFFF;
        font-weight: bold;
        margin: -6px 4px 0 0;
        padding: 0px 5px 0;
        width: 20px;
        height: 21px;
    }
    
    #PatrolSearch0
    {
        font-size: 12px;
        font-weight: bold;
    }
</style>
<div id="tab">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td style="height: 24px;">
                        <div id="menu">
                            <div class="OperateNote">
                                <span id="buttons">
                                    <img src="../../Images/branch.png" border="0" />当前位置：网络办公&gt;&gt;即时通讯</span></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="Chat.aspx?state=0">未读消息</a>&nbsp;&nbsp;<a href="Chat.aspx?state=1">已读消息</a>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
