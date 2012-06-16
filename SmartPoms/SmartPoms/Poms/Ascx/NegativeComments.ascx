<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NegativeComments.ascx.cs"
    Inherits="SmartPoms.Poms.Ascx.NegativeComments" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="查看舆情信息" Width="95%">
    <br />
    <table id="paramOption" class="table">
        <tr>
            <td width="75">
                <asp:Label ID="Label1" runat="server" Text="时间范围"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBeginDate" runat="server" MaxLength="15" Width="170" 
                    ReadOnly="true"></asp:TextBox>

                    <span>　至　</span>

                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="15" Width="170" 
                    ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <span>请选择时间范围。</span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="网站名称"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSiteName" runat="server" Width="490" Height="35" TextMode="MultiLine"
                    Text="腾讯网,新华网,新浪网,搜狐新闻,人民网,凤凰网,网易新闻,光明网">
                </asp:TextBox>
            </td>
            <td>
                <span>多个网站之间用英文,隔开。（如腾讯网,新华网）</span>
             
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtSiteName" ErrorMessage="只能输入汉字、数字、字母、英文逗号。" 
                    ValidationExpression="[0-9a-zA-Z\u4E00-\u9FA5,]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="关键字词"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtKeywordList" runat="server" TextMode="MultiLine" Width="490"
                    Height="35" Text="高速公路,高管局">
                </asp:TextBox>
            </td>
            <td>
                <span>多个关键字之间用英文,隔开。（如中国,河南,郑州）</span>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="只能输入汉字、数字、字母、英文逗号。" ControlToValidate="txtKeywordList" 
                    ValidationExpression="[0-9a-zA-Z\u4E00-\u9FA5,]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="统计方式"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoSortResult" runat="server" RepeatDirection="Horizontal"
                 Width="500" Height="35">
                    <asp:ListItem Text="点击升序" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="点击降序" Value="1"></asp:ListItem>
                    <asp:ListItem Text="评论升序" Value="2"></asp:ListItem>
                    <asp:ListItem Text="评论降序" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <span>请选择统计方式。</span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="panelResult" runat="server" GroupingText="共查询到 0 条记录">
        <asp:GridView ID="dgvComments" runat="server" AllowPaging="True" Width="100%" OnPageIndexChanging="dgvComments_PageIndexChanging"
            EnableModelValidation="True" PageSize="50" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="发布时间">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("sendtime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文章标题">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("url") %>' Target="_blank">
                           <%# Eval("title")%>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="媒体">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("media")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="作者">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("author")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="点击量">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("clicknum")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="评论量">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("commentnum")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="网站名称">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("sitename")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
                NextPageText="下一页" PreviousPageText="上一页" />
        </asp:GridView>
    </asp:Panel>
</asp:Panel>
