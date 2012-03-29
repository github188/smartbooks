<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventList.aspx.cs" Inherits="EventList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <!--ͨ��ͷ��-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">����λ�ã�<a href="index.aspx">��ҳ</a> >> <a href="DepartBasicInfo.aspx?tid=60"><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Remark"]%></a> >> <%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%></div>
    <ul class="piclist">
        <asp:Repeater ID="rptEventList" runat="server">
        <ItemTemplate>
           <li>
        <p><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString()) %>]</span><%# Eval("N_Content") %></p>
        <img src='newsimages/<%# Eval("N_ImgPath") %>' width="120" height="90" /></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="fanye"><span>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    </div>
  </div>
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">վ������&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" ���� "type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="�߼�����"type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
    <div class="dashiji mar_t10">
      <dl>
        <dt></dt>
        <dd>
          <ul class="lanmulist">
            <li> <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2011">2011��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2010">2010��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2009">2009��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton4" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2008">2008��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton5" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2007">2007��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton6" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2006">2006��</asp:LinkButton></li>
            <li> <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton1_Command" CommandName="eventlist" CommandArgument="2005">2005��</asp:LinkButton></li>
          </ul>
        </dd>
        <dd class="lanmu_b"></dd>
      </dl>
    </div>
  </div>
</div>
    
    
    
     <!--ͨ�õײ�-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
