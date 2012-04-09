<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorityPage.ascx.cs"
    Inherits="SmartPoms.admin.ascx.AuthorityPage" %>
<asp:Panel ID="TitlePanel" runat="server"  GroupingText="权限管理" Width="800">
    <asp:Panel ID="ChildPanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="名称："></asp:Label>
        <asp:TextBox ID="txt_Name" Width="120" MaxLength="30" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="标识："></asp:Label>
        <asp:TextBox ID="txt_Tag" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="说明："></asp:Label>
        <asp:TextBox ID="txt_Description" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label4" runat="server" Text="排序："></asp:Label>
        <asp:TextBox ID="txt_order" Width="30px" runat="server" 
            onkeypress="return event.keyCode>=48&&event.keyCode<=57"
            onpaste="return !clipboardData.getData('text').match(/\D/)">
        </asp:TextBox><br /><br />
        <asp:Button ID="btn_add" CssClass="smallbtn" runat="server" Text="新增" OnClick="btn_add_Click" />
    </asp:Panel>
    <div id="strinfo" runat="server" class="mbox pbox" visible="false"></div>
    <asp:GridView ID="AuthorityLists" runat="server" DataKeyNames="AuthorityID" CssClass="Grid"
        AllowSorting="True" OnRowCommand="AuthorityLists_RowCommand" OnRowDataBound="AuthorityLists_RowDataBound"
        AllowPaging="True" OnPageIndexChanging="AuthorityLists_PageIndexChanging" PageSize="15"
        AutoGenerateColumns="False" OnRowCancelingEdit="AuthorityLists_RowCancelingEdit"
        OnRowEditing="AuthorityLists_RowEditing" OnRowUpdating="AuthorityLists_RowUpdating" Width="100%">
        <FooterStyle  />
        <RowStyle CssClass="Row" />
        <Columns>
            <asp:BoundField DataField="AuthorityID" HeaderText="编号" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="Lab_name" runat="server" Text='<%# Eval("AuthorityName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_name" Width="120" MaxLength="30" runat="server" Text='<%# Eval("AuthorityName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标识">
                <ItemTemplate>
                    <asp:Label ID="Lab_tag" runat="server" Text='<%# Eval("AuthorityTag") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_tag" Width="120" MaxLength="30" runat="server" Text='<%# Eval("AuthorityTag") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明">
                <ItemTemplate>
                    <asp:Label ID="Lab_Description" runat="server" Text='<%# Eval("AuthorityDescription") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Description" Width="120" MaxLength="30" runat="server" Text='<%# Eval("AuthorityDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排序">
                <ItemTemplate>
                    <asp:Label ID="lab_order" runat="server" Text='<%# Eval("AuthorityOrder") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_order" Width="30" MaxLength="3" onkeypress="return event.keyCode>=48&&event.keyCode<=57"
                        onpaste="return !clipboardData.getData('text').match(/\D/)" runat="server" Text='<%# Eval("AuthorityOrder") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_Edit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CommandArgument='<%# Eval("AuthorityID")%>'></asp:LinkButton>
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
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btn_del" runat="server" CausesValidation="False" CommandName="Del"
                        Text="删除" CommandArgument='<%# Eval("AuthorityID")%>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="HeadingCell" />
        <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
    </asp:GridView>
    <div id="GridViewMsg" style="padding: 5px; float:left;" runat="server">
    </div>
</asp:Panel>
