<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGrant.ascx.cs" Inherits="SmartPoms.admin.ascx.UserGrant" %>

<asp:Panel ID="TitlePanel" runat="server" Width="95%" >
    给<asp:Label ID="UNAME" runat="server" ForeColor="Red"></asp:Label>授权
    <asp:Label ID="UID" runat="server" Text="" Style="display: none;"></asp:Label>，
    <asp:Label ID="Label2" runat="server" Text="允许和禁止都被选中或为空将删除该权限" ForeColor="#FF6600"></asp:Label>
    <asp:Label ID="TID" runat="server" Text="" Style="display: none;"></asp:Label>
</asp:Panel>

<asp:Panel ID="ChildPanel" runat="server" Width="95%" >
    <asp:Label ID="Label3" runat="server" Text="请选择授权类型："></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="0">模块授权</asp:ListItem>
        <asp:ListItem Value="1">用户角色</asp:ListItem>
    </asp:DropDownList>
</asp:Panel>

<div id="strinfo" runat="server" class="mbox pbox" visible="false">
</div>

<br />
<asp:Panel ID="ModelPanel" runat="server" Width="95%" >
    <div style="float: left;">
        <asp:GridView ID="ModuleTypeView" Width="100px" runat="server" DataKeyNames="ModuleTypeID"
            AllowSorting="True" OnRowCommand="ModuleType_RowCommand" AutoGenerateColumns="False"
            ShowHeader="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="ModuleTypeID" HeaderText="编号" Visible="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="false" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtn_name" CommandArgument='<%# Eval("ModuleTypeID")%>' CommandName="EditView"
                            runat="server" Text='<%# Eval("ModuleTypeName") %>' ToolTip='<%# Eval("ModuleTypeDescription") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" Height="24px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="float: left; margin-left: 10px;">
        <asp:GridView ID="ModuleView" Width="100px" runat="server" DataKeyNames="ModuleID"
            CssClass="Grid" AllowSorting="True" AutoGenerateColumns="False" OnRowDataBound="ModuleView_RowDataBound"
            OnSelectedIndexChanging="ModuleView_SelectedIndexChanging">
            <FooterStyle  />
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
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="white-space: nowrap;">
                                    <div align="center" style="color: #339900;">
                                        允许</div>
                                </td>
                                <td style="white-space: nowrap;">
                                    <asp:CheckBoxList ID="AuthorityList_Grant" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <div align="center" style="color: #FF0000;">
                                        禁止</div>
                                </td>
                                <td style="white-space: nowrap;">
                                    <asp:CheckBoxList ID="AuthorityList_Deny" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
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
        <div style="height: 24px; line-height: 24px; margin-top: 5px;">
            <asp:Button ID="btn_AllSave" runat="server" Visible="false" CssClass="smallbtn" Text="保存全部"
                OnClick="btn_AllSave_Click" />
        </div>
    </div>
</asp:Panel>
<br />
<asp:Panel ID="RolePanel" runat="server" Width="95%" >
    <table width="500" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
        <tr>
            <td width="200" height="30" bgcolor="#CCCCCC">
                <div align="center">
                    用户角色</div>
            </td>
            <td width="100" bgcolor="#CCCCCC">
                <div align="center" style="color: #FFFFFF;">
                </div>
            </td>
            <td width="200" bgcolor="#CCCCCC">
                <div align="center">
                    系统角色列表</div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFFF">
                <div align="center" style="margin: 10px;">
                    <asp:ListBox ID="RoleList" runat="server" Style="width: 160px;" SelectionMode="Multiple"
                        Height="205px"></asp:ListBox>
                    <asp:TextBox ID="OldRoleList" runat="server" Style="display: none;"></asp:TextBox>
                    <asp:TextBox ID="TRoleList" runat="server" Style="display: none;"></asp:TextBox>
                </div>
            </td>
            <td bgcolor="#FFFFFF">
                <div align="center">
                    <input id="btn_plus" type="button" value="   <<   " onclick="javascript:copyToList('FromRoleList','RoleList')" /><br />
                    <br />
                    <input id="btn_subtract" type="button" value="   >>   " onclick="javascript:copyToList('RoleList','FromRoleList')" /><br />
                    <br />
                    <asp:Button ID="btn_saverole" runat="server" Text=" 保 存 " OnClick="btn_saverole_Click" /><br />
                    <br />
                    按下CTRL鍵<br />
                    可以多選
                </div>
            </td>
            <td bgcolor="#FFFFFF">
                <div align="center" style="margin: 10px;">
                    <asp:ListBox ID="FromRoleList" runat="server" Style="width: 160px;" SelectionMode="Multiple"
                        Height="205px"></asp:ListBox>
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>
