<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportData.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.ImportData" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">导入数据</a></li>
        <li><a href="#tabs-2">数据预览</a></li>
    </ul>
    <!--导入数据开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        导入数据
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr height="38">
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="数据文件:"></asp:Label>
                        <asp:FileUpload ID="fileUpAccessDB" runat="server" CssClass="input {required:true}" />
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td>
                        请选择Office 2003 Access数据库文件格式(*.mdb)。
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:HiddenField ID="hidPercentage" runat="server" Value="0"/>
                        <asp:Label ID="lblprogressbarNum" runat="server"></asp:Label>
                        <div id="progressbar"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--导入数据结束-->
    <!--数据预览开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>导入时间</th>
                            <th>车牌号码</th>
                            <th>入口站名</th>
                            <th>入口时间</th>
                            <th>出口站名</th>
                            <th>出口时间</th>
                            <th>支付方式</th>
                            <th>轴数</th>
                            <th>实际超载率</th>
                            <th>总重量</th>
                            <th>总计隧道费</th>
                            <th>距离</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("IMPORTDATE")%></td>
                            <td><%#Eval("VEHICLELICENSE")%></td>
                            <td><%#Eval("ENTRYSTATIONNAME")%></td>
                            <td><%#DateTime.Parse(Eval("ENTRYTIME").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>                            
                            <td><%#Eval("EXITSTATIONNAME")%></td>
                            <td><%#DateTime.Parse(Eval("EXITTIME").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                            <td><%#Eval("PAYTYPE")%></td>
                            <td><%#Eval("AXISNUM")%></td>
                            <td><%#Eval("OVERLOADRATE")%></td>
                            <td><%#Eval("TOTALWEIGHT")%></td>
                            <td><%#Eval("TOTALTOLL")%></td>
                            <td><%#Eval("DISTANCE")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>导入时间</td>
                            <td>车牌号码</td>
                            <td>入口站名</td>
                            <td>入口时间</td>
                            <td>出口站名</td>
                            <td>出口时间</td>
                            <td>支付方式</td>
                            <td>轴数</td>
                            <td>实际超载率</td>
                            <td>总重量</td>
                            <td>总计隧道费</td>
                            <td>距离</td>
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
    <!--数据预览结束-->
</div>
