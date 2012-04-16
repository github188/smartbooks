<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fengjing_info.aspx.cs" Inherits="gstravel_fengjing_info" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"] %>-<%=((DataTable)ViewState["dtNews"]).Rows[0]["T_Name"] %>-风景名胜-高速出游-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
 
<div id="main2">
	<div class="wid800tit mar_b10">您的位置：<a href="../index.aspx">首页</a> >> <a href="chuyou.html">高速出游</a> >> <a href="fengjingmingsheng.html">风景名胜</a> >> <a href="fengjing_list.aspx?tid=<%=((DataTable)ViewState["dtNews"]).Rows[0]["T_ID"] %>"><%=((DataTable)ViewState["dtNews"]).Rows[0]["T_Name"] %></a></div>  
<div class="pages wid760">
        		<h1><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"]%></h1> 
                <p class="page_date">文章出处：<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_From"]%>  &nbsp;&nbsp;发布日期：<%=PubClass.Tool.Get_ShortDate(((DataTable)ViewState["dtNews"]).Rows[0]["N_Time"].ToString())%></p>
                <div class="page_con">
                  <%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Content"]%>
              </div>
	
  </div>

    <div class="clear"></div>
</div>
<!--通用底部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
