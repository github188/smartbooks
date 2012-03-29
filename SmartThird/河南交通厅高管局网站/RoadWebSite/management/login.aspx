<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="management_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>登录入口-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
        function ValidateForm(){
            if($.trim(document.getElementById("txtName").value)==""){
               alert("请输入用户名！");
               $("#txtName").focus();
               return false;
            }
            if(document.getElementById("txtPwd").value==""){
               alert("请输入密码！");
               $("#txtPwd").focus();
               return false;
            }
           if($.trim(document.getElementById("txtCode").value)==""){
              alert("请输入验证码！");
              $("#txtCode").focus();
              return false;
            }
            return true;
         }
         function ResetForm(){
           document.getElementById("txtName").value="";
           document.getElementById("txtPwd").value="";
           document.getElementById("txtCode").value="";
           return false;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
    
    <div class="log_title"></div>
    
    <div class="log_mid">
    <table width="340" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:30px; margin-bottom:30px;">
  <tr>
    <td width="70" height="40" align="center"><b>用户名：</b></td>
    <td>
        <asp:TextBox ID="txtName" runat="server" Width="230px" CssClass="input_uname"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="40" align="center"><b>密 &nbsp;&nbsp;码：</b></td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" CssClass="input_upwd"
            Width="230px" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="40" align="center"><b>验证码：</b></td>
    <td>
        <asp:TextBox ID="txtCode" runat="server" CssClass="input_code" Width="170px"></asp:TextBox>&nbsp;&nbsp;<img src="CheckCode.aspx"  align="absmiddle"/>
        </td>
  </tr>
  <tr>
    <td height="50" align="center">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
    <td>
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn_login" OnClientClick="return ValidateForm()" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
<asp:Button ID="btnReset" runat="server" CssClass="btn_cancle" OnClientClick="return ResetForm()" /></td>
  </tr>
</table>

    </div>
    <div class="jishu"><span>技术支持：郑州豫图信息技术有限公司</span></div>
    <div id="btm">
       <div class="left_btm"></div>
       <div class="middle_btm"></div>
       <div class="right_btm"></div>
    </div>
    
    </div>
    </form>
</body>
</html>
