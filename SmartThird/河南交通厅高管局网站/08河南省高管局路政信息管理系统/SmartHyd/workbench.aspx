<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workbench.aspx.cs" Inherits="SmartHyd.workbench" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的工作台</title>

    <script src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>

  <style type="text/css">
    body{margin:0px; padding:0px; font-size:12px;}
    

    #title
    {
	    height:30px;
	    line-height:30px;
	    font-size:12px;
	    font-weight:bold;
	    font-family:微软雅黑;
	    border-bottom:1px solid #15428b;
    }
    #title .welcome
    {
	    width:auto;
	    float:left;
	    padding-left:10px;
    }
    #title .weather
    {
	    width:auto;
	    float:right;
	    padding-right:10px;
    }
    #message
    {
    	height:30px;
    	line-height:30px;
    	padding-left:10px;
    	font-family:微软雅黑;
    	font-size:12px;
    	font-weight:bold;
    }
    #message .notify{float:left;width:auto;height:30px;line-height:30px;}
    #message .history{ float:right;width:auto;height:30px;line-height:30px;}
    #work
    {
        padding-left:10px;
    }

    /*Example for a Menu Style*/
    .menu { background-color:#008bd3; border-bottom:1px solid #d7d7d7; height:36px; width:600px; }
    .menu ul { margin:0px; padding:0px; list-style:none; text-align:left; }
    .menu li { display:inline; padding-left:10px; line-height:36px; }
    .menu li a { color:#ffffff; text-decoration:none; height:34px;line-height:34px; width:120px; padding:1px 1px 2px 1px;  }
    .menu li a.tabactive { border-left:1px solid #d7d7d7;height:34px;line-height:34px;  border-right:1px solid #d7d7d7;color:#000000; background-color:#ffffff; font-weight:bold; position:relative; }
    #tabcontent1, #tabcontent2, #tabcontent3, #tabcontent4, #tabcontent5, #tabcontent6 
    {
    	height:260px; 
    	border-top:1px solid #ececec;
    	border-bottom:1px solid #008bd3;
    	border-left:1px solid #008bd3;
    	border-right:1px solid #008bd3;  
    	width:598px; 
    
    	padding-left:6px 0px; 
    	font-size:12px; 
    	margin-bottom:5px; 
    }
    #tabcontent1 span, #tabcontent2 span, #tabcontent3 span, #tabcontent4 span, #tabcontent5 span, #tabcontent6 span
    {
    	padding-left:10px;
    	width:580px;
    	border-bottom:1px dotted #cccccc;
    	display:block;
    	height:24px;
    	line-height:24px;
    }
  </style>

  <script type="text/javascript" language="javascript">
      /*
      EASY TABS 1.2 Produced and Copyright by Koller Juergen
      www.kollermedia.at | www.austria-media.at
      Need Help? http:/www.kollermedia.at/archive/2007/07/10/easy-tabs-12-now-with-autochange
      You can use this Script for private and commercial Projects, but just leave the two credit lines, thank you.
      */

      //EASY TABS 1.2 - MENU SETTINGS
      //Set the id names of your tablink (without a number at the end)
      var tablink_idname = new Array("tablink")
      //Set the id name of your tabcontentarea (without a number at the end)
      var tabcontent_idname = new Array("tabcontent")
      //Set the number of your tabs
      var tabcount = new Array("6")
      //Set the Tab wich should load at start (In this Example:Tab 2 visible on load)
      var loadtabs = new Array("1")
      //Set the Number of the Menu which should autochange (if you dont't want to have a change menu set it to 0)
      var autochangemenu = 1;
      //the speed in seconds when the tabs should change
      var changespeed = 3;
      //should the autochange stop if the user hover over a tab from the autochangemenu? 0=no 1=yes
      var stoponhover = 0;
      //END MENU SETTINGS

      /*Swich EasyTabs Functions - no need to edit something here*/
      function easytabs(menunr, active) { if (menunr == autochangemenu) { currenttab = active; } if ((menunr == autochangemenu) && (stoponhover == 1)) { stop_autochange() } else if ((menunr == autochangemenu) && (stoponhover == 0)) { counter = 0; } menunr = menunr - 1; for (i = 1; i <= tabcount[menunr]; i++) { document.getElementById(tablink_idname[menunr] + i).className = 'tab' + i; document.getElementById(tabcontent_idname[menunr] + i).style.display = 'none'; } document.getElementById(tablink_idname[menunr] + active).className = 'tab' + active + ' tabactive'; document.getElementById(tabcontent_idname[menunr] + active).style.display = 'block'; } var timer; counter = 0; var totaltabs = tabcount[autochangemenu - 1]; var currenttab = loadtabs[autochangemenu - 1]; function start_autochange() { counter = counter + 1; timer = setTimeout("start_autochange()", 1000); if (counter == changespeed + 1) { currenttab++; if (currenttab > totaltabs) { currenttab = 1 } easytabs(autochangemenu, currenttab); restart_autochange(); } } function restart_autochange() { clearTimeout(timer); counter = 0; start_autochange(); } function stop_autochange() { clearTimeout(timer); counter = 0; }

      window.onload = function () {
          var menucount = loadtabs.length; var a = 0; var b = 1; do { easytabs(b, loadtabs[a]); a++; b++; } while (b <= menucount);
          if (autochangemenu != 0) { start_autochange(); }
      }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="title">
        <div class="welcome">欢迎您，Administrator!</div>
        <div class="weather">今日天气：郑州 21°C-35°C 晴</div>
    </div>
    <div id="message">
        <div class="notify">未读公文:公文收件箱<span style="color:Red;">2</span>封</div>
        <div class="history">最近登录的时间：2012-06-18 09:10:25</div>
    </div>
    <div id="work">
    <div class="menu">
      <ul>
        <li><a href="#" onmouseover="easytabs('1', '1');" onfocus="easytabs('1', '1');" onclick="return false;"  title="" id="tablink1">最新公文</a></li>
        <li><a href="#" onmouseover="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"  title="" id="tablink2">电子公告</a></li>
        <li><a href="#" onmouseover="easytabs('1', '3');" onfocus="easytabs('1', '3');" onclick="return false;"  title="" id="tablink3">路政动态</a></li>
        <li><a href="#" onmouseover="easytabs('1', '4');" onfocus="easytabs('1', '4');" onclick="return false;"  title="" id="tablink4">事务提醒</a></li>
        <li><a href="#" onmouseover="easytabs('1', '5');" onfocus="easytabs('1', '5');"  onclick="return false;" title="" id="tablink5">高速路况</a></li>
        <li><a href="#" onmouseover="easytabs('1', '6');" onfocus="easytabs('1', '6');"  onclick="return false;" title="" id="tablink6">考评回复</a></li>
      </ul>
    </div>
    <!--End of the Tabmenu 2 -->
    <!--Start Tabcontent 1 -->
    <div id="tabcontent1">
        <span>公文标题[0001]</span>
        <span>公文标题[0002]</span>
        <span>公文标题[0003]</span>
        <span>公文标题[0004]</span>
        <span>公文标题[0005]</span>
        <span>公文标题[0006]</span>
        <span>公文标题[0007]</span>
        <span>公文标题[0008]</span>
        <span>公文标题[0009]</span>
        <span>公文标题[0010]</span>
    </div>
    <!--End Tabcontent 1-->
    <!--Start Tabcontent 2-->
    <div id="tabcontent2">Tabcontent 2</div>
    <!--End Tabcontent 2 -->
    <!--Start Tabcontent 3-->
    <div id="tabcontent3">Tabcontent 3</div>
    <!--End Tabcontent 3-->
    <!--Start Tabcontent 4-->
    <div id="tabcontent4">Tabcontent 4</div>
    <!--End Tabcontent 4-->
    <!--Start Tabcontent 5-->
    <div id="tabcontent5">Tabcontent 5</div>
    <!--End Tabcontent 5-->
    <!--Start Tabcontent 6-->
    <div id="tabcontent6">Tabcontent 6</div>
    <!--End Tabcontent 6-->     
    </div>                                                
    </form>
</body>
</html>
