<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Service_Index.aspx.cs" Inherits="service_Service_Index" %>
<%@ Import Namespace="MainService" %>
<%@ Import Namespace="MainModel" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/index_new.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:287px; overflow:hidden;"></iframe></div>
    <div id="box"> 
    <div class="right">
	<!--֪ͨ���� begin-->
	<div class="gonggao wid270_b mar_t10">
	  <dl>
	    <dt>
	      <p class="right mar_t10 mar_r20"><a href="NewsList.aspx?tid=25"><img src="../images/fuwu/more.jpg" width="33" height="5" /></a></p>
        </dt>
	    <dd>
        <marquee direction="up" scrollamount="3" onmouseover="this.stop()" onmouseout="this.start()"  height="170" width="240px">
	        <ul>
	           <asp:Repeater ID="rptTZGG" runat="server">
                     <ItemTemplate>
                      <li><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# Eval("N_Title") %></a><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span></li>
                     </ItemTemplate>
               </asp:Repeater>
          </ul>
          </marquee>
        </dd>
      </dl>
    </div>
	<!--֪ͨ���� end-->
        <!--�������� begin-->
  <div class="guanzhu wid270_b mar_t10">
        	<dl>
            	<dt><p class="right mar_t10 mar_r20"><a href="ServiceRank.aspx"><img src="../images/fuwu/more.jpg" width="33" height="5" /></a></p></dt>
            	<dd>
            	  <ul>
            	  <%
                      DataTable dtService = DBHelper.GetDataSet("select top 10 * from T_ServiceInfo where S_QuarterRank<=0 order by S_QuarterRank asc");
                      if (dtService != null) {
                          for (int i = 0; i < dtService.Rows.Count; i++)
                          {
                              string strServiceId = dtService.Rows[i]["S_ID"].ToString();
                              string strServiceName = dtService.Rows[i]["S_Name"].ToString();
                              string strStar = dtService.Rows[i]["S_Star"].ToString();
                              string strCity = dtService.Rows[i]["S_City"].ToString();
                              string strIco = "";
                              if (strStar == "������") {
                                  strIco = "<img src=\"../images/fuwu/5star.jpg\" width=\"69\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "�����"){
                                  strIco = "<img src=\"../images/fuwu/4star.jpg\" width=\"55\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "����"){
                                  strIco = "<img src=\"../images/fuwu/3star.jpg\" width=\"41\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "���"){
                                  strIco = "<img src=\"../images/fuwu/2star.jpg\" width=\"28\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "��"){
                                  strIco = "<img src=\"../images/fuwu/1star.jpg\" width=\"13\" height=\"13\" align=\"absmiddle\" alt=\"һ�Ǽ�������\">";
                              }
                              else if (strStar == "����ͣ����")
                              {
                                  strIco = "<img src=\"../images/fuwu/parking.jpg\" width=\"55\" height=\"13\" align=\"absmiddle\" alt=\"����ͣ����\">";
                              }
                              %>
                  <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=strServiceId %>" target="_blank"><%=strServiceName %></a><sapn><%=strIco %></sapn></li>
                             <%
                          }
                      }
                  %>
                  </ul>
            	</dd>                
            </dl>
    </div>
        <!--���չ�ע end-->
        
        </div>
        <div style="width:700px; overflow:hidden;">
       <!--����begin-->
       <div id="new" class="mar_t10">
         <dl> 
         <dt><span class="right mar_t15 mar_r20"><a href="NewsList.aspx?tid=26"><img src="../images/fuwu/more.jpg" width="33" height="5" alt="��վ����" /></a></span></dt>
         <dd>
           <ul>
             <asp:Repeater ID="rptServiceNews" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),22) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
           </ul>        
         <div style="width:287px; height:218px; overflow:hidden;">
         	 <%
            //��վͼƬ����
           System.Data.DataTable dt_PicNews = NewsInfoService.Get_TopAnyPicNews(26,5);
           string strPics = "";
           string strLinks = "";
           string strTexts = "";
           if (dt_PicNews != null)
           {
               for (int i = 0; i < dt_PicNews.Rows.Count; i++)
               {
                   string strNID = dt_PicNews.Rows[i]["N_ID"].ToString();
                   string strPic = "../newsimages/" + dt_PicNews.Rows[i]["N_ImgView"].ToString();
                   string strText = CommonFunction.SubString(dt_PicNews.Rows[i]["N_Title"].ToString(), 22);
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
       var focus_width=287;
       var focus_height=198;
       var text_height=20;
       var swf_height = focus_height+text_height;
       var pics= '<%=strPics %>';
       var links= '<%=strLinks %>';
       var texts= '<%=strTexts %>';
       document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="portal/inc/flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#cccccc">');document.write('<param name="menu" value="false"><param name=wmode value="opaque">');document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');document.write('<embed src="portal/inc/flash/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#cccccc" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');document.write('</object>');
       </script>
         </div>
               </dd>
             </dl>
           </div>
       <!--���� end-->
       <div class="clear"></div>   
   <!--������վ begin-->
   <div id="gaosu" class="mar_t10">
   		<dl>
        	<dt><p><a href="AllServiceList.aspx" style="color:#000; font-weight:normal; float:right; border-right:none;">���� >></a><a href="AllServiceList.aspx">ȫ��������</a><a href="SelectServiceByHighWay.aspx">�����ٹ�·</a><a href="SelectServiceByCity.aspx">������</a><a href="SelectServiceByStar.aspx" style="border-right:none;">���Ǽ�����</a></p>
		  </dt>
            <dd>           	
            <ul>
   				<asp:Repeater ID="rptServices" runat="server">
                <ItemTemplate>
                  <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%# Eval("S_ID") %>" target="_blank"><%# Eval("S_Name") %></a></li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
                    <div class="clear"></div>
            </dd>
        </dl>
   </div>
   <!--������վ end-->
   </div>
   <div class="clear"></div>
       <div class="right">
       <dl id="iso" class="mar_t10">
       		<dt><p class="right mar_t15 mar_r20"><a href="NewsList.aspx?tid=24"><img src="../images/fuwu/more.jpg" width="33" height="5" alt="ISO���ʱ�׼����֤" /></a></p></dt>
       		<dd>
            	 <ul>
                   <asp:Repeater ID="rptISO" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),15) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                 </ul>
            </dd>
       </dl>
       <!--��ҵ���� begin-->
    <div class="hybk wid270_b mar_t10">
       		<dl>
            	<dt><p class="right mar_t15 mar_r20"><a href="NewsPaperList.aspx"><img src="../images/fuwu/more.jpg" width="33" height="5" /></a></p></dt>
                <dd>
                  <ul>
                      <asp:Repeater ID="rptNewsPaper" runat="server">
                      <ItemTemplate>
                      <li><a href='ViewNewsPaper.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><img src='../newspaper/<%# Eval("N_AImgView") %>' width="110" height="130" alt='<%# Eval("N_Title") %>' /></a><br /><a href='ViewNewsPaper.aspx?nid=<%# Eval("N_ID") %>' target="_blank"  title='<%# Eval("N_Title") %>'><%# Eval("N_Title") %></a><p>��������:<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString()) %></p></li>
                      </ItemTemplate>
                      </asp:Repeater>
                  </ul>
                  <div class="clear"></div>
                </dd>
            </dl>
       </div>
       <!--��վ�Ļ� end-->
       
       
  	 </div>
   <div class="div2">
       <div class="mar_t10">
           <!--���齻�� begin-->           
           <div class="study right">
              <dl>
                    <dt><p><a href="NewsList.aspx?tid=21"><img src="../images/fuwu/more.jpg" width="33" height="5" align="absmiddle" alt="���齻��" /></a></p></dt>
                    <dd>                       
                        <ul>                           
                           <asp:Repeater ID="rptJYJL" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
           </div>
           <!--���齻�� end-->
           <!--��ҵ���� begin-->
           <div class="guiding">
             <dl>
               <dt>
                 <p><a href="#"><img src="../images/fuwu/more.jpg" width="33" height="5" align="absmiddle" alt="�����ƶ�" /></a></p>
               </dt>
               <dd>
                 <!--��ҵ���� begin-->
                 <ul>
                     <asp:Repeater ID="rptHYGZ" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='#' title='<%#Eval("N_Title") %>' ><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                 </ul>                 
               </dd>
             </dl><!--��ҵ���� end-->
           </div>
           <!--���� end-->
         <div class="clear"></div>
       </div>
       <div class="mar_t10">
       		<div class="wenhua right">
       		<dl>
                <dt><p><a href="NewsList.aspx?tid=27"><img src="../images/fuwu/more.jpg" width="33" height="5" align="absmiddle" alt="��վ�Ļ�" /></a></p></dt>
                <dd>                       
                    <ul>
                    	<asp:Repeater ID="rptYZWH" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                    </ul>
                </dd>
            </dl>
         </div>
            <div class="download">
       		<dl>
                <dt>
                  <p><a href="DownloadList.aspx"><img src="../images/fuwu/more.jpg" width="33" height="5" align="absmiddle" alt="��������" /></a></p></dt>
                <dd>                       
                    <ul>
                        <asp:Repeater ID="rptDownLoad" runat="server">
                     <ItemTemplate>
                      <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("FD_CreateDate").ToString()) %>]</span><a href='../DownLoad/<%# Eval("FD_Path") %>' title='<%#Eval("FD_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("FD_Title").ToString(),20) %></a></li>
                     </ItemTemplate>
                     </asp:Repeater>
                    </ul>
                </dd>
            </dl>
            </div>
       </div>
     
        <div id="fuwu" class="mar_t10">
                <div class="fuwu_nav">
                    <ul>
                        <li><a href="NewsList.aspx?tid=130" class="fuwu2" id="yzfw11" onmouseover="TabMove2(1,1,5)">��ɫ������</a></li>
                        <li><a href="NewsList.aspx?tid=131" class="fuwu1" id="yzfw12" onmouseover="TabMove2(1,2,5)">��ͼ���ķ�</a></li>
                        <li><a href="NewsList.aspx?tid=132" class="fuwu1" id="yzfw13" onmouseover="TabMove2(1,3,5)">��Ʒ������·</a></li>
                        <li><a href="NewsList.aspx?tid=133" class="fuwu1" id="yzfw14" onmouseover="TabMove2(1,4,5)">��ס����</a></li>
                        <li><a href="NewsList.aspx?tid=134" class="fuwu1" id="yzfw15" onmouseover="TabMove2(1,5,5)">�ŵ��ŷ�</a></li>
                    </ul>
                    <div class="clear"></div>
                </div>
                <div id="contents11">
                    <ul>
                        <asp:Repeater ID="rptTSFWQ" runat="server">
                        <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul> 
                  <div class="clear"></div>
             	</div> 
                
  				<div id="contents12" style="display:none;">
              		<ul>
                        <asp:Repeater ID="rptKTZSF" runat="server">
                        <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>  
                    <div class="clear"></div>      	
                </div>
                <div id="contents13" style="display:none;">
                    <ul>
                       <asp:Repeater ID="rptJPLYXL" runat="server">
                        <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear"></div>        	
                </div>
                <div id="contents14" style="display:none;">
                    <ul>
                        <asp:Repeater ID="rptCZXY" runat="server">
                        <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>  
                    <div class="clear"></div>      	
                </div>
                <div id="contents15" style="display:none;">
                    <ul>
                       <asp:Repeater ID="rptGDYF" runat="server">
                        <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%#Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),20) %></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul> 
                    <div class="clear"></div>       	
                </div>        
        </div>
           
   </div>
 </div>
    <!--ͨ�õײ�-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:50px; overflow:hidden;"></iframe></div>
      
    </form>
</body>
</html>
