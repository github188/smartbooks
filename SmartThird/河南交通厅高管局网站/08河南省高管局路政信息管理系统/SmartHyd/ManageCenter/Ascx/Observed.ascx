<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Observed.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Observed" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加日志</a></li>
        <li><a href="#tabs-2">日志查看</a></li>
    </ul>
    <!--添加日志开始(电子巡逻)-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加巡逻日志
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="巡查中队:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:DropDownList ID="ddldept" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="巡查人员:"></asp:Label>
                        <asp:TextBox ID="txtPATROLUSER" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="天气情况:"></asp:Label>
                        <asp:TextBox ID="txtWEATHER" runat="server" CssClass="input" Text="晴天"></asp:TextBox>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="开始时间:"></asp:Label>
                        <asp:TextBox ID="txtBEGINTIME" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="结束时间:"></asp:Label>
                        <asp:TextBox ID="txtENDTIME" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="巡查处理情况:"></asp:Label>
                        <asp:TextBox ID="txtLog" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加日志结束(电子巡逻)-->
    <!--日志查看开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                单位部门
                            </th>
                            <th>
                                巡逻人员
                            </th>
                            <th>
                                天气情况
                            </th>
                            <th>
                                开始时间
                            </th>
                            <th>
                                结束时间
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <#=Eval('DPTNAME')#>
                            </td>
                            <td>
                                <#=Eval('username')#>
                            </td>
                            <td>
                                <#=Eval('WEATHER')#>
                            </td>
                            <td>
                                <#=Eval('BEGINTIME')#>
                            </td>
                            <td>
                                <#=Eval('ENDDATE')#>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>
                                单位部门
                            </td>
                            <td>
                                巡逻人员
                            </td>
                            <td>
                                天气情况
                            </td>
                            <td>
                                开始时间
                            </td>
                            <td>
                                结束时间
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20">
        </webdiyer:AspNetPager>
    </div>
    <!--日志查看结束-->
</div>
