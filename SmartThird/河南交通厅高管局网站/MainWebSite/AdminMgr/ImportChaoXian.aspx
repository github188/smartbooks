<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportChaoXian.aspx.cs" Inherits="AdminMgr_ImportChaoXian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据导入-超限运输审批情况表-河南省交通运输厅高速公路管理局网站后台管理系统</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="ContentBox">
    <div id="editmenu1">超限运输审批情况表 >> 数据导入</div>
    
    
     <table width="600" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#6298e1" style="border-collapse:collapse; margin-top:20px;">
  <tr>
    <td style="width: 100px; height: 40px;" align="center">
        导入EXCEL文件：</td>
    <td >&nbsp;<asp:FileUpload ID="FUploadXls" runat="server" Width="450px" />
    <br />&nbsp;提示：在这点击<a href="xls/template.xls" style="color:Blue;">下载</a>EXCEL数据模板!
    </td>
  </tr>
  <tr>
    <td height="40" align="right">&nbsp;</td>
    <td >&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg"   OnClick="ImageButton1_Click"/>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
    
    </div>
    </form>
</body>
</html>
