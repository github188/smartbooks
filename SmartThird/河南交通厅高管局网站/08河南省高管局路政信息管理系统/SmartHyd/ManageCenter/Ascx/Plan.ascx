<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Plan.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Plan" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/Office.aspx"><font size="+1">网络办公&gt;&gt;</font></a> <a
                    href="../ManageCenter/Plan.aspx"><font size="+1">事务提醒&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <ul id="menu">
        <li><a href="#tabs-1">事务提醒管理</a></li>
        <li><a href="#tabs-2">添加事务提醒</a></li>
    </ul>
    <!--事务提醒管理开始-->
    <div id="tabs-1">
        <table class="edit" width="100%" cellspacing="0" cellpadding="3">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                编号
                            </th>
                            <th>
                                事务类型
                            </th>
                            <th>
                                开始时间
                            </th>
                            <th>
                                结束时间
                            </th>
                            <th>
                                日程内容
                            </th>
                            <th>
                                提醒时间
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="TableLine1">
                            <td align="center">
                                <%#Eval("CALENDARID")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARTYPE")%>
                            </td>
                            <td align="center">
                                <%#Eval("START_DATE")%>
                            </td>
                            <td align="center">
                                <%#Eval("END_DATE")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARCONTENT")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARREMIND")%>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--事务提醒管理结束-->
    <!--添加事务提醒开始-->
    <div id="tabs-2">
        <table class="TableBlock" width="100%">
            <thead>
                <tr class="TableHeader">
                    <th colspan="2">
                        新建事务提醒
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="LabType" runat="server" Text="事务类型:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="DdrType" runat="server">
                            <asp:ListItem Value="0">工作计划</asp:ListItem>
                            <asp:ListItem Value="1">个人事务</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="LbUser" runat="server" Text="所属者:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtUser" CssClass="input {required:true}" runat="server"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbstart" runat="server" Text="开始时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtStartTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="LbEnd" runat="server" Text="结束时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtEndTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbcontent" runat="server" Text="事务内容:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="input {required:true}"
                            Height="40px" Width="341px"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbprompt" runat="server" Text="提醒时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtPrompt" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加事务提醒结束-->
</div>
