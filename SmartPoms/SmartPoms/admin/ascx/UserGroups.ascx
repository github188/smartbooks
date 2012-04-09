<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGroups.ascx.cs"
    Inherits="SmartPoms.admin.ascx.UserGroups" %>
<asp:Panel ID="TitlePanel" runat="server" GroupingText="用户分组管理" Width="95%" >
    <asp:Panel ID="ChildPanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="所属上级："></asp:Label>
        <asp:DropDownList ID="gtList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gtList_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="名称："></asp:Label>
        <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="说明："></asp:Label>
        <asp:TextBox ID="txt_Description" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="排序："></asp:Label>
        <asp:TextBox ID="txt_order" Width="30px" runat="server" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
            onpaste="return !clipboardData.getData('text').match(/\D/)" MaxLength="3"></asp:TextBox>
        <asp:Button ID="btn_add" CssClass="smallbtn" runat="server" Text="新增" OnClick="btn_add_Click" />
    </asp:Panel>
    <div id="strinfo" runat="server" class="mbox pbox" visible="false">
    </div>
    <asp:GridView ID="GroupsLists" runat="server" DataKeyNames="UG_ID" CssClass="Grid"
        AllowSorting="True" OnRowCommand="GroupsLists_RowCommand" OnRowDataBound="GroupsLists_RowDataBound"
        AllowPaging="True" OnPageIndexChanging="GroupsLists_PageIndexChanging" PageSize="15"
        AutoGenerateColumns="False" OnRowCancelingEdit="GroupsLists_RowCancelingEdit"
        OnRowEditing="GroupsLists_RowEditing" OnRowUpdating="GroupsLists_RowUpdating"
         Width="100%">
        <FooterStyle  />
        <RowStyle CssClass="Row" />
        <Columns>
            <asp:BoundField HeaderText="分组编号" DataField="UG_ID" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="Lab_name" runat="server" Text='<%# Eval("UG_Name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_name" Width="120" MaxLength="30" runat="server" Text='<%# Eval("UG_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明">
                <ItemTemplate>
                    <asp:Label ID="Lab_Description" runat="server" Text='<%# Eval("UG_Description")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Description" Width="120" MaxLength="30" runat="server" Text='<%# Eval("UG_Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序">
                <ItemTemplate>
                    <asp:Label ID="lab_order" runat="server" Text='<%# Eval("UG_Order") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_order" Width="30" MaxLength="3" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
                        onpaste="return !clipboardData.getData('text').match(/\D/)" runat="server" Text='<%# Eval("UG_Order") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CommandArgument='<%# Eval("UG_ID")%>'></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btn_update" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btn_cancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_del" runat="server" CausesValidation="False" CommandName="Del"
                        Text="删除" CommandArgument='<%# Eval("UG_ID")%>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="HeadingCell" />
        <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
    </asp:GridView>
    <div id="GridViewMsg" style="padding: 5px; float:left;" runat="server">
    </div>
</asp:Panel>
