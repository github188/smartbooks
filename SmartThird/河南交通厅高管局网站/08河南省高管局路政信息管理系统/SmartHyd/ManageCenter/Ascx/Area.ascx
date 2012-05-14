<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Area.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Area" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加违章建筑</a></li>
        <li><a href="#tabs-2">违章建筑查看</a></li>
    </ul>
    <!--添加违章建筑开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加违章建筑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="分类名称:"></asp:Label>
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>                    
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                        <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="违章名称:"></asp:Label>
                        <asp:TextBox ID="txtAREANAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                        <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="50"></asp:TextBox>
                        <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                        <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="50"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="位置描述:"></asp:Label>
                        <asp:TextBox ID="txtSUMMARY" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="登记时间:"></asp:Label>
                        <asp:TextBox ID="txtREGTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="竣工时间:"></asp:Label>
                        <asp:TextBox ID="txtCOMPTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="物主名称:"></asp:Label>
                        <asp:TextBox ID="txtOWNER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Image ID="imgPhoto" runat="server" Width="120" Height="120" />
                    </td>

                    <td>
                        <asp:Label ID="Label9" runat="server" Text="现场照片:"></asp:Label>
                        <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" Width="160" />
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>

                    
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                        <asp:TextBox ID="txtREMARK" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label11" runat="server" Text="详细描述:"></asp:Label>
                        <asp:TextBox ID="txtDETAILED" runat="server" CssClass="input {required:true}" TextMode="MultiLine"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label12" runat="server" Text="现状描述:"></asp:Label>
                        <asp:TextBox ID="txtSTATUS" runat="server" CssClass="input {required:true}" TextMode="MultiLine"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" style="text-align: center;"></td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加违章建筑结束-->
    <!--违章建筑浏览开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>编号</th>
                            <th>部门名称</th>
                            <th>违章名称</th>
                            <th>违章分类</th>
                            <th>公路名称</th>
                            <th>桩号(K+M)</th>
                            <th>位置描述</th>
                            <th>登记时间</th>
                            <th>竣工时间</th>
                            <th>物主名称</th>
                            <th>现状描述</th>
                            <th>备注信息</th>
                            <th>现场照片</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("ID")%></td>
                            <td><%#Eval("DPTNAME")%></td>
                            <td><%#Eval("AREANAME")%></td>
                            <td><%#Eval("TYPENAME")%></td>
                            <td><%#Eval("LINENAME")%></td>
                            <td><%#Eval("STAKEK").ToString() + "+" + Eval("STAKEM").ToString() %></td>
                            <td><%#Eval("SUMMARY")%></td>
                            <td><%#Eval("REGTIME")%></td>
                            <td><%#Eval("COMPTIME")%></td>
                            <td><%#Eval("OWNER")%></td>
                            <td><%#Eval("STATUS")%></td>
                            <td><%#Eval("REMARK")%></td>
                            <td><%#Eval("PHOTO")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>编号</td>
                            <td>部门名称</td>
                            <td>违章名称</td>
                            <td>违章分类</td>
                            <td>公路名称</td>
                            <td>桩号(K+M)</td>
                            <td>位置描述</td>
                            <td>登记时间</td>
                            <td>竣工时间</td>
                            <td>物主名称</td>
                            <td>现状描述</td>
                            <td>备注信息</td>
                            <td>现场照片</td>
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
    <!--违章建筑浏览结束-->
</div>
