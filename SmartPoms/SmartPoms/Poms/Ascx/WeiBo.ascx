<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeiBo.ascx.cs" Inherits="SmartPoms.Poms.Ascx.WeiBo" %>
<asp:Panel ID="panelParam" runat="server" Width="95%" GroupingText="关键词">
    <asp:TextBox ID="txtKeywordList" runat="server" 
        TextMode="MultiLine">
    </asp:TextBox>

    <asp:GridView ID="dgvResult" runat="server" AllowPaging="True" Width="100%" OnPageIndexChanging="dgvResult_PageIndexChanging"
        EnableModelValidation="True" PageSize="3" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="发布时间">
                <ItemTemplate>
                    <%# Eval("sendtime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="内容">
                <ItemTemplate>
                    <%# Eval("title") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="作者">
                <ItemTemplate>
                    <%# Eval("author") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
            NextPageText="下一页" PreviousPageText="上一页" />
    </asp:GridView>

</asp:Panel>
<asp:Panel ID="panelWeiBoList" runat="server" Width="95%" GroupingText="微博动态">
    <ul id="weiboItem" class="weiboItem"></ul>
</asp:Panel>
