<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trash.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.Trash" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>垃圾箱</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：公文管理 > 垃圾箱 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="grvAcceptList" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" BorderWidth="1px" CellPadding="3"
                    Width="100%" OnRowCommand="grvAcceptList_RowCommand">
                    <Columns>
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
                        <asp:TemplateField HeaderText="操作选项">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="back" CommandArgument='<%#Eval("id") %>'>还原</asp:LinkButton>
                                <asp:LinkButton runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>'>彻底删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="90" />
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
                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
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
