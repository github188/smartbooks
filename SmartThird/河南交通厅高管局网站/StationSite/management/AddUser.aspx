<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="management_AddUser" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>添加收费站用户信息-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />修改密码</div>
    </div>
    
    <div class="mar_l50 mar_t50">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <table width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="100" height="30" align="right">用户名：</td>
    <td>
        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">密码：</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" Width="250px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">所属收费站：</td>
    <td>
        <asp:DropDownList ID="ddlStation" runat="server" Width="255px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/management/images/botton_gif_009.gif" OnClick="ImageButton1_Click" /></td>
  </tr>
</table>
</ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    </div>
    </form>
</body>
</html>
