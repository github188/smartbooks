<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lishizhizui_list.aspx.cs" Inherits="gstravel_lishizhizui_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����֮��-���ٳ���-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../style/all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="wid800tit mar_b10">����λ�ã�<a href="../index.aspx">��ҳ</a> >> <a href="chuyou.html">���ٳ���</a> >> ����֮��</div>
  <div class="wid490 right">
    <ul class="gscy_list">
      <asp:Repeater ID="rptLSZZ" runat="server">
              <ItemTemplate>
                <li><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString())%>]</span><a href='lishizhizui_info.aspx?nid=<%#  Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'>&middot;<%# PubClass.Tool.SubString(Eval("N_Title").ToString(), 30)%> </a></li>
              </ItemTemplate>
            </asp:Repeater>  
    </ul>
    <div class="gscy_fanye">
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    </div>
  </div>
  <iframe src="hnmap.html" scrolling="no" frameborder="0" style="width:300px; height:390px; overflow:hidden;"></iframe>
  <div class="clear"></div>
</div>
    
 <!--ͨ�õײ�-->
 <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
 
    </form>
</body>
</html>
