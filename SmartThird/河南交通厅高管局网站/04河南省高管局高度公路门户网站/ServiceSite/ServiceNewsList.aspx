<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ServiceNewsList.aspx.cs" Inherits="ServiceNewsList" Title="" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    	<dl id="pager">
        	<dt><p class="weizhi">您的位置：<a href="#">首页</a> >> <a href="#">驿站新闻</a></p>驿站新闻</dt>
        	<dd>
        	<div class="page_bg">
        	<ul class="page_newlist">
                    <asp:Repeater ID="rptNewsList" runat="server">
                    <ItemTemplate>
                       <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a href='NewsDetailInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='Eval("N_Title")'><%# PubClass.Tool.SubString(CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"(",")"), 45)%></a></li>
                    </ItemTemplate>
                    </asp:Repeater>  
                </ul>
                <div class="pages">
                 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
                </div>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	
    </div>
  <div>   	  
    
    <dl id="jiben">
            <dt><p class="more37"><a href="ServiceBasicInfo.aspx">更多 >></a></p>基本信息</dt><dd><div class="wid200">
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
    <div class="diaocha">
          <div class="diaocha_con">
            <p class="right"><a href="ServiceVote.aspx">参与投票</a></p>
       <a href="SurveyResult.aspx" target="_blank">投票结果</a></div>
      </div>
  </div>
    <div class="clear"></div>
</div>
</asp:Content>



