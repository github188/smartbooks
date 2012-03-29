<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRoadDepart.aspx.cs" Inherits="management_AddRoadDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>添加路政单位-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="box_mr2">
    
        <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />路政单位信息管理&nbsp;&nbsp;>>&nbsp;&nbsp;添加路政单位</div>
        </div>
        
        
        <div class="mar_l50 mar_t50">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      <table width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="100" height="35" align="right">
        路政单位名称：</td>
    <td>
        <asp:TextBox ID="txtName" runat="server" Width="290px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right">所属地市：</td>
    <td>
        <asp:DropDownList ID="ddlCity" runat="server" Width="294px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="40" align="right">&nbsp;</td>
    <td><asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/management/images/btn_save.gif" OnClick="ImageButton1_Click" /></td>
  </tr>
</table>
 </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        
        
    </div>
    </form>
</body>
</html>
