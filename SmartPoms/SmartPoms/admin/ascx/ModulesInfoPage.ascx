<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModulesInfoPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.ModulesInfoPage" %>
<asp:Panel ID="TitlePanel" runat="server" Visible="false" CssClass="bg02 titlePadding">
    <asp:Label ID="id" runat="server" Text="Label" Style="display: none;"></asp:Label>
    <asp:LinkButton ID="mt_btn_add" runat="server" 
        Text="新增分类" 
        OnClick="mt_btn_add_Click"
        ForeColor="#000000">
    </asp:LinkButton>
    <asp:LinkButton ID="m_btn_add" Text="新增模块" 
        runat="server" 
        OnClick="m_btn_add_Click"
        ForeColor="#000000">
    </asp:LinkButton>
    <asp:Label ID="MID" runat="server" Text="" Style="display: none;"></asp:Label>
</asp:Panel>

<div id="strinfo" runat="server" class="mbox pbox" visible="false"></div>

<div style="height: auto !important; height: 450px; min-height: 450px; padding-bottom: 10px;">

    <asp:Panel ID="EditModuleTypePanel" runat="server" Visible="false" Style="margin: 10px;
        float: left;">
        <table width="500" border="0" cellpadding="0" cellspacing="5">
            <tr>
                <td width="70">
                    <div style="text-align: right; padding-right: 5px;">
                        上级分类：</div>
                </td>
                <td>
                    <asp:DropDownList ID="txt_MTPID" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="MT_ID" runat="server" Text="" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: right; padding-right: 5px;">
                        类型名称：</div>
                </td>
                <td>
                    <asp:TextBox ID="txt_MTName" runat="server"  MaxLength="30" Width="250"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: right; padding-right: 5px;">
                        说明：</div>
                </td>
                <td>
                    <asp:TextBox ID="txt_MTDescription" runat="server" Width="250px" MaxLength="120"
                         Height="40px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: right; padding-right: 5px;">
                        排充：</div>
                </td>
                <td>
                    <asp:TextBox ID="txt_MTorder" runat="server"  MaxLength="30" Width="250"
                        onkeypress="return event.keyCode&gt;=48&amp;&amp;event.keyCode&lt;=57" onpaste="return !clipboardData.getData('text').match(/\D/)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="mt_btn_save" class="button" runat="server" Text=" 保 存 " OnClick="mt_btn_save_Click" />
                    <asp:Button ID="mt_btn_update" runat="server" class="button" Text=" 更  新 " OnClick="mt_btn_update_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="mt_btn_delete" class="button" runat="server" Text=" 删 除 " OnClick="mt_btn_delete_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="EditModulePanel" Visible="false" runat="server" Style="margin: 10px;float: left;">
        <table width="310" border="0" cellpadding="0" cellspacing="2">
            <tr>
                <td style="text-align: right;">
                    所属分类：
                </td>
                <td>
                    <asp:DropDownList ID="txt_MT" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    名称：
                </td>
                <td width="260">
                    <asp:TextBox ID="txt_name" Width="250" MaxLength="30"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    标识：
                </td>
                <td>
                    <asp:TextBox ID="txt_tag" Width="250" MaxLength="30"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    地址：
                </td>
                <td>
                    <asp:TextBox ID="txt_url" Width="250"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="txt_state" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">启用</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    排序：
                </td>
                <td>
                    <asp:TextBox ID="txt_order" Width="250" MaxLength="4"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    说明：
                </td>
                <td>
                    <asp:TextBox ID="txt_Description" Width="250px" MaxLength="120" 
                        runat="server" Height="40px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; white-space: nowrap;">
                    显示到菜单：
                </td>
                <td>
                    <asp:RadioButtonList ID="IsMenu" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                        <asp:ListItem Value="0">不显示</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    权限
                    <asp:Label ID="AuthorityNum" runat="server" Text="0" Style="display: none"></asp:Label>
                    <asp:Label ID="M_ID" runat="server" Text="" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background-color: #fff; margin-top: 10px; margin-bottom: 10px; border: 1px solid #ccc;">
                        <div style="border-top: 1px solid #666; border-left: 1px solid #666; border-right: 1px solid #fff;
                            border-bottom: 1px solid #fff;">
                            <div style="border-top: 1px solid #666; border-left: 1px solid #666; border-right: 1px solid #c1c1c1;
                                border-bottom: 1px solid #c1c1c1;">
                                <table border="0" cellpadding="0" cellspacing="2">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100">
                                            <div id="divstate" runat="server">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="m_btn_save" class="button" runat="server" Text=" 保 存 " OnClick="m_btn_save_Click" />
                    <asp:Button ID="m_btn_update" class="button" runat="server" Text=" 更 新 " OnClick="btn_update_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="m_btn_delete" class="button" runat="server" Text=" 删 除 " OnClick="m_btn_delete_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
