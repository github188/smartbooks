<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="NewsDetailInfo.aspx.cs" Inherits="NewsDetailInfo"  %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main">

    <%
        if (Convert.ToInt32(dt.Rows[0]["TypeID"]) == 1)
        {
        %>
        <div class="daohang mar_t10">您的位置：<a href="index.aspx">首页</a> >> <a href='ServiceNewsList.aspx'><%=dt.Rows[0]["TypeName"] %></a></div>
    <p class="page_name"><%=dt.Rows[0]["N_Title"] %></p>
    <p class="page_date">信息类别:<%=dt.Rows[0]["TypeName"]%>&nbsp;&nbsp; 发布时间:<%=dt.Rows[0]["N_Time"] %> </p>
    <div class="page_con">
    	<%=dt.Rows[0]["N_Content"] %>
    </div>
        <%
        }
        else if (Convert.ToInt32(dt.Rows[0]["TypeID"]) == 6)
        {
      %>
        <div class="daohang mar_t10">您的位置：<a href="index.aspx">首页</a> >> <a href='ServiceNewsList.aspx'><%=dt.Rows[0]["TypeName"] %></a></div>
    <p class="page_name"><%=CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(),"(",")")%></p>
    <p class="page_date">信息类别:<%=dt.Rows[0]["TypeName"]%>&nbsp;&nbsp; 发布时间:<%=dt.Rows[0]["N_Time"] %> </p>
    <div class="page_con">
       <div style="text-align:center;"><img src='newsImages/<%=CommonFunction._GetMidInfo(dt.Rows[0]["N_Title"].ToString(),"{","}")%>' /></div>
    	<%=dt.Rows[0]["N_Content"] %>
    </div>
        <%
        }
        else { 
        %>
        <div class="daohang mar_t10">您的位置：<a href="index.aspx">首页</a> >> <a href='NewsList.aspx?tid=<%=dt.Rows[0]["TypeId"] %>'><%=dt.Rows[0]["TypeName"] %></a></div>
    <p class="page_name"><%=dt.Rows[0]["N_Title"].ToString() %></p>
    <p class="page_date">信息类别:<%=dt.Rows[0]["TypeName"]%>&nbsp;&nbsp; 发布时间:<%=dt.Rows[0]["N_Time"] %> </p>
    <div class="page_con">
    	<%=dt.Rows[0]["N_Content"] %>
    </div>
        <%
        }
         %>
	
    <div class="page_bottom">信息来源:[<%=dt.Rows[0]["N_Frorm"]%>]   浏览次数:<%=dt.Rows[0]["N_ViewedCount"]%> <a href="javascript:window.print()">【打印此文】</a><a href="javascript:close();">【关闭窗口】 </a>
    <% ServiceNewService.RecordViewedTimes(Convert.ToInt32(dt.Rows[0]["N_ID"])); %>
</div>
</div>
</asp:Content>

