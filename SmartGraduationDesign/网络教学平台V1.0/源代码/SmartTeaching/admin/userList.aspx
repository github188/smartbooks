<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userList.aspx.cs" Inherits="SmartTeaching.admin.userList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
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
            <li><a href="#tab1">用户管理</a></li>
        </ul>
        <div id="tab1">
            <table class="table_width">
                <tr>
                    <td id="Right_Seach">
                        请输入用户账号：
                        <asp:TextBox ID="txtserach" runat="server"></asp:TextBox>
                    </td>
                    <td id="Reght_IS">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    </td>
                </tr>
                <tr>
                    <td id="right_list" colspan="2">
                        <asp:DataList ID="dlAdmin" runat="server" Width="100%" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <ItemStyle ForeColor="#000066" />
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="au_01">
                                            用户编号
                                        </td>
                                        <td class="au_02">
                                            用户账号
                                        </td>
                                        <td class="au_03">
                                            用户密码
                                        </td>
                                        <td class="au_05">
                                            操作
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="au_01">
                                            <%#Eval("UserId") %>
                                        </td>
                                        <td class="au_02">
                                            <a href="userAdd.aspx?id=<%# DataBinder.Eval(Container.DataItem, "UserId")%>"><%#Eval("UserName") %></a>
                                        </td>
                                        <td class="au_03">
                                            <%#Eval("Userpwd") %>
                                        </td>
                                        <td class="au_05">
                                            <asp:LinkButton ID="lklUpdate" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                OnClick="lklUpdate_Click">编辑</asp:LinkButton>┆
                                            <asp:LinkButton ID="lklDelete" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                OnClick="lklDelete_Click">删除</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td class="right_Page" colspan="2">
                        当前页码为： 『<asp:Label ID="labNowPageNum" runat="server" Text="1"></asp:Label>』总页码为：
                        『<asp:Label ID="labAllPageNum" runat="server"></asp:Label>』
                        <asp:LinkButton ID="lklFirst" runat="server" OnClick="lklFirst_Click">首页&nbsp;&nbsp;</asp:LinkButton>
                        <asp:LinkButton ID="lklBack" runat="server" OnClick="lklBack_Click">上一页&nbsp;&nbsp;</asp:LinkButton>
                        <asp:LinkButton ID="lklNext" runat="server" OnClick="lklNext_Click">下一页&nbsp;&nbsp;</asp:LinkButton>
                        <asp:LinkButton ID="lklLast" runat="server" OnClick="lklLast_Click">尾页</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
