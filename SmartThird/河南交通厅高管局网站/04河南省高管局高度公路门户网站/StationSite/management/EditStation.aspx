<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditStation.aspx.cs" Inherits="management_EditStation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�༭�շ�վ��Ϣ-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
         function CheckSubmitForm(){  
           if($.trim(document.getElementById("FileUpload1").value)==""){
               alert("���ϴ���Ƭ");
               return false;
            }
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("�ϴ���Ƭ�ĸ�ʽӦΪ.jpg��.gif��ʽ");
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
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />�༭�շ�վ��Ϣ</div>
    </div>
    
    <div class="mar_l20 mar_t20">
    <div class="group_tit">�շ�վ������Ϣ</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table width="750" border="1" cellpadding="0" cellspacing="0" class="mar_t10 mar_l10" style=" border-collapse:collapse;" bordercolor="#CCCCCC">
  <tr>
    <td width="120" height="30" align="right">�շ�վ���ƣ�</td>
    <td width="250">
        <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="220px"></asp:TextBox></td>
    <td width="120" align="right">�շ�վƴ����</td>
    <td>
        <asp:TextBox ID="txtPinYin" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">���׮�ţ�</td>
    <td>
        <asp:TextBox ID="txtStake" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">�������</td>
    <td>
        <asp:TextBox ID="txtStakeNum" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�����ˣ�</td>
    <td>
        <asp:TextBox ID="txtRen" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">��ϵ�绰��</td>
    <td>
        <asp:TextBox ID="txtPhone" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�����ƺţ�</td>
    <td colspan="3">
        <asp:TextBox ID="txtHonour" runat="server" Width="592px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="right">��ӭ�ǣ�</td>
    <td colspan="3">
        <asp:TextBox ID="txtWelcome" runat="server" Width="592px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="right">�������٣�</td>
    <td>
        <asp:DropDownList ID="ddlHighway" runat="server" Width="224px">
        </asp:DropDownList></td>
    <td align="right">������λ��</td>
    <td>
        <asp:DropDownList ID="ddlUnit" runat="server" Width="224px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right">�������У�</td>
    <td>
        <asp:DropDownList ID="ddlCity" runat="server" Width="224px">
        </asp:DropDownList></td>
    <td align="right">�շ�վ�Ǽ���</td>
    <td>
        <asp:DropDownList ID="ddlStar" runat="server" Width="224px">
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right">��������</td>
    <td>
        <asp:TextBox ID="txtLaneNum" runat="server" Width="220px"></asp:TextBox></td>
    <td align="right">���ڵ�·������</td>
    <td>
        <asp:TextBox ID="txtExitToRoad" runat="server" Width="220px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�շ�վ��飺</td>
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
<div class="group_remark"><span>������ʾ��</span>���׮�ź������һһ��Ӧ�����磺���׮��ΪK34+456,��ô�����ӦΪ34.456�����׮��ת��Ϊ�����������ǣ���ĸKȡ��,"+"���滻Ϊ"."��</div>
</ContentTemplate>
        </asp:UpdatePanel>
 
    <div class="group_tit mar_t20">
        �շ�վ��Ƭ����</div>
    
    <table width="750" border="1" cellpadding="0" cellspacing="0" class="mar_t10 mar_l10" style=" border-collapse:collapse;" bordercolor="#CCCCCC">
  <tr>
    <td width="120" height="30" align="right">�շ�վ��Ƭ��</td>
    <td>
        <asp:Image ID="Image1" runat="server" Height="450px" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right">�ϴ���Ƭ��</td>
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
<div class="group_remark"><span>������ʾ��</span>�ϴ����շ�վ��ƬӦΪ.jpg��.gif��ʽ��Ϊȷ���ϴ���Ƭ�����������ϴ������ҿ����600���ص���Ƭ,ϵͳ���Զ����ϴ�����Ƭ����ɿ�600���ء�</div>
<div class="mar_t20"></div>
    
    </div>
    
    </div>
    </form>
</body>
</html>
