<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditLogo.aspx.cs" Inherits="management_EditLogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�༭�շ�վLOGO-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
         function CheckSubmitForm(){  
           if($.trim(document.getElementById("FileUpload1").value)==""){
               alert("���ϴ�LOGO");
               return false;
            }
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("�ϴ�LOGO�ĸ�ʽӦΪ.jpg��.gif��ʽ");
              return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />�༭�շ�վLOGO</div>
    </div>
    
    <div class="mar_l50 mar_t50">
    <table width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="80" height="30" align="right">�ϴ�LOGO��</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="395px" /></td>
  </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/management/images/botton_gif_009.gif" OnClientClick="return CheckSubmitForm()"  OnClick="ImageButton1_Click" /></td>
  </tr>
  </table>
  <div class="group_remark"><span>������ʾ��</span>�շ�վLOGOӦΪ.jpg��.gif��ʽ,���λ826*194����,��LOGOӦ���շ�վ�ṩ����������󣬷����ϴ���</div>
    </div>
    
    </div>
    </form>
</body>
</html>
