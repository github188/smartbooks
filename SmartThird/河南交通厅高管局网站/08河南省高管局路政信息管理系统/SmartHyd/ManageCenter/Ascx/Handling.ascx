<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Handling.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Handling" %>
<table width="100%">
    <tr>
        <td>
            时间段：
        </td>
        <td>
            <asp:TextBox ID="txtBEGINDate" ReadOnly="true" runat="server" CssClass="input {required:true}"
                Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtBEGINTIME"  ReadOnly="true" runat="server" CssClass="input {required:true}" Width="70px"></asp:TextBox><span>至</span>
            <asp:TextBox ID="txtENDDate" ReadOnly="true" runat="server" CssClass="input {required:true}"
                Width="80px"></asp:TextBox>
            <asp:TextBox ID="txtENDTIME" ReadOnly="true" runat="server" CssClass="input {required:true}" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            处理情况：
        </td>
        <td>
            <asp:TextBox ID="txtLog" runat="server" CssClass="input" TextMode="MultiLine" Style="margin-right: 517px"
                Width="647px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            备注：
        </td>
        <td>
            <asp:TextBox ID="txtRemark" runat="server" CssClass="input" TextMode="MultiLine"
                Height="79px" Width="658px"></asp:TextBox>
        </td>
    </tr>
</table>
