<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Station_Index.aspx.cs" Inherits="station_Station_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>收费管理-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/station.css" rel="stylesheet" type="text/css" />
    <link href="../style/indexmenu.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/index_new.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/prototype.js"></script>
    <script type="text/javascript" src="../js/scriptaculous.js?load=effects,builder"></script>
    <script type="text/javascript" src="../js/lightbox.js"></script>
    <link rel="stylesheet" href="../css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
     <!--通用头部-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:287px; overflow:hidden;"></iframe></div>
    
    
    
 <!--主体部分-->
<div id="main">
  <!--左侧-->
  <div style="width:700px; float:left; overflow:hidden;">
    <!--收费站新闻-->
    <div id="news">
      <dl>
        <dt>
          <p class="more"><a href="NewsList.aspx?tid=101"><img src="../images/station/more.jpg"/></a></p>
        </dt>
        <dd>
          <div style="width:680px; margin:5px auto; overflow:hidden;">
            <!--新闻-->
            <div style="width:400px; float:right;">
              <ul>
                <asp:Repeater ID="rptGZDT" runat="server">
                    <ItemTemplate>
                     <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),25) %></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
              </ul>
            </div>
            <!--图片滚动-->
            <div style="width:260px; height:217px; overflow:hidden;">
                <%
            //工作动态图片新闻
           System.Data.DataTable dt_PicNews = MainService.NewsInfoService.Get_TopAnyPicNews(101,5);
           string strPics = "";
           string strLinks = "";
           string strTexts = "";
           if (dt_PicNews != null)
           {
               for (int i = 0; i < dt_PicNews.Rows.Count; i++)
               {
                   string strNID = dt_PicNews.Rows[i]["N_ID"].ToString();
                   string strPic = "../newsimages/" + dt_PicNews.Rows[i]["N_ImgView"].ToString();
                   string strText = CommonFunction.SubString(dt_PicNews.Rows[i]["N_Title"].ToString(), 20);
                   string strLink = "NewsInfo.aspx?nid=" + strNID;
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
       var focus_width=260;
       var focus_height=197;
       var text_height=20;
       var swf_height = focus_height+text_height;
       var pics= '<%=strPics %>';
       var links= '<%=strLinks %>';
       var texts= '<%=strTexts %>';
       document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="portal/inc/flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#cccccc">');document.write('<param name="menu" value="false"><param name=wmode value="opaque">');document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');document.write('<embed src="portal/inc/flash/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#cccccc" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');document.write('</object>');
       </script>
            </div>
          </div>
        </dd>
        <dd class="gzdt_b"></dd>
      </dl>
    </div>
    <dl class="right glzc mar_t10">
      <dt>
        <p class="more"><a href="NewsList.aspx?tid=102"><img src="../images/station/more.jpg"/></a></p>
      </dt>
      <dd>
        <ul>
        <asp:Repeater ID="rptGLZC" runat="server">
                    <ItemTemplate>
                     <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),18) %></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
         
        </ul>
      </dd>
      <dd class="glzc_b"></dd>
    </dl>
    <dl class="gzzd mar_t10">
      <dt>
        <p class="more"><a href="NewsList.aspx?tid=100"><img src="../images/station/more.jpg"/></a></p>
      </dt>
      <dd>
        <ul>
            <asp:Repeater ID="rptZCFG" runat="server">
                        <ItemTemplate>
                         <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),18) %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
        </ul>
      </dd>
      <dd class="gzzd_b"></dd>
    </dl>
  </div>
  <!--右侧-->
  <div class="left" style="width:270px; margin-left:10px; overflow:hidden;">
    <!--站内公告-->
    <dl class="zngg">
      <dt><p class="more"><a href="NewsList.aspx?tid=104"><img src="../images/station/more.jpg"/></a></p></dt>
      <dd>
       <marquee direction="up" scrollamount="3" onmouseover="this.stop()" onmouseout="this.start()" width="260px" height="225px" style="margin:0 auto;">
	        <ul>
	           <asp:Repeater ID="rptZNGG" runat="server">
                     <ItemTemplate>
                      <li><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# Eval("N_Title") %></a><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span></li>
                     </ItemTemplate>
               </asp:Repeater>
          </ul>
          </marquee>
        <ul>
          
        </ul>
      </dd>
      <dd class="zngg_b"></dd>
    </dl>
    <!--服务之星-->
    <dl id="stars" class="mar_t10">
      <dt>
        <p class="more"><a href="StarList.aspx?tid=105"><img src="../images/station/more.jpg"/></a></p>
      </dt>
      <dd>
        <asp:Repeater ID="rptStationStar" runat="server">
                <ItemTemplate>
                   <div class="star_con">
                   <p><a href='StarInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_From") %>' class="orange"><%# Eval("N_From") %></a></p>
                   &nbsp; &nbsp;<%# PubClass.Tool.SubString(Eval("N_HotIco").ToString(), 53)%><a href='StarInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank"  class="orange">[查看详细]</a>
                   </div>
            	<p class="star_img"><a href='StarInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><img src='../newsimages/<%# Eval("N_ImgView") %>' width="120" height="140" alt='<%# Eval("N_From") %>'/></a></p>
                </ItemTemplate>
                </asp:Repeater>
      </dd>
    </dl>
  </div>
  <div class="clear"></div>
  <!--广告-->
  <div style="width:980px; margin:0 auto; margin-top:10px; height:100px; overflow:hidden;"> <img src="../images/station/huodong.jpg" width="980" height="100" /> </div>
  <div style="width:980px; overflow:hidden;">
    <div class="left" style="width:700px; overflow:hidden;">
      <!--收费站查询-->
      <dl id="station_sear" class="mar_t10">
        <dt>
          <div class="sear_type"><a href="#">全部收费站</a><a href="#">按高速公路</a><a href="#">按地区查询</a><a href="#">按管理公司</a>
            <div class="clear"></div>
          </div>
        </dt>
        <dd>
        <!--  <ul>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
            <li><a href="#">济广豫皖省界收费站</a></li>
          </ul>-->
          <div class="clear"></div>
        </dd>
      </dl>
    </div>
    <div class="left" style="width:270px; margin-left:10px; overflow:hidden;">
      <!--星级收费站-->
      <dl id="stations" class="mar_t10">
        <dt>
          <p class="more"><a href="NewsList.aspx?tid=103"><img src="../images/station/more.jpg"/></a></p>
        </dt>
        <dd>
          <asp:Repeater ID="rptStarStation" runat="server">
                <ItemTemplate>
                  <p><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><img src='../images/station/fangfa.jpg' width="240" height="150" alt='<%# Eval("N_Title") %>' /></a></p><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a>
                </ItemTemplate>
                </asp:Repeater>
        </dd>
      </dl>
    </div>
  </div>
  <div class="clear"></div>
  <div class="right" style="width:700px; margin-top:10px; overflow:hidden;">
    <!--基层资讯-->
    <dl id="jiceng" class="left">
      <dt>
        <p class="more"><a href="NewsList.aspx?tid=109"><img src="../images/station/more.jpg"/></a></p>
      </dt>
      <dd style="height:137px;">
        <ul>
          <asp:Repeater ID="rptJCZX" runat="server">
                    <ItemTemplate>
                     <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
        </ul>
      </dd>
    </dl>
    <!--收费站文化-->
    <dl id="wenhua" class="left mar_l10">
      <dt>
        <p class="more"><a href="NewsList.aspx?tid=110"><img src="../images/station/more.jpg"/></a></p>
      </dt>
      <dd  style="height:137px;">
        <ul>
           <asp:Repeater ID="rptSFZWH" runat="server">
                    <ItemTemplate>
                     <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
        </ul>
      </dd>
    </dl>
    <div class="clear"></div>
  </div>
  <div style="width:270px; margin-top:10px; overflow:hidden;">
    <div class="tousu">
      <div class="tousu_con">
        <p class="right"><a href="#">在线调查</a></p>
        <a href="#">在线投诉</a> </div>
    </div>
    <p class="mar_t10"><a href="http://map.hngsgl.info" target="_blank"><img src="../images/station/mon_map.jpg" width="270" height="75" /></a></p>
  </div>
</div>
<!--主体部分 end-->
<!--图片滚动-->
<div style="width:980px; margin:0 auto; margin-top:10px; overflow:hidden">
	<div class="photo_t"></div>
    <div class="photo_bg">
    	<div class="photo_r">
        	<div class="photo_l">
            	<div id="demo" class="gundong" align="center">
                  <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td valign="top" id="marquePic1"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                        <tr>
                          <asp:Repeater ID="rptStationMien" runat="server">
                            <ItemTemplate>
                              <td><a href='../newsimages/<%# Eval("N_ImgPath") %>' rel="lightbox[StationMien]" title='<%# Eval("N_Title") %>'><img src='../newsimages/<%# Eval("N_ImgView") %>' width="150" height="120" alt='<%# Eval("N_Title") %>' /></a><br />
                            <a href="NewsInfo.aspx?nid=<%# Eval("N_ID") %>" target="_blank" title="<%# Eval("N_Title") %>"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),12) %></a></td>
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
            </div>
        </div>
    </div>
</div>   
    
    
    
 <!--通用底部-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
