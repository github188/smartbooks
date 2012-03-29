<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Import Namespace="MainService" %>
<%@ Import Namespace="MainModel" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>网站首页-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/prototype.js"></script>
    <script type="text/javascript" src="js/scriptaculous.js?load=effects,builder"></script>
    <script type="text/javascript" src="js/lightbox.js"></script>
    <script type="text/javascript" src="js/index_new.js"></script>
    <link rel="stylesheet" href="css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
     <!--通用头部-->
 
 <div style=" width:980px; margin:0 auto;"><iframe src="CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:288px; overflow:hidden;"></iframe></div>
<div id="main">
<div>
	<!---->
	<div class="left">
	<!--公众出行服务-->
	  <div><a href="http://map.hngsgl.info/" target="_blank"><img src="images/cxlogo.jpg" alt="公众出行信息服务" /></a></div>
      <!--维修施工信息服务-->
      <div style="margin-top:2px;"><a href="http://mc.hngsgl.info/" target="_blank"><img src="images/sglogo.jpg" alt="维修施工信息服务" /></a></div>
	<!--实时路况-->
	  <dl id="lukuang">
   	    <dt><p class="more" style="margin-top:4px;"><a href="RoadConditionList.aspx" style=" color:#fff;" target="_blank">更多 >></a></p></dt>
        <dd>
        <marquee direction="up" scrollamount="3"  height="121"  style=" margin-left:10px;"width="220px" onmouseover="this.stop()" onmouseout="this.start()">
            	<ul>
            	<li><asp:Label ID="lblLJZHZX" runat="server" Text=""></asp:Label></li>
                  <asp:Repeater ID="rptCurrentRoadConditon" runat="server">
                  <ItemTemplate>
                   <li><%# Eval("N_Content")%></li>
                  </ItemTemplate>
                  </asp:Repeater>
                </ul>
            </marquee>
		</dd>        
      </dl>
      <div class="left_b"></div>
	</div>
    <!---->
  	<div class="left mar_l10">
    	<!--政务信息-->
      <dl id="new_xinxi">
   	      <dt>
   	        <p class="more"><a href="NewsInfoList.aspx?tid=62">更多 >></a></p>
        </dt>
   	      <dd>
   	        <div class="right new_xinxi_con">
                   <asp:Repeater ID="rptTop1_NewsList" runat="server">
                   <ItemTemplate>
                   <h1><a href="NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>" title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 29)%></a></h1>
   	          <p> &nbsp;&nbsp;&nbsp;&nbsp;<%# PubClass.Tool.SubString(Eval("N_HotIco").ToString(), 104)%><a href="NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>" class="orange" target="_blank">[点击更多]</a></p>
                   </ItemTemplate>
                   </asp:Repeater>
            </div>
   	        <div style="width:220px; height:175px; background:#bbb; overflow:hidden;">
   	         <%
            //图片政务信息
           System.Data.DataTable dt_PicNews = NewsInfoService.Get_TopAnyPicNews(62,5);
           string strPics = "";
           string strLinks = "";
           string strTexts = "";
           if (dt_PicNews != null)
           {
               for (int i = 0; i < dt_PicNews.Rows.Count; i++)
               {
                   string strNID = dt_PicNews.Rows[i]["N_ID"].ToString();
                   string strPic = "newsimages/" + dt_PicNews.Rows[i]["N_ImgView"].ToString();
                   string strText = CommonFunction.SubString(dt_PicNews.Rows[i]["N_Title"].ToString(), 17);
                   string strLink = "NewsInfoDetail.aspx?nid=" + strNID;
                   if (i == dt_PicNews.Rows.Count - 1)
                   {
                       strPics += strPic;
                       strLinks += strLink;
                       strTexts += strText;
                   }
                   else {
                       strPics += strPic + "|";
                       strLinks += strLink + "|";
                       strTexts += strText + "|";
                   }
               }
           }
            
    
     %>
       <script type='text/javascript'>
       var focus_width=220;
       var focus_height=155;
       var text_height=20;
       var swf_height = focus_height+text_height;
       var pics= '<%=strPics %>';
       var links= '<%=strLinks %>';
       var texts= '<%=strTexts %>';
       document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="portal/inc/flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#cccccc">');document.write('<param name="menu" value="false"><param name=wmode value="opaque">');document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');document.write('<embed src="portal/inc/flash/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#cccccc" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');document.write('</object>');
       </script>
   	        </div>
   	        <div style="margin-top:5px;"><img src="images/line.gif" width="461" height="2" /></div>
   	        <ul>
   	            <asp:Repeater ID="rptTop2_4NewsList" runat="server">
                <ItemTemplate>
                   <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 30)%></a></li>
                </ItemTemplate>
            </asp:Repeater>
            </ul>
        </dd>
      </dl>
      <div class="new_xinxi_b"></div>
   </div>
    <!---->
  <div class="left mar_l10" > 
    	<!--公告公示-->   	
        <dl id="gonggao">
       	  <dt><p class="more"><a href="NewsInfoList.aspx?tid=63">更多 >></a></p>公告公示</dt>
          <dd>
          <div style="height:220px; overflow:hidden;">
            	<ul>
                  <asp:Repeater ID="rptSiteNotice" runat="server">
                  <ItemTemplate>
                   <li><a href='NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>'><%# Eval("N_Title")%></a><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span></li>
                  </ItemTemplate>
                  </asp:Repeater>
                </ul>
            </div>
            <div style="margin-top:10px;"><a href="ChaoXianReport.aspx"><img src="images/chaoxian.jpg" alt="河南省高速公路超限运输审批情况表" /></a></div>
            <!--
            <div class="search">
            	<p style=" margin:5px 0 0 50px; color:#09C;">站内搜索&nbsp;<input name="search" type="text" style="border:1px #CCC solid; height:20px; line-height:20px;"/></p><p style="margin-left:70px;margin-top:10px;"><input name="search" value=" 搜索 "type="button" style="background:url(images/search_btn.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />&nbsp;&nbsp;<input name="search" value="高级搜索"type="button" style="background:url(images/search_btn.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" /></p>
            </div>
            -->
          </dd>
        </dl>
        <!--搜索-->
        
  </div>
    <div class="clear"></div>
 </div>   
    <div class="propagate mar_t10"><img src="images/propagate.jpg" width="976" height="106" /></div>
    <!--服务快捷方式和列表-->
  <div class="mar_t10">
	<div class="right" style="width:750px;">
        	<dl class="right list">
            	<dt class="xinwen"><p class="more38"><a href="GsNewsList.aspx?tid=2" target="_blank">更多 >></a></p>高速新闻</dt>
                <dd>
                	<ul>
                    	<asp:Repeater ID="rptGsNews" runat="server">
                        <ItemTemplate>
                           <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='PageInfoDetail.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot;<%# PubClass.Tool.SubString("["+Eval("N_From")+"]"+Eval("N_Title").ToString(), 22)%></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
                <dd class="list_b"></dd>
            </dl>
            
            <dl class="list">
            	<dt class="dongtai"><p class="more38"><a href="WorkExpressList.aspx" target="_blank">更多 >></a></p>工作动态</dt>
                <dd>
                	<ul>
                    	<asp:Repeater ID="rptWorkexpress" runat="server">
                        <ItemTemplate>
                           <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='workexpress/<%#  Eval("N_ImgPath") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot;<%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 22)%></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
                <dd class="list_b"></dd>
            </dl>
            
            <dl class="right mar_t10 list">
            	<dt class="down"><p class="more38"><a href="DownloadList.aspx" target="_blank">更多 >></a></p>
            	文件下载</dt>
                <dd>
                	<ul>
                        <asp:Repeater ID="rptDownLoad" runat="server">
                        <ItemTemplate>
                           <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("FD_CreateDate").ToString())%>]</span><a href='DownLoad/<%# Eval("FD_Path") %>' title='<%# Eval("FD_Title") %>'>&middot;<%# PubClass.Tool.SubString(Eval("FD_Title").ToString(), 22)%></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
                <dd class="list_b"></dd>
            </dl>
            
            <dl class="mar_t10 list">
            	<dt class="zhengce"><p class="more38"><a href="PolicyRulesList.aspx?tid=50" target="_blank">更多 >></a></p>
            	政策法规</dt>
                <dd>
                	<ul>
                    	<asp:Repeater ID="rptRuleList" runat="server">
                        <ItemTemplate>
                           <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='PolicyRuleInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot;<%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 22)%></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </dd>
                <dd class="list_b"></dd>
            </dl>
    </div>
        <div id="fuwu">
          <p class="fuwu_t"></p>
            <ul>
                <li><img src="images/fuwu1.jpg" width="200" height="60" alt="全省统一服务电话12122"/></li>
                <li><a href="http://www.weather.com.cn/weather/101180101.shtml" target="_blank"><img src="images/fuwu2.jpg" width="200" height="60" alt="出行天气" /></a></li>
                <li><a href="gstravel/chuyou.html" target="_blank"><img src="images/fuwu3.jpg" width="200" height="60"  alt="高速出游"/></a></li>
                <li><a href="GSKnowledge/index.html" target="_blank"><img src="images/fuwu4.jpg" width="200" height="60" alt="高速知识"/></a></li>
                <li><a href="GSWenYuan/NewsList.aspx?tid=4" target="_blank"><img src="images/fuwu5.jpg" width="200" height="60" alt="高速文苑"/></a></li>
                <li><a href="MessageBoard.aspx"><img src="images/fuwu6.jpg" width="200" height="60" alt="高速留言" /></a></li>
                <li><a href="mailto:tggj@hncd.gov.cn"><img src="images/fuwu7.jpg" width="200" height="60" alt="局长信箱" /></a></li>
            </ul>
            <p class="fuwu_b"></p>
        </div>
        <div class="clear"></div>
  </div>
    <!--高速采风-->
    <div class="mar_t10">
      
      <div class="caifeng_r">
   	    <div class="caifeng_l">
        <div class="caifeng_t"></div>
        <div id="demo" class="gundong">
          <table border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td valign="top" id="marquePic1"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                <tr>
                    <asp:Repeater ID="rptGsFengCai" runat="server">
                    <ItemTemplate> 
                       <td><a href='newsimages/<%# Eval("N_ImgPath") %>' rel="lightbox[fengcai]" title='<%# Eval("N_Title") %>'><img src='newsimages/<%# Eval("N_ImgView") %>' width="150" height="120" alt='<%# Eval("N_Title") %>' /></a></td>
                    </ItemTemplate>
                    </asp:Repeater>
                </tr>
              </table></td>
              <td id="marquePic2" valign="top"></td>
            </tr>
          </table>
        </div>
        <script type="text/javascript"> 
                    var speed=50 
                    marquePic2.innerHTML=marquePic1.innerHTML 
                    function Marquee(){ 
                    if(demo.scrollLeft>=marquePic1.scrollWidth){ 
                    demo.scrollLeft=0 
                    }else{ 
                    demo.scrollLeft++ 
                    } 
                    } 
                    var MyMar=setInterval(Marquee,speed) 
                    demo.onmouseover=function() {clearInterval(MyMar)} 
                    demo.onmouseout=function() {MyMar=setInterval(Marquee,speed)} 
                </script>
        <div class="caifeng_b"></div>
        </div>
      </div>        
  </div>
  <!--友情链接和管理公司等-->
  <div class="mar_t10">
<div class="right">
        	<div id="companylist">
  <div class="news_line">
    <div class="news_nav"><a href="#" class="xinwen2" id="Button11" onmouseover="TabMoveIndex(1,1,4)">管理公司</a>
<a href="#" class="xinwen1" id="Button12" onmouseover="TabMoveIndex(1,2,4)">服务区</a>
<a href="#" class="xinwen1" id="Button13" onmouseover="TabMoveIndex(1,3,4)">收费站</a>
<a href="#" class="xinwen1" id="Button14" onmouseover="TabMoveIndex(1,4,4)">路政</a></div>
      <div class="clear"></div>       
    </div>
       <div id="ContentBox11">
      <ul class="companylst" >
        <li>
          <a href="http://www.hnew.com.cn/" target="_blank">河南高速公路发展有限责任公司</a></li>
        <li><a href="http://www.zygs.com/zygs/index.jsp" target="_blank">河南中原高速公路股份有限公司</a></li>
        <li><a href="http://www.xpngs.com/" target="_blank">河南省许平南高速公路有限责任公司</a></li>        
        <li><a href="http://www.hnyngs.com/" target="_blank">河南省豫南高速投资有限公司</a></li>
        <li><a href="http://www.sdecl.com.cn/" target="_blank">山东高速集团河南许禹许亳公路有限公司</a></li>
      </ul>
      </div>
      <div id="ContentBox12" style="display:none">
      <ul class="servicelst" >
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=7" target="_blank">许昌服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=16" target="_blank">三门峡服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=20" target="_blank">郑州北服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=22" target="_blank">开封服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=15" target="_blank">灵宝服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=5" target="_blank">郑州东服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=25" target="_blank">商丘服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=29" target="_blank">濮阳服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=61" target="_blank">罗山服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=98"target="_blank" >郑州西服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=23"target="_blank" >民权服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=2" target="_blank">安阳服务区</a></li>
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=8" target="_blank">漯河服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=33"target="_blank" >扶沟服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=34" target="_blank">周口东服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=35" target="_blank">项城南服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=77" target="_blank">禹州西服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=78" target="_blank">鄢陵南服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=85"target="_blank" >沁阳服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=102" target="_blank">禹州服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=103" target="_blank">平顶山南服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=104" target="_blank">尧山服务区</a></li>
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=106" target="_blank">平顶山服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=87" target="_blank">延津服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=95" target="_blank">获嘉服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=99"target="_blank" >少林服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=101"target="_blank" >郑州南服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=4" target="_blank">原阳服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=48" target="_blank">汝阳服务区</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=57" target="_blank">唐河服务区</a></li>
        </ul>
        </div>
        <div id="ContentBox13" style="display:none">
      <ul class="company" >
        <li>收费站数据正在建设中</li>
        </ul>
        </div>
        <div id="ContentBox14" style="display:none">
      <ul class="lzlist" >
          <asp:Repeater ID="rptLZ" runat="server">
          <ItemTemplate>
             <li><a href='http://road.hngsgl.info/CheckToRoad.aspx?roadid=<%# Eval("RD_ID") %>' target="_blank"><%# Eval("RD_Name") %></a></li>
          </ItemTemplate>
          </asp:Repeater>
        
        </ul>
        </div>
    </div>
        </div>
  <dl id="link">
        	<dt>友情链接</dt>
            <dd>
              <select name="mylink1" onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;" >
                <option selected="selected">---------+厅直单位+---------</option>
                <option value="http://www.hncd.gov.cn">河南省交通运输厅</option>
                <option value="http://www.hngl.gov.cn">河南省交通运输厅公路管理局</option>
                <option value="http://www.hngsgl.info">河南省交通运输厅高速公路管理局</option>
                <option value="http://www.yz.ha.cn">河南省交通运输厅道路运输局</option>
                <option value="http://www.hnmsa.cn">河南省交通运输厅航务局</option>
              </select>
            </dd>
            <dd>
            	<select name="mylink2"  onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">--------+省辖市交通+--------</option>
                  <option value="http://www.zzjtj.gov.cn">郑州市交通局</option>
                  <option value="http://www.ayjtj.cn">安阳市交通局</option>
                  <option value="http://www.xxjtj.cn">新乡市交通局</option>
                  <option value="http://www.jzjtj.gov.cn">焦作市交通局</option>
                  <option value="http://www.pyjt.gov.cn">濮阳市交通局</option>
                  <option value="http://www.xcsjtj.gov.cn">许昌市交通局</option>
                  <option value="http://www.sqjtj.gov.cn">商丘市交通局</option>
                  <option value="http://www.jyjt.gov.cn">济源市交通局</option>
                  <option value="http://www.zmdjtj.gov.cn">驻马店市交通局</option>
                  <option value="http://www.kfjtj.gov.cn">开封市交通局</option>
                  <option value="http://jtj.smx.gov.cn">三门峡市交通局</option>
                  <option value="http://jtj.ly.gov.cn">洛阳市交通局</option>
                  <option value="http://www.hbt.gov.cn">鹤壁市交通局</option>
                  <option value="http://www.xyjtw.gov.cn">信阳市交通局</option>
                  <option value="http://www.nyjt.gov.cn">南阳市交通局</option>
                  <option value="http://www.lhjiaotong.gov.cn">漯河市交通局</option>
                  <option value="http://www.pdsjt.gov.cn">平顶山市交通局</option>
            	</select>
            </dd>
            <dd>
            	<select name="mylink3"  onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">---------+政府网站+---------</option>
                  <option value="http://www.henan.gov.cn">河南省人民政府</option>
                  <option value="http://www.zhengzhou.org.cn">中国郑州</option>
                  <option value="http://www.fmprc.gov.cn">外交部</option>
                  <option value="http://www.sdpc.gov.cn">国家发展计划委</option>
                  <option value="http://www.sasac.gov.cn">国资委</option>
                  <option value="http://www.moe.edu.cn">教育部</option>
                  <option value="http://www.most.gov.cn">科学技术部</option>
                  <option value="http://www.costind.gov.cn">国防科工委</option>
                  <option value="http://www.seac.gov.cn">国家民委</option>
                  <option value="http://www.mps.gov.cn">公安部</option>
                  <option value="http://www.mca.gov.cn">民政部</option>
                  <option value="http://www.mohrss.gov.cn">人事部</option>
                  <option value="http://www.mlr.gov.cn">国土资源部</option>
                  <option value="http://www.cin.gov.cn">建设部</option>
                  <option value="http://www.chinamor.cn.net">铁道部</option>
                  <option value="http://www.moc.gov.cn">交通部</option>
                  <option value="http://www.mii.gov.cn">信息产业部</option>
                  <option value="http://www.agri.gov.cn">农业部</option>
                  <option value="http://www.mwr.gov.cn">水利部</option>
                  <option value="http://www.moftec.gov.cn">外经贸部</option>
                  <option value="http://www.pbc.gov.cn">中国人民银行</option>
                  <option value="http://www.moh.gov.cn">卫生部</option>
                  <option value="http://www.sfpc.gov.cn">国家计生委</option>
                  <option value="http://www.ccnt.gov.cn">文化部</option>
                  <option value="http://www.mohrss.gov.cn">劳动和社会保障部</option>
            	</select>
            </dd>
<dd style="margin-bottom:18px;" >
            	<select name="mylink4" onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">---------+热点链接+---------</option>
            	  <option value="http://www.hnglw.com">河南公路网</option>
            	  <option value="http://www.cngaosu.com">中国高速公路网</option>
            	  <option value="http://www.xinhuanet.com">新华社</option>
            	  <option value="http://www.china.com">中华网</option>
            	  <option value="http://www.people.com.cn">人民日报</option>
            	  <option value="http://www.ifeng.com">凤凰卫视</option>
            	  <option value="http://www.zz.ha.cn">商都信息港</option>
            	  <option value="http://www.online.ha.cn">河南信息港</option>
            	  <option value="http://www.dahe.cn">河南报业网</option>
            	  <option value="http://www.cctv.com">中央电视台</option>
            	  <option value="http://www.china.org.cn">英语新闻</option>
            	  <option value="http://www.google.cn">Google</option>
            	  <option value="http://www.37c.net.cn/">37℃医学网</option>
            	  <option value="http://www.hnqi.gov.cn">河南质量信息网</option>
            	  <option value="http://www.sina.com.cn">新浪</option>
            	  <option value="http://www.drivego.cn">梦随心动-人车行</option>
            	</select>
            </dd>
      </dl>
    </div>
</div>
 <!--通用底部-->
 <div style=" width:980px; margin:0 auto;"><iframe src="CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:100px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
