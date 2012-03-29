<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList"  %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div id="main">
   		<div class="contact_weizhi"><a href="index.aspx">首页</a> >> 
               <asp:Label ID="lblNewsType" runat="server" Text="lblNewsType"></asp:Label></div>
        <div class="pages">
        	<ul class="newlist">
        	    <asp:Repeater ID="rptNewsList" runat="server">
                              <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Date").ToString()) %>]</span><a href='NewsInfo.aspx?nid=<%# Eval("N_ID") %>'  title='<%# Eval("N_Title") %>' target="_blank"><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),56) %></a></li>
                              </ItemTemplate>
                            </asp:Repeater>
           </ul>
            <div class="fanye">
               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
            </div>
        </div>
   </div>

</asp:Content>

