<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="AdminMgr_UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区用户信息列表</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg"><p style="height:25px;"><img src="images/ico07.gif" width="20" height="18" /><span style="font-size:12px"> 按用户名查询：</span><asp:TextBox ID="txtName" runat="server" CssClass="InputBorderStyle" Width="120px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSearch.jpg" ImageAlign="absmiddle" OnClick="ImageButton1_Click" /></p></div>
    <div class="divContent">
	<div style=" text-align:right; line-height:25px;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AddUser.aspx" CssClass="Font13Add">添加用户</asp:HyperLink></div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="用户名" DataField="U_Name" >
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="密码" DataField="U_Pwd" >
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="所属服务区" DataField="S_Name" >
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="用户备注" DataField="U_Remark" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"U_ID") %>' OnClientClick="return confirm('确定要删除该用户吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        删除
                    </HeaderTemplate>
                    <ControlStyle  />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
	    </div>
	</form>
</body>
</html>
