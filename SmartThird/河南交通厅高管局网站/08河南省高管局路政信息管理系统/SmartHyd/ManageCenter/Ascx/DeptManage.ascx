<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DeptManage" %>
<div id="contents">
<table width="100%" border="1">
<tr><td><span>当前部门：</span><div id="deptUrl" runat="server"></div></td>
<td>
    <asp:Button ID="BtnAdd" runat="server" Text="新增" onclick="BtnAdd_Click" />
</td>
</tr>
<tr>
<td colspan="2">
<div id="deptbind" runat="server"></div>
</td>
</tr>
</table>
</div>
