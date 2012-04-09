<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupsPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.GroupsPage" %>
<asp:Panel ID="TitlePanel" runat="server" GroupingText="分组管理" Width="95%">
    <asp:Panel ID="ChildPanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="类型："></asp:Label>
        <asp:DropDownList ID="gtList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gtList_SelectedIndexChanged">
            <asp:ListItem Value="1">角色分组</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="名称："></asp:Label>
        <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="说明："></asp:Label>
        <asp:TextBox ID="txt_Description" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="排序："></asp:Label>
        <asp:TextBox ID="txt_order" Width="30px" runat="server" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
            onpaste="return !clipboardData.getData('text').match(/\D/)">
        </asp:TextBox><br /><br />
        <asp:Button ID="btn_add" CssClass="smallbtn" runat="server" Text="新增" OnClick="btn_add_Click" />
        <div id="strinfo" runat="server" class="mbox pbox" visible="false">
        </div>
    </asp:Panel>
    <asp:GridView ID="GroupsLists" runat="server" DataKeyNames="GroupID" CssClass="Grid"
        AllowSorting="True" OnRowCommand="GroupsLists_RowCommand" OnRowDataBound="GroupsLists_RowDataBound"
        AllowPaging="True" OnPageIndexChanging="GroupsLists_PageIndexChanging" PageSize="15"
        AutoGenerateColumns="False" OnRowCancelingEdit="GroupsLists_RowCancelingEdit"
        OnRowEditing="GroupsLists_RowEditing" OnRowUpdating="GroupsLists_RowUpdating" Width="100%">
        <FooterStyle  />
        <RowStyle CssClass="Row" />
        <Columns>
            <asp:BoundField HeaderText="分组编号" DataField="GroupID" ReadOnly="true">
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="Lab_name" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_name" Width="120" MaxLength="30" runat="server" Text='<%# Eval("GroupName") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明">
                <ItemTemplate>
                    <asp:Label ID="Lab_Description" runat="server" Text='<%# Eval("GroupDescription")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Description" Width="120" MaxLength="30" runat="server" Text='<%# Eval("GroupDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序">
                <ItemTemplate>
                    <asp:Label ID="lab_order" runat="server" Text='<%# Eval("GroupOrder") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_order" Width="30" MaxLength="3" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
                        onpaste="return !clipboardData.getData('text').match(/\D/)" runat="server" Text='<%# Eval("GroupOrder") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CommandArgument='<%# Eval("GroupID")%>'></asp:LinkButton>
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
                        Text="删除" CommandArgument='<%# Eval("GroupID")%>'></asp:LinkButton>
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
