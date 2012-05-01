<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userAdd.aspx.cs" Inherits="SmartTeaching.admin.userAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <link href="../css/Manage.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css"
        rel="stylesheet" type="text/css" />
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script type="text/jscript" src="../Scripts/jquery-ui-1.8.18.custom/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script type="text/jscript" src="../Scripts/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tab1">用户信息</a></li>
        </ul>
        <div id="tab1">
            <table cellspacing="0" rules="all" border="1" style="border-collapse:collapse;" >
                <tr>
                    <td>
                        用户编号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtnum" runat="server" Enabled="false" Text="-1"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        登录账号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server" MaxLength="18"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        登录密码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户角色：
                    </td>
                    <td>
                        角色信息：<br />
                        <asp:RadioButtonList ID="rdoRoles" runat="server" RepeatDirection="Horizontal" Width="500">
                        </asp:RadioButtonList>
                        <br />
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
