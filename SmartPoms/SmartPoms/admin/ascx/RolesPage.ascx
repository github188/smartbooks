<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RolesPage.ascx.cs" Inherits="SmartPoms.admin.ascx.RolesPage" %>
<asp:Panel ID="TitlePanel" runat="server" GroupingText="角色管理" Width="95%">
    <asp:Panel ID="addpanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="分组："></asp:Label>
        <asp:DropDownList ID="GroupList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="GroupList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="名称："></asp:Label>
        <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="说明："></asp:Label>
        <asp:TextBox ID="txt_Description" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="排序："></asp:Label>
        <asp:TextBox ID="txt_order" Width="30px" runat="server" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
            onpaste="return !clipboardData.getData('text').match(/\D/)"></asp:TextBox><br /><br />
        <asp:Button ID="btn_add" CssClass="smallbtn" runat="server" Text="新增" OnClick="btn_add_Click" />
    </asp:Panel>
    <div id="strinfo" runat="server" class="mbox pbox" visible="false">
    </div>
    <asp:GridView ID="RolesLists" runat="server" DataKeyNames="RoleID" CssClass="Grid"
        AllowSorting="True" OnRowCommand="RolesLists_RowCommand" OnRowDataBound="RolesLists_RowDataBound"
        AllowPaging="True" OnPageIndexChanging="RolesLists_PageIndexChanging" PageSize="15"
        AutoGenerateColumns="False" OnRowCancelingEdit="RolesLists_RowCancelingEdit"
        OnRowEditing="RolesLists_RowEditing" OnRowUpdating="RolesLists_RowUpdating" Width="100%">
        <FooterStyle  />
        <RowStyle CssClass="Row" />
        <Columns>
            <asp:BoundField DataField="RoleID" HeaderText="编号" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="Lab_name" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_name" Width="120" MaxLength="30" runat="server" Text='<%# Eval("RoleName") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明">
                <ItemTemplate>
                    <asp:Label ID="Lab_Description" runat="server" Text='<%# Eval("RoleDescription") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Description" Width="120" MaxLength="30" runat="server" Text='<%# Eval("RoleDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="分组">
                <ItemTemplate>
                    <asp:Label ID="Lab_GroupID" runat="server" Text='<%# Eval("RoleGroupID") %>'></asp:Label>
                    <asp:Label ID="hid_GroupID" runat="server" Text='<%# Eval("RoleGroupID") %>' Style="display: none;"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Lab_GroupID" runat="server" Text='<%# Eval("RoleGroupID") %>' Style="display: none;"></asp:Label>
                    <asp:Label ID="hid_GroupID" runat="server" Text='<%# Eval("RoleGroupID") %>' Style="display: none;"></asp:Label>
                    <asp:DropDownList ID="GroupID" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序">
                <ItemTemplate>
                    <asp:Label ID="lab_order" runat="server" Text='<%# Eval("RoleOrder") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_order" Width="30" MaxLength="3" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
                        onpaste="return !clipboardData.getData('text').match(/\D/)" runat="server" Text='<%# Eval("RoleOrder") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CommandArgument='<%# Eval("RoleID")%>'></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btn_update" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btn_cancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_del" runat="server" CausesValidation="False" CommandName="Del"
                        Text="删除" CommandArgument='<%# Eval("RoleID")%>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="HeadingCell" />
        <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
    </asp:GridView>
    <div id="GridViewMsg" style="padding: 5px; float:left;" runat="server">
    </div>
</asp:Panel>
