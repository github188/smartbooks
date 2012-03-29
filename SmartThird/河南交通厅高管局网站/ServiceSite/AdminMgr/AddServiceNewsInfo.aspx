<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddServiceNewsInfo.aspx.cs" Inherits="AdminMgr_AddServiceNewsInfo" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>文章信息编辑</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
               <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:820px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">文章信息编辑</div>
	<div class="divContent">
    <fieldset>
    <legend>文章信息编辑</legend>
    <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse">
  <tr>
    <td width="100" height="30" align="center">文章标题：</td>
    <td>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="InputBorderStyle" Width="633px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
            ErrorMessage="输入标题"></asp:RequiredFieldValidator></td>
  </tr>
   <tr>
    <td width="100" height="30" align="center">文章出处：</td>
    <td>
        <asp:TextBox ID="txtForm" runat="server" CssClass="InputBorderStyle" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtForm"
            ErrorMessage="请输入文章出处"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="30" align="center">文章内容：</td>
    <td><textarea name="t_contents" style="display:none"><%=ViewState["strContent"]%></textarea>
          <iframe name="eWEditor" src="edithtml/ewebeditor.htm?id=t_contents&style=blue"
          frameborder="0" scrolling="no" width="100%" height="400" id="IFRAME1">
          </iframe></td>
  </tr>
  <tr>
    <td height="30" align="center">&nbsp;</td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg"
            OnClick="ImageButton1_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
    </fieldset>
    </div>

    </form>
</body>
</html>
