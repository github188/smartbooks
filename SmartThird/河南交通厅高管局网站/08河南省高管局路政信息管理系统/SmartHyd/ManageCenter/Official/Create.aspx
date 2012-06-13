<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.Create" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新建公文</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/kindeditor-4.0.5/kindeditor-min.js" type="text/javascript"></script>
    <script src="../../Scripts/kindeditor-4.0.5/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(function () {
            /*编辑器*/
            var editor;
            KindEditor.ready(function (K) {
                /*发文内容*/
                editor = K.create('textarea[id="txtContent"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                    width: "100%",
                    height: "260px"
                });
            });
        });
    </script>
    <style type="text/css">
        #TreeViewAcceptUnit
        {
            overflow: scroll;
            width: 270px;
            height: 100%;
            float: right;
            border: 1px solid #A6C9E2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td colspan="2">
                    <asp:Label ID="lblSourceTitle" runat="server" Text="新建公文"></asp:Label>
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
                    <asp:HiddenField ID="hidParentPrimary" runat="server" Value="0" />
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="100%" MaxLength="80">
                    </asp:TextBox>
                </td>
                <td rowspan="5" valign="top">
                    <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeview" 
                        ImageSet="Arrows" 
                        onselectednodechanged="TreeViewAcceptUnit_SelectedNodeChanged">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
                            VerticalPadding="0px" ForeColor="#5555DD" />
                    </asp:TreeView>
                </td>
            </tr>
            <!--发文字号-->
            <tr>
                <td nowrap="nowrap" class="TableData">
                    发文字号:
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtSendCode" runat="server" CssClass="input" Width="100%" MaxLength="80"></asp:TextBox>
                </td>
            </tr>
            <!--发文内容-->
            <tr>
                <td nowrap="nowrap" class="TableData" valign="top">
                    发文内容:
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="4000" Width="100%" Height="200">
                    </asp:TextBox>
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
                    <a href="../OfficialType/Create.aspx">新建公文分类</a>
                </td>
            </tr>
            <!--发文分值-->
            <tr>
                <td nowrap="nowrap" class="TableData">
                    高级选项:
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtSCORE" runat="server" CssClass="input" Width="40" MaxLength="5">0</asp:TextBox>
                    <asp:CheckBox ID="chkIsReply" runat="server" Text="允许回复" CssClass="input" Checked="true" />
                    <%--<asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                        <asp:ListItem Text="0.已审核√" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="1.未审核×" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2.草稿箱×" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3.已删除×" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4.已隐藏×" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5.已结贴√" Value="5"></asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
                <td class="TableData" nowrap="nowrap">
                    <asp:LinkButton ID="lnkSelectAll" runat="server">全选</asp:LinkButton>
                    <asp:LinkButton ID="lnkSelectNoAll" runat="server">反选</asp:LinkButton>
                    <asp:LinkButton ID="lnkSelectUnit" runat="server">运营单位</asp:LinkButton>
                    <asp:LinkButton ID="lnkSelectGroup" runat="server">路政大队</asp:LinkButton>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td colspan="3" nowrap="nowrap">
                    <asp:Button ID="btnSubmit" runat="server" Text="发送" CssClass="Button" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="存草稿" CssClass="Button" OnClick="btnSave_Click" />
                    <asp:Button ID="btnPrint" runat="server" Text="打印" CssClass="Button" OnClick="btnPrint_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
