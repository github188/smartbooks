<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Plan.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Plan" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建日程</a></li>
        <li><a href="#tabs-2">日程管理</a></li>
    </ul>
    <!--新建日程开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="2">
                        新建日程
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="LabType" runat="server" Text="事务类型:"></asp:Label>
                    </td>
                    <td>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:DropDownList ID="DdrType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbUser" runat="server" Text="所属者:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtUser" CssClass="input {required:true}" runat="server"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbstart" runat="server" Text="开始时间:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbEnd" runat="server" Text="结束时间:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbcontent" runat="server" Text="事务内容:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbprompt" runat="server" Text="提醒时间:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrompt" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td style="text-align: center;">
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--新建日程结束-->
    <!--日程管理开始-->
    <div id="tabs-2">
    </div>
    <!--日程管理结束-->
</div>
