<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/TreeView.ascx" tagname="TreeView" tagprefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-2">公文管理</a></li>
        <li><a href="#tabs-3">详细信息</a></li>
    </ul>
    
    <!--公文管理开始-->
    <div id="tabs-2">
        <!--公文分类-->
        <table class="TableList" width="100%">
            <tbody>
                <tr class="TableHeader">
                    <td width="250">档案分类</td>
                    <td>公文列表</td>
                </tr>
                <tr>
                    <td nowrap="nowrap" valign="top">
                        <uc1:TreeView ID="TreeView1" runat="server" TreeEnum="DocuemntClass" />
                    </td>
                    <td nowrap="nowrap" valign="top">
                        <table class="TableList" width="100%">
                            <tbody>
                                <!--标题行-->
                                <tr class="TableHeader" align="center">
                                    <td>发文标题</td>
                                    <td>发文字号</td>
                                    <td>发文时间</td>
                                    <td>发文分值</td>
                                    <td>发文状态</td>
                                </tr>
                
                                <!--项集合-->
                                <asp:Repeater ID="repArticleList" runat="server">
                                    <ItemTemplate>
                                        <tr class="TableLine1">
                                            <td><%#Eval("title")%></td>
                                            <td><%#Eval("sendcode")%></td>
                                            <td><%#Eval("TIMESTAMP")%></td>
                                            <td><%#Eval("score")%></td>
                                            <td><%#Eval("status")%></td>
                                        </tr>
                                    </ItemTemplate>                    
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>

        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
            TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager2_PageChanging" CssClass="anpager"
            CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--公文管理结束-->

    <!--详细信息开始-->
    <div id="tabs-3">
        <asp:Repeater ID="repList" runat="server">
            <HeaderTemplate>
                <table class="TableList" width="961">
                    <tbody>
                        <!--首选行-->
                        <tr class="TableHeader">
                            <td width="163">
                                回复:20|查看：40
                            </td>
                            <td width="798" style="text-align: left; padding-left: 6px;">
                                [公告]关于XXXX放假的通知
                            </td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <!--item项(根据ID获取帖子信息 和 回帖信息)-->
                <!--标题行-->
                <tr class="TableControl">
                    <td width="163" align="center">
                        <%#Eval("dptname")%>
                    </td>
                    <td width="798">
                        <span style="float: left;">发表于：<%#Eval("TIMESTAMP")%></span><span style="float: right;
                            margin: 0px 6px 0px 6px;">楼主</span> <span style="float: right; margin: 0px 6px 0px 6px;">
                                得分:<%#Eval("score")%></span><span style="float: right; margin: 0px 6px 0px 6px;
                                    color: #B00;"><%#Eval("status")%></span></td>
                </tr>
                <!--内容框-->
                <tr>
                    <td valign="top" width="163" style="background-color: #E7F0FB;">
                        <img style="width: 111px; height: 122px; margin: 10px 20px 10px 20px; padding: 6px;
                            background-color: #FFFFFF;" src="../../Images/user-ico.jpg" />
                        <table style="color: #444; height: 20px;">
                            <tr>
                                <td colspan="2" align="center">
                                    <%#Eval("username")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    工作证号
                                </td>
                                <td>
                                    <%#Eval("jobnumber")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    联系电话
                                </td>
                                <td>
                                    <%#Eval("phone")%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="758" valign="top" style="padding: 20px; overflow: hidden;">
                        <h2>
                            <%#Eval("title")%></h2>
                        <h5>
                            <%#Eval("sendcode")%></h5>
                        <div>
                            <%#Eval("content")%></div>
                        <div style="color: #002D93;">
                            <span>下载附件:</span> <a href='<%#Eval("annex")%>'>
                                <%#Eval("title")%></a>
                        </div>
                    </td>
                </tr>
                <!--操作栏-->
                <tr class="TableControl">
                    <td nowrap="nowrap" width="163" align="center">
                        <a href="#">发送消息</a> <a href="#">发送邮件</a>
                    </td>
                    <td width="798">
                        <asp:Button ID="btnReply" runat="server" Text="回复" CssClass="BigButtonA" />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="BigButtonA" />
                        <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="BigButtonA" />
                    </td>
                </tr>
                <tr style="height: 6px;"></tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
            TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging" CssClass="anpager"
            CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--详细信息结束-->
</div>
