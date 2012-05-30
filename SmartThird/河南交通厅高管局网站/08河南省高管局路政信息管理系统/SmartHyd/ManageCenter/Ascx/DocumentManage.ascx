<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/TreeView.ascx" TagName="TreeView" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建公文</a></li>
        <li><a href="#tabs-2">发文管理</a></li>
    </ul>
     <!--新建发文开始-->
    <div id="tabs-1">
        <span class="big3">新建公文</span>
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2">
                        新建公文
                    </td>
                    <td>
                        收文单位
                    </td>
                </tr>
                <!--发文标题-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文标题:
                    </td>
                    <td class="TableData" style="width: 100%;">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input {required:true,minlength:1,maxlength:800}"
                            Width="500">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                    <td rowspan="8" valign="top">
                        <asp:TreeView ID="TreeViewAcceptUnit" runat="server" Height="100%" CssClass="treeview">
                        </asp:TreeView>
                    </td>
                </tr>
                <!--发文字号-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        发文字号:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSendCode" runat="server" CssClass="input {required:true,minlength:1,maxlength:80}"
                            Width="200"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--发文内容-->
                <tr>
                    <td nowrap="nowrap" class="TableData" valign="top">
                        发文内容:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" CssClass="input {required:true,minlength:1,maxlength:4000}"
                            TextMode="MultiLine">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
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
                        <asp:TextBox ID="txtSCORE" runat="server" CssClass="input {required:true,minlength:1,maxlength:3}"
                            Width="75">0</asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
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
                    <td nowrap="nowrap" class="TableData" valign="top">
                        发文状态:
                    </td>
                    <td nowrap="nowrap" class="TableData" valign="top">
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
                    <td colspan="3" nowrap="nowrap">                        
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建发文结束-->
    <!--公文管理开始-->
    <div id="tabs-2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span class="big3">发文管理</span>
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
                            </td>
                            <!--档案列表-->
                            <td nowrap="nowrap" valign="top">
                                <span class="big3">发文列表</span>
                                <!--发文列表-->
                                <table class="TableList" width="100%">
                                    <tbody>
                                        <!--标题行-->
                                        <tr class="TableHeader" align="center">
                                            <td width="235">
                                                操作选项
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
                                                        <asp:Button runat="server" CommandName="edit" Text="编辑" CssClass="BigButtonA" CommandArgument='<%#Eval("id")%>' />
                                                        <asp:Button runat="server" CommandName="delete" Text="删除" CssClass="BigButtonA" CommandArgument='<%#Eval("id")%>' />
                                                        <asp:Button runat="server" CommandName="checkout" Text="结贴" CssClass="BigButtonA"
                                                            CommandArgument='<%#Eval("id")%>' />
                                                        <asp:Button runat="server" CommandName="detail" Text="详情" CssClass="BigButtonA" CommandArgument='<%#Eval("id")%>' />
                                                    </td>
                                                    <td align="left">
                                                        <a href='DocumentReply.aspx?id=<%#Eval("id") %>'>
                                                            <%#Eval("title")%>
                                                        </a>
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
