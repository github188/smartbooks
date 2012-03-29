<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lishizhizui_list.aspx.cs" Inherits="gstravel_lishizhizui_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>河南之最-高速出游-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="wid800tit mar_b10">您的位置：<a href="../index.aspx">首页</a> >> <a href="chuyou.html">高速出游</a> >> 河南之最</div>
  <div class="wid490 right">
    <ul class="gscy_list">
      <asp:Repeater ID="rptLSZZ" runat="server">
              <ItemTemplate>
                <li><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString())%>]</span><a href='lishizhizui_info.aspx?nid=<%#  Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'>&middot;<%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 30)%> </a></li>
              </ItemTemplate>
            </asp:Repeater>  
    </ul>
    <div class="gscy_fanye">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    </div>
  </div>
  <iframe src="hnmap.html" scrolling="no" frameborder="0" style="width:300px; height:390px; overflow:hidden;"></iframe>
  <div class="clear"></div>
</div>
    
 <!--通用底部-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
 
    </form>
</body>
</html>
