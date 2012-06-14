<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentTypeManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentTypeManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<%@ Register Src="../../Ascx/TreeView.ascx" TagName="TreeView" TagPrefix="uc2" %>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
    <tr>
        <td style="height: 24px;">
            <div id="menu">
                <div class="OperateNote">
                    <span id="buttons">
                        <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="../Official/OfficialIndex.aspx">发文管理</a>》档案分类管理</span></div>
            </div>
        </td>
    </tr>
    <tr>
        <td style="height: 24px; line-height: 24px; font-size: 13px; border-bottom: 1px solid #8cb2e2;">
            <div style="float: left; width: auto;">
                选择单位或部门：
                <uc1:Department ID="Department2" width="300" runat="server" />
            </div>
            <div style="float: right; width: 100px;">
                <asp:ImageButton ID="btn_addDtype" runat="server" ImageUrl="~/Images/adddtype.png"
                    OnClick="btn_addDtype_Click" />
            </div>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #006699">
                <asp:Repeater ID="RptList" runat="server" OnItemCommand="RptList_ItemCommand">
                    <HeaderTemplate>
                        <tbody>
                            <tr style="color: #ffffff; font-weight: bold; font-size: 12px; height: 24px; line-height: 24px;"
                                align="center">
                                <td>
                                    操作
                                </td>
                                <td>
                                    分类名称
                                </td>
                                <td>
                                    分类描述
                                </td>
                                <td>
                                    排序
                                </td>
                                <td>
                                    状态
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td style="background-color: #ffffff; font-size: 12px; width: 180px">
                                <asp:Button ID="Button1" runat="server" CommandName="delete" Text="删除" CssClass="BigButtonA"
                                    CommandArgument='<%#Eval("id")%>' />
                                <asp:Button ID="Button2" runat="server" CommandName="update" Text="编辑" CssClass="BigButtonA"
                                    CommandArgument='<%#Eval("id")%>' />
                            </td>
                            <td style="background-color: #ffffff; font-size: 12px; width: 150px; font-weight: bold;">
                                <%# Eval("TYPENAME")%>
                            </td>
                            <td align="left" style="background-color: #ffffff; font-size: 12px;">
                                <%# Eval("SUMMARY")%>
                            </td>
                            <td style="background-color: #ffffff; font-size: 12px; width: 80px">
                                <%# Eval("SORT")%>
                            </td>
                            <td style="background-color: #ffffff; font-size: 12px; width: 100px">
                                <%# Eval("STATUS").ToString().Equals("0") ? "正常" : "删除"%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
            <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                TextAfterPageIndexBox="页" CssClass="anpager" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
            </webdiyer:AspNetPager>
        </td>
    </tr>
</table>
