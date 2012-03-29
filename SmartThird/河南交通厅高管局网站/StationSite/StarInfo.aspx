<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="StarInfo.aspx.cs" Inherits="StarInfo" Title="" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<!--main begin-->
	<div id="mainbody">
	    <%
            DataTable dtNews = (DataTable)ViewState["dtNews"];
            string strTID = dtNews.Rows[0]["T_ID"].ToString();
            string strType = dtNews.Rows[0]["T_Name"].ToString();
            string strTitle = dtNews.Rows[0]["N_Title"].ToString();
            string strFrom = dtNews.Rows[0]["N_From"].ToString();
            string strDate = PubClass.Tool.Get_ShortDate(dtNews.Rows[0]["N_Date"].ToString());
            string strContent = dtNews.Rows[0]["N_Content"].ToString();
            if (strContent.IndexOf("<$$>") > 0) {
                strContent = strContent.Substring(strContent.IndexOf("<$$>")+4);
            }                         
	     %>
    	<div class="daohang">您当前的位置： <a href="index.aspx">首页</a> >> <a href='StarsList.aspx?tid=<%=strTID %>'><%=strType%></a></div>
        <div class="pages">
        		<h1><%=strTitle%></h1>
                <p class="page_date">服务之星：<%=strFrom %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布日期：<%=strDate %> </p>
                <div class="page_con">
                	<%=strContent %>
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

