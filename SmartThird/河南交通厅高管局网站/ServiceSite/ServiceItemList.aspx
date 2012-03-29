<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ServiceItemList.aspx.cs" Inherits="ServiceItemList" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    	<dl id="pager">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务内容</p><%= ViewState["itemName"]%></dt>
        	<dd>
        	<div class="page_bg">
        	<ul class="page_newlist">
                <asp:Repeater ID="rptServiceItem" runat="server">
                <ItemTemplate>
                  <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><label>[<%# Eval("M_Name") %>]</label><a href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' title='<%# Eval("I_Title") %>'  target="_blank"><%# PubClass.Tool.SubString(Eval("I_Title").ToString(),45) %></a></li>
                  
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
    <dl class="services">
    	<dt>服务内容</dt><dd><ul>
                
            	<li><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/service1.jpg" CommandName="serviceitem" CommandArgument="1" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li>
            	<li><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/service2.jpg" CommandName="serviceitem" CommandArgument="2" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li>
            	<li><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="images/service4.jpg" CommandName="serviceitem" CommandArgument="4" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li>
            	<li><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="images/service3.jpg" CommandName="serviceitem" CommandArgument="3" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li>
            	<li><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="images/service5.jpg" CommandName="serviceitem" CommandArgument="5" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li>
            	<li><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="images/service6.jpg" CommandName="serviceitem" CommandArgument="6" Width="190" Height="40" OnCommand="ServiceItem_Command" /></li></ul>        
         </dd>
        <dd class="service_b"></dd>
    </dl>
    <dl id="jiben" style="margin-top:5px;">
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
  </div>
    <div class="clear"></div>
</div>
</asp:Content>

