<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysLog.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.SysLog" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">日志管理</a></li>
    </ul>
    <div id="tabs-1">
        <table class="TableList" width="100%">
            <tbody>
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>                    
                    <tr class="TableHeader" align="center">
                        <td>
                            日志编号
                        </td>
                        <td>
                            日志类型
                        </td>
                        <td>
                            创建时间
                        </td>
                        <td>
                            日志内容
                        </td>
                        <td>
                            操作人
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>                    
                    <tr class="TableLine1" align="center">                            
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
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
</div>
