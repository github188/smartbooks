<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftMenu.aspx.cs" Inherits="AdminMgr_leftMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>河南省交通运输厅高速公路管理局网站后台管理</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function showDivDisplay(p){
			if(document.getElementById("btnmenu"+p).style.display=="block"){
			   document.getElementById("btnmenu"+p).style.display="none"
			}else if(document.getElementById("btnmenu"+p).style.display=="none"){
			   document.getElementById("btnmenu"+p).style.display="block"
			}
		}
    </script>
  
</head>
<body style="background:url(images/leftbg.jpg) repeat-y; background-color:#11456c;">
 <form id="form1" runat="server"> 
 <div  class="leftmenu">
 <%
     MainModel.UserInfo info = (MainModel.UserInfo)Session["GsglInfo"];
     if (info.U_DepartId == 1)
     {
%>
<div class="btnmenu"  onclick="showDivDisplay(1)">网站首页</div>
 <div id="btnmenu1" style=" display:none"> 
 <div class="navimg"></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="WorkExpressMgr.aspx?tid=1"  target="mainFrame">工作动态</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=2"  target="mainFrame">高速新闻</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=3"  target="mainFrame">领导讲话</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=4"  target="mainFrame">高速采风</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="FileDownloadMgr.aspx?ftid=1"  target="mainFrame">文件下载</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="MessageBoardMgr.aspx"   target="mainFrame">高速留言</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=5"  target="mainFrame">联系我们</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="WorkExpressMgr.aspx?tid=6"  target="mainFrame" title="述职述学述廉报告">述职述学...</a></div>
 </div>


<div class="btnmenu"  onclick="showDivDisplay(10)">政务公开</div>
 <div  id="btnmenu10" style=" display:none">
 <div class="navimg"></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=60"  target="mainFrame">机构简介</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=61"  target="mainFrame">机构职能</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImageTextRemarkNewsMgr.aspx?tid=62"  target="mainFrame">政务信息</a></div>
   <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=63"  target="mainFrame">公告公示</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=64"  target="mainFrame">大事记</a></div>
 </div>


<div class="btnmenu"  onclick="showDivDisplay(2)">政策法规</div>
 <div  id="btnmenu2" style=" display:none">
 <div class="navimg"></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=50"  target="mainFrame">国家法规</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=51"  target="mainFrame">省政府法规</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=52"  target="mainFrame">行业管理法规</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=53"  target="mainFrame">修改法规</a></div>
 </div>
 
 
  <div class="btnmenu"  onclick="showDivDisplay(12)">高速知识</div>
 <div  id="btnmenu12" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=1" target="mainFrame">高速公路专题</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=2" target="mainFrame" >高速公路指路标志</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=3" target="mainFrame" >高速公路服务区</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=4" target="mainFrame" >高速公路收费</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=5" target="mainFrame">高速公路路政</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="KnowledgeArticleMgr.aspx?kmid=6" target="mainFrame">高速公路养护</a></div>
 </div>
 
  <div class="btnmenu"  onclick="showDivDisplay(9)">高速出游</div>
 <div  id="btnmenu9" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=120"   target="mainFrame">河南之最</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=121"   target="mainFrame">人文景观</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=122"   target="mainFrame">景区景点</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=123"   target="mainFrame">精品线路</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=124"   target="mainFrame">文化遗产</a></div>
 </div>
 
 
  <div class="btnmenu"  onclick="showDivDisplay(11)">应急管理</div>
 <div  id="btnmenu11" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=70" target="mainFrame">法律法规</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=71" target="mainFrame" title="国家应急预案">国家应急...</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=72" target="mainFrame" title="河南省应急预案">河南省应</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=73" target="mainFrame" title="行业管理应急预案">行业管理..</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=74" target="mainFrame">突发事件</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=75" target="mainFrame">典型案例</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=76" target="mainFrame" title="公众防灾应急手册">公众防灾..</a></div>
 </div>
<%
     }
     else if (info.U_DepartId == 2) {
%>
<div class="btnmenu"  onclick="showDivDisplay(3)">服务区管理</div>
 <div  id="btnmenu3" style=" display:none">
 <div class="navimg"></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImageTextNewsMgr.aspx?tid=26"   target="mainFrame">驿站新闻</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=20"   target="mainFrame">行业规章</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=21"   target="mainFrame">经验交流</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=27"   target="mainFrame">驿站文化</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="FileDownloadMgr.aspx?ftid=2"   target="mainFrame">资料下载</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="NewsPaperMgr.aspx"   target="mainFrame">行业报刊</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=24"   target="mainFrame" title="ISO国际标准化认证">ISO国际...</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=25"   target="mainFrame">通知公告</a></div>
 </div>
 
 <div class="btnmenu"  onclick="showDivDisplay(13)">服务区风采</div>
 <div  id="btnmenu13" style=" display:none">
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=130"   target="mainFrame">特色服务区</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=131"   target="mainFrame">开图走四方</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=132"   target="mainFrame">精品旅游线路</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=133"   target="mainFrame">吃住行游</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=134"   target="mainFrame">古道遗风</a></div>
 </div>
<%
     }
     else if (info.U_DepartId == 3) {
%>
 <div class="btnmenu"  onclick="showDivDisplay(6)">路政管理</div>
 <div  id="btnmenu6" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=88" target="mainFrame">站内公告</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImageTextNewsMgr.aspx?tid=89" target="mainFrame">工作动态</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=90" target="mainFrame">路政风采</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=91" target="mainFrame">队伍建设</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=92" target="mainFrame">依法行政</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=93" target="mainFrame">队伍管理</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=94" target="mainFrame">超限治理</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=95" target="mainFrame">精神文明</a></div>
 </div>
<%
     }
     else if (info.U_DepartId == 4) {
%>
<div class="btnmenu"  onclick="showDivDisplay(7)">养护管理</div>
 <div  id="btnmenu7" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=30" target="mainFrame">养护动态</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=31" target="mainFrame">办事指南</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=32" target="mainFrame">基层资讯</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=33" target="mainFrame">规章制度</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=34" target="mainFrame">文明创建</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=35" target="mainFrame">养护交流</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=36" target="mainFrame" title="养护新技术、新材料、新设备">养护新技...</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=37" target="mainFrame">养护管理</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=38" target="mainFrame">施工公告</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=39" target="mainFrame" title="公路技术状况评定">公路技术...</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=40" target="mainFrame">养护掠影</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="FileDownloadMgr.aspx?ftid=3"   target="mainFrame">资料下载</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=41" target="mainFrame">通知公告</a></div>
 </div>
<%
     }
     else if (info.U_DepartId == 5) {
%>
<div class="btnmenu"  onclick="showDivDisplay(8)">收费站管理</div>
 <div  id="btnmenu8" style=" display:none" >
 <div class="navimg"></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImageTextNewsMgr.aspx?tid=101" target="mainFrame">工作动态</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=100" target="mainFrame">规章制度</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=102" target="mainFrame">管理之窗</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=104" target="mainFrame">站内公告</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=103" target="mainFrame">星级收费站</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="StationStarMgr.aspx?tid=105" target="mainFrame">服务之星</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=109" target="mainFrame">基层资讯</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CommonNewsMgr.aspx?tid=110" target="mainFrame">收费站文化</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImgageNewsMgr.aspx?tid=111" target="mainFrame">收费站风采</a></div>
 </div>
 
<%
     }
     else if (info.U_DepartId == 6) { 
%>
<div class="btnmenu"  onclick="showDivDisplay(4)">交通管制</div>
 <div  id="btnmenu4" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="#">添加管制</a></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="#">管制信息</a></div>
 </div>
 
 
 <div class="btnmenu"  onclick="showDivDisplay(5)">实时路况</div>
 <div  id="btnmenu5" style=" display:none" >
 <div class="navimg"></div>
 <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="CurrentRoadContion.aspx?tid=80"  target="mainFrame">及时路况</a></div>
  <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="HistoryRoadCondition.aspx?tid=81"  target="mainFrame">历史路况</a></div>
 </div>
 
<%     
    }
    else if (info.U_DepartId == 8) { 
    %>
    <div class="btnmenu"  onclick="showDivDisplay(15)">超限运输审批情况表</div>
     <div  id="btnmenu15" style=" display:none" >
     <div class="navimg"></div>
     <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ChaoXianMgr.aspx"  target="mainFrame">信息列表</a></div>
     <div class="btnsubmenu" onmouseover="this.className='btnsubmenuonmove'" onmouseout="this.className='btnsubmenu'"><a href="ImportChaoXian.aspx"  target="mainFrame">数据导入</a></div>
    </div>
    <%
    }
  %>
 
 


 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 

 
 </div>
  
</form>
</body>
</html>
