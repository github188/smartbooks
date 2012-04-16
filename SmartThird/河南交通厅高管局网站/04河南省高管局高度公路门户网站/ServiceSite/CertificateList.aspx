<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="CertificateList.aspx.cs" Inherits="CertificateList" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    	<div id="serviceinfodiv1" style="display:block">
    	     <dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 认证证书</p>ISO认证</dt>
            <dd>
                <div class="jianjie_con">
                    <asp:Repeater ID="rptISO" runat="server">
                    <ItemTemplate>
                      <p class="jianjie_pic" style="text-align:center"><img src='CertificateImg/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"{","}") %>' /><br /><%# Eval("N_Content") %></p>
                    </ItemTemplate>
                    </asp:Repeater>
                </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	</div>
    	
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

