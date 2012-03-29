<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="NewsInfo.aspx.cs" Inherits="NewsInfo" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="main">
        <%
            DataTable dt = (DataTable)ViewState["dtNews"];
            string strType = dt.Rows[0]["T_Name"].ToString();
            string strTID=dt.Rows[0]["T_ID"].ToString();
            string strTitle = dt.Rows[0]["N_Title"].ToString();
            string strFrom = dt.Rows[0]["N_From"].ToString();
            string strDate = PubClass.Tool.Get_ShortDate(dt.Rows[0]["N_Date"].ToString());
            string strContent = dt.Rows[0]["N_Content"].ToString();
         %>
   		<div class="contact_weizhi"><a href="index.aspx">首页</a> >> <a href="NewsList.aspx?tid=<%=strTID %>"><%=strType %></a></div>
        <div class="pages">
          <div id="NewsContent">
        	<h1><%=strTitle %></h1>
            <div class="page_date">信息来源【<%=strFrom %>】&nbsp;&nbsp;&nbsp;&nbsp;<%=strDate %></div>
            <div class="page_con"><%=strContent %></div>
            <%
                if (dt.Rows[0]["N_ImgPath"].ToString().Trim() != "") { 
                %>
                <div style=" margin:5px; text-align:center;"><img src="NewsImg/<%=dt.Rows[0]["N_ImgPath"] %>"  alt="<%=strTitle %>"/></div>
                <%
                }
            %>
            
          </div>
            <div class="page_bottom" style=" margin-top:20px;"><a href="javascript:close();">【关闭窗口】 </a></div>
        </div>
   </div>


</asp:Content>

