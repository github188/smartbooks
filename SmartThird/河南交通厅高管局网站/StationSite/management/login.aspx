<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="management_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ϵͳ��¼-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
        function ValidateForm(){
            if($.trim(document.getElementById("txtName").value)==""){
               alert("�������û�����");
               $("#txtName").focus();
               return false;
            }
            if(document.getElementById("txtPwd").value==""){
               alert("���������룡");
               $("#txtPwd").focus();
               return false;
            }
           if($.trim(document.getElementById("txtCode").value)==""){
              alert("��������֤�룡");
              $("#txtCode").focus();
              return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
         <table width="220" border="0" cellpadding="0" cellspacing="0" style="margin-top:80px; margin-left:300px;">
  <tr>
    <td width="60" align="right">�û�����</td>
    <td height="35">
        <asp:TextBox ID="txtName" runat="server" Width="145px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right">���룺</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" Width="145px" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right">��֤�룺</td>
    <td>
        <asp:TextBox ID="txtCode" runat="server" Width="90px"></asp:TextBox>
        <img src="CheckCode.aspx" alt="��֤��" align="absmiddle" />
        </td>
  </tr>
  <tr>
    <td align="right">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>&nbsp;</td>
    <td height="60">
        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/management/images/btnsubmit.jpg"  OnClientClick="return ValidateForm()" OnClick="btnSubmit_Click"/></td>
  </tr>
</table>

    </div>
    </form>
</body>
</html>
