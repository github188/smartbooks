<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftMenu.aspx.cs" Inherits="AdminMgr_leftMenu" %>
<%@ Import Namespace="Model" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统菜单</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
   function _ChangServiceMenuDisplay(p){
       for(var i=1;i<=6;i++){
	       if(p==i){
		     document.getElementById("servicemenu"+p).style.display="block";
			 document.getElementById("serviceimg"+p).src="images/ico03.gif";
		   }else{
		      document.getElementById("servicemenu"+i).style.display="none";
			  document.getElementById("serviceimg"+i).src="images/ico04.gif";
		   }
	   }
   }
   function _ChangServiceSubMenuImg(p){
      for(var i=1;i<=18;i++){
	       if(p==i){
		     document.getElementById("servicesubimg"+p).src="images/ico05.gif";
		   }else{
		      document.getElementById("servicesubimg"+i).src="images/ico06.gif";
		   }
	   }
   }
</script>
<script type="text/javascript" language="javascript">
   function _ChangAdminMenuDisplay(p){
       for(var i=1;i<=2;i++){
	       if(p==i){
		     document.getElementById("adminmenu"+p).style.display="block";
			 document.getElementById("adminimg"+p).src="images/ico03.gif";
		   }else{
		      document.getElementById("adminmenu"+i).style.display="none";
			  document.getElementById("adminimg"+i).src="images/ico04.gif";
		   }
	   }
   }
   function _ChangAdminSubMenuImg(p){
      for(var i=1;i<=7;i++){
	       if(p==i){
		     document.getElementById("adminsubimg"+p).src="images/ico05.gif";
		   }else{
		      document.getElementById("adminsubimg"+i).src="images/ico06.gif";
		   }
	   }
   }
</script>
</head>
<body class="leftmenu-bg"> 
  <form id="form1" runat="server">
   <div class="leftmenu-leftdiv">

<!--头部-->
<div class="header">
<div class="left"><img src="images/ico02.gif"></div>
<div class="right1">你好，<b><%=((UserInfo)Session["ServiceUser"]).U_Name%></b></div>
<div class="right2"><a href="Loginout.aspx" target="_top">[ 退出 ]</a></div>
</div>

