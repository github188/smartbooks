<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index"  %>
<%@ Import Namespace="RoadEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="main">
        <%
        RoadDepart depart = (RoadDepart)Session["roadinfo"];   
	 %>
    	<dl id="jianjie" class=" left wid550">
        	<dt><p class="right mar_t10 mar_r20"><a href="DepartBasicInfo.aspx">更多>></a></p></dt>
            <dd>
                <div class="jianjie_r">
                    <div class="jianjie_l">
                    <div style="margin:10px 15px;"><p class="left bor mar_r5"><a href="RoadPhoto/<%=depart.RD_MainPhoto %>" rel="lightbox[photo]" title="<%=depart.RD_Name %>形象照片">
   			    <img src="RoadPhoto/<%=depart.RD_ViewPhoto %>" width="150" height="120" alt='<%=depart.RD_Name %>形象照片' /></a></p><%=PubClass.Tool.SubString(depart.RD_Remark,255) %><a href="DepartBasicInfo.aspx" class="f60">[点击详情]</a></div>                    	
                     </div>
                  </div>
            </dd>
        </dl>
        <dl id="contact" class="left wid240 mar_l10">
        	<dt></dt>
            <dd>
            	<div class="jianjie_r">
                	<div class="jianjie_l">
                    	 <div style="margin:10px 15px;">
                              单位负责人：<%=depart.RD_Manager %><br />
                              联系电话：<%=depart.RD_Phone %><br />
                              单位传真：<%=depart.RD_Fax %> <br />
                              电子信箱：<%=depart.RD_Email %> <br />
                              邮政编码：<%=depart.RD_PostCode %> <br />
                              地址：<%=depart.RD_Address %>
                         </div>
                    </div>
                </div>
            </dd>
        </dl>
        <div class="clear"></div>
    </div>
    <div class="main">
		<dl id="fagui" class="left">
        	<dt><p class="right mar_t15 mar_r20"><a href="NewsList.aspx?tid=2">更多>></a></p></dt>
            <dd>
            	<div class="new_r">
                	<div class="new_l">
                    	<ul>
                            <asp:Repeater ID="rptLZFG" runat="server">
                              <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),23) %></a></li>
                              </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                  </div>
                </div>
            </dd>
        </dl>
        <dl id="dongtai" class="left mar_l10">
        	<dt><p class="right mar_t15 mar_r20"><a href="NewsList.aspx?tid=1">更多>></a></p></dt>
            <dd>
            	<div class="new_r">
                	<div class="new_l">
                    <ul>
                       <asp:Repeater ID="rptGZDT" runat="server">
                              <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),23) %></a></li>
                              </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
            	</div>
            </dd>
        </dl>       
        <div class="clear"></div>
    </div>
    
    <!--路政风采-->
    <div class="main">
    <dl id="fengcai">
    	<dt><p class="right mar_t10 mar_r20"><a href="RongYuList.aspx?tid=3">更多>></a></p></dt>
        <dd>
        	<div class="fengcai_r">
            	<div class="fengcai_l">
                <div id="demo" class="gundong" align="center">
               <table border="0" cellpadding="0" cellspacing="0">
                 <tr>
                   <td valign="top" id="marquePic1"><table cellpadding="0" cellspacing="0" border="0" class="gundong2">
                     <tr>
                       <asp:Repeater ID="rptRongYu" runat="server">
                          <ItemTemplate>
                           <td>
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu1]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><img src='NewsImg/<%# Eval("N_ImgView") %>'  alt='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>' /></a><br />
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu2]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),9) %></a>
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
            </div>
        </dd>
    </dl>
    </div>

</asp:Content>

