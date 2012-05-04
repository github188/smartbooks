<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Patrol.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Patrol" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">日志查看</a></li>
        <li><a href="#tabs-2">添加日志</a></li>
    </ul>
    <!--日志查看开始-->
    <div id="tabs-1">
        <table class="table">
            <asp:Repeater ID="repLogList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                标题
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
                            <td>
                                测试标题
                            </td>
                            <td>
                                提交
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="2">
                                分页
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    <!--日志查看结束-->
    <!--添加日志开始-->
    <div id="tabs-2">
        <table class="edit">
            <thead>
                <tr>
                    <th>
                        标题
                    </th>
                    <th>
                        操作
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="left">
                        用户名
                    </td>
                    <td class="center">
                        <input type="text" value="email" class="input" />
                    </td>
                    <td class="right">
                        请输入用户名
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        用户名
                    </td>
                    <td class="center">
                        <input type="text" value="请输入用户名" class="input" />
                    </td>
                    <td class="right">
                        <div id="alert" class="ui-state-highlight ui-corner-all" style="width:300px;">
                            <span class="ui-icon ui-icon-info" style="float: left;"></span>请输入您的用户名。
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">
                        <input type="submit" value="提交" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加日志结束-->
</div>
