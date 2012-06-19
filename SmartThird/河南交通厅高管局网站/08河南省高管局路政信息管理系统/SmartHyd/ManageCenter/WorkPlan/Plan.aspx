<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="SmartHyd.ManageCenter.WorkPlan.Plan" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>事务管理</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
            <tr>
                <td style="height: 24px;">
                    <div id="menu">
                        <div class="OperateNote">
                            <span id="buttons">
                                <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="Plan.aspx">网络办公&gt;&gt;</a><a
                                    href="">事务提醒</a></span></div>
                                    <ul>
                                <li id="menu_Title0" class="normal">
                                    <a href="PlanEdit.aspx">
                                        <span id="Span1">
                                            <img src="../../Images/add.png" alt="" border="0" />新建事务
                                        </span>
                                    </a>
                                </li>
                                </ul>
                    </div>
                </td>
            </tr>
            <tr id="search_condition_panel" style="height: 24px; border-bottom: 1px solid #8cb2e2;">
                <td>
                    <table id="PatrolSearch0" width="480px" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="24" align="right">
                                <span id="PatrolSearch1">事务类型：</span>
                            </td>
                            <td height="24">
                                <asp:DropDownList ID="DDLType" runat="server">
                                <asp:ListItem Value="0">工作计划</asp:ListItem>
                                <asp:ListItem Value="1">个人事务</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td height="24" align="right">
                                <span id="PatrolSearch2">日期：</span>
                            </td>
                            <td height="24">
                                <asp:TextBox ID="txt_Time" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
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
                        BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" 
                        BorderWidth="1px" CellPadding="3"
                        Width="100%" onrowcommand="gv_log_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="TITLE" HeaderText="标题">
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
                            <asp:TemplateField HeaderText="操作选项">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%#Eval("CALENDARID") %>'>编辑</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="javascript:return confirm('确定要删除吗?');" CommandName="del" CommandArgument='<%#Eval("CALENDARID") %>'>删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="60" />
                        </asp:TemplateField>
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
                    <webdiyer:aspnetpager id="AspNetPager1" cssclass="anpager" runat="server" custominfohtml="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" pageindexboxtype="TextBox"
                        prevpagetext="上一页" showcustominfosection="Right" showpageindexbox="Auto" submitbuttontext="Go"
                        textafterpageindexbox="页" textbeforepageindexbox="转到" onpagechanging="AspNetPager1_PageChanging">
                </webdiyer:aspnetpager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
