﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accept.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.Accept" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收文管理</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" border="0" />当前位置：档案管理 > 收文管理 </span>
                    </div>
                </div>
            </td>
        </tr>
        <tr id="search_condition_panel" style="height: 24px; border-bottom: 1px solid #8cb2e2;">
            <td>
                <table id="PatrolSearch" width="480px" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="24" align="right">
                            <span id="PatrolSearch">起始时间：</span>
                        </td>
                        <td height="24">
                            <asp:TextBox ID="txt_startTime" runat="server" class="Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td height="24" align="right">
                            <span id="PatrolSearch">截止时间：</span>
                        </td>
                        <td height="24">
                            <asp:TextBox ID="txt_endTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                        </td>
                        <td width="80" height="24" align="center">
                            <asp:Button ID="btn_ok" runat="server" Text="" CssClass="btn_search" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="grvAcceptList" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" 
                    BorderWidth="1px" CellPadding="3"
                    Width="100%" onrowcommand="grvAcceptList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="dptname" HeaderText="发文单位">
                            <ItemStyle Width="250" />
                        </asp:BoundField>
                        <asp:BoundField DataField="title" HeaderText="公文标题"></asp:BoundField>
                        <asp:BoundField DataField="sendcode" HeaderText="发文字号">
                            <ItemStyle Width="120" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TIMESTAMP" HeaderText="发文时间">
                            <ItemStyle Width="120" />
                        </asp:BoundField>
                        <asp:BoundField DataField="score" HeaderText="公文分值">
                            <ItemStyle Width="60" />
                        </asp:BoundField>
                        <asp:BoundField DataField="status" HeaderText="公文状态">
                            <ItemStyle Width="60" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作选项">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="reply" CommandArgument='<%#Eval("id") %>'>回复</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="view" CommandArgument='<%#Eval("id") %>'>查看</asp:LinkButton>
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
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" 
                    CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
