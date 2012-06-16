<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SmartHyd.ManageCenter.ControlArea.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>违章信息管理</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" border="0" />当前位置：违章管理 > 违章信息管理 </span>
                    </div>
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="Add.aspx"
                            title="新增路产" target="ElectronicPatrolFrame"><span id="Span1">
                                <img src="../../Images/add.png" alt="" border="0" />添加信息</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <!--首选行-->
        <tr class="TableHeader">
            <td>
                违章信息管理
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" class="TableData">
                <asp:GridView ID="dgvList" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%"
                    OnRowCommand="dgvList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="AREANAME" HeaderText="违章名称">
                            <ItemStyle Width="140" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LINENAME" HeaderText="公路名称">
                            <ItemStyle Width="140" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="桩号位置">
                            <ItemTemplate>
                                K:<%#Eval("STAKEK")%>+ M:<%#Eval("STAKEM")%>
                            </ItemTemplate>
                            <ItemStyle Width="140" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="REGTIME" HeaderText="登记时间">
                            <ItemStyle Width="110" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OWNER" HeaderText="物主名称">
                            <ItemStyle Width="110" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="现状描述" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="view" CommandArgument='<%#Eval("id") %>'>查看</asp:LinkButton>
                                <asp:LinkButton runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80" />
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
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                    TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                    PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
