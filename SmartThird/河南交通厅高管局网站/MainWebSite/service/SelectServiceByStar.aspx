<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectServiceByStar.aspx.cs" Inherits="service_SelectServiceByStar" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>���Ǽ������ѯ������-����������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">����λ�ã�<a href="../index.aspx">��ҳ</a> >> <a href="Service_Index.aspx">����������</a> >> ���Ǽ�����</div>
    	<div class="pages">
        	      
        	      <dl class="servicelist">
        	      <dt>���Ǽ�������</dt>
    <%
        System.Data.DataTable dt_5Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='������' order by S_QuarterRank asc,S_Star desc");
        if (dt_5Star != null) {
                   for (int i = 0; i < dt_5Star.Rows.Count; i++)
                   {
                       string S_Name = dt_5Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_5Star.Rows[i]["S_ID"]);
                       %>
                        <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                       <%
                   }
        }
    %>
    </dl>
    <div class="clear"></div>
    
    
    
    <dl class="servicelist">
     <dt>���Ǽ�������</dt>
    <%
        System.Data.DataTable dt_4Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='�����' order by S_QuarterRank asc,S_Star desc");
        if (dt_4Star != null) {
                   for (int i = 0; i < dt_4Star.Rows.Count; i++)
                   {
                       string S_Name = dt_4Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_4Star.Rows[i]["S_ID"]);
                       %>
                        <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                       <%
                   }
        }
    %>
    </dl>
    <div class="clear"></div>
    
    <dl class="servicelist">
    <dt>���Ǽ�������</dt>
    <%
        System.Data.DataTable dt_3Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='����' order by S_QuarterRank asc,S_Star desc");
        if (dt_3Star != null) {
                   for (int i = 0; i < dt_3Star.Rows.Count; i++)
                   {
                       string S_Name = dt_3Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_3Star.Rows[i]["S_ID"]);
                       %>
                        <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                       <%
                   }
        }
    %>
    </dl>
    <div class="clear"></div>
    
    <dl class="servicelist">
    <dt>����ͣ����</dt>
    <%
        System.Data.DataTable dt_TCStar = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='����ͣ����' order by S_QuarterRank asc,S_Star desc");
        if (dt_TCStar != null) {
                   for (int i = 0; i < dt_TCStar.Rows.Count; i++)
                   {
                       string S_Name = dt_TCStar.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_TCStar.Rows[i]["S_ID"]);
                       %>
                        <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                       <%
                   }
        }
    %>
    </dl>
    <div class="clear"></div>
    
    
    <dl class="servicelist">
     <dt>���Ǽ����·�����</dt>
    <%
        System.Data.DataTable dt_2Star = PubClass.DBHelper.GetDataSet("select * from T_ServiceInfo where S_Star='���' or S_Star='��' or S_Star='' or S_Star is null  order by S_QuarterRank asc,S_Star desc");
        if (dt_2Star != null) {
                   for (int i = 0; i < dt_2Star.Rows.Count; i++)
                   {
                       string S_Name = dt_2Star.Rows[i]["S_Name"].ToString();
                       int S_ID = Convert.ToInt32(dt_2Star.Rows[i]["S_ID"]);
                       %>
                        <dd><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=S_ID %>" target="_blank"><%=S_Name %></a></dd>
                       <%
                   }
        }
    %>
     </dl>
    <div class="clear"></div>   	      
        	      
        	      
        	      
        	      
        	      
        </div>    
  </div>
  
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">վ������&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" ���� "type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="�߼�����"type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
    <div class="servicetype mar_t10">
      <dl>
        <dt></dt>
        <dd>
        	<div class="btnmenu"><a href="AllServiceList.aspx">ȫ��������</a></div>
          	<div class="btnmenu"><a href="SelectServiceByHighWay.aspx">�����ٹ�·</a></div>	
            <div class="btnmenu"><a href="SelectServiceByCity.aspx">������</a></div>
            <div class="btnmenu"><a href="SelectServiceByStar.aspx">���Ǽ�����</a></div>
        </dd>
        <dd class="lanmu_b"></dd>
      </dl>
    </div>
  </div>
</div>
    
    
 <!--ͨ�õײ�-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
 
    </form>
</body>
</html>
