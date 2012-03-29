<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMyLink.aspx.cs" Inherits="AdminMgr_AddMyLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑友情链接信息</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:620px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="righttopnavbg">编辑友情链接信息</div>
    <div class="divContent">
    <fieldset>
       <legend>编辑友情链接信息</legend>
       <table width="600" border="0" align="center" cellpadding="3" cellspacing="0" style="border-collapse:collapse" bordercolor="#B8C9D6">
         <tr>
        <td width="150" height="40" align="right">标题：&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width="370px" CssClass="InputBorderStyle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="输入标题"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td height="40" align="right">链接地址：&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtURL" runat="server" Width="370px" CssClass="InputBorderStyle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtURL"
                ErrorMessage="输入地址"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td height="40" align="right">&nbsp;
            </td>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit1.jpg"
                OnClick="ImageButton1_Click" />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
      </tr>
    </table>
    </fieldset>   
    </div>
    </form>
</body>
</html>
  