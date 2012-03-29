<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyMessage.aspx.cs" Inherits="AdminMgr_ReplyMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>回复留言</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
               <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:570px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">回复留言板信息</div>
     <div class="divContent">
     <fieldset>
     <legend>回复留言板信息</legend>
     <table width="550" border="0" align="center" cellpadding="3" cellspacing="0" style="border-collapse:collapse" bordercolor="#B8C9D6">
   <tr>
    <td width="103" height="30" align="right">
        昵称：</td>
    <td width="441">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
  </tr>
  
  <tr>
    <td height="30" align="right">
        时间：</td>
    <td>
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td height="30" align="right">
        内容：</td>
    <td>
        <asp:Label ID="lblContent" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td height="30" align="right">
        回复：</td>
    <td>
        <asp:TextBox ID="lblReply" runat="server" CssClass="InputBorderStyle" Height="104px" TextMode="MultiLine" Width="280px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/AdminMgr/images/btnReply.jpg" OnClick="ImageButton2_Click" /></td>
  </tr>
</table>
     </fieldset>
     </div>
	
    </form>
</body>
</html>
