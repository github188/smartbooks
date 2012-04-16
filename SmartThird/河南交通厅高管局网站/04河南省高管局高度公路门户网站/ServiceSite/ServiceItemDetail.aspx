<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ServiceItemDetail.aspx.cs" Inherits="ServiceItemDetail" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main">
	<div class="daohang mar_t10">您的位置：<a href="index.aspx">首页</a> >> <a href='ServiceItemList.aspx?mid=<%=dt.Rows[0]["M_ParentID"] %>'><%=ServiceModelService.Get_ServiceItemName(Convert.ToInt32(dt.Rows[0]["M_ParentID"])) %></a> </div>
    <p class="page_name"><%=dt.Rows[0]["I_Title"] %></p>
    <p class="page_date">信息类别:<%=dt.Rows[0]["M_Name"] %>&nbsp;&nbsp; 发布时间:<%=dt.Rows[0]["I_Time"] %> </p>
    <div class="page_con">
    	<%=dt.Rows[0]["I_Content"] %>
    </div>
    <div class="page_bottom"><a href="javascript:window.print();">【打印此文】</a><a href="javascript:window.close();">【关闭窗口】 </a>
</div>
</div>
</asp:Content>

