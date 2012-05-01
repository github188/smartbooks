<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsAdd.aspx.cs" Inherits="SmartTeaching.admin.newsAdd"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加文章</title>
    <link href="../css/Manage.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css"
        rel="stylesheet" type="text/css" />
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../Scripts/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script type="text/jscript" src="../Scripts/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tab1">添加文章</a></li>
        </ul>
        <div id="tab1">
            <table>
                <tr>
                    <td>
                        文章标题：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="350"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        文章分类：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNewaType" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        文章摘要：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Width="350px" Height="57px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        文章内容：
                    </td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="500px" Height="104px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        附件资料：
                    </td>
                    <td>
                        <asp:FileUpload ID="fileup" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
