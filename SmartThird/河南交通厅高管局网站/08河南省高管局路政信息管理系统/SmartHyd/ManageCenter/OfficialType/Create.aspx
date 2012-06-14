﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="SmartHyd.ManageCenter.OfficialType.Create" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新建公文</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td colspan="3">
                    新建公文分类
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    分类名称:
                </td>
                <td class="TableData" style="width: 100%;">
                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="100%" MaxLength="80">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    分类描述:
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtSummary" runat="server" CssClass="input" Width="100%" MaxLength="80" Height="120"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData" valign="top">
                    高级选项：
                </td>
                <td class="TableData">
                    <asp:DropDownList ID="ddlTypeId" runat="server" CssClass="input">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSort" runat="server" CssClass="input" Width="20" Text="1" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td colspan="3" nowrap="nowrap">
                    <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="Button" 
                        onclick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" 
                        onclick="btnCancel_Click"  />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
