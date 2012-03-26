<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeiBo.ascx.cs" Inherits="SmartPoms.Poms.Ascx.WeiBo" %>
<asp:Panel ID="panelParam" runat="server" Width="95%" GroupingText="参数设置">
    
</asp:Panel>
<asp:Panel ID="panelResult" runat="server" Width="95%" GroupingText="监测结果">
    <asp:GridView ID="dgvResult" runat="server" AllowPaging="True" Width="100%" OnPageIndexChanging="dgvResult_PageIndexChanging"
        EnableModelValidation="True" PageSize="50" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="发布时间">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="内容">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="作者">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
            NextPageText="下一页" PreviousPageText="上一页" />
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="panelWeiBoList" runat="server" Width="95%" GroupingText="微博网站">
    
    <asp:Panel ID="panelSina" runat="server" GroupingText="新浪微博">        
        <div id="weibosina" class="weiboScrollBox">            
        </div>
    </asp:Panel>

    <asp:Panel ID="panelTx" runat="server" GroupingText="腾讯微博">
        <div id="weibotx" class="weiboScrollBox"></div>
    </asp:Panel>

    <asp:Panel ID="panelWy" runat="server" GroupingText="网易微博">
        <div id="weibowy" class="weiboScrollBox"></div>
    </asp:Panel>
</asp:Panel>
