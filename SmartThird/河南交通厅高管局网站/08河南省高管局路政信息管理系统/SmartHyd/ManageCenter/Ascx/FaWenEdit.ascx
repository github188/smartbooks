<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FaWenEdit.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.FaWenEdit" %>
<div id="content">
    <h1 align="center">
        河南省交通运输厅高速公路管理局</h1>
    <table class="edit" align="center" width="700">
        <tr>
            <td class="left" align="center">
                发文字号
            </td>
            <td class="red">
                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                <asp:TextBox ID="txNumber" runat="server" CssClass="input"></asp:TextBox>
            </td>
            <%--<td class="red" align="center">密级</td>
		<td class="red"><input type="text" name="secret" class="field" size=20
			value=""></td>--%>
        </tr>
        <tr>
            <td class="left" align="center">
                发文类型
            </td>
            <td>
                <asp:DropDownList ID="Ddl_type" runat="server" CssClass="input">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="red" align="center">
                发文标题
            </td>
            <td class="red" colspan="3">
                <asp:TextBox ID="txTitle" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="red" align="center">
                公文内容
            </td>
            <td class="red" colspan="3">
                <asp:TextBox ID="TxContent" runat="server" CssClass="input" Height="140px" TextMode="MultiLine"
                    Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="red" align="center">
                主办单位
            </td>
            <td class="red">
                <asp:DropDownList ID="DdlOrgan" runat="server" CssClass="input">
                </asp:DropDownList>
            </td>
            <%--<td class="red" align="center">缓急程度</td>
		<td class="red"><input type="text" name="priority" class="field"
			size=20 value=""></td>--%>
        </tr>
        <%--<tr>
		<td class="red" align="center">主送</td>
		<td class="red" colspan=3>&nbsp;</td>
	</tr>--%>
        <tr>
            <td class="left" align="center">
                备注
            </td>
            <td class="red" colspan="3">
                <asp:TextBox ID="TxRemark" runat="server" CssClass="input" Height="40px" TextMode="MultiLine"
                    Width="313px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left" align="center">
                附件
            </td>
            <td class="red" colspan="3">
                <asp:FileUpload ID="FileUploadPath" runat="server" CssClass="input" />
            </td>
        </tr>
        <tr>
            <td class="red" align="center" colspan='3'>
                <asp:Button ID="BtnEdit" runat="server" Text="修改" OnClick="BtnEdit_Click" />
                <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
            </td>
        </tr>
    </table>
</div>
