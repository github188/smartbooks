<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 304px;
    }
    .style2
    {
        width: 14%;
    }
</style>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr>
            <td class="style2">
                <font size="+2">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+2">系统管理</font></a>&gt; <a
                    href="../ManageCenter/UserManage.aspx"><font size="+2">用户管理</font></a>&gt;
            </td>
        </tr>
    </table>
    <ul>
        <li><a href="#tabs-1">用户列表</a></li>
        <li><a href="#tabs-2">添加用户</a></li>
    </ul>
    <!--用户列表开始-->
    <div id="tabs-1">
    <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td class="style1">
                        部门
                    </td>
                    <td colspan="2">
                        用户
                    </td>
                </tr>
                <tr>
                <td rowspan="8" valign="top" class="style1">
                        <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeview">
                        </asp:TreeView>
                    </td>
                <td>
                   <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="repList" runat="server">
                    <HeaderTemplate>
                        <tr class="TableHeader" align="center">
                            <td>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </td>
                            <td>
                                操作
                            </td>
                            <td>
                                工作证号
                            </td>
                            <td>
                                登录账号
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td>
                                <asp:CheckBox ID="CheckSingle" runat="server" />
                            </td>
                            <td>
                                <a href="#">
                                    <image src="../../Images/edit_big.jpg" alt="编辑"></image>
                                </a>
                            </td>
                            <td>
                                <%# Eval("jobnumber")%>
                            </td>
                            <td>
                                <%# Eval("username")%>
                            </td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
                </td>
                </tr>
                </tbody>
                </table>
     
        
    </div>
    <!--用户列表结束-->
    <!--添加用户开始-->
    <div id="tabs-2">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--标题栏-->
                <tr class="TableHeader">
                    <td colspan="4">
                        添加用户
                    </td>
                </tr>
                <!--部门、账号-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        所属部门:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        用户账号:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="input {required:true,minlength:5,maxlength:12}">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--密码、性别-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        用户密码:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input {required:true,minlength:5,maxlength:12}">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        用户性别:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:DropDownList ID="ddlSex" runat="server" CssClass="input">
                            <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <!--生日、学历-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        出生年月:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:TextBox ID="txtBIRTHDAY" runat="server" CssClass="input {required:true}">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        最高学历:
                    </td>
                    <td nowrap="nowrap" class="TableData" style="width: 325px;">
                        <asp:TextBox ID="txtDEGREE" runat="server" CssClass="input {required:true}" Text="本科">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--政治面貌、身份证号-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        政治面貌:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtFACE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        身份证号:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtIDNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--工作证号、所学专业-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        工作证号:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtJOBNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        所学专业:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtPROF" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <!--联系方式、备注信息-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        联系方式:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">
                        备注信息:
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <!--用户照片-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        用户照片
                    </td>
                    <td nowrap="nowrap" class="TableData" colspan="3">
                        <asp:FileUpload ID="fileupPhoto" runat="server" />
                    </td>
                </tr>
                <!--按钮栏-->
                <tr class="TableControl" align="center">
                    <td colspan="4" nowrap="nowrap">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--添加用户结束-->
</div>
