<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFuwuStar.aspx.cs" Inherits="management_AddFuwuStar" ValidateRequest="false" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <title>编辑<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
     <link href="style/default.css" rel="stylesheet" type="text/css" />
      <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
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
            <%
        string strAction = ViewState["strAction"].ToString();
        if (strAction == "add") {
     %>
           if($.trim(document.getElementById("FileUpload1").value)==""){
               alert("请上传图片");
               return false;
            }
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("上传图片的格式应为.jpg或.gif格式");
              return false;
            }
     <%
        }
        else if (strAction == "update") { 
         %>
          if($.trim(document.getElementById("FileUpload1").value)!=""){
            var strDocName=$.trim(document.getElementById("FileUpload1").value);
            strDocName=strDocName.toLowerCase();
            var lastIndex=strDocName.lastIndexOf(".");
            var strExtent=strDocName.substring(lastIndex);
            if(!(strExtent==".jpg"||strExtent==".jpeg"||strExtent==".gif")){
              alert("上传图片的格式应为.jpg或.gif格式");
              return false;
            }
            }
     <%
        }
     %>
     if($.trim(document.getElementById("txtShortRemark").value)==""){
               alert("请输入文章简介！");
               $("#txtShortRemark").focus();
               return false;
            }
            return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />编辑<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息</div>
    </div>
    
    <div class="mar_l20 mar_t30">
    <table width="750" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="80" height="30" align="right">文章标题：</td>
    <td colspan="3">
        <asp:TextBox ID="txtTitle" runat="server" Width="650px"></asp:TextBox></td>
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
    <td height="30" align="right" valign="top">上传图片：</td>
    <td colspan="3">
        <asp:FileUpload ID="FileUpload1" runat="server" Width="560px" /></td>
    </tr>
    <tr>
    <td height="30" align="right" valign="top">
        文章简介：</td>
    <td colspan="3">
        <asp:TextBox ID="txtShortRemark" runat="server" Height="60px" TextMode="MultiLine"
            Width="650px"></asp:TextBox></td>
    </tr>
    <tr>
    <td height="30" align="right" valign="top">文章内容：</td>
    <td colspan="3">
        <textarea name="t_contents" style="display:none"><%=ViewState["strContent"]%></textarea>
      <iframe name="eWEditor" src="edithtml/ewebeditor.htm?id=t_contents&style=blue"
          frameborder="0" scrolling="no" width="100%"  id="IFRAME1" style="height: 400px" >
        </iframe>
        </td>
    </tr>
  <tr>
    <td height="35" align="right">&nbsp;</td>
    <td colspan="3">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/management/images/botton_gif_009.gif" OnClientClick="return ValidateForm()"    OnClick="ImageButton1_Click" /></td>
    </tr>
</table>
<div class="group_remark"><span>操作提示：</span>文章标题即为评为服务之星个人事迹标题;文章来源即为评为服务之星人姓名;上传的图片即为评为服务之星人照片,上传后将在网站首页和个人事迹详细内容中显示,支持.jpg或.gif格式,为确保上传图片的质量，请上传清晰且宽大于600像素的图片,系统会自动把上传的图片处理成宽600像素;文章简介即为个人事迹简介,200字左右即可;文章内容即为个人事迹详细内容,其文本编辑器中也可以上传图片(在此上传的照片的宽度应为600像素左右,不能超过网页的宽度，否则影响页面的显示)。</div>
    </div>
    </div>
    </form>
</body>
</html>
