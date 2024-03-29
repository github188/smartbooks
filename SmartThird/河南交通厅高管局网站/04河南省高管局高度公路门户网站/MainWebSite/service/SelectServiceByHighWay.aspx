<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectServiceByHighWay.aspx.cs" Inherits="service_SelectServiceByHighWay" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>按高速公路查询服务区-服务区管理-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">您的位置：<a href="../index.aspx">首页</a> >> <a href="Service_Index.aspx">服务区管理</a> >> 按高速公路查询</div>
    	<div class="pages">
        	     <%
                     DataTable dtHighWay = DBHelper.GetDataSet("select * from T_HighWayInfo");
                     if (dtHighWay != null) {
                         for (int i = 0; i < dtHighWay.Rows.Count; i++)
                         {
                             int H_ID = Convert.ToInt32(dtHighWay.Rows[i]["H_ID"]);
                             string H_Name = dtHighWay.Rows[i]["H_Name"].ToString();
                             DataTable dtService = DBHelper.GetDataSet("select * from T_ServiceInfo where S_HID="+H_ID+" order by S_QuarterRank asc,S_Star desc");
                              %>
                              <dl class="servicelist">
                                <dt><%=H_Name %></dt>     
                              <%
                             if (dtService != null) {
                                 for (int k = 0; k < dtService.Rows.Count; k++)
                                 {
                                     int S_ID = Convert.ToInt32(dtService.Rows[k]["S_ID"]);
                                     string S_Name = dtService.Rows[k]["S_Name"].ToString();
                                     %>
                                     <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                                     <%
                                 }
                             }
                             %>
                              </dl>
                              <div class="clear"></div>
                             <%
                         }
                     }   
        	      %>
           
        </div>    
  </div>
  
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">站内搜索&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" 搜索 "type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="高级搜索"type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
    <div class="servicetype mar_t10">
      <dl>
        <dt></dt>
        <dd>
        	<div class="btnmenu"><a href="AllServiceList.aspx">全部服务区</a></div>
          	<div class="btnmenu"><a href="SelectServiceByHighWay.aspx">按高速公路</a></div>	
            <div class="btnmenu"><a href="SelectServiceByCity.aspx">按地市</a></div>
            <div class="btnmenu"><a href="SelectServiceByStar.aspx">按星级分类</a></div>
        </dd>
        <dd class="lanmu_b"></dd>
      </dl>
    </div>
  </div>
</div>
    
    
 <!--通用底部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
 
    </form>
</body>
</html>
