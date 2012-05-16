<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysLog.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.SysLog" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
          <li><a href="#tabs-1">日志管理</a></li>
      </ui>
    <div id="tabs-1">
        <table class="table" width="100%" align="center">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                日志编号
                            </th>
                            <th>
                                日志类型
                            </th>
                            <th>
                                创建时间
                            </th>
                            <th>
                                日志内容
                            </th>
                            <th>
                                操作人
                            </th>
                            <%--  <th>
                                操作
                            </th>--%>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckSingle" runat="server" />
                                <asp:Label ID="LOGID" runat="server" Text='<%#Eval("LOGID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("LOGID")%>
                            </td>
                            <td>
                                <%# Eval("LOGTYPE")%>
                            </td>
                            <td>
                                <%# Eval("CREATEDATE")%>
                            </td>
                            <td>
                                <%# Eval("DESCRIPTION")%>
                            </td>
                            <td>
                                <%# Eval("OPERATORID")%>
                            </td>
                            <%-- <td>
                                <a href="AfficheEdit.aspx?aid=<%# Eval("LOGID")%>">编辑</a> 
                                <a href="" id="delhref" runat="server"> 删除</a>
                                 onclick="javascript:delete_notify(<%# Eval("LOGID")%>)"
                                    
                                   
                            </td>--%>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="2">
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
    </div>
</div>
