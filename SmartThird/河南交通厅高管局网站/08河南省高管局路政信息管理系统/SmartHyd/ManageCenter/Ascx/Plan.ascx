<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Plan.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Plan" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
<div id="tab">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="Div1">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="../ManageCenter/Office.aspx">网络办公&gt;&gt;</a><a href="">事务提醒</a></span></div>
                </div>
            </td>
        </tr>
        <tr id="search_condition_panel" style="height: 24px; border-bottom: 1px solid #8cb2e2;">
            <td>
                <table id="PatrolSearch0" width="480px" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="24" align="right">
                            <span id="PatrolSearch1">起始时间：</span>
                        </td>
                        <td height="24">
                            <asp:TextBox ID="txt_startTime" runat="server" class="Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td height="24" align="right">
                            <span id="PatrolSearch2">截止时间：</span>
                        </td>
                        <td height="24">
                            <asp:TextBox ID="txt_endTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td width="80" height="24" align="center">
                            <asp:Button ID="btn_ok" runat="server" Text="" CssClass="btn_search" OnClick="btn_ok_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="gv_log" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" BorderWidth="1px" CellPadding="3"
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="CALENDARID" HeaderText="事务编号">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CALENDARTYPE" HeaderText="事务类型">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="START_DATE" HeaderText="开始时间">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="END_DATE" HeaderText="结束时间">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CALENDARCONTENT" HeaderText="事务内容" />
                        <asp:BoundField DataField="CALENDARREMIND" HeaderText="提醒时间">
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
 
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
