<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPwd.aspx.cs" Inherits="management_EditPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�޸�����-·����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="box_mr2">
    
        <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />ϵͳ����&nbsp;&nbsp;>>&nbsp;&nbsp;�޸�����</div>
        </div>
        
        <div class=" mar_t40 mar_l40">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            ��<ContentTemplate>
            ��   <table width="400" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="35" align="right" style="width: 100px">�û�����</td>
    <td>
        <asp:TextBox ID="txtName" runat="server" Width="240px" ReadOnly="True"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right" style="width: 100px">ԭʼ���룺</td>
    <td>
        <asp:TextBox ID="txtOldPwd" runat="server" Width="240px" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right" style="width: 100px">�����룺</td>
    <td>
        <asp:TextBox ID="txtNewPwd" runat="server" Width="240px" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right" style="width: 100px">�ظ����룺</td>
    <td>
        <asp:TextBox ID="txtRNewPwd" runat="server" Width="240px" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right" style="width: 100px">��ʵ������</td>
    <td>
        <asp:TextBox ID="txtTrueName" runat="server" Width="240px" ></asp:TextBox></td>
  </tr>
  <tr>
    <td height="35" align="right" style="width: 100px">��ϵ�绰��</td>
    <td>
        <asp:TextBox ID="txtPhone" runat="server" Width="240px" ></asp:TextBox></td>
  </tr>
  <tr>
    <td height="40" align="right" style="width: 100px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/management/images/btn_save.gif" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/management/images/btn_reset.gif" OnClick="btnReset_Click" /></td>
  </tr>
</table>
            ��</ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        
    </div>
    </form>
</body>
</html>
