<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Term.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Term" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>

    <!--装备查看开始-->
    <div>
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>装备类型</th>
                            <th>设备名称</th>
                            <th>设备编号</th>
                            <th>所属部门</th>
                            <th>出厂编号</th>
                            <th>规格型号</th>
                            <th>制造厂商</th>
                            <th>装备用途</th>
                            <th>投入时间</th>
                            <th>存放地点</th>
                            <th>设备状态</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("typename")%></td>
                            <td><%#Eval("termname")%></td>
                            <td><%#Eval("termcode")%></td>
                            <td><%#Eval("dptname")%></td>
                            <td><%#Eval("serialcode")%></td>
                            <td><%#Eval("format")%></td>
                            <td><%#Eval("brand")%></td>
                            <td><%#Eval("USE")%></td>
                            <td><%#Eval("usetime")%></td>
                            <td><%#Eval("SAVEPOINT")%></td>
                            <td><%#Eval("status")%></td>
                            <td>
                            <a href="TermEdit.aspx?id=<%# %>">编辑</a>
                            <a href="">删除</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
    </div>
    <!--装备查看结束-->
