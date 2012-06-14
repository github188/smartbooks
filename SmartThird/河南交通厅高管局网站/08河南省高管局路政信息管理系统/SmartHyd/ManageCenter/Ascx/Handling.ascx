<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Handling.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Handling" %>
<table width="100%">
            <tr>
                <td>
                    时间段：
                </td>
                <td>
                    <asp:TextBox ID="txtBEGINTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                    至<asp:TextBox ID="txtENDTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    处理情况：
                </td>
                <td>
                    <asp:TextBox ID="txtLog" runat="server" CssClass="input" TextMode="MultiLine">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    备注：
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>