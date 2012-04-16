<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCertificate.aspx.cs" Inherits="AdminMgr_AddCertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加ISO认证证书</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
               <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:570px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">添加ISO认证证书</div>
    <div class="divContent">
       <fieldset>
       <legend>添加ISO认证证书</legend>
        <table width="550" border="0" align="center" cellpadding="3" cellspacing="0" style="border-collapse:collapse" bordercolor="#B8C9D6"> 
        <tr>
    <td height="30" align="right" style="width:100px;">
        证书图片：</td>
    <td>
        <asp:FileUpload ID="FileUploadImg" runat="server" CssClass="InputBorderStyle" Width="376px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUploadImg"
            ErrorMessage="*"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right" style="width:100px;">证书备注：</td>
    <td >
        <asp:TextBox ID="txtRemark" runat="server" CssClass="InputBorderStyle" Height="200px" TextMode="MultiLine" Width="371px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRemark"
            ErrorMessage="*"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td align="right" style="height: 32px">&nbsp;
        </td>
    <td style="height: 32px">
        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg" OnClick="btnAdd_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td  height="30" align="left"  colspan="2">
        操作提示：上传证书的最佳宽度为600像素，高度不限，支持.jpg、.gif图片文件。</td>
   
  </tr>
</table>

       </fieldset>
    </div>
    </form>
</body>
</html>
