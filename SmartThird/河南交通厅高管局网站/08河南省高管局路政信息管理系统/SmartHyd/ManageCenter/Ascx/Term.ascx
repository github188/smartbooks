<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Term.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Term" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加装备</a></li>
        <li><a href="#tabs-2">装备查看</a></li>
    </ul>
    <!--添加装备开始(电子巡逻)-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加装备
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
                        <asp:Label ID="Label3" runat="server" Text="装备类型:"></asp:Label>
                        <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="设备编号:"></asp:Label>
                        <asp:TextBox ID="txtTERMCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="设备名称:"></asp:Label>
                        <asp:TextBox ID="txtTERMNAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="出厂编号:"></asp:Label>
                        <asp:TextBox ID="txtSERIALCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="规格型号:"></asp:Label>
                        <asp:TextBox ID="txtFORMAT" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="制造厂商:"></asp:Label>
                        <asp:TextBox ID="txtBRAND" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="装备用途:"></asp:Label>
                        <asp:TextBox ID="txtUse" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="投入时间:"></asp:Label>
                        <asp:TextBox ID="txtUSETIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="设备状态:"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input" >
                            <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label9" runat="server" Text="备注信息:"></asp:Label>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input"></asp:TextBox>
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
    <!--添加装备结束-->
    <!--装备查看开始-->
    <div id="tabs-2">
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
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>装备类型</td>
                            <td>设备名称</td>
                            <td>设备编号</td>
                            <td>所属部门</td>
                            <td>出厂编号</td>
                            <td>规格型号</td>
                            <td>制造厂商</td>
                            <td>装备用途</td>
                            <td>投入时间</td>
                            <td>存放地点</td>
                            <td>设备状态</td>
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
    <!--装备查看结束-->
</div>
