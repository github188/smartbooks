<!--#include file = "private.aspx"-->

<%
'######################################
' eWebEditor v3.00 - Advanced online web based WYSIWYG HTML editor.
' Copyright (c) 2003-2004 eWebSoft.com
'
' For further information go to http://www.ewebsoft.com/
' This copyright notice MUST stay intact for use.
'######################################
%>

<html>
<head>
<title>eWebEditor</title>
<meta http-equiv=Content-Type content=text/html; charset=gb2312>
<link type=text/css href='private.css' rel=stylesheet>
<base target=main>
</head>
<script language=javascript>
<!--
function menu_tree(meval)
{
  var left_n=eval(meval);
  if (left_n.style.display=="none")
  { eval(meval+".style.display='';"); }
  else
  { eval(meval+".style.display='none';"); }
}
-->
</script>
<body>
<center>

  <table cellspacing=0  class="Menu">
  <tr><th align=center  onclick="javascript:menu_tree('left_1');" >≡ 首选服务 ≡</th></tr>
  <tr id='left_1'><td >
    <table width='100%'>
    <tr><td><img border=0 src='images/menu.gif' align=absmiddle>&nbsp;<a href='style.aspx'>样式管理</a></td></tr>
    <tr><td><img border=0 src='images/menu.gif' align=absmiddle>&nbsp;<a href='upload.aspx'>上传管理</a></td></tr>
    </table>
  </td></tr>
  </table>

  <table width='90%' height=2><tr ><td></td></tr></table>
  <table cellspacing=0  class="Menu">
  <tr><th align=center  onclick="javascript:menu_tree('left_2');" >≡ 辅助服务 ≡</th></tr>
  <tr id='left_2'><td>
    <table width='100%'>
    <tr><td><img border=0 src='images/menu.gif' align=absmiddle>&nbsp;<a href='main.aspx'>后台首页</a></td></tr>
    <tr><td><img border=0 src='images/menu.gif' align=absmiddle>&nbsp;<a href='modipwd.aspx'>修改密码</a></td></tr>
    <tr><td><img border=0 src='images/menu.gif' align=absmiddle>&nbsp;<a onclick="return confirm('提示：您确定要退出系统吗？')" href='login.aspx?action=out' target='_parent'>退出后台</a></td></tr>
    </table>
  </td></tr>
  </table>
  
  <table width='90%' height=2><tr ><td></td></tr></table>
  <table cellspacing=0  class="Menu">
  <tr><th align=center  >〓 版本信息 〓</th></tr>
  <tr><td align=center>eWebEditor 3.0</td></tr>
  <tr><td align=center><a href='http://www.ewebsoft.com/product/ewebeditor/' target=_blank><b>在线帮助</b></a></td></tr>
  </table>

</center>
</body>
</html>