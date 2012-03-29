<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="StationInfo.aspx.cs" Inherits="StationInfo" Title="" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <!--main begin-->
	<div id="mainbody">
    <div class="daohang">您当前的位置：<a href="index.aspx">首页</a> >> 收费站简介</div>
<div id="jianjie_page" style="width:800px; margin:10px auto; overflow:hidden;">
                	 <p class="name2">收费站基本信息</p>
                 <%
                     TollStation station = (TollStation)Session["stationinfo"];
                 %>
       			 <table width="700" border="0" cellspacing="1" cellpadding="1">
                    <tr>
                      <td colspan="4" align="center"><span class="name"><%=station.TS_Name %></span></td>
                    </tr>
                    <tr>
                      <th width="105">桩号</th>
                      <td width="250"><%=station.TS_Stake %></td>
                      <th width="105">所属高速</th>
                      <td width="250"><%=station.TS_Highway.H_Name %></td>
                    </tr>
                    <tr>
                      <th>里程数</th>
                      <td><%=station.TS_StakeNum %></td>
                      <th>所属地区</th>
                      <td><%=station.TS_City.CI_Name %></td>
                    </tr>
                    <tr>
                      <th>联系电话</th>
                      <td><%=station.TS_Phone %></td>
                      <th>负责人</th>
                      <td><%=station.TS_Manager %></td>
                    </tr>
                    <tr>
                      <th>车道</th>
                      <td><%=station.TS_LaneNum %></td>
                      <th>出口道路及城镇</th>
                      <td><%=station.TS_ExitToRoad %></td>
                    </tr>
                    <tr>
                      <th>荣誉称号</th>
                      <td colspan="3"><%=station.TS_Honour %></td>
                    </tr>
                  </table>
 <p class="name2">收费站相关介绍</p>   
   			  <div class="name_pic">
   			    <div class="name_pic">
   			    <a href="StationPhoto/<%=station.TS_MainPhoto %>" rel="lightbox[photo]" title="<%=station.TS_Name %>形象照片">
   			    <img src="StationPhoto/<%=station.TS_ViewPhoto %>" width="150" height="120" alt='<%=station.TS_Name %>形象照片' /></a>
   			    </div>
		     </div><%=station.TS_Remark %> 
        			</div>
    </div>
    <!--main end-->


</asp:Content>

