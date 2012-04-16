<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddServiceModel.aspx.cs" Inherits="AdminMgr_AddServiceModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加子服务项目信息</title>
       <link href="style/css.css" rel="stylesheet" type="text/css" />
                 <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:420px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">添加子服务项目信息</div>
     <div class="divContent">
    <fieldset>
    <legend>添加子服务项目信息</legend>
     <table width="400" height="30" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse">
      <tr>
        <td height="30" colspan="2" align="center" style="font-size:16px; font-weight:bold; color:#000000;">添加子服务项目信息</td>
      </tr>
	  <tr>
        <td width="120" height="30" align="right">子服务项目名称：&nbsp;&nbsp; </td>
        <td width="268"><asp:TextBox ID="txtName" runat="server" CssClass="InputBorderStyle" Width="150px"></asp:TextBox>
            </td>
      </tr>
      <tr>
        <td height="30" align="right">所属父服务项目：&nbsp;&nbsp;</td>
        <td><asp:DropDownList ID="ddlModel" runat="server" CssClass="InputBorderStyle" Width="156px">
            </asp:DropDownList></td>
      </tr>
      <tr>
        <td height="30" align="right">
            <asp:Literal ID="Literal1" runat="server" ></asp:Literal>&nbsp;</td>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/index1_86.gif" OnClick="ImageButton1_Click" /></td>
      </tr>
    </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
