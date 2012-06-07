<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysLog.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.SysLog" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
                <tr>
                    <td style="height:24px;">
                        <div id="menu">
                            <div class="OperateNote"><span id="buttons"><img src="../Images/branch.png" border="0" />当前位置：系统管理》系统日志</span></div>
                        </div>
                    </td>
                </tr>
                <tr id="search_condition_panel" style="height:24px;border-bottom:1px solid #8cb2e2;">
                    <td >
                        <table id="PatrolSearch" width="480px" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td height="24" align="right"><span id="PatrolSearch">起始时间：</span></td>
                            <td height="24">
                                <asp:TextBox ID="txt_startTime" runat="server" class="Wdate" Width="120"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"
></asp:TextBox></td>
                            <td height="24" align="right"><span id="PatrolSearch">截止时间：</span></td>
                            <td height="24"><asp:TextBox ID="txt_endTime" runat="server"  Width="120" class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"
></asp:TextBox></td>
                            <td width="80" height="24" align="center">
                                <asp:Button ID="btn_ok" runat="server" Text="" CssClass="btn_search" 
                                    onclick="btn_ok_Click" /></td>
                          </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                    <td valign="top">
                        <asp:GridView ID="gv_log" runat="server" AutoGenerateColumns="False" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" BorderWidth="1px" 
                            CellPadding="3" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="LOGID" HeaderText="日志编号" >
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LOGTYPE" HeaderText="日志类型" >
                                 <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CREATEDATE" HeaderText="创建时间">
                                 <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DESCRIPTION" HeaderText="日志内容" />
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


