<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoadTerm.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.RoadTerm" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加路产设备</a></li>
        <li><a href="#tabs-2">路产设备查看</a></li>
    </ul>
    <!--添加路产设备开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加路产设备
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
                        <asp:Label ID="Label3" runat="server" Text="设备类型:"></asp:Label>
                        <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input">                            
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="设备状态:"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                            <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                        <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                        <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="20"></asp:TextBox>
                        <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                        <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="20"></asp:TextBox>
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
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                        <asp:TextBox ID="txtREMARK" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr height="38">
                    <td colspan="3">
                        <asp:Label ID="Label9" runat="server" Text="设备照片:"></asp:Label>
                        <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}" />
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
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
    <!--添加路产设备结束-->
    <!--路产设备查看开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                设备类型
                            </th>
                            <th>
                                设备名称
                            </th>
                            <th>
                                设备编号
                            </th>
                            <th>
                                所属部门
                            </th>
                            <th>
                                高速公路
                            </th>
                            <th>
                                桩号位置
                            </th>
                            <th>
                                登记时间
                            </th>
                            <th>
                                竣工时间
                            </th>
                            <th>
                                设备照片
                            </th>
                            <th>
                                备注信息
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>
                                设备类型
                            </td>
                            <td>
                                设备名称
                            </td>
                            <td>
                                设备编号
                            </td>
                            <td>
                                所属部门
                            </td>
                            <td>
                                高速公路
                            </td>
                            <td>
                                桩号位置
                            </td>
                            <td>
                                登记时间
                            </td>
                            <td>
                                竣工时间
                            </td>
                            <td>
                                设备照片
                            </td>
                            <td>
                                备注信息
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
    <!--路产设备看结束-->
</div>
