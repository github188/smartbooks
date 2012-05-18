<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建发文</a></li>
        <li><a href="#tabs-2">发文浏览</a></li>
        <li><a href="#tabs-3">发文管理</a></li>
    </ul>
    <!--新建发文开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2">
                        添加公文
                    </td>
                </tr>
                <!--发文标题-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文标题:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="333"></asp:TextBox>
                    </td>
                </tr>
                <!--发文字号-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文字号:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSendCode" runat="server" CssClass="input" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <!--发文内容-->
                <tr>
                    <td nowrap="nowrap" class="TableData" valign="top">
                        发文内容:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <!--附件文档-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        附件文档:
                    </td>
                    <td class="TableData">
                        <asp:FileUpload ID="fileUpAnnex" runat="server" CssClass="input" />
                    </td>
                </tr>
                <!--所属分类-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        所属分类:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlTypeId" runat="server" CssClass="input">
                            <asp:ListItem Text="公告通知" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="年终考核" Value="0"></asp:ListItem>
                            <asp:ListItem Text="浮动考核" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <!--发文分值-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文分值:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSCORE" runat="server" CssClass="input" Width="25">0</asp:TextBox>
                    </td>
                </tr>
                <!--允许回复-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        允许回复:
                    </td>
                    <td class="TableData">
                        <asp:RadioButtonList ID="rdoIsReply" runat="server" RepeatDirection="Horizontal"
                            CssClass="input">
                            <asp:ListItem Text="允许回复" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="不允许回复" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <!--发文状态-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文状态:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                            <asp:ListItem Text="0.已审核√" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="1.未审核×" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2.草稿箱×" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3.已删除×" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4.已隐藏×" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5.已结贴√" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <!--操作按钮-->
                <tr class="TableControl" align="center">
                    <td colspan="2" nowrap="nowrap">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" />
                        <asp:Button ID="btnCancel" runat="server" Text="返回" CssClass="BigButtonA" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建发文结束-->
    <!--发文浏览开始-->
    <div id="tabs-2">
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
                        <span style="float: left;">发表于：<%#Eval("TIMESTAMP")%></span> <span style="float: right;
                            margin: 0px 6px 0px 6px;">楼主</span> <span style="float: right; margin: 0px 6px 0px 6px;">
                                得分:<%#Eval("score")%></span> <span style="float: right; margin: 0px 6px 0px 6px;
                                    color: #B00;">
                                    <%#Eval("status")%></span>
                    </td>
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
                <tr style="height: 6px;">
                </tr>
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
    <!--发文浏览结束-->
    <!--发文管理开始-->
    <div id="tabs-3">
        <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="repArticleList" runat="server">
                    <HeaderTemplate>
                        <!--标题行-->
                        <tr class="TableHeader" align="center">
                            <td>
                                标题
                            </td>
                            <td>
                                字号
                            </td>
                            <td>
                                时间
                            </td>
                            <td>
                                分值
                            </td>
                            <td>
                                状态
                            </td>
                            <td>
                                附件
                            </td>
                            <!--操作行-->
                            <td>
                                操作
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1">
                            <td><%#Eval("title")%></td>
                            <td><%#Eval("sendcode")%></td>
                            <td><%#Eval("TIMESTAMP")%></td>
                            <td><%#Eval("score")%></td>
                            <td><%#Eval("status")%></td>
                            <td><%#Eval("annex")%></td>
                            <!--操作行-->
                            <td>
                                编辑/删除
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <!--操作按钮栏-->
                        <tr class="TableControl">
                            <td colspan="7">
                                <asp:Button ID="btnDownload" runat="server" Text="编辑" CssClass="BigButtonA" />
                                <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="BigButtonA" />
                            </td>
                        </tr>
                    </FooterTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
            TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager2_PageChanging" CssClass="anpager"
            CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--发文管理结束-->
</div>
