<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllServiceList.aspx.cs" Inherits="service_AllServiceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����ʡ�����з������б�-����������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">����λ�ã�<a href="../index.aspx">��ҳ</a> >> <a href="Service_Index.aspx">����������</a> >> ȫ��������</div>
    	<div class="pages">
            <ul class="serviceall">
                <asp:Repeater ID="rptServices" runat="server">
                <ItemTemplate>
                  <li><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%# Eval("S_ID") %>" target="_blank"><%# Eval("S_Name") %></a></li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
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
