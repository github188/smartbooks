<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentCreate.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentCreate" %>
<table class="TableBlock" width="100%" align="center">
    <tbody>
        <!--首选行-->
        <tr class="TableHeader">
            <td colspan="2">
                新建公文
            </td>
            <td>
                收文单位
            </td>
        </tr>
        <!--发文标题-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                发文标题:
            </td>
            <td class="TableData" style="width: 100%;">
                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input {required:true,minlength:1,maxlength:800}"
                    Width="70%" MaxLength="80">
                </asp:TextBox>
                <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                </div>
            </td>
            <td rowspan="8" valign="top">
                <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeview">
                </asp:TreeView>
            </td>
        </tr>
        <!--发文字号-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                发文字号:
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtSendCode" runat="server" CssClass="input {required:true,minlength:1,maxlength:80}"
                    Width="200" MaxLength="80"></asp:TextBox>
                <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                </div>
            </td>
        </tr>
        <!--发文内容-->
        <tr>
            <td nowrap="nowrap" class="TableData" valign="top">
                发文内容:
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtContent" runat="server" CssClass="input {required:true,minlength:1,maxlength:4000}"
                    TextMode="MultiLine" MaxLength="4000" Width="100%" Height="200">
                </asp:TextBox>
                <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                </div>
            </td>
        </tr>
        <!--附件文档-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                附件文档:
            </td>
            <td class="TableData">
                <asp:FileUpload ID="fileUpAnnex" runat="server" CssClass="input" />
            </td>
        </tr>
        <!--所属分类-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                所属分类:
            </td>
            <td class="TableData">
                <asp:DropDownList ID="ddlTypeId" runat="server" CssClass="input">
                    <asp:ListItem Text="公告通知" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="年终考核" Value="0"></asp:ListItem>
                    <asp:ListItem Text="浮动考核" Value="0"></asp:ListItem>
                </asp:DropDownList>
                <a href="DocumentTypeManage.aspx">新建公文分类</a>
            </td>
        </tr>
        <!--发文分值-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                发文分值:
            </td>
            <td class="TableData">
                <asp:TextBox ID="txtSCORE" runat="server" CssClass="input {required:true,minlength:1,maxlength:3}"
                    Width="75" MaxLength="5">0</asp:TextBox>
                <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                </div>
            </td>
        </tr>
        <!--允许回复-->
        <tr>
            <td nowrap="nowrap" class="TableData">
                允许回复:
            </td>
            <td class="TableData">
                <asp:RadioButtonList ID="rdoIsReply" runat="server" RepeatDirection="Horizontal"
                    CssClass="input">
                    <asp:ListItem Text="允许回复" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="不允许回复" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <!--发文状态-->
        <tr>
            <td nowrap="nowrap" class="TableData" valign="top">
                发文状态:
            </td>
            <td nowrap="nowrap" class="TableData" valign="top">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                    <asp:ListItem Text="0.已审核√" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="1.未审核×" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2.草稿箱×" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3.已删除×" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4.已隐藏×" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5.已结贴√" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <!--操作按钮-->
        <tr class="TableControl" align="center">
            <td colspan="3" nowrap="nowrap">
                <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
                <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </tbody>
</table>
