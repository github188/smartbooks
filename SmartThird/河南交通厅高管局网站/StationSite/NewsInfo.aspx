<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="NewsInfo.aspx.cs" Inherits="NewsInfo" Title="" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!--main begin-->
	<div id="mainbody">
	    <%
            DataTable dtNews = (DataTable)ViewState["dtNews"];
	     %>
    	<div class="daohang">您当前的位置： <a href="index.aspx">首页</a> >> <a href='NewsList.aspx?tid=<%=dtNews.Rows[0]["T_ID"] %>'><%=dtNews.Rows[0]["T_Name"]%></a></div>
        <div class="pages">
        		<h1><%=dtNews.Rows[0]["N_Title"]%></h1>
                <p class="page_date">文章来源：<%=dtNews.Rows[0]["N_From"] %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布日期：<%=PubClass.Tool.Get_ShortDate(dtNews.Rows[0]["N_Date"].ToString())%> </p>
                <div class="page_con">
                	<%=dtNews.Rows[0]["N_Content"]%>
                	<%
                        if (dtNews.Rows[0]["N_ImgPath"].ToString().Trim().Length > 0) { 
                        %>
                        <div style=" margin:5px auto; text-align:center;">
                          <img  src="NewsImg/<%=dtNews.Rows[0]["N_ImgPath"] %>"/>
                        </div>
                        <%
                        }   
                	 %>
                </div>
        </div>    
    </div>
    <!--main end-->

</asp:Content>

