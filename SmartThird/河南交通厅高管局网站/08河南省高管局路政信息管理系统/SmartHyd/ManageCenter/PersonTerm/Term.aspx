<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Term.aspx.cs" Inherits="SmartHyd.ManageCenter.PersonTerm.Term" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>装备管理</title>
    <link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function EditEquip() {
            window.location.href = "TermEdit.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
            <tr>
                <td style="height: 24px;">
                    <div id="menu">
                        <div class="OperateNote">
                            <span id="buttons0">
                                <img src="../../Images/branch.png" alt="" border="0" />当前位置：人员装备管理中心&gt;&gt;装备管理</span></div>
                        <ul>
                            <li id="menu_Title0"  class="normal"><a href="TermEdit.aspx"
                                title="装备新增" onclick="EditEquip()"><span id="buttons1">
                                    <img src="../../Images/add.png" alt="" border="0" />&nbsp;新增装备</span> </a>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
                <td>
                    <table id="PatrolSearch" width="480" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="80" height="24" align="right">
                                <span id="PatrolSearch1">设备名称：</span>
                            </td>
                            <td width="120" height="24" colspan="3">
                                <asp:TextBox ID="TxtTermName" runat="server" class="controlstyle txtboxstyle"></asp:TextBox>
                            </td>
                            <td width="80" height="24" align="right">
                                <span id="PatrolSearch2">设备类型：</span>
                            </td>
                            <td width="120" height="24">
                                <asp:DropDownList ID="DdrType" runat="server">
                                </asp:DropDownList>
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
                    <asp:GridView ID="gv_patrollist" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%"
                        OnRowCommand="gv_patrollist_RowCommand">
                        <Columns>
                            <asp:CheckBoxField />
                            <asp:BoundField DataField="typename" HeaderText="装备类型" />
                            <asp:BoundField DataField="termname" HeaderText="设备名称" />
                            <asp:BoundField DataField="termcode" HeaderText="设备编号" />
                            <asp:BoundField DataField="dptname" HeaderText="所属单位" />
                            <asp:BoundField DataField="serialcode" HeaderText="出厂编号" />
                            <asp:BoundField DataField="format" HeaderText="规格型号" />
                            <asp:BoundField DataField="brand" HeaderText="制造厂商" />
                            <asp:BoundField DataField="USE" HeaderText="装备用途" />
                            <asp:BoundField DataField="usetime" HeaderText="投入时间" />
                            <asp:BoundField DataField="SAVEPOINT" HeaderText="存放地点" />
                            <asp:BoundField DataField="status" HeaderText="设备状态" />
                            <asp:TemplateField HeaderText="操作选项">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Lbtview" runat="server" CommandName="view" CommandArgument='<%#Eval("termid") %>'>查看</asp:LinkButton>
                                    <asp:LinkButton ID="LbtEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("termid") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="LbtDel" runat="server" OnClientClick="return confirm('确定删除该日志吗？')"
                                        CommandName="del" CommandArgument='<%#Eval("termid") %>'>删除</asp:LinkButton>
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
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                        PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
                    </webdiyer:AspNetPager>
                    <!--装备查看结束-->
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
