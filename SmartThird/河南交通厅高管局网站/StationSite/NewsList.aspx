<%@ Page Language="C#" MasterPageFile="~/index.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" Title="" %>
<%@ Import Namespace="StationModel" %>
<%@ Import Namespace="StationService" %>
<%@ Import Namespace="PubClass" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!--main begin-->
	<div id="mainbody">
    	<!--最新动态-->
    	<dl id="<%=ViewState["strClass"] %>" class="right">
        	<dt><p>您当前的位置：<a href="index.aspx">首页</a> >> 
                <asp:Label ID="lblTypeName" runat="server" Text="type"></asp:Label></p></dt>
            <dd>
            	<ul>
                    <asp:Repeater ID="rptNewsList" runat="server">
                     <ItemTemplate>
                        <li><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>' title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),37) %></a></li>
                     </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="fanye">
                  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
                </div>
            </dd>
            <dd class="wid580_b"></dd>
        </dl>
       <!--公告-->
    	<dl id="gg">
        	<dt><p class="right more"><a href="StationInfo.aspx"><img src="images/more.jpg" width="40" height="11" /></a></p></dt>
        <dd>
            	<div style=" width:206px; margin:0 auto; height:290px; overflow:hidden;"> 
            	<p class="jianjie_pic">
            	<%
                    TollStation station = (TollStation)Session["stationinfo"];   
            	 %>
            	 <a href="StationPhoto/<%=station.TS_MainPhoto %>" rel="lightbox[photo]" title="<%=station.TS_Name %>形象照片">
            	<img src='StationPhoto/<%=station.TS_ViewPhoto %>' width="150" height="120" alt='<%=station.TS_Name %>形象照片' />
            	</a>
            	</p>
            	<%=PubClass.Tool.SubString(station.TS_Remark,178) %> <a href="StationInfo.aspx" class="orange" title="<%=station.TS_Remark %>">[点击详情]</a>
                </div>
          </dd>
            <dd class="gg_b"></dd>
        </dl> 
        <div class="clear"></div>
    </div>
    <!--main end-->

</asp:Content>

