<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NegativeReported.ascx.cs"
    Inherits="SmartPomsApp.poms.ascx.NegativeReported" %>
<asp:DataList ID="ddlViewList" runat="server">
    <ItemTemplate>
        <div id="jqpageresultitem">
            <a id="jqpageresultitemtitle" href='<%# Eval("REFERER")%>' target="_blank">
                <%# Eval("TITLE") %></a> <span id="jqpageresultitemreferer">
                    <%# Eval("REFERER")%></span> <a>网页快照</a>
            <p>
                <span id="jqpageresultitempublishdate">
                    <%#Eval("PUBLISHDATE")%>
                    -&nbsp;</span>
                <%#Eval("DETAIL")%><b>...</b></p>
            <!--相关信息-->
            <ul id="jqpageresultiteminfo">
                <li>媒体:<%# Eval("SOURCE") %></li>
                <li>作者:<%# Eval("AUTHOR") %></li>
                <li>浏览:<%# Eval("CLICK")%></li>
                <li>回复:<%# Eval("COMMENT")%></li>
                <li>评分:<%# Eval("SCORE")%></li>
            </ul>
            <!--相似文章1-3条-->
            <ul id="jqpageresultitemrelated">
                <li><a>相似文章<a></li>
            </ul>
        </div>
    </ItemTemplate>
</asp:DataList>