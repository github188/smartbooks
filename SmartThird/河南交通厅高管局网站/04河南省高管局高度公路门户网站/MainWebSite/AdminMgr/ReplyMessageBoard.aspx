<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyMessageBoard.aspx.cs" Inherits="AdminMgr_ReplyMessageBoard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>回复留言-河南省交通运输厅高速公路管理局</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
         function ValidateForm(){
            if(document.getElementById("txtReply").value==""){
               alert("请输入回复内容！");
               return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  id="ContentBox">
    
    <div id="editmenu1">网站首页 >> 回复留言</div>
     <table width="600" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#6298e1" style="border-collapse:collapse; margin-top:20px;">
  <tr>
    <td height="30" align="right"  >留言人姓名：</td>
    <td>
        <asp:TextBox ID="txtUName" runat="server" BackColor="#E0E0E0" CssClass="inputBorderstyle1"
            Enabled="False" Width="300px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right" >电子邮件：</td>
    <td>
        <asp:TextBox ID="txtEmail" runat="server" BackColor="#E0E0E0" CssClass="inputBorderstyle1"
            Enabled="False" Width="300px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right"  >联系电话：</td>
    <td>
        <asp:TextBox ID="txtPhone" runat="server" BackColor="#E0E0E0" CssClass="inputBorderstyle1"
            Enabled="False" Width="300px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right"  >留言日期：</td>
    <td>
        <asp:TextBox ID="txtTime" runat="server" BackColor="#E0E0E0" CssClass="inputBorderstyle1"
            Enabled="False" Width="300px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right"  >留言内容：</td>
    <td>
        <asp:TextBox ID="txtContent" runat="server" BackColor="#E0E0E0" CssClass="inputBorderstyle1"
            Enabled="False" Height="110px" TextMode="MultiLine" Width="420px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right">管理员回复：</td>
    <td>
        <asp:TextBox ID="txtReply" runat="server" CssClass="inputBorderstyle1" Height="120px"
            TextMode="MultiLine" Width="420px"></asp:TextBox></td>
  </tr>
   
  <tr>
    <td height="30" align="right"  >&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg" OnClick="ImageButton1_Click" OnClientClick="return ValidateForm()"  />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
