<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDownload.aspx.cs" Inherits="AdminMgr_AddDownload"  ValidateRequest="false"%> 
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑<%=((DataTable) ViewState["dtType"]).Rows[0]["FT_Name"]%>-河南省交通运输厅高速公路管理局</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
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
    
    <div id="editmenu1">文件下载 >> 上传<%=((DataTable)ViewState["dtType"]).Rows[0]["FT_Name"]%></div>
    
     <table width="700" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#6298e1" style="border-collapse:collapse; margin-top:20px;">
  <tr>
    <td  height="40" align="right" style="width: 100px">
        文件标题：</td>
    <td>
        <asp:TextBox ID="txtTitle" runat="server" Width="500px" CssClass="inputBorderstyle1"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="40" align="right" >
        上传时间：</td>
    <td>
        <asp:TextBox ID="txtTime" runat="server"  Width="275px" CssClass="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
    </td>
  </tr>
 <tr>
    <td height="40" align="right" >
        上传文件：</td>
    <td>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="inputBorderstyle1" Width="570px" /></td>
  </tr>
  <tr>
    <td height="40" align="right" ></td>
    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg" OnClick="ImageButton1_Click" OnClientClick="return ValidateForm()" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
  </tr>
</table>
       

    </div>
    </form>
</body>
</html>
