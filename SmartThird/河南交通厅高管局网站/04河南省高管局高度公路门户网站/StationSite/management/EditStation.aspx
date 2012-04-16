<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditStation.aspx.cs" Inherits="management_EditStation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>编辑收费站信息-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
         function CheckSubmitForm(){  
           if($.trim(document.getElementById("FileUpload1").value)==""){
               alert("请上传照片");
               return false;
            }
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("上传照片的格式应为.jpg或.gif格式");
              return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />编辑收费站信息</div>
    </div>
    
    <div class="mar_l20 mar_t20">
    <div class="group_tit">收费站基本信息</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table width="750" border="1" cellpadding="0" cellspacing="0" class="mar_t10 mar_l10" style=" border-collapse:collapse;" bordercolor="#CCCCCC">
  <tr>
    <td width="120" height="30" align="right">收费站名称：</td>
    <td width="250">
        <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="220px"></asp:TextBox></td>
    <td width="120" align="right">收费站拼音：</td>
    <td>
        <asp:TextBox ID="txtPinYin" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">里程桩号：</td>
    <td>
        <asp:TextBox ID="txtStake" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">里程数：</td>
    <td>
        <asp:TextBox ID="txtStakeNum" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">负责人：</td>
    <td>
        <asp:TextBox ID="txtRen" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">联系电话：</td>
    <td>
        <asp:TextBox ID="txtPhone" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">荣誉称号：</td>
    <td colspan="3">
        <asp:TextBox ID="txtHonour" runat="server" Width="592px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="right">欢迎辞：</td>
    <td colspan="3">
        <asp:TextBox ID="txtWelcome" runat="server" Width="592px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="right">所属高速：</td>
    <td>
        <asp:DropDownList ID="ddlHighway" runat="server" Width="224px">
        </asp:DropDownList></td>
    <td align="right">所属单位：</td>
    <td>
        <asp:DropDownList ID="ddlUnit" runat="server" Width="224px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right">所属地市：</td>
    <td>
        <asp:DropDownList ID="ddlCity" runat="server" Width="224px">
        </asp:DropDownList></td>
    <td align="right">收费站星级：</td>
    <td>
        <asp:DropDownList ID="ddlStar" runat="server" Width="224px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right">车道数：</td>
    <td>
        <asp:TextBox ID="txtLaneNum" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">出口道路及城镇：</td>
    <td>
        <asp:TextBox ID="txtExitToRoad" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">收费站简介：</td>
    <td colspan="3">
        <asp:TextBox ID="txtRemark" runat="server" Height="80px" TextMode="MultiLine" Width="592px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td colspan="3">
        <asp:ImageButton ID="btnSaveInfo" runat="server" ImageUrl="~/management/images/botton_gif_009.gif"
            OnClick="btnSaveInfo_Click" /></td>
    </tr>
</table>
<div class="group_remark"><span>操作提示：</span>里程桩号和里程数一一对应。例如：里程桩号为K34+456,那么里程数应为34.456。里程桩号转换为里程数额规则是：字母K取消,"+"号替换为"."。</div>
</ContentTemplate>
        </asp:UpdatePanel>
 
    <div class="group_tit mar_t20">
        收费站照片管理</div>
    
    <table width="750" border="1" cellpadding="0" cellspacing="0" class="mar_t10 mar_l10" style=" border-collapse:collapse;" bordercolor="#CCCCCC">
  <tr>
    <td width="120" height="30" align="right">收费站照片：</td>
    <td>
        <asp:Image ID="Image1" runat="server" Height="450px" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right">上传照片：</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td><asp:ImageButton ID="btnSavePhoto" runat="server" ImageUrl="~/management/images/botton_gif_009.gif"
        OnClientClick="return CheckSubmitForm()"    OnClick="btnSavePhoto_Click"  /><asp:Literal
                ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
<div class="group_remark"><span>操作提示：</span>上传的收费站照片应为.jpg或.gif格式。为确保上传照片的质量，请上传清晰且宽大于600像素的照片,系统会自动把上传的照片处理成宽600像素。</div>
<div class="mar_t20"></div>
    
    </div>
    
    </div>
    </form>
</body>
</html>
