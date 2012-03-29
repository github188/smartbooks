<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--main begin-->
	<div id="mainbody">
    	<!--收费站简介&最新动态-->
    	<dl id="news" class="right"> 
        	<dt><p style="float:right; margin-top:10px; margin-right:10px;">
        	<a href="NewsList.aspx?tid=1"><img src="images/more.jpg" width="40" height="11" /></a></p></dt>
            <dd>
            <div style="width:550px; margin:0 auto; overflow:hidden;">
				<ul class="newlist">
                 <asp:Repeater ID="rptZXDT" runat="server">
                     <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot; <%# PubClass.Tool.SubString(Eval("N_Title").ToString(),23) %></a></li>
                     </ItemTemplate>
                    </asp:Repeater>
               </ul>
               <!--图片新闻-->
               <div style="width:180px; height:140px; overflow:hidden;">
                  <%
                      DataTable dt_PicNews = NewsInfoService.Get_Top5ImgNewsViewList(((TollStation)Session["stationinfo"]).TS_ID, 1);
                       string strPics = "";
                       string strLinks = "";
                       string strTexts = "";
                       if (dt_PicNews != null)
                       {
                           for (int i = 0; i < dt_PicNews.Rows.Count; i++)
                           {
                               string strNID = dt_PicNews.Rows[i]["N_ID"].ToString();
                               string strPic = "NewsImg/" + dt_PicNews.Rows[i]["N_ImgView"].ToString();
                               string strText = PubClass.Tool.SubString(dt_PicNews.Rows[i]["N_Title"].ToString(), 13);
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
             var focus_width=180;
             var focus_height=120;
             var text_height=20;
             var swf_height = focus_height+text_height;
             var swf_height = focus_height+text_height;
               var pics= '<%=strPics %>';
               var links= '<%=strLinks %>';
               var texts= '<%=strTexts %>';
               document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="portal/inc/flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#cccccc">');document.write('<param name="menu" value="false"><param name=wmode value="opaque">');document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');document.write('<embed src="portal/inc/flash/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#cccccc" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');document.write('</object>');
            </script>
           </div>
           </div>
            </dd>
            <dd style="height:150px; overflow:hidden;">
            <div style="width:550px; margin:0 auto; overflow:hidden;">
            <div class="news_name mar_t10"><p style="float:right; margin-top:7px;"><a href="NewsList.aspx?tid=2"><img src="images/more.jpg" width="40" height="11" /></a></p></div>
            <ul class="gonggao" style="margin-top:5px;">
                  <asp:Repeater ID="rptTZGG" runat="server">
                     <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot; <%# PubClass.Tool.SubString(Eval("N_Title").ToString(),40) %></a></li>
                     </ItemTemplate>
                    </asp:Repeater>
               </ul>
               </div>
            </dd>
            <dd class="wid580_b"></dd>
        </dl>
        <!--公告-->
    	<dl id="gg">
        	<dt><p class="right more"><a href="StationInfo.aspx"><img src="images/more.jpg" width="40" height="11" /></a></p></dt>
        <dd>
            	<div style=" width:206px; margin:0 auto; height:290px; overflow:hidden;">
            	<p class="jianjie_pic">
            	<%
                    TollStation station = (TollStation)Session["stationinfo"];   
            	 %>
            	 <a href="StationPhoto/<%=station.TS_MainPhoto %>" rel="lightbox[photo]" title="<%=station.TS_Name %>形象照片">
            	<img src='StationPhoto/<%=station.TS_ViewPhoto %>' width="150" height="120" alt='<%=station.TS_Name %>形象照片' />
            	</a>
            	</p>
            	<%=PubClass.Tool.SubString(station.TS_Remark,178) %> <a href="StationInfo.aspx" class="orange" title="<%=station.TS_Remark %>">[点击详情]</a>
                </div>
          </dd>
            <dd class="gg_b"></dd>
        </dl> 
        <div class="clear"></div>
        <!--荣誉展示-->   
        <div id="rongyu" class="mar_t10">
        	<div id="demo" class="gundong">
            <table border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td valign="top" id="marquePic1"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                  <tr>
                      <asp:Repeater ID="rptRongYu" runat="server">
                       <ItemTemplate>
                           <td>
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu1]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><img src='NewsImg/<%# Eval("N_ImgView") %>'  alt='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>' /></a><br />
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu2]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),13) %></a>
                            </td>
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
        <div class="mar_t10">
      	  <!--站区文化-->
        <dl id="wenhua" class="right">
        	<dt><p class="right more"><a href="NewsList.aspx?tid=5"><img src="images/more.jpg" width="40" height="11" /></a></p>站区文化</dt>
            <dd>
            	<ul>
                    <asp:Repeater ID="rptZQWH" runat="server">
                     <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank">&middot; <%# PubClass.Tool.SubString(Eval("N_Title").ToString(),23) %></a></li>
                     </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </dd>
        </dl>
         <!--服务之星-->
        <dl id="star">
        	<dt><p class="right more"><a href="StarsList.aspx?tid=4"><img src="images/more.jpg" width="40" height="11" /></a></p>服务之星</dt>
            <dd>
           	  <div class="star_con">
                     <asp:Repeater ID="rptStar" runat="server">
                       <ItemTemplate>
                           <div class="right star_content">
                             <h1><a href='StarInfo.aspx?nid=<%# Eval("N_ID") %>'><%# Eval("N_From") %></a></h1><%#PubClass.Tool.SubString(Eval("N_Content").ToString().Substring(0,Eval("N_Content").ToString().IndexOf("<$$>")),93)%><a href='StarInfo.aspx?nid=<%# Eval("N_ID") %>'>[点击详情]</a>
                           </div>
                        <div class="star_pic">
                         <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[star]" title='服务之星：<%# Eval("N_From") %>'><img src='NewsImg/<%# Eval("N_ImgView") %>'  width="100" height="120"  alt='服务之星：<%# Eval("N_Title") %>' /></a>
                        </div>
                       </ItemTemplate>
                     </asp:Repeater>
                </div>
            </dd>
        </dl>
        </div>   
        <!--收费站风采-->
        <dl id="fengcai" class=" mar_t10">
        	<dt><p class="right more"><a href="FengCaiList.aspx?tid=6"><img src="images/more.jpg" width="40" height="11" /></a></p>
       	    收费站风采</dt>
            <dd>
            	<div id="demo2" class="gundong2">
            <table border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td valign="top" id="marquePic11"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                  <tr>
                   <asp:Repeater ID="rptFengCai" runat="server">
                       <ItemTemplate>
                           <td>
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[fengcai1]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><img src='NewsImg/<%# Eval("N_ImgView") %>'  alt='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>' /></a><br />
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[fengcai2]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),13) %></a>
                            </td>
                       </ItemTemplate>
                      </asp:Repeater>
                  </tr>
                </table></td>
                <td id="marquePic22" valign="top"></td>
              </tr>
            </table>
          </div>
          <script type="text/javascript"> 
                    var speed=50 
                    marquePic22.innerHTML=marquePic11.innerHTML 
                    function Marquee(){ 
                    if(demo2.scrollLeft>=marquePic11.scrollWidth){ 
                    demo2.scrollLeft=0 
                    }else{ 
                    demo2.scrollLeft++ 
                    } 
                    } 
                    var MyMar=setInterval(Marquee,speed) 
                    demo2.onmouseover=function() {clearInterval(MyMar)} 
                    demo2.onmouseout=function() {MyMar=setInterval(Marquee,speed)} 
                </script>
            
            </dd>
            <dd class="fengcai_b"></dd>
        </dl>
    </div>
    <!--main end-->

</asp:Content>

