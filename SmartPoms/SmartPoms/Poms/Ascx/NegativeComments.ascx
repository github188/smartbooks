<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NegativeComments.ascx.cs" Inherits="SmartPoms.Poms.Ascx.NegativeComments" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="负面评论文章" Width="95%">
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="Label1" runat="server" Text="开始时间："></asp:Label>
        <asp:TextBox ID="txtBeginDate" runat="server" MaxLength="15"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="结束时间："></asp:Label>
        <asp:TextBox ID="txtEndDate" runat="server" MaxLength="15"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
    <br />
    <asp:GridView ID="dgvComments" runat="server" AllowPaging="True" Width="100%"
        onpageindexchanging="dgvComments_PageIndexChanging" 
        EnableModelValidation="True" PageSize="50" >
        <Columns>                    
            <asp:TemplateField HeaderText="原文链接">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("页面链接") %>' Target="_blank">查看
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>                    
        </Columns>
        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
            Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />        
    </asp:GridView>
</asp:Panel>