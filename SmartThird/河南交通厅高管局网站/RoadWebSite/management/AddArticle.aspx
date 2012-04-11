<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddArticle.aspx.cs" Inherits="management_AddArticle" ValidateRequest="false" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>编辑<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <%--<script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>--%>
      <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
      <script type="text/javascript" language="javascript">
        function ValidateForm(){
            if($.trim(document.getElementById("txtTitle").value)==""){
               alert("请输入文章标题！");
               $("#txtTitle").focus();
               return false;
            }
            if($.trim(document.getElementById("txtFrom").value)==""){
               alert("请输入文章来源！");
               $("#txtFrom").focus();
               return false;
            }
            return true;
         }
    </script>

    <script type="text/javascript" src="../Script/jquery-1.6.2.js"></script>
    <script type="text/javascript" src="../Script/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../Script/kindeditor-4.0.5/lang/zh_CN.js"></script>    
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="t_contents"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                            'subscript', 'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image',
                            'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'map', 'code', 'pagebreak',
                            'link', 'unlink', '|'],
                    width: "100%",
                    height: "350px",
                    resizeMode: 1,
                    uploadJson : '../api/upload_json.ashx',
				    fileManagerJson : '../api/file_manager_json.ashx',
				    allowFileManager : true
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="box_mr2">
    
        <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />路政动态&nbsp;&nbsp;>>&nbsp;&nbsp;编辑<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息</div>
        </div>
        
        
        <div class="mar_l20 mar_t30">
    <table width="750" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="80" height="30" align="right">文章标题：</td>
    <td colspan="3">
        <asp:TextBox ID="txtTitle" runat="server" Width="99%"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="right" width="80">文章来源：</td>
    <td width="180">
        <asp:TextBox ID="txtFrom" runat="server" Width="170px"></asp:TextBox></td>
    <td width="80" align="right">发布日期：</td>
    <td width="410">
        <asp:TextBox ID="txtDate" runat="server" Width="170px" CssClass="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" valign="top">文章内容：</td>
    <td colspan="3">
    <textarea name="t_contents" style="display:none"><%=ViewState["strContent"]%></textarea>      
    </td>
    </tr>
  <tr>
    <td height="40" align="right">&nbsp;</td>
    <td colspan="3">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/management/images/btn_save.gif" OnClientClick="return ValidateForm()"    OnClick="ImageButton1_Click" /></td>
    </tr>
</table>
    </div>
      
      </div>
    </form>
</body>
</html>
