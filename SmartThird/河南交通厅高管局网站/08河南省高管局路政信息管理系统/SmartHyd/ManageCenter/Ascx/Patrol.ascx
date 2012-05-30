﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Patrol.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Patrol" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<div id="tab">
    <ul>
        <%--<li><a href="#tabs-1">添加日志</a></li>
        <li><a href="#tabs-2">日志查看</a></li>--%>
        <li><a href="#tabs-1">人工巡逻</a></li>
        <li><a href="#tabs-2">电子巡逻</a></li>
    </ul>
    <!--添加日志开始-->
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
                        
                        <uc1:Department ID="Department1" runat="server" />
                        
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="负责人员:"></asp:Label>
                        <asp:TextBox ID="txtRESPUSER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="巡查人员:"></asp:Label>
                        <asp:TextBox ID="txtPATROLUSER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="车牌号码:"></asp:Label>
                        <asp:TextBox ID="txtBUSNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="巡查里程:"></asp:Label>
                        <asp:TextBox ID="txtMILEAGE" runat="server" CssClass="input {required:true}" Text="1000"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="天气情况:"></asp:Label>
                        <asp:TextBox ID="txtWEATHER" runat="server" CssClass="input {required:true}" Text="晴天"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="巡查处理情况:"></asp:Label>
                        <asp:TextBox ID="txtLog" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label8" runat="server" Text="移交内业处理事项:"></asp:Label>
                        <asp:TextBox ID="txtWITHIN" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label9" runat="server" Text="移交下班处理事项:"></asp:Label>
                        <asp:TextBox ID="txtNEXTWITHIN" runat="server" CssClass="input"  TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label10" runat="server" Text="移交下班器材:"></asp:Label>
                        <asp:TextBox ID="txtGOODS" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="交班中队:"></asp:Label>
                        <asp:TextBox ID="txtSHIFTCAPTAIN" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="接班中队:"></asp:Label>
                        <asp:TextBox ID="txtACCEPTCAPTAIN" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="车牌号码:"></asp:Label>
                        <asp:TextBox ID="txtACCEPTBUSNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="开始时间:"></asp:Label>
                        <asp:TextBox ID="txtBEGINTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="结束时间:"></asp:Label>
                        <asp:TextBox ID="txtENDTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="里程表数:"></asp:Label>
                        <asp:TextBox ID="txtBUSKM" runat="server" CssClass="input {required:true}" Text="1000"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" onclick="btnCancel_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加日志结束-->

    <!--日志查看开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>单位部门</th>
                            <th>巡逻人员</th>
                            <th>巡查车牌号</th>
                            <th>巡查里程</th>
                            <th>天气情况</th>
                            <th>交接班时间</th>
                            <th>接班巡逻车里程表（KM）</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("dptname") %></td>
                            <td><%#Eval("username") %></td>
                            <td><%#Eval("busnumber") %>></td>
                            <td><%#Eval("mileage") %></td>
                            <td><%#Eval("weather") %>></td>
                            <td><%#Eval("ticktime") %>></td>
                            <td><%#Eval("buskm") %>></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>单位部门</td>
                            <td>巡逻人员</td>
                            <td>巡查车牌号</td>
                            <td>巡查里程</td>
                            <td>天气情况</td>
                            <td>交接班时间</td>
                            <td>接班巡逻车里程表（KM）</td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--日志查看结束-->
    
</div>
