<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Import Namespace="MainService" %>
<%@ Import Namespace="MainModel" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>��վ��ҳ-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="style/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/prototype.js"></script>
    <script type="text/javascript" src="js/scriptaculous.js?load=effects,builder"></script>
    <script type="text/javascript" src="js/lightbox.js"></script>
    <script type="text/javascript" src="js/index_new.js"></script>
    <link rel="stylesheet" href="css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
     <!--ͨ��ͷ��-->
 
 <div style=" width:980px; margin:0 auto;"><iframe src="CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:288px; overflow:hidden;"></iframe></div>
<div id="main">
<div>
	<!---->
	<div class="left">
	<!--���ڳ��з���-->
	  <div><a href="http://map.hngsgl.info/" target="_blank"><img src="images/cxlogo.jpg" alt="���ڳ�����Ϣ����" /></a></div>
      <!--ά��ʩ����Ϣ����-->
      <div style="margin-top:2px;"><a href="http://mc.hngsgl.info/" target="_blank"><img src="images/sglogo.jpg" alt="ά��ʩ����Ϣ����" /></a></div>
	<!--ʵʱ·��-->
	  <dl id="lukuang">
   	    <dt><p class="more" style="margin-top:4px;"><a href="RoadConditionList.aspx" style=" color:#fff;" target="_blank">���� >></a></p></dt>
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
    	<!--������Ϣ-->
      <dl id="new_xinxi">
   	      <dt>
   	        <p class="more"><a href="NewsInfoList.aspx?tid=62">���� >></a></p>
        </dt>
   	      <dd>
   	        <div class="right new_xinxi_con">
                   <asp:Repeater ID="rptTop1_NewsList" runat="server">
                   <ItemTemplate>
                   <h1><a href="NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>" title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 29)%></a></h1>
   	          <p> &nbsp;&nbsp;&nbsp;&nbsp;<%# PubClass.Tool.SubString(Eval("N_HotIco").ToString(), 104)%><a href="NewsInfoDetail.aspx?nid=<%# Eval("N_ID") %>" class="orange" target="_blank">[�������]</a></p>
                   </ItemTemplate>
                   </asp:Repeater>
            </div>
   	        <div style="width:220px; height:175px; background:#bbb; overflow:hidden;">
   	         <%
            //ͼƬ������Ϣ
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
    	<!--���湫ʾ-->   	
        <dl id="gonggao">
       	  <dt><p class="more"><a href="NewsInfoList.aspx?tid=63">���� >></a></p>���湫ʾ</dt>
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
            <div style="margin-top:10px;"><a href="ChaoXianReport.aspx"><img src="images/chaoxian.jpg" alt="����ʡ���ٹ�·�����������������" /></a></div>
            <!--
            <div class="search">
            	<p style=" margin:5px 0 0 50px; color:#09C;">վ������&nbsp;<input name="search" type="text" style="border:1px #CCC solid; height:20px; line-height:20px;"/></p><p style="margin-left:70px;margin-top:10px;"><input name="search" value=" ���� "type="button" style="background:url(images/search_btn.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />&nbsp;&nbsp;<input name="search" value="�߼�����"type="button" style="background:url(images/search_btn.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" /></p>
            </div>
            -->
          </dd>
        </dl>
        <!--����-->
        
  </div>
    <div class="clear"></div>
 </div>   
    <div class="propagate mar_t10"><img src="images/propagate.jpg" width="976" height="106" /></div>
    <!--�����ݷ�ʽ���б�-->
  <div class="mar_t10">
	<div class="right" style="width:750px;">
        	<dl class="right list">
            	<dt class="xinwen"><p class="more38"><a href="GsNewsList.aspx?tid=2" target="_blank">���� >></a></p>��������</dt>
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
            	<dt class="dongtai"><p class="more38"><a href="WorkExpressList.aspx" target="_blank">���� >></a></p>������̬</dt>
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
            	<dt class="down"><p class="more38"><a href="DownloadList.aspx" target="_blank">���� >></a></p>
            	�ļ�����</dt>
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
            	<dt class="zhengce"><p class="more38"><a href="PolicyRulesList.aspx?tid=50" target="_blank">���� >></a></p>
            	���߷���</dt>
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
                <li><img src="images/fuwu1.jpg" width="200" height="60" alt="ȫʡͳһ����绰12122"/></li>
                <li><a href="http://www.weather.com.cn/weather/101180101.shtml" target="_blank"><img src="images/fuwu2.jpg" width="200" height="60" alt="��������" /></a></li>
                <li><a href="gstravel/chuyou.html" target="_blank"><img src="images/fuwu3.jpg" width="200" height="60"  alt="���ٳ���"/></a></li>
                <li><a href="GSKnowledge/index.html" target="_blank"><img src="images/fuwu4.jpg" width="200" height="60" alt="����֪ʶ"/></a></li>
                <li><a href="GSWenYuan/NewsList.aspx?tid=4" target="_blank"><img src="images/fuwu5.jpg" width="200" height="60" alt="������Է"/></a></li>
                <li><a href="MessageBoard.aspx"><img src="images/fuwu6.jpg" width="200" height="60" alt="��������" /></a></li>
                <li><a href="mailto:tggj@hncd.gov.cn"><img src="images/fuwu7.jpg" width="200" height="60" alt="�ֳ�����" /></a></li>
            </ul>
            <p class="fuwu_b"></p>
        </div>
        <div class="clear"></div>
  </div>
    <!--���ٲɷ�-->
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
  <!--�������Ӻ͹���˾��-->
  <div class="mar_t10">
<div class="right">
        	<div id="companylist">
  <div class="news_line">
    <div class="news_nav"><a href="#" class="xinwen2" id="Button11" onmouseover="TabMoveIndex(1,1,4)">����˾</a>
<a href="#" class="xinwen1" id="Button12" onmouseover="TabMoveIndex(1,2,4)">������</a>
<a href="#" class="xinwen1" id="Button13" onmouseover="TabMoveIndex(1,3,4)">�շ�վ</a>
<a href="#" class="xinwen1" id="Button14" onmouseover="TabMoveIndex(1,4,4)">·��</a></div>
      <div class="clear"></div>       
    </div>
       <div id="ContentBox11">
      <ul class="companylst" >
        <li>
          <a href="http://www.hnew.com.cn/" target="_blank">���ϸ��ٹ�·��չ�������ι�˾</a></li>
        <li><a href="http://www.zygs.com/zygs/index.jsp" target="_blank">������ԭ���ٹ�·�ɷ����޹�˾</a></li>
        <li><a href="http://www.xpngs.com/" target="_blank">����ʡ��ƽ�ϸ��ٹ�·�������ι�˾</a></li>        
        <li><a href="http://www.hnyngs.com/" target="_blank">����ʡԥ�ϸ���Ͷ�����޹�˾</a></li>
        <li><a href="http://www.sdecl.com.cn/" target="_blank">ɽ�����ټ��ź�����������·���޹�˾</a></li>
      </ul>
      </div>
      <div id="ContentBox12" style="display:none">
      <ul class="servicelst" >
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=7" target="_blank">���������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=16" target="_blank">����Ͽ������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=20" target="_blank">֣�ݱ�������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=22" target="_blank">���������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=15" target="_blank">�鱦������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=5" target="_blank">֣�ݶ�������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=25" target="_blank">���������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=29" target="_blank">���������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=61" target="_blank">��ɽ������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=98"target="_blank" >֣����������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=23"target="_blank" >��Ȩ������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=2" target="_blank">����������</a></li>
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=8" target="_blank">��ӷ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=33"target="_blank" >����������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=34" target="_blank">�ܿڶ�������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=35" target="_blank">����Ϸ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=77" target="_blank">������������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=78" target="_blank">۳���Ϸ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=85"target="_blank" >����������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=102" target="_blank">���ݷ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=103" target="_blank">ƽ��ɽ�Ϸ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=104" target="_blank">Ңɽ������</a></li>
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=106" target="_blank">ƽ��ɽ������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=87" target="_blank">�ӽ������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=95" target="_blank">��η�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=99"target="_blank" >���ַ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=101"target="_blank" >֣���Ϸ�����</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=4" target="_blank">ԭ��������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=48" target="_blank">����������</a></li>
                       
                        <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=57" target="_blank">�ƺӷ�����</a></li>
        </ul>
        </div>
        <div id="ContentBox13" style="display:none">
      <ul class="company" >
        <li>�շ�վ�������ڽ�����</li>
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
        	<dt>��������</dt>
            <dd>
              <select name="mylink1" onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;" >
                <option selected="selected">---------+��ֱ��λ+---------</option>
                <option value="http://www.hncd.gov.cn">����ʡ��ͨ������</option>
                <option value="http://www.hngl.gov.cn">����ʡ��ͨ��������·�����</option>
                <option value="http://www.hngsgl.info">����ʡ��ͨ���������ٹ�·�����</option>
                <option value="http://www.yz.ha.cn">����ʡ��ͨ��������·�����</option>
                <option value="http://www.hnmsa.cn">����ʡ��ͨ�����������</option>
              </select>
            </dd>
            <dd>
            	<select name="mylink2"  onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">--------+ʡϽ�н�ͨ+--------</option>
                  <option value="http://www.zzjtj.gov.cn">֣���н�ͨ��</option>
                  <option value="http://www.ayjtj.cn">�����н�ͨ��</option>
                  <option value="http://www.xxjtj.cn">�����н�ͨ��</option>
                  <option value="http://www.jzjtj.gov.cn">�����н�ͨ��</option>
                  <option value="http://www.pyjt.gov.cn">����н�ͨ��</option>
                  <option value="http://www.xcsjtj.gov.cn">����н�ͨ��</option>
                  <option value="http://www.sqjtj.gov.cn">�����н�ͨ��</option>
                  <option value="http://www.jyjt.gov.cn">��Դ�н�ͨ��</option>
                  <option value="http://www.zmdjtj.gov.cn">פ����н�ͨ��</option>
                  <option value="http://www.kfjtj.gov.cn">�����н�ͨ��</option>
                  <option value="http://jtj.smx.gov.cn">����Ͽ�н�ͨ��</option>
                  <option value="http://jtj.ly.gov.cn">�����н�ͨ��</option>
                  <option value="http://www.hbt.gov.cn">�ױ��н�ͨ��</option>
                  <option value="http://www.xyjtw.gov.cn">�����н�ͨ��</option>
                  <option value="http://www.nyjt.gov.cn">�����н�ͨ��</option>
                  <option value="http://www.lhjiaotong.gov.cn">����н�ͨ��</option>
                  <option value="http://www.pdsjt.gov.cn">ƽ��ɽ�н�ͨ��</option>
            	</select>
            </dd>
            <dd>
            	<select name="mylink3"  onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">---------+������վ+---------</option>
                  <option value="http://www.henan.gov.cn">����ʡ��������</option>
                  <option value="http://www.zhengzhou.org.cn">�й�֣��</option>
                  <option value="http://www.fmprc.gov.cn">�⽻��</option>
                  <option value="http://www.sdpc.gov.cn">���ҷ�չ�ƻ�ί</option>
                  <option value="http://www.sasac.gov.cn">����ί</option>
                  <option value="http://www.moe.edu.cn">������</option>
                  <option value="http://www.most.gov.cn">��ѧ������</option>
                  <option value="http://www.costind.gov.cn">�����ƹ�ί</option>
                  <option value="http://www.seac.gov.cn">������ί</option>
                  <option value="http://www.mps.gov.cn">������</option>
                  <option value="http://www.mca.gov.cn">������</option>
                  <option value="http://www.mohrss.gov.cn">���²�</option>
                  <option value="http://www.mlr.gov.cn">������Դ��</option>
                  <option value="http://www.cin.gov.cn">���貿</option>
                  <option value="http://www.chinamor.cn.net">������</option>
                  <option value="http://www.moc.gov.cn">��ͨ��</option>
                  <option value="http://www.mii.gov.cn">��Ϣ��ҵ��</option>
                  <option value="http://www.agri.gov.cn">ũҵ��</option>
                  <option value="http://www.mwr.gov.cn">ˮ����</option>
                  <option value="http://www.moftec.gov.cn">�⾭ó��</option>
                  <option value="http://www.pbc.gov.cn">�й���������</option>
                  <option value="http://www.moh.gov.cn">������</option>
                  <option value="http://www.sfpc.gov.cn">���Ҽ���ί</option>
                  <option value="http://www.ccnt.gov.cn">�Ļ���</option>
                  <option value="http://www.mohrss.gov.cn">�Ͷ�����ᱣ�ϲ�</option>
            	</select>
            </dd>
<dd style="margin-bottom:18px;" >
            	<select name="mylink4" onchange="javascript:window.open(this.options[this.selectedIndex].value)" style=" width:183px;">
            	  <option selected="selected">---------+�ȵ�����+---------</option>
            	  <option value="http://www.hnglw.com">���Ϲ�·��</option>
            	  <option value="http://www.cngaosu.com">�й����ٹ�·��</option>
            	  <option value="http://www.xinhuanet.com">�»���</option>
            	  <option value="http://www.china.com">�л���</option>
            	  <option value="http://www.people.com.cn">�����ձ�</option>
            	  <option value="http://www.ifeng.com">�������</option>
            	  <option value="http://www.zz.ha.cn">�̶���Ϣ��</option>
            	  <option value="http://www.online.ha.cn">������Ϣ��</option>
            	  <option value="http://www.dahe.cn">���ϱ�ҵ��</option>
            	  <option value="http://www.cctv.com">�������̨</option>
            	  <option value="http://www.china.org.cn">Ӣ������</option>
            	  <option value="http://www.google.cn">Google</option>
            	  <option value="http://www.37c.net.cn/">37��ҽѧ��</option>
            	  <option value="http://www.hnqi.gov.cn">����������Ϣ��</option>
            	  <option value="http://www.sina.com.cn">����</option>
            	  <option value="http://www.drivego.cn">�����Ķ�-�˳���</option>
            	</select>
            </dd>
      </dl>
    </div>
</div>
 <!--ͨ�õײ�-->
 <div style=" width:980px; margin:0 auto;"><iframe src="CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:100px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
