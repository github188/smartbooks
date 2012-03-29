<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewsPaper.aspx.cs" Inherits="AdminMgr_AddNewsPaper" ValidateRequest="false" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加服务区行业报刊-河南省交通运输厅高速公路管理局</title>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
         function ValidateForm(){
            if(document.getElementById("txtTitle").value==""){
               alert("请输入文章标题！");
               return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
   <div  id="ContentBox">
 
    <div  id="editmenu2">
    <div class="top">服务区管理 >> 编辑行业报刊信息</div>
    <div class="buttom">
        备注:服务区行业报刊图片的宽应为1000像素,高不做限制(系统自动生成缩略图的宽高为:152*225像素),支持.jpg、.gif格式图片文件</div>
    </div>
    
     <table width="650" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#6298e1" style="border-collapse:collapse; margin-top:20px;">
  <tr>
    <td width="108" height="30" align="right" style="width: 108px">
        报刊标题：</td>
    <td colspan="2">
        <asp:TextBox ID="txtTitle" runat="server"  CssClass="inputBorderstyle1" Width="315px"></asp:TextBox> <span style="color:#6298e1" >
            (标题格式如：2010年第1期)</span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
            ErrorMessage="*"></asp:RequiredFieldValidator></td>
  </tr>
   <tr>
    <td width="108" height="30" align="right" style="width: 108px">
        发布日期：</td>
    <td colspan="2">
        <asp:TextBox ID="txtTime" runat="server" Width="200px" CssClass="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox> </td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 108px">
        第一版图片：</td>
    <td  style="width:385px;">
        <asp:FileUpload ID="FileUploadImgA" runat="server" Height="16px" Width="372px" CssClass="inputBorderstyle1"  />
    </td>
    <td ><asp:Image ID="ImgA" runat="server" Width="145px"  /></td>
  </tr>
  <tr>
    <td align="right" style="width: 108px; height: 163px;">
        第二版图片：</td>
    <td style="width:385px; height: 163px;">
        <asp:FileUpload ID="FileUploadImgB" runat="server" Height="16px" Width="372px" CssClass="inputBorderstyle1"  />
    </td>
    <td style="height: 163px" ><asp:Image ID="ImgB" runat="server" Width="145px"  /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 108px">
        第三版图片：</td>
    <td  style="width:385px;"><asp:FileUpload id="FileUploadImgC" runat="server" Width="372px" CssClass="inputBorderstyle1" Height="16px"></asp:FileUpload>  
    </td>
    <td ><asp:Image ID="ImgC" runat="server" Width="145px"  /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 108px">
        第四版图片：</td>
    <td style="width:385px;">
        <asp:FileUpload ID="FileUploadImgD" runat="server" Height="16px" Width="372px" CssClass="inputBorderstyle1"  />
       
    </td>
    <td ><asp:Image ID="ImgD" runat="server" Width="145px"  /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 108px">&nbsp;</td>
    <td colspan="2">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg" OnClick="ImageButton1_Click" OnClientClick="return ValidateForm()" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
       

    </div>
    </form>
</body>
</html>
