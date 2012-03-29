<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditLogo.aspx.cs" Inherits="management_EditLogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>编辑收费站LOGO-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
         function CheckSubmitForm(){  
           if($.trim(document.getElementById("FileUpload1").value)==""){
               alert("请上传LOGO");
               return false;
            }
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("上传LOGO的格式应为.jpg或.gif格式");
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
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />编辑收费站LOGO</div>
    </div>
    
    <div class="mar_l50 mar_t50">
    <table width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="80" height="30" align="right">上传LOGO：</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="395px" /></td>
  </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/management/images/botton_gif_009.gif" OnClientClick="return CheckSubmitForm()"  OnClick="ImageButton1_Click" /></td>
  </tr>
  </table>
  <div class="group_remark"><span>操作提示：</span>收费站LOGO应为.jpg或.gif格式,宽高位826*194像素,该LOGO应由收费站提供，美工处理后，方可上传。</div>
    </div>
    
    </div>
    </form>
</body>
</html>
