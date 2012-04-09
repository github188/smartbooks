<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.ConfigPage" %>
<asp:Panel ID="TitlePanel" runat="server"  GroupingText="系统配置">
    <div id="strinfo" runat="server" class="mbox pbox" visible="false"></div>
    <asp:GridView ID="ConfigList" runat="server" DataKeyNames="ItemID" CssClass="Grid"
        AllowSorting="True" OnRowDataBound="ConfigList_RowDataBound" AllowPaging="True"
        OnPageIndexChanging="ConfigList_PageIndexChanging" PageSize="15" AutoGenerateColumns="False"
        OnRowCancelingEdit="ConfigList_RowCancelingEdit" OnRowEditing="ConfigList_RowEditing"
        OnRowUpdating="ConfigList_RowUpdating">
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="编号" ReadOnly="True" Visible="False">
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:BoundField>
            <asp:BoundField DataField="ItemName" HeaderText="配置项" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="配置值">
                <ItemTemplate>
                    <asp:Label ID="Lab_value" runat="server" Text='<%# Eval("ItemValue") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_value" Width="120" MaxLength="30"  runat="server"
                        Text='<%# Eval("ItemValue") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:BoundField DataField="ItemDescription" HeaderText="说明" ReadOnly="True">
                <ItemStyle Wrap="false" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CommandArgument='<%# Eval("ItemID")%>'></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="btn_update" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btn_cancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="HeadingCell" />
        <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
    </asp:GridView>
</asp:Panel>
