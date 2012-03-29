<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPicNews.aspx.cs" Inherits="AdminMgr_AddPicNews" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加图片新闻</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:770px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="righttopnavbg"> 编辑图片新闻</div>
    <div class="divContent">
    <fieldset>
      <legend>编辑图片新闻</legend>
        <table width="750px" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse">
     <tr>
    <td width="120" height="30" align="right" >
        新闻标题：</td>
    <td colspan="2" >
        <asp:TextBox ID="txtTitle" runat="server" Width="524px" CssClass="InputBorderStyle"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
            ErrorMessage="*"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="30" align="right" >
        图片上传：</td>
    <td width="344"  >
        <asp:FileUpload ID="FileUploadImg" runat="server" Width="331px" CssClass="InputBorderStyle" /></td>
    <td width="278"  >
        <asp:Image ID="ImgNews" runat="server" Width="150px" /></td>
  </tr>
  
  <tr>
    <td align="right" style="height: 340px" >
        新闻简介：
    </td>
    <td colspan="2" style="height: 340px"  >
        <textarea name="t_contents" style="display:none" class="TextAreaStyle"><%= ViewState["strContent"]%></textarea>
          <iframe name="eWEditor" src="edithtml/ewebeditor.htm?id=t_contents&style=blue"
          frameborder="0" scrolling="no" width="100%" height="300" id="IFRAME1" >
          </iframe></td>
  </tr>
  <tr>
    <td height="30" >&nbsp;</td>
    <td colspan="2" >
          <asp:ImageButton ID="btnSaveImage" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnSaveImage_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td height="40" colspan="3">
        &nbsp;新闻图片上传：上传的图片要能够展示新闻要点，图片宽高比例为4:3、最佳宽度为600像素，支持gif,jpg图片格式，为了保证前台页面的正常显示，至少要添加1条图片新闻。</td>
    </tr>
</table>

    </fieldset>
   </div>
    </form>
</body>
</html>
