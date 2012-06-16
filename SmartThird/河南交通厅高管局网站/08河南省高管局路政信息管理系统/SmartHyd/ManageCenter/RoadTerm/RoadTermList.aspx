<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermList.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>·���豸�б�ҳ</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td style="height: 24px;">
                        <div id="menu">
                            <div class="OperateNote">
                                <span id="buttons">
                                    <img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã�·���豸���� > ·����ѯ</span></div>
                            <ul>
                                <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="RoadTermAdd.aspx"
                                    title="����·��" target="RoadPropertyFrame"><span id="buttons">
                                        <img src="../../Images/add.png" alt="" border="0" />����·��</span></a></li>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
                    <td>
                        <table id="PatrolSearch" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="100" height="24" align="right" style="line-height: 24px;">
                                    ·����λ��
                                </td>
                                <td height="24">
                                    <uc1:Department ID="Department1" runat="server" />
                                </td>
                                <td width="100" height="24" align="right">
                                    �豸���ͣ�
                                </td>
                                <td width="120" height="24">
                                    <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input">
                                    </asp:DropDownList>
                                </td>
                                <td width="100" height="24" align="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="24" align="right">
                                    ��ʼʱ�䣺
                                </td>
                                <td height="24">
                                    <asp:TextBox ID="txtBeginTime" runat="server" class="Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                                </td>
                                <td height="24" align="right">
                                    ����ʱ��:
                                </td>
                                <td height="24">
                                    <asp:TextBox ID="txtEndTime" runat="server" class="Wdate controlstyle" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                                </td>
                                <td width="80" height="24" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn_search" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="dgvRoadList" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            Width="100%" onrowcommand="dgvRoadList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ROADNAME" HeaderText="�豸����" />
                                <asp:BoundField DataField="LINENAME" HeaderText="���ٹ�·" />
                                <asp:TemplateField HeaderText="׮��λ��">
                                    <ItemTemplate>
                                        K:<%#Eval("STAKEK")%>+ M:<%#Eval("STAKEM")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="REGTIME" HeaderText="�Ǽ�ʱ��" />
                                <asp:BoundField DataField="COMPTIME" HeaderText="����ʱ��" />
                                <asp:TemplateField HeaderText="����">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="view" CommandArgument='<%#Eval("id") %>'>�鿴</asp:LinkButton>
                                        <asp:LinkButton runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>'>ɾ��</asp:LinkButton>
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
                    </td>
                </tr>
            </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%PageCount%ҳ����ǰΪ��%CurrentPageIndex%ҳ"
                FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="TextBox"
                PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanging="AspNetPager1_PageChanging"
                PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
            </webdiyer:AspNetPager>
            <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
