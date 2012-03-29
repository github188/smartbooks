<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AdminMgr_AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加服务区用户信息</title>
      <link href="style/css.css" rel="stylesheet" type="text/css" />
                <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:570px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">添加服务区用户信息</div>
	<div class="divContent">
     <fieldset>
     <legend>添加服务区用户信息</legend>
     <table width="550" border="0" align="center" cellpadding="3" cellspacing="0" style="border-collapse:collapse" bordercolor="#B8C9D6">
   <tr>
    <td width="103" height="30" align="right">用户名：</td>
    <td width="441">
      <asp:TextBox ID="txtName" runat="server" CssClass="InputBorderStyle" Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
            ErrorMessage="输入用户名"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="30" align="right">密码：</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" CssClass="InputBorderStyle" TextMode="Password" Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
            ErrorMessage="输入密码"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="30" align="right">重复密码：</td>
    <td>
        <asp:TextBox ID="txtRPwd" runat="server" CssClass="InputBorderStyle" TextMode="Password" Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRPwd"
            ErrorMessage="再次输入密码"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd"
            ControlToValidate="txtRPwd" ErrorMessage="密码不一致"></asp:CompareValidator></td>
  </tr>
  <tr>
    <td height="30" align="right">服务区：</td>
    <td>
        <asp:DropDownList ID="ddlService" runat="server" CssClass="TextAreaStyle" Width="186px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlService"
            ErrorMessage="选择服务区"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="30" align="right">用户备注：</td>
    <td>
        <asp:TextBox ID="txtRemark" runat="server" CssClass="InputBorderStyle" Height="104px" TextMode="MultiLine" Width="280px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/AdminMgr/images/index1_86.gif" OnClick="btnAdd_Click" /></td>
  </tr>
</table>
     </fieldset>
    </div>
	</form>
</body>
</html>
