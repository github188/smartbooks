<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Plan.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Plan" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建日程</a></li>
        <li><a href="#tabs-2">日程管理</a></li>
    </ul>
    <!--新建日程开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="2">
                        新建日程
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="LabType" runat="server" Text="事务类型:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:DropDownList ID="DdrType" runat="server">
                            <asp:ListItem Value="0">工作计划</asp:ListItem>
                            <asp:ListItem Value="1">个人事务</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbUser" runat="server" Text="所属者:"></asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="TxtUser" CssClass="input {required:true}" runat="server"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbstart" runat="server" Text="开始时间:"></asp:Label>
                        <asp:TextBox ID="txtStartTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbEnd" runat="server" Text="结束时间:"></asp:Label>
                        <asp:TextBox ID="txtEndTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbcontent" runat="server" Text="事务内容:"></asp:Label>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbprompt" runat="server" Text="提醒时间:"></asp:Label>
                        <asp:TextBox ID="txtPrompt" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td style="text-align: center;">
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--新建日程结束-->
    <!--日程管理开始-->
    <div id="tabs-2">
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
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <%#Eval("CALENDARID")%>
                            </td>
                            <td>
                                <%#Eval("CALENDARTYPE")%>
                            </td>
                            <td>
                                <%#Eval("START_DATE")%>
                            </td>
                            <td>
                                <%#Eval("END_DATE")%>
                            </td>
                            <td>
                                <%#Eval("CALENDARCONTENT")%>
                            </td>
                            <td>
                                <%#Eval("CALENDARREMIND")%>
                            </td>
                            <td>
                                <a href="#">编辑</a> <a href="#">删除</a>
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
    <!--日程管理结束-->
</div>
