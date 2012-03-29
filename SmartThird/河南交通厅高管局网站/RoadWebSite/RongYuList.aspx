<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="RongYuList.aspx.cs" Inherits="RongYuList" Title="Untitled Page" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="main">
   		<div class="contact_weizhi"><a href="index.aspx">首页</a> >> 
               <asp:Label ID="lblNewsType" runat="server" Text="Label"></asp:Label></div>
        <div class="pages">
        	<ul class="piclist">
                <asp:Repeater ID="rptRongYu" runat="server">
                          <ItemTemplate>
                           <li>
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu1]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><img src='NewsImg/<%# Eval("N_ImgView") %>'  alt='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>' /></a><br />
                             <a href='NewsImg/<%# Eval("N_ImgPath") %>' rel="lightbox[rongyu2]" title='标题：<%# Eval("N_Title") %><br>简介：<%# Eval("N_Content") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),9) %></a>
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


</asp:Content>

