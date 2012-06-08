<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Affiche.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Affiche" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
 <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
    <tr>
        <td style="height: 24px;">
            <div id="menu">
                <div class="OperateNote">
                    <span id="buttons">
                        <img src="../../Images/branch.png" alt="" border="0" />当前位置：<a href="">网络办公&gt;&gt;</a>电子公告</span></div>
                         <ul>
                                <li id="menu_Title0" class="normal">
                                    <a href="../AfficheEdit.aspx" target="PatrolFrame">
                                        <span id="Span1">
                                            <img src="../../Images/add.png" alt="" border="0" />新建公告
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
                        <span id="PatrolSearch1">标题：</span>
                    </td>
                    <td height="24">
                        <asp:TextBox ID="txt_title" runat="server" Width="120"></asp:TextBox>
                    </td>
                    <td height="24" align="right">
                        <span id="PatrolSearch2">时间：</span>
                    </td>
                    <td height="24">
                        <asp:TextBox ID="txt_endTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
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
            <table class="TableBlock" width="100%" cellspacing="0" cellpadding="3" align="center">
                <asp:Repeater ID="RptAffiche" runat="server">
                    <HeaderTemplate>
                        <thead>
                            <tr class="TableHeader">
                                <th>
                                    <asp:CheckBox ID="CheckallAffiche" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                                </th>
                                <th>
                                    标题
                                </th>
                                <th>
                                    发布人
                                </th>
                                <th>
                                    创建时间
                                </th>
                                <th>
                                    状态
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td align="center">
                                    <asp:CheckBox ID="CheckSingleAffiche" runat="server" />
                                    <asp:Label ID="AFFICHEID" runat="server" Text='<%#Eval("AFFICHEID") %>' Visible="false"></asp:Label>
                                </td>
                                <td align="center">
                                    <a href="">
                                        <%# Eval("AFFICHETITLE")%></a>
                                </td>
                                <td align="center">
                                    <%# Eval("AFFICHER")%>
                                </td>
                                <td align="center">
                                    <%# Eval("AFFICHEDATE")%>
                                </td>
                                <td align="center">
                                    <%# Eval("STATES")%>
                                </td>
                                <td align="center">
                                    <a href="AfficheEdit.aspx?aid=<%# Eval("AFFICHEID")%>">编辑</a> 
                                    <a href="" id="delhref">删除</a>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="6">
                                    <%--分页--%>
                                </td>
                            </tr>
                        </tfoot>
                    </FooterTemplate>
                </asp:Repeater>
            </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
            </webdiyer:AspNetPager>
        </td>
    </tr>
</table>
