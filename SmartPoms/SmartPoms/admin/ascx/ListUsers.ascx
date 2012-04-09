<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUsers.ascx.cs" Inherits="SmartPoms.admin.ascx.ListUsers" %>


<asp:Panel ID="TitlePanel" runat="server"  GroupingText="用户管理">
    
    <asp:Panel ID="ChildPanel" runat="server">
        <asp:Label ID="Label3" runat="server" Text="名称："></asp:Label>
        <asp:DropDownList ID="GroupList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="GroupList_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="搜索用户名："></asp:Label>
        <asp:TextBox ID="txt_name"  runat="server"></asp:TextBox>
        <asp:Button ID="btn_search" CssClass="smallbtn" runat="server" Text="查找" OnClick="btn_search_Click" />
    </asp:Panel>

    <div id="strinfo" runat="server" visible="false" ></div>

    <asp:GridView ID="UserList" runat="server" DataKeyNames="UserID" CssClass="Grid"
            OnRowCommand="UserList_RowCommand" OnRowDataBound="UserList_RowDataBound" PageSize="15"
            AutoGenerateColumns="False" Width="100%">
            <FooterStyle  />
            <RowStyle CssClass="Row" />
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="编号" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="用户名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户角色">
                    <ItemTemplate>
                        <asp:Label ID="Lab_RoleName" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户组">
                    <ItemTemplate>
                        <asp:Label ID="Lab_GroupName" runat="server" Text='<%# Eval("UG_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="Lab_state" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="创建时间" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField HeaderText="最后一次登录时间" DataField="LastLoginTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="授权" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_grant" runat="server" CausesValidation="False" CommandName="Grant"
                            Text="授权" CommandArgument='<%# Eval("UserID").ToString()+","+Eval("UserName").ToString()%>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="link_view" runat="server" NavigateUrl='<%# Eval("UserID", "~/admin/EditUserPage.aspx?uid={0}") %>'
                            Text="查看详情"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_del" runat="server" CausesValidation="False" CommandName="Del"
                            Text="删除" CommandArgument='<%# Eval("UserID")%>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeadingCell" />
            <AlternatingRowStyle BorderStyle="None" CssClass="AlternatingRow" />
        </asp:GridView>

    <div id="GridViewMsg" runat="server" style="padding: 5px; float:left; height:20px;">
    </div>

</asp:Panel>