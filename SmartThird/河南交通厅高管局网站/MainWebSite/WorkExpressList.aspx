<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkExpressList.aspx.cs" Inherits="WorkExpressList" %>
<%@ Import Namespace="MainModel" %>
<%@ Import Namespace="MainService" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="PubClass" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>工作动态-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <!--通用头部-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
       
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 工作动态</div>
    	<ul class="alllist">
            <asp:Repeater ID="rptWorkExpress" runat="server">
              <ItemTemplate>
                <li><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString())%>]</span><a href='workexpress/<%#  Eval("N_ImgPath") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),40)%> </a></li>
              </ItemTemplate>
            </asp:Repeater>  
        </ul>
        <div class="fanye">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
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
    <div class="dongtai mar_t10">
      <dl>
        <dt></dt>
        <dd>
          
          <%
                  int nowYear=DateTime.Now.Year;
                  int nowMonth = DateTime.Now.Month;
                  for (int i = nowYear; i >= 2010; i--) { 
                     %>
                      <div class="btnmenu"  onclick="showDivDisplay(<%=nowYear %>,2010,<%=i %>)"><a href="#"><%=i %>年</a></div>
             	        <div  id="btnmenu<%=i %>" style=" display:none" >
                         <div class="navimg"></div>
                            <%
                                if (i == 2010) {
                                 %>
                                 <div class="btnsubmenu"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="menunav" CommandArgument="2010-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                 <div class="btnsubmenu"><asp:LinkButton ID="LinkButton2" runat="server"  CommandName="menunav" CommandArgument="2010-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                 <%
                                }
                                else if (i==2011)
                                {
                                    if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton7" runat="server" CommandName="menunav" CommandArgument="2011-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton8" runat="server"  CommandName="menunav" CommandArgument="2011-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton9" runat="server" CommandName="menunav" CommandArgument="2011-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton10" runat="server"  CommandName="menunav" CommandArgument="2011-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton12" runat="server"  CommandName="menunav" CommandArgument="2011-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton13" runat="server" CommandName="menunav" CommandArgument="2011-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton14" runat="server"  CommandName="menunav" CommandArgument="2011-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton16" runat="server" CommandName="menunav" CommandArgument="2011-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton17" runat="server"  CommandName="menunav" CommandArgument="2011-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton19" runat="server"  CommandName="menunav" CommandArgument="2011-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton3" runat="server" CommandName="menunav" CommandArgument="2011-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton4" runat="server"  CommandName="menunav" CommandArgument="2011-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton5" runat="server" CommandName="menunav" CommandArgument="2011-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton6" runat="server"  CommandName="menunav" CommandArgument="2011-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                                else if(i==2012) {
                                    if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton11" runat="server" CommandName="menunav" CommandArgument="2012-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton15" runat="server"  CommandName="menunav" CommandArgument="2012-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton18" runat="server" CommandName="menunav" CommandArgument="2012-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton20" runat="server"  CommandName="menunav" CommandArgument="2012-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton21" runat="server"  CommandName="menunav" CommandArgument="2012-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton22" runat="server" CommandName="menunav" CommandArgument="2012-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton23" runat="server"  CommandName="menunav" CommandArgument="2012-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton24" runat="server" CommandName="menunav" CommandArgument="2012-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton25" runat="server"  CommandName="menunav" CommandArgument="2012-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton26" runat="server"  CommandName="menunav" CommandArgument="2012-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton27" runat="server" CommandName="menunav" CommandArgument="2012-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton28" runat="server"  CommandName="menunav" CommandArgument="2012-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton29" runat="server" CommandName="menunav" CommandArgument="2012-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton30" runat="server"  CommandName="menunav" CommandArgument="2012-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                                else if (i == 2013) {
                                     if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton31" runat="server" CommandName="menunav" CommandArgument="2013-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton32" runat="server"  CommandName="menunav" CommandArgument="2013-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton33" runat="server" CommandName="menunav" CommandArgument="2013-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton34" runat="server"  CommandName="menunav" CommandArgument="2013-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton35" runat="server"  CommandName="menunav" CommandArgument="2013-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton36" runat="server" CommandName="menunav" CommandArgument="2013-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton37" runat="server"  CommandName="menunav" CommandArgument="2013-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton38" runat="server" CommandName="menunav" CommandArgument="2013-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton39" runat="server"  CommandName="menunav" CommandArgument="2013-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton40" runat="server"  CommandName="menunav" CommandArgument="2013-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton41" runat="server" CommandName="menunav" CommandArgument="2013-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton42" runat="server"  CommandName="menunav" CommandArgument="2013-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton43" runat="server" CommandName="menunav" CommandArgument="2013-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton44" runat="server"  CommandName="menunav" CommandArgument="2013-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                                else if (i == 2014) {
                                   if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton45" runat="server" CommandName="menunav" CommandArgument="2014-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton46" runat="server"  CommandName="menunav" CommandArgument="2014-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton47" runat="server" CommandName="menunav" CommandArgument="2014-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton48" runat="server"  CommandName="menunav" CommandArgument="2014-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton49" runat="server"  CommandName="menunav" CommandArgument="2014-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton50" runat="server" CommandName="menunav" CommandArgument="2014-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton51" runat="server"  CommandName="menunav" CommandArgument="2014-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton52" runat="server" CommandName="menunav" CommandArgument="2014-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton53" runat="server"  CommandName="menunav" CommandArgument="2014-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton54" runat="server"  CommandName="menunav" CommandArgument="2014-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton55" runat="server" CommandName="menunav" CommandArgument="2014-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton56" runat="server"  CommandName="menunav" CommandArgument="2014-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton57" runat="server" CommandName="menunav" CommandArgument="2014-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton58" runat="server"  CommandName="menunav" CommandArgument="2014-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                                else if (i == 2015) {
                                    if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton59" runat="server" CommandName="menunav" CommandArgument="2015-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton60" runat="server"  CommandName="menunav" CommandArgument="2015-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton61" runat="server" CommandName="menunav" CommandArgument="2015-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton62" runat="server"  CommandName="menunav" CommandArgument="2015-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton63" runat="server"  CommandName="menunav" CommandArgument="2015-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton64" runat="server" CommandName="menunav" CommandArgument="2015-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton65" runat="server"  CommandName="menunav" CommandArgument="2015-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton66" runat="server" CommandName="menunav" CommandArgument="2015-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton67" runat="server"  CommandName="menunav" CommandArgument="2015-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton68" runat="server"  CommandName="menunav" CommandArgument="2015-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton69" runat="server" CommandName="menunav" CommandArgument="2015-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton70" runat="server"  CommandName="menunav" CommandArgument="2015-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton71" runat="server" CommandName="menunav" CommandArgument="2015-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton72" runat="server"  CommandName="menunav" CommandArgument="2015-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                                else if (i == 2016) { 
                                      if (i == nowYear)
                                    {
                                        if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 4) { 
                                              %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton73" runat="server" CommandName="menunav" CommandArgument="2016-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton74" runat="server"  CommandName="menunav" CommandArgument="2016-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton75" runat="server" CommandName="menunav" CommandArgument="2016-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton76" runat="server"  CommandName="menunav" CommandArgument="2016-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 3){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton77" runat="server"  CommandName="menunav" CommandArgument="2016-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton78" runat="server" CommandName="menunav" CommandArgument="2016-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton79" runat="server"  CommandName="menunav" CommandArgument="2016-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }else if(PubClass.Tool.Get_QuarterByMonth(nowMonth) == 2){
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton80" runat="server" CommandName="menunav" CommandArgument="2016-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton81" runat="server"  CommandName="menunav" CommandArgument="2016-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                        else if (PubClass.Tool.Get_QuarterByMonth(nowMonth) == 1)
                                        {
                                            %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton82" runat="server"  CommandName="menunav" CommandArgument="2016-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                        }
                                    }
                                    else { 
                                       %>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton83" runat="server" CommandName="menunav" CommandArgument="2016-10-1" OnCommand="LinkButton3_Command">第四季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton84" runat="server"  CommandName="menunav" CommandArgument="2016-7-1"  OnCommand="LinkButton3_Command">第三季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton85" runat="server" CommandName="menunav" CommandArgument="2016-4-1" OnCommand="LinkButton3_Command">第二季度</asp:LinkButton></div>
                                       <div class="btnsubmenu"><asp:LinkButton ID="LinkButton86" runat="server"  CommandName="menunav" CommandArgument="2016-1-1"  OnCommand="LinkButton3_Command">第一季度</asp:LinkButton></div>
                                       <%
                                    }
                                }
                            %>
                      </div>
                     <%
                  } 
          %>
        </dd>
        <dd class="lanmu_b"></dd>
      </dl>
    </div>
  </div>
</div>
    
     <!--通用底部-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
	    function showDivDisplay(divStart,divEnd,divIndex){
			    for(var i=divStart;i>=divEnd;i--){
				     if(divIndex==i){
					    document.getElementById("btnmenu"+divIndex).style.display="block"; 
			         }else{
					    document.getElementById("btnmenu"+i).style.display="none"; 	 
				     }
			    }
		    }
    </script>
