<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceRank.aspx.cs" Inherits="service_ServiceRank" %>
<%@ Import Namespace="MainService" %>
<%@ Import Namespace="MainModel" %>
<%@ Import Namespace="PubClass" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>��������-����������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">����λ�ã�<a href="../index.aspx">��ҳ</a> >> <a href="service_Index.aspx">����������</a> >> ��������</div>
    	<div class="pages"> 
            <div id="paiminglist">
                <table width="580" border="0" cellspacing="1" cellpadding="1">
                  <tr class="biaoti">
                    <th width="123">����������</th>
                    <th width="123">�Ǽ�</th>
                    <th width="147">��������</th>
                    <th width="113">����·��</th>
                    <th width="58">����</th>
                  </tr>
                  <%
                      DataTable dtService = DBHelper.GetDataSet("select * from T_Service_HighWay where S_QuarterRank<=3 order by S_QuarterRank asc");
                      if (dtService != null) {
                          for (int i = 0; i < dtService.Rows.Count; i++)
                          {
                              string strServiceId = dtService.Rows[i]["S_ID"].ToString();
                              string strServiceName = dtService.Rows[i]["S_Name"].ToString();
                              string strStar = dtService.Rows[i]["S_Star"].ToString();
                              string strCity = dtService.Rows[i]["S_City"].ToString();
                              string strHighWay = dtService.Rows[i]["H_Name"].ToString();
                              string strRank = dtService.Rows[i]["S_QuarterRank"].ToString();
                              string strIco = "";
                              if (strStar == "������") {
                                  strIco = "<img src=\"../images/fuwu/5star.jpg\" width=\"69\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "�����"){
                                  strIco = "<img src=\"../images/fuwu/4star.jpg\" width=\"55\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "����"){
                                  strIco = "<img src=\"../images/fuwu/3star.jpg\" width=\"41\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "���"){
                                  strIco = "<img src=\"../images/fuwu/2star.jpg\" width=\"28\" height=\"13\" align=\"absmiddle\" alt=\"���Ǽ�������\">";
                              }else if(strStar == "��"){
                                  strIco = "<img src=\"../images/fuwu/1star.jpg\" width=\"13\" height=\"13\" align=\"absmiddle\" alt=\"һ�Ǽ�������\">";
                              }
                              else if (strStar == "����ͣ����")
                              {
                                  strIco = "<img src=\"../images/fuwu/parking.jpg\" width=\"55\" height=\"13\" align=\"absmiddle\" alt=\"����ͣ����\">";
                              }
                              %>
                                 <tr>
                                    <td><a href="http://service.hngsgl.info/CheckToService.aspx?serviceid=<%=strServiceId %>" target="_blank"><%=strServiceName %></a></td>
                                    <td><%=strIco %></td>
                                    <td><%=strCity %></td>
                                    <td><%=strHighWay %></td>
                                    <th><%=strRank %></th>
                                  </tr>
                              <%
                          }
                      }
                  %>
                </table>                  	
            </div>    
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
    
  </div>
</div>
    
    
 <!--ͨ�õײ�-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
 
    </form>
</body>
</html>
