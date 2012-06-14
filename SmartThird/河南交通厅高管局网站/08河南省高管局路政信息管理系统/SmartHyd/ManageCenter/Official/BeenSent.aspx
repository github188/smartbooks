<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeenSent.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.BeenSent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/TreeView.ascx" TagName="TreeView" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>已发送</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*树控件*/
        .treeview
        {
            float: left;
            overflow: scroll;
            font-size: 15px;
            height: 470px;
            width: 240px;
        }
        .treeview tr
        {
            float: left;
        }
    </style>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：公文管理 > 已发送 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">                
                <tr id="search_condition_panel" style="height: 24px; border-bottom: 1px solid #8cb2e2;">
                    <td>
                        <table style="height: 100%; width: 100%;">
                            <tr>
                                <!--导航-->
                                <td valign="top" style="height: 470px; width: 240px;">
                                    <uc1:TreeView ID="TreeView1" runat="server" TreeEnum="DocuemntClass" />
                                </td>
                                <!--数据-->
                                <td valign="top">
                                    <table id="PatrolSearch" width="480px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="24">
                                                <span id="Span2">公文标题:</span>
                                                <asp:TextBox ID="txt_title" runat="server" class="Wdate" Width="250"></asp:TextBox>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn_search" OnClick="btnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="grvPublishList" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" BorderWidth="1px" CellPadding="3"
                                        Width="100%" OnRowCommand="grvPublishList_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="title" HeaderText="公文标题"></asp:BoundField>
                                            <asp:BoundField DataField="sendcode" HeaderText="公文字号">
                                                <ItemStyle Width="120" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TIMESTAMP" HeaderText="发文时间">
                                                <ItemStyle Width="120" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="score" HeaderText="考核分值">
                                                <ItemStyle Width="55" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="status" HeaderText="公文状态">
                                                <ItemStyle Width="55" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="操作选项">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>'>编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="checkout" CommandArgument='<%#Eval("id") %>'>考核</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="detail" CommandArgument='<%#Eval("id") %>'>详情</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="isread" CommandArgument='<%#Eval("id") %>'>追踪</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="150" />
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
                                    <br />
                                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
