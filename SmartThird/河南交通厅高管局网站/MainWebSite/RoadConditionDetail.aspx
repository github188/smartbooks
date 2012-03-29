<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoadConditionDetail.aspx.cs" Inherits="RoadConditionDetail" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"] + "-" + "实时路况" %>-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
   <div id="main2">
  <div class="right wid580">
    <div class="weizhi">您的位置：<a href="index.aspx">首页</a> >> <a href="RoadConditionList.aspx">实时路况</a></div>
    	<div class="pages">
        		<h1><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"]%></h1>
                <p class="page_date">文章出处：<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_From"]%>  &nbsp;&nbsp;&nbsp; 发布日期：<%=PubClass.Tool.Get_ShortDate(((DataTable)ViewState["dtNews"]).Rows[0]["N_Time"].ToString())%> </p>
                <div class="page_con">
                	<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Content"]%>
                </div>
        </div>    
  </div>
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">站内搜索&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" 搜索 "type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="高级搜索"type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
    <div style="height:250px;"></div>
  </div>
</div>

 <!--通用底部-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
