<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.MenuManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加菜单</a></li>
        <li><a href="#tabs-2">菜单管理</a></li>
    </ul>
    <!--添加菜单 start-->
    <div id="tabs-1">
        <span class="big3" style=" margin-right:20px;">添加菜单</span>
        <table class="TableList" width="100%">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2" align="left" style=" text-align:left;">
                        添加菜单
                    </td>
                </tr>

                <!--菜单名称-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        菜单名称:
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="txtMenuName" runat="server" 
                            CssClass="input {required:true,minlength:1,maxlength:50}"
                            Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>

                <!--菜单地址-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">
                        菜单地址:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtMenuUrl" runat="server" 
                            CssClass="input {required:true,minlength:1,maxlength:50}"
                            Width="350" Text="ManageCenter/">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                
                <!--菜单描述-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        菜单描述:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSummary" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                            Height="81px" TextMode="MultiLine" Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>

                <!--菜单图标-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        菜单图标:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtMenuIco" runat="server" 
                            CssClass="input {required:true,minlength:1,maxlength:50}"
                            Width="350" Text="Images/sale_manage.png">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;"></div>
                    </td>
                </tr>

                <!--父菜单编号-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        父级菜单:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlMenuParentNode" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <!--状态-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        状态:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="input">
                            <asp:ListItem Text="正常" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="关闭" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <!--submit button-->
                <tr class="TableControl" align="center">
                    <td colspan="2" nowrap="nowrap" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--添加菜单 end-->
    <!--菜单列表 start-->
    <div id="tabs-2">
    </div>
    <!--菜单列表 end-->
</div>
