<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainTenance_index.aspx.cs" Inherits="maintenance_MainTenance_index" %>
<%@ Import Namespace="PubClass" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>��������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/maintenance.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/prototype.js"></script>
<script type="text/javascript" src="../js/scriptaculous.js?load=effects,builder"></script>
<script type="text/javascript" src="../js/lightbox.js"></script>
<link rel="stylesheet" href="../css/lightbox.css" type="text/css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <!--ͨ��ͷ��-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonTop_980.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:980px; height:287px; overflow:hidden;"></iframe></div>
    
        <!--����-->
        <div id="main">
            <div class="right wid270"> 
	            <!--����ָ��-->
                <dl id="bszn">
                    <dt><p class="more"><a href="NewsList.aspx?tid=31">����>></a></p>����ָ��</dt>
                    <dd>
        	            <ul>
            	         <asp:Repeater ID="rptBSZN" runat="server">
                             <ItemTemplate>
                               <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 14)%></a></li>                             
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <!--·�桢����ϵͳ���-->
                <div class="mar_t10"><a href="http://main.hngsgl.info" target="_blank"><img alt="" src="../images/yh/qiaoliang_link.jpg" width="269" height="109" /></a></div>
                <div class="mar_t10"><a href="http://hnyh.hncd.cn/hngs" target="_blank"><img alt="" src="../images/yh/road_link.jpg" width="270" height="109" /></a></div>
                <!--�����ƶ�-->
                <dl id="guizhang" class="mar_t10">
                    <dt><p class="more"><a href="NewsList.aspx?tid=33">����>></a></p>�����ƶ�</dt>
                    <dd>
        	            <ul>
            	         <asp:Repeater ID="rptGZZD" runat="server">
                             <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 14)%></a></li>                             
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <!--��������-->
                <dl id="wenming" class="mar_t10">
                    <dt><p class="more"><a href="NewsList.aspx?tid=34">����>></a></p>��������</dt>
                    <dd>
        	            <ul>
            	         <asp:Repeater ID="rptWMCJ" runat="server">
                             <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 14)%></a></li>                         
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                    </dd>
                </dl>        
            </div>
            <div class="wid700">
	            <!--����-->
                <dl id="gg" class="left">
                    <dt><p class="more"><a href="NewsList.aspx?tid=41">����>></a></p></dt>
                    <dd style="margin:10px auto;">
                     <marquee direction="up" scrollamount="3" onmouseover="this.stop()" onmouseout="this.start()" style="width:220px; margin:0 auto; height:153px; overflow:hidden;">
        	            <ul>
                             <asp:Repeater ID="rptTZGG" runat="server">
                                 <ItemTemplate>
                                    <li>
                                        <a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%#Eval("N_Title") %></a>
                                        <span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span></li>                           
                                 </ItemTemplate>
                             </asp:Repeater>
                        </ul>
                        </marquee>
                    </dd>
                </dl>
	            <!--������̬-->
                <dl id="dongtai" class="left mar_l10">
                    <dt><p class="more"><a href="NewsList.aspx?tid=30">����>></a></p></dt>
                    <dd>
        	            <ul>
            	         <asp:Repeater ID="rptYHDT" runat="server">
                             <ItemTemplate>
                               <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 28)%></a></li>                              
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                    </dd>
                </dl>  
                <div class="clear"></div>  	
                <!--��������-->
                <dl id="download" class="left mar_t10">
                    <dt><p class="more"><a href="DownloadList.aspx">����>></a></p></dt>
                    <dd>
        	            <ul>
                            <asp:Repeater ID="rptDownLoad" runat="server">
                                <ItemTemplate>
                                   <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("FD_CreateDate").ToString())%>]</span><a href='../DownLoad/<%#Eval("FD_Path") %>' title='<%# Eval("FD_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("FD_Title").ToString(), 22)%></a></li>  
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
	            <!--������Ѷ-->
                <dl id="jiceng" class="left mar_t10 mar_l10">
                    <dt><p class="more"><a href="NewsList.aspx?tid=32">����>></a></p></dt>
                    <dd>
        	            <ul>
            	         <asp:Repeater ID="rptJCZX" runat="server">
                             <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                           
                             </ItemTemplate>
                         </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <div class="clear"></div>
                <!--������������Ӧ��-->
                <div class="guanli mar_t10">
    	            <div style="width:698px; overflow:hidden;"><img src="../images/yh/guanli_t.jpg" width="698" height="28" /></div>
                       <!--�¼������²��ϡ����豸-->
                        <dl class="guanli_type left">
                            <dt><p class="more"><a href="NewsList.aspx?tid=36">����>></a></p>�����¼������²��ϡ����豸</dt>
                            <dd>
                	            <ul>
            	                 <asp:Repeater ID="rptYHXJS" runat="server">
                                     <ItemTemplate>
                                       <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                              
                                     </ItemTemplate>
                                 </asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                        <!--��������-->
                        <dl class="guanli_type left">
                            <dt><p class="more"><a href="NewsList.aspx?tid=37">����>></a></p>��������</dt>
                            <dd>
                	            <ul>
            	                 <asp:Repeater ID="rptYHGL" runat="server">
                                     <ItemTemplate>
                                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                              
                                     </ItemTemplate>
                                 </asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                        <div class="clear"></div>
                        <!--ʩ������-->
                        <dl class="guanli_type left">
                            <dt><p class="more"><a href="NewsList.aspx?tid=38">����>></a></p>ʩ������</dt>
                            <dd>
                	            <ul>
            	                 <asp:Repeater ID="rptSGGG" runat="server">
                                     <ItemTemplate>
                                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                            
                                     </ItemTemplate>
                                 </asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                        <!--��·����״������-->
                        <dl class="guanli_type left">
                            <dt><p class="more"><a href="NewsList.aspx?tid=39">����>></a></p>��·����״������</dt>
                            <dd>
                	            <ul>
            	                 <asp:Repeater ID="rptJSPD" runat="server">
                                     <ItemTemplate>
                                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                             
                                     </ItemTemplate>
                                 </asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                     <div class="clear"></div>  
              </div>
                <!--��������-->
                <dl id="jiaoliu"  class="mar_t10">
    	            <dt><p class="more2"><a href="NewsList.aspx?tid=35" style="color:#FFF;">����>></a></p></dt>
                    <dd style="height:143px;">
        	            <div class="jiaoliu_con">
            	            <ul>
        	                 <asp:Repeater ID="rptYHJL" runat="server">
                                 <ItemTemplate>
                                    <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a href='NewsInfo.aspx?nid=<%#Eval("N_ID") %>' title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 20)%></a></li>                                
                                 </ItemTemplate>
                             </asp:Repeater>
                            </ul>
                            <div class="clear"></div>
                        </div>
                    </dd>
                    <dd class="jiaoliu_b"></dd>
                </dl>            
            </div>	
           <div class="clear"></div>
        </div>

        <!--������Ӱ-->
        <div class="photos mar_t10">
            <div class="photos_b">
                <div class="photos_t">
                    <div class="photos_r">
                      <div class="photos_l">
                        <div id="demo" class="gundong" align="center">
                          <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              <td valign="top" id="marquePic1" style="width: 1px"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                                <tr>                                  
                                 <asp:Repeater ID="rptYHMien" runat="server">
                                     <ItemTemplate>
                                         <td><a href='../newsimages/<%# Eval("N_ImgPath") %>' rel="lightbox[YHMienImg]" title='<%# Eval("N_Title") %>'><img src='../newsimages/<%# Eval("N_ImgView") %>' width="132" height="102" alt='<%# Eval("N_Title") %>' /></a>
                                        <p><a href='../newsimages/<%# Eval("N_ImgPath") %>' rel="lightbox[YHMienText]" title='<%# Eval("N_Title") %>'><%#PubClass.Tool.SubString(Eval("N_Title").ToString(),8) %>�ԶԶ�</a></p>
                                         </td>
                                     </ItemTemplate>
                                 </asp:Repeater>
                                </tr>
                              </table></td>
                              <td id="marquePic2" valign="top" style="width: 1px"></td>
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
        </div>
        <!--ͨ�õײ�-->
 <div style=" width:980px; margin:0 auto;"><iframe src="../CommonButtom_980.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:980px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
