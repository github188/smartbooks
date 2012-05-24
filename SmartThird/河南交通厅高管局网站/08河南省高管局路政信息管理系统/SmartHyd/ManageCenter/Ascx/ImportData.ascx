<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportData.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.ImportData" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">导入数据</a></li>
        <li><a href="#tabs-2">数据预览</a></li>
    </ul>
    <!--导入数据开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--标题栏-->
                <tr class="TableHeader">
                    <td colspan="3">导入数据</td>
                </tr>

                <tr>
                    <td colspan="2" nowrap="nowrap" class="TableData">
                        <asp:Label ID="Label1" runat="server" Text="数据文件:"></asp:Label>
                        <asp:FileUpload ID="fileUpAccessDB" runat="server" CssClass="input {required:true}" />
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        请选择Office 2003 Access数据库文件格式(*.mdb)。
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--导入数据结束-->
    <!--数据预览开始-->
    <div id="tabs-2">
        <table class="TableList" width="100%">
            <tbody>
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>                    
                    <tr class="TableHeader" align="center">
                        <td>
                            导入时间
                        </td>
                        <td>
                            车牌号码
                        </td>
                        <td>
                            入口站名
                        </td>
                        <td>
                            入口时间
                        </td>
                        <td>
                            出口站名
                        </td>
                        <td>
                            出口时间
                        </td>
                        <td>
                            支付方式
                        </td>
                        <td>
                            轴数
                        </td>
                        <td>
                            实际超载率
                        </td>
                        <td>
                            总重量
                        </td>
                        <td>
                            总计隧道费
                        </td>
                        <td>
                            距离
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>                    
                    <tr class="TableLine1" align="center">
                        <td>
                            <%#Eval("IMPORTDATE")%>
                        </td>
                        <td>
                            <%#Eval("VEHICLELICENSE")%>
                        </td>
                        <td>
                            <%#Eval("ENTRYSTATIONNAME")%>
                        </td>
                        <td>
                            <%#DateTime.Parse(Eval("ENTRYTIME").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </td>
                        <td>
                            <%#Eval("EXITSTATIONNAME")%>
                        </td>
                        <td>
                            <%#DateTime.Parse(Eval("EXITTIME").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>
                        </td>
                        <td>
                            <%#Eval("PAYTYPE")%>
                        </td>
                        <td>
                            <%#Eval("AXISNUM")%>
                        </td>
                        <td>
                            <%#Eval("OVERLOADRATE")%>
                        </td>
                        <td>
                            <%#Eval("TOTALWEIGHT")%>
                        </td>
                        <td>
                            <%#Eval("TOTALTOLL")%>
                        </td>
                        <td>
                            <%#Eval("DISTANCE")%>
                        </td>
                    </tr>                    
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--数据预览结束-->
</div>
