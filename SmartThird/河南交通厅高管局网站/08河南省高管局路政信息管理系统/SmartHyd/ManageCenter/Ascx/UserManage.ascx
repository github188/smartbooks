<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加用户</a></li>
        <li><a href="#tabs-2">浏览用户</a></li>
    </ul>
    <!--添加用户开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加用户
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
                        <asp:Label ID="Label2" runat="server" Text="用户账号:"></asp:Label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input {required:true,minlength:5,maxlength:12}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="用户密码:"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input {required:true,minlength:5,maxlength:12}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="用户性别:"></asp:Label>
                        <asp:DropDownList ID="ddlSex" runat="server" CssClass="input">
                            <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="出生年月:"></asp:Label>
                        <asp:TextBox ID="txtBIRTHDAY" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="最高学历:"></asp:Label>
                        <asp:TextBox ID="txtDEGREE" runat="server" CssClass="input {required:true}" Text="本科"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="政治面貌:"></asp:Label>
                        <asp:TextBox ID="txtFACE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="身份证号:"></asp:Label>
                        <asp:TextBox ID="txtIDNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="工作证号:"></asp:Label>
                        <asp:TextBox ID="txtJOBNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="所学专业:"></asp:Label>
                        <asp:TextBox ID="txtPROF" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="联系方式:"></asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="备注信息:"></asp:Label>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label13" runat="server" Text="用户照片:"></asp:Label>
                        <asp:FileUpload ID="fileupPhoto" runat="server" />
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
    <!--添加用户结束-->
    <!--浏览用户开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>所属部门</th>
                            <th>工作证号</th>
                            <th>登录账号</th>
                            <th>联系电话</th>
                            <th>用户性别</th>
                            <th>政治面貌</th>
                            <th>最高学历</th>
                            <th>所学专业</th>
                            <th>出生年月</th>
                            <th>身份证号</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%# Eval("dptname") %></td>
                            <td><%# Eval("jobnumber")%></td>
                            <td><%# Eval("username")%></td>
                            <td><%# Eval("phone")%></td>
                            <td><%# Eval("sex")%></td>
                            <td><%# Eval("face")%></td>
                            <td><%# Eval("DEGREE")%></td>
                            <td><%# Eval("prof")%></td>
                            <td><%# Eval("birthday")%></td>
                            <td><%# Eval("idnumber")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>所属部门</td>
                            <td>工作证号</td>
                            <td>登录账号</td>
                            <td>联系电话</td>
                            <td>用户性别</td>
                            <td>政治面貌</td>
                            <td>最高学历</td>
                            <td>所学专业</td>
                            <td>出生年月</td>
                            <td>身份证号</td>
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
    <!--浏览用户结束-->
</div>
