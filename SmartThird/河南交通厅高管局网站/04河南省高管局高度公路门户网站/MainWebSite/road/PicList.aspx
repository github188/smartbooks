<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicList.aspx.cs" Inherits="road_PicList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>单页</title>
    <link href="../style/road.css" rel="stylesheet" type="text/css" />
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
        <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
        <div id="main2">
          <div class="right wid580">
            <div class="weizhi">您的位置：<a href="../index.aspx">首页</a>>><a href="Road_Index.aspx"><%=ViewState["Remark"] %></a>>><a href="PicList.aspx?tid=<%=ViewState["tid"] %>"><%=ViewState["TName"] %></a></div>
   	        <div class="pages">
                <ul class="piclist">                
                    <asp:Repeater ID="Repeater_Pic" runat="server">
                      <ItemTemplate>
                        <li>
                            <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>">
                                <img alt="<%#Eval("N_Title") %>" src='../newsimages/<%#Eval("N_ImgView") %>' width="261" height="196" />
                            </a>
                            <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>">
                                <%#PubClass.Tool.SubString(Eval("N_Title").ToString(),8) %>
                            </a>
                        </li>
                      </ItemTemplate>
                    </asp:Repeater>  
                 </ul>
                <div class="clear"></div>
               <div class="fanye">
                 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
                 </webdiyer:AspNetPager>
               </div>
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
          </div>
        </div>
        <!--通用底部-->
        <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