<%
    if (((UserInfo)Session["ServiceUser"]).U_Power == 1)
    {
     %>
     
     <!--服务区用户-->
<div>

<div class="menu"><img src="images/ico04.gif" id="serviceimg1"><a href="javascript:_ChangServiceMenuDisplay(1)">服务区信息管理</a></div>
<div id="servicemenu1" style="display:none">
<div class="submemu"><img src="images/ico06.gif" id="servicesubimg1"><a href="EditServiceInfo.aspx" target="mainFrame" onClick="_ChangServiceSubMenuImg(1)">编辑信息</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg2"><a href="CertificateMgr.aspx" target="mainFrame"  onClick="_ChangServiceSubMenuImg(2)">ISO认证管理</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="serviceimg2"><a href="javascript:_ChangServiceMenuDisplay(2)">服务区栏目</a></div>
<div  id="servicemenu2"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg3"><a href="ServiceNewsMgr.aspx?tid=1" target="mainFrame"  onClick="_ChangServiceSubMenuImg(3)">驿站新闻</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg4"><a href="ServiceNewsMgr.aspx?tid=3" target="mainFrame"  onClick="_ChangServiceSubMenuImg(4)">管理制度</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg5"><a href="ServiceNewsMgr.aspx?tid=5" target="mainFrame"  onClick="_ChangServiceSubMenuImg(5)">文明创建</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg6"><a href="ServiceNewsMgr.aspx?tid=7" target="mainFrame"  onClick="_ChangServiceSubMenuImg(6)">驿站文化</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg7"><a href="ServiceNewsMgr.aspx?tid=8" target="mainFrame"  onClick="_ChangServiceSubMenuImg(7)">学习园地</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg8"><a href="PicNewsMgr.aspx?tid=6" target="mainFrame"  onClick="_ChangServiceSubMenuImg(8)">图片新闻</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg9"><a href="ServiceNoticeMgr.aspx?tid=2" target="mainFrame"  onClick="_ChangServiceSubMenuImg(9)">公告公示</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="serviceimg3"><a href="javascript:_ChangServiceMenuDisplay(3)">服务项目动态</a></div>
<div  id="servicemenu3"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg10"><a href="ServiceItemMgr.aspx?pid=1" target="mainFrame"  onClick="_ChangServiceSubMenuImg(10)">餐厅服务</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg11"><a href="ServiceItemMgr.aspx?pid=2" target="mainFrame" onClick="_ChangServiceSubMenuImg(11)">超市服务</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg12"><a href="ServiceItemMgr.aspx?pid=3" target="mainFrame" onClick="_ChangServiceSubMenuImg(12)">加油服务</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg13"><a href="ServiceItemMgr.aspx?pid=4" target="mainFrame"  onClick="_ChangServiceSubMenuImg(13)">客房服务</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg14"><a href="ServiceItemMgr.aspx?pid=5" target="mainFrame"  onClick="_ChangServiceSubMenuImg(14)">汽修服务</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg15"><a href="ServiceItemMgr.aspx?pid=6" target="mainFrame"  onClick="_ChangServiceSubMenuImg(15)">停车服务</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="serviceimg4"><a href="javascript:_ChangServiceMenuDisplay(4)">留言板管理</a></div>
<div  id="servicemenu4"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg16"><a href="MessageBoardList.aspx" target="mainFrame"  onClick="_ChangServiceSubMenuImg(16)">留言列表</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="serviceimg5"><a href="javascript:_ChangServiceMenuDisplay(5)">友情链接</a></div>
<div  id="servicemenu5"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg17"><a href="MyLinkMgr.aspx" target="mainFrame"  onClick="_ChangServiceSubMenuImg(17)">链接管理</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="serviceimg6"><a href="javascript:_ChangServiceMenuDisplay(6)">用户信息管理</a></div>
<div  id="servicemenu6"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="servicesubimg18"><a href="UpdateUserInfo.aspx" target="mainFrame"  onClick="_ChangServiceSubMenuImg(18)">修改用户信息</a></div>
</div>



</div>
     
     
     
     
     <%
    }
    else if (((UserInfo)Session["ServiceUser"]).U_Power == 0)
    { 
    %>
    
    <!--系统管理员用户-->
<div>

<div class="menu"><img src="images/ico04.gif" id="adminimg1"><a href="javascript:_ChangAdminMenuDisplay(1)">服务区信息管理</a></div>
<div id="adminmenu1" style="display:none">
<div class="submemu"><img src="images/ico06.gif" id="adminsubimg1"><a href="ServiceList.aspx" target="mainFrame" onClick="_ChangAdminSubMenuImg(1)">信息列表</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="adminsubimg2"><a href="AddServiceInfo.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(2)">添加服务区</a></div>
<div class="submemu"><img src="images/ico06.gif" id="adminsubimg3"><a href="ServiceModelMgr.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(3)">服务项目管理</a></div>
<div class="submemu"><img src="images/ico06.gif" id="adminsubimg4"><a href="SiteMainImg.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(4)">网站主页图片</a></div>
<div class="submemu"><img src="images/ico06.gif" id="adminsubimg5"><a href="QuarterRank.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(5)">服务区季度排名</a></div>
</div>


<div class="menu"><img src="images/ico04.gif"  id="adminimg2"><a href="javascript:_ChangAdminMenuDisplay(2)">用户信息管理</a></div>
<div  id="adminmenu2"  style="display:none">
<div class="submemu"><img src="images/ico06.gif"  id="adminsubimg6"><a href="UserList.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(6)">用户列表</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="adminsubimg7"><a href="AddUser.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(7)">添加用户</a></div>
<div class="submemu"><img src="images/ico06.gif"  id="adminsubimg8"><a href="UpdateUserInfo.aspx" target="mainFrame"  onClick="_ChangAdminSubMenuImg(8)">修改账户信息</a></div>
</div>




</div>

    
    
    
    <%
    }
     %>







</div> 

  </form>  
</body>
</html>

