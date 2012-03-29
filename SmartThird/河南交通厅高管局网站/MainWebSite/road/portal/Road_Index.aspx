<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Road_Index.aspx.cs" Inherits="road_Road_Index" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
        <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
        <title>路政管理-河南省交通运输厅高速公路管理局门户网站</title>
        <link href="../style/road.css" rel="stylesheet" type="text/css" />
        <link href="../css/lightbox.css" rel="stylesheet" type="text/css" />
        <script src="../js/lightbox.js" type="text/javascript" language="javascript"></script>
        <script type="text/javascript" language="javascript">
            $(document).ready(function(){
	            $("#s a").lightbox();
            });
        </script>        
    </head>
    <body>
        <form id="form1" runat="server">
             <!--通用头部-->
            <div style=" width:980px; margin:0 auto;"><iframe src="../CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:287px; overflow:hidden;"></iframe></div>
    
              <div class="main">
                 <!--右侧-->
                 <div class="right wid700">
                   <!--新闻-->
                   <dl id="news">
                     <dt>
                       <p><a href="NewsList.aspx?tid=89"><img src="../images/road/more.jpg" width="51" height="16" /></a></p>
                     </dt>
                     <dd>
                       <ul>
                         <asp:Repeater ID="Repeater_gzdt" runat="server">
                             <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 28)%></a></li>                             
                             </ItemTemplate>
                         </asp:Repeater>
                       </ul>
                       <div class="new_img">
                         <script type='text/javascript'>
                            var focus_width=240;
                            var focus_height=170;
                            var text_height=20;
                            var swf_height = focus_height+text_height;
                            var pics= "<%=Path %>";
                            var links= "<%=ActionUrl%>";
                            var texts= "<%=Intro %>";
                            document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
                            document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="portal/inc/flash/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#cccccc">');
                            document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
                            document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
                            document.write('<embed src="portal/inc/flash/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#cccccc" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
                            document.write('</object>');</script>
                         </div>
                     </dd>
                     <dd class="b"></dd>
                   </dl>
                   <!--队伍建设-->
                   <dl id="fengcai" class="mar_t10">
                     <dt>
                       <p><a href="PicList.aspx?tid=91"><img src="../images/road/more.jpg" width="51" height="16" /></a></p>
                     </dt>
                     <dd>
                       <div id="pic">
                         <div id="demo" class="gundong" align="center">
                           <table border="0" cellpadding="0" cellspacing="0">
                             <tr>
                               <td valign="top" id="marquePic1"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                                 <tr id="s">
                                    <asp:Repeater ID="Repeater_dwjs" runat="server">
                                         <ItemTemplate>
                                            <td>
                                                <a href="Page.aspx?id=<%#Eval("N_ID") %>" >
                                                    <img src='../newsimages/<%#Eval("N_ImgPath") %>' alt="<%#Eval("N_Title") %>" width="120" height="90" />
                                                </a>
                                                <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#PubClass.Tool.SubString(Eval("N_Title").ToString(),12) %></a>
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
                     </dd>
                     <dd class="b"></dd>
                   </dl>
                </div>
                 <!--左侧-->
                 <div class="wid270">
                   <dl id="gg">
                     <dt><a href="NewsList.aspx?tid=88"><img alt="公告" src="../images/road/gg_t.jpg" width="270" height="30" /></a></dt>
                     <dd>
                       <div class="gg_con">
                         <marquee direction="up" scrollamount="3" onmouseover="this.stop()" onmouseout="this.start()"  height="180px" width="230px">
				            <ul class="gglist">
                                 <asp:Repeater ID="Repeater_gg" runat="server">
                                     <ItemTemplate>
                                        <li>
                                            <a href="PublicNotice.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>">
                                                <%#Eval("N_Title")%>
                                            </a>
                                            <span>[<%#Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span></li>                           
                                     </ItemTemplate>
                                 </asp:Repeater>
                            </ul>
                         </marquee>
                       </div>
                     </dd>
                     <dd class="b"></dd>
                   </dl>
                   <!-- 路况信息-->
                   <dl id="lingdao" class="mar_t10">
                     <dt><a href="../RoadConditionList.aspx"><img alt="路况信息" src="../images/road/lingdao_t.jpg" width="270" height="34" /></a></dt>
                     <dd>
                       <ul>
                         <asp:Repeater ID="rptRoadCondition" runat="server">
                             <ItemTemplate>
                                <li><span>[<%#PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString()) %>]</span><a href="../RoadConditionDetail.aspx?nid=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>" target="_blank"><%#PubClass.Tool.SubString(Eval("N_Content").ToString(),12)%></a></li>
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                     </dd>
                     <dd class="b"></dd>
                   </dl>
                 </div>
              </div>
              <!-- 路况信息-->
            <div class="main">
              <!--右侧-->
              <div class="right wid700">
                <!--队伍管理-->
                <dl id="zhishi" class="right">
                  <dt><a href="NewsList.aspx?tid=93"><img src="../images/road/zhishi_t.jpg" width="345" height="30" /></a></dt>
                  <dd>
                    <ul>
                      <asp:Repeater ID="Repeater_dwgl" runat="server">
                         <ItemTemplate>
                            <li><span>[<%#PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#Tool.SubString(Eval("N_Title").ToString(),21)%></a></li>
                         </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                  </dd>
                  <dd class="b"></dd>
                </dl>
                <!--依法行政-->
                <dl id="fagui">
                  <dt><a href="NewsList.aspx?tid=92"><img src="../images/road/fagui_t.jpg" width="345" height="30" /></a></dt>
                  <dd>
                    <ul>
                      <asp:Repeater ID="Repeater_yfxz" runat="server">
                         <ItemTemplate>
                            <li><span>[<%#PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#Tool.SubString(Eval("N_Title").ToString(),21)%></a></li>
                         </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                  </dd>
                  <dd class="b"></dd>
                </dl>
                <div class="banner4 mar_tb10"><img src="../images/road/banner4.jpg" width="700" height="90" /></div>
                <!--精神文明-->
                <dl id="wenming" class="right">
                  <dt><a href="NewsList.aspx?tid=95"><img src="../images/road/wenming_t.jpg" width="345" height="30" /></a></dt>
                  <dd>
                    <ul>
                      <asp:Repeater ID="Repeater_jswm" runat="server">
                         <ItemTemplate>
                            <li><span>[<%#PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#Tool.SubString(Eval("N_Title").ToString(),21)%></a></li>
                         </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                  </dd>
                  <dd class="b"></dd>
                </dl>
                <!--超限治理-->
                <dl id="dangtuan">
                  <dt><a href="NewsList.aspx?tid=94"><img src="../images/road/dangtuan_t.jpg" width="345" height="30" /></a></dt>
                  <dd>
                    <ul>
                      <asp:Repeater ID="Repeater_cxzl" runat="server">
                         <ItemTemplate>
                            <li><span>[<%#PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#Tool.SubString(Eval("N_Title").ToString(),21)%></a></li>
                         </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                  </dd>
                  <dd class="b"></dd>
                </dl>
              </div>
              <!--左侧-->
              <!--路政风采-->
              <div class="wid270">
                <dl id="rongyu">
                  <dt><a href="PicList.aspx?tid=90"><img src="../images/road/rongyu_t.jpg" width="270" height="34" /></a></dt>
                  <dd>
                    <ul>                      
                      <asp:Repeater ID="Repeater_lzfc" runat="server">
                         <ItemTemplate>
                            <li>
                                <a href="Page.aspx?id=<%#Eval("N_ID") %>">
                                    <img src='../newsimages/<%#Eval("N_ImgPath") %>' alt= "<%#Eval("N_Title") %>" width="120" height="90" />
                                </a>
                                <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>"><%#PubClass.Tool.SubString(Eval("N_Title").ToString(),8)%></a>
                            </li>
                         </ItemTemplate>
                      </asp:Repeater>
                    </ul>
                  </dd>
                  <dd class="b"></dd>
                </dl>
                <div class="contact mar_t10">
                  <p class="contact_con">地址：河南省郑州市中原区陇海路<br />
                    与桐柏路交叉口凯旋门C座0814<br />
                    Q  Q：34455664456<br />
                    电话：0371-34455664<br />
                    邮箱：34455664@qq.com</p>
                </div>
              </div>
              <div class="clear"></div>
            </div>

            <!--通用底部-->
            <div style=" width:980px; margin:0 auto;"><iframe src="../CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:50px; overflow:hidden;"></iframe></div>
        </form>
    </body>
</html>
