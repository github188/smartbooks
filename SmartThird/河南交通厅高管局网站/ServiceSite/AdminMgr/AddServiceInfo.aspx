<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddServiceInfo.aspx.cs" Inherits="AdminMgr_AddServiceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加服务区</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
               <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:620px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">添加服务区</div>
	<div class="divContent">
    <fieldset>
    <legend>添加服务区</legend>
    <table width="600" border="0" align="center" cellpadding="3" cellspacing="0" style="border-collapse:collapse" bordercolor="#B8C9D6">
  <tr>
    <td height="30" align="right" style="width: 200px">服务区名称：&nbsp;&nbsp;</td>
    <td style="width: 398px">
        <asp:TextBox ID="txtName" runat="server" BackColor="Transparent" CssClass="InputBorderStyle"
            Width="250px"></asp:TextBox></td>
  </tr>
  
  <tr>
    <td height="30" align="right" style="width: 200px">星级标准：&nbsp;&nbsp;</td>
    <td style="width: 398px">
        <asp:DropDownList ID="ddlStar" runat="server" CssClass="TextAreaStyle" Width="255px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>★</asp:ListItem>
            <asp:ListItem>★★</asp:ListItem>
            <asp:ListItem>★★★</asp:ListItem>
            <asp:ListItem>★★★★</asp:ListItem>
            <asp:ListItem>★★★★★</asp:ListItem>
            <asp:ListItem>优秀停车区</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 200px">类型：&nbsp;&nbsp;</td>
    <td style="width: 398px">
        <asp:DropDownList ID="ddlType" runat="server" CssClass="TextAreaStyle" Width="255px">
            <asp:ListItem>服务区</asp:ListItem>
            <asp:ListItem>停车场</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 200px">所属高速：&nbsp;&nbsp;</td>
    <td style="width: 398px">
        <asp:DropDownList ID="ddlGs" runat="server" BackColor="White" CssClass="TextAreaStyle"
            Width="255px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 200px">所属地市：&nbsp;&nbsp;</td>
    <td style="width: 398px">
        <asp:DropDownList ID="ddlCity" runat="server" BackColor="White" CssClass="TextAreaStyle"
            Width="255px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 200px">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
    <td style="width: 398px"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/index1_86.gif"
            OnClick="ImageButton1_Click" /></td>
  </tr>
</table>
    </fieldset>
    </div>
    </form>
</body>
</html>
