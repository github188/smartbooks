<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSiteMainImg.aspx.cs" Inherits="AdminMgr_EditSiteMainImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>编辑服务区门户网站主页图片</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:640px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="righttopnavbg"> 编辑服务区门户网站主页图片</div>
    <div class="divContent">
    <fieldset>
      <legend>编辑服务区门户网站主页图片</legend>
        <table width="620px" border="0" align="center" cellpadding="2" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse">
     <tr>
    <td height="30" align="right" style="width:100px;">
        新闻标题：</td>
    <td  >
        <asp:Image ID="SiteImg" runat="server" Height="90px" Width="490px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 100px" >
        图片上传：</td>
    <td   >
        <asp:FileUpload ID="FileUploadImg" runat="server" Width="490px" CssClass="InputBorderStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 100px">&nbsp;</td>
    <td  >
          <asp:ImageButton ID="btnSaveImage" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnSaveImage_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        &nbsp;网站主页图片上传：上传的图片要能够展示服务区的概貌，图片宽高为980*180像素，支持gif,jpg图片格式。</td>
    </tr>
</table>

    </fieldset>
   </div>
    </form>
</body>
</html>
