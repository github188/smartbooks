<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminHander.ascx.cs"
    Inherits="SmartPoms.Ascx.AdminHander" %>

<div id="handerleft">
    <span class="username">
    <%=SmartPoms.Code.SessionBox.GetUserSession().LoginName %>
    </span>
</div>
<div id="handerright">
    <asp:Button ID="btnGoHome" runat="server" Text="首页" onclick="btnGoHome_Click" />
    <asp:Button ID="btnGoBack" runat="server" Text="后退" onclick="btnGoBack_Click" />
    <asp:Button ID="btnGo" runat="server" Text="前进" onclick="btnGo_Click" />
    <asp:Button ID="btnRefresh" runat="server" Text="刷新" 
        onclick="btnRefresh_Click" />
    <asp:Button ID="btnQuit" runat="server" Text="退出" onclick="btnQuit_Click" />
    <span class="handerserverdate">服务器时间: 
        <%=DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") %>
        <%=DateTime.Now.DayOfWeek %>
        <%=DateTime.Now.DayOfYear %>/366
    </span>
</div>