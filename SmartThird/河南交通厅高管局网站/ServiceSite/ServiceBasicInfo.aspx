<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ServiceBasicInfo.aspx.cs" Inherits="ServiceBasicInfo" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
   function DisplaySelectedDiv(p){
      for(var i=1;i<=9;i++){
         if(p==i){
         document.getElementById("serviceinfodiv"+p).style.display="block";
         }else{
         document.getElementById("serviceinfodiv"+i).style.display="none";
         }
      }
   }
</script>
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    	<div id="serviceinfodiv1" style="display:block">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>服务区简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_Remark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv2" style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>餐厅简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_CYImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_CYRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv3"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>超市简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_CSImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_CSRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv4"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>客房简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_ZSImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_ZSRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv5"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>加油站简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_JYZImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_JYZRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv6"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>汽修简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_QXImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_QXRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv7"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>停车场简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_TCSImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_TCSRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv8"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>卫生间简介</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_WSJImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_WSJRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	<div id="serviceinfodiv9"  style="display:none">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区简介</p>服务队伍</dt>
            <dd>
                <div class="jianjie_con">
                	<p class="jianjie_pic"><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_FWDWImage %>' /></p><%=((ServiceInfo)Session["serviceinfo"]).S_FWDWRemark %>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
    	
    	
    	
    	
    </div>
  <div>   	  
    <dl class="services">
    	<dt>基本简介</dt>
        <dd> 
        	<ul>
            	<li><a href="javascript:DisplaySelectedDiv(1)"><img src="images/jianjie1.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(2)"><img src="images/jianjie2.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(3)"><img src="images/jianjie3.jpg" width="190" height="40" /></a></li>
                  <li><a href="javascript:DisplaySelectedDiv(4)"><img src="images/jianjie5.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(5)"><img src="images/jianjie4.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(6)"><img src="images/jianjie6.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(7)"><img src="images/jianjie7.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(8)"><img src="images/jianjie8.jpg" width="190" height="40" /></a></li>
                <li><a href="javascript:DisplaySelectedDiv(9)"><img src="images/jianjie9.jpg" width="190" height="40" /></a></li>
            </ul>        
         </dd>
        <dd class="service_b"></dd>
    </dl>
    <dl id="jiben" style="margin-top:5px;">
            <dt><p class="more37"></p>基本信息</dt><dd><div class="wid200">
                <p class="align fon16"><%=((ServiceInfo)Session["serviceinfo"]).S_Name %></p>
                <p class="align" style=" padding:7px 0;">
                <%
                    if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★★") { 
                    %>
                     <img src="images/star.jpg"  alt="五星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★"){
                    %>
                     <img src="images/4star.jpg"  alt="四星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★"){
                    %>
                     <img src="images/3star.jpg"  alt="三星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★"){
                    %>
                     <img src="images/2star.jpg"  alt="二星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★"){
                    %>
                     <img src="images/1star.jpg"  alt="一星级服务区" />
                    <%
                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "优秀停车区")
                    {
                    %>
                     <img src="images/parking.jpg" width="138" height="26" alt="优秀停车区" />
                    <%
                    }
                     %>
               
                </p>
                位置：<%=PubClass.DBHelper.GetStringScalar("select H_Name from T_HighWayInfo where H_ID=" + ((ServiceInfo)Session["serviceinfo"]).S_HID)%>，桩号：<%=((ServiceInfo)Session["serviceinfo"]).S_Stake %><br />
                服务电话：<%=((ServiceInfo)Session["serviceinfo"]).S_Phone %><br />
             <p class="service_pic">
               <a href='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' rel="lightbox[serviceimg]" title='<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片'><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' width="96" height="72" alt="<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片" /></a></p>
               <span title="<%=((ServiceInfo)Session["serviceinfo"]).S_Remark %>"> <%=PubClass.Tool.SubString(((ServiceInfo)Session["serviceinfo"]).S_Remark, 64)%> </span></div>
            </dd>
            <dd class="jiben_b"></dd>
        </dl>
  </div>
    <div class="clear"></div>
</div>
</asp:Content>

