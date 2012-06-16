<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SmartHyd.ManageCenter.Document.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>档案查看</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：档案管理 > 档案查看 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td>
                    档案浏览
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    <asp:GridView ID="grvList" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" BorderWidth="1px" CellPadding="3"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="title" HeaderText="档案名称"></asp:BoundField>
                            <asp:BoundField DataField="sendcode" HeaderText="档案编号">
                                <ItemStyle Width="140" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TIMESTAMP" HeaderText="创建时间">
                                <ItemStyle Width="110" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作选项">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandName="view" CommandArgument='<%#Eval("id") %>'>查看</asp:LinkButton>
                                    <asp:LinkButton  runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton   runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton>
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
                    <asp:Literal ID="Literal1" Visible="false" runat="server"></asp:Literal>
                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
