<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RolesAuthorizedPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.RolesAuthorizedPage" %>
<asp:Panel ID="TitlePanel" runat="server" GroupingText="角色授权" Width="95%">
    <div id="strinfo" runat="server" class="mbox pbox" visible="false">
    </div>
    <table border="0" cellpadding="0" cellspacing="2" class="table">
        <tr>
            <td style="white-space: nowrap;" valign="top">
                <div style="height: 24px; line-height: 24px;">
                    <asp:DropDownList ID="GroupList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="GroupList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="Rid" runat="server" Text="" Style="display: none;"></asp:Label>
                </div>
                <div style="margin-top: 5px;">
                    <asp:GridView ID="RoleView" Width="100px" runat="server" DataKeyNames="RoleID" AllowSorting="True"
                        OnRowCommand="RoleView_RowCommand" AutoGenerateColumns="False" ShowHeader="False"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="RoleID" HeaderText="编号" Visible="false">
                                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="名称">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_name" CommandArgument='<%# Eval("RoleID")%>' CommandName="EditView"
                                        runat="server" Text='<%# Eval("RoleName") %>' ToolTip='<%# Eval("RoleDescription") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="100px" Height="24px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td style="white-space: nowrap;" valign="top">
                <div style="height: 24px; line-height: 24px;">
                    <div class="rowdiv">
                        <asp:DropDownList ID="ModuleTypeList" runat="server" Enabled="false" AutoPostBack="True"
                            OnSelectedIndexChanged="ModuleTypeList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="margin-top: 5px;">
                    <asp:GridView ID="ModuleView" runat="server" DataKeyNames="ModuleID" CssClass="Grid"
                        AllowSorting="True" AutoGenerateColumns="False" OnRowDataBound="ModuleView_RowDataBound"
                        OnSelectedIndexChanging="ModuleView_SelectedIndexChanging">
                        <FooterStyle />
                        <RowStyle CssClass="Row" />
                        <Columns>
                            <asp:TemplateField HeaderText="模块名称">
                                <ItemTemplate>
                                    <asp:Label ID="lab_ID" runat="server" Text='<%# Eval("ModuleID")%>' Style="display: none"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ModuleName") %>'></asp:Label>
                                    <asp:Label ID="lab_Verify" runat="server" Text="" Style="display: none"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="权限列表">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="AuthorityList" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" 更新 ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_update" runat="server" CommandArgument='<%# Eval("ModuleID")%>'
                                        CausesValidation="False" CommandName="Select" Text="更新"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="HeadingCell" />
                        <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
                    </asp:GridView>
                </div>
                <div style="height: 24px; line-height: 24px; margin-top: 5px;">
                    <asp:Button ID="btn_AllSave" runat="server" CssClass="smallbtn" Visible="false" Text="保存全部"
                        OnClick="btn_AllSave_Click" />
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>
