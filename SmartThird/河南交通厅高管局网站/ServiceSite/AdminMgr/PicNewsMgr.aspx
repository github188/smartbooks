﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicNewsMgr.aspx.cs" Inherits="AdminMgr_PicNewsMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片新闻</title>
      <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">图片新闻</div>
     <div  class="divContent">
    <div style=" text-align:right; line-height:15px;" >
         <asp:HyperLink ID="linkAddTitle" runat="server"  CssClass="Font13Add" NavigateUrl="AddPicNews.aspx?action=add" >添加新闻</asp:HyperLink>&nbsp;</div>
    
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center"   OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# CommonFunction._GetMidInfo(DataBinder.Eval(Container.DataItem, "N_Title").ToString(),"(",")")%>
                    </ItemTemplate>
                    <HeaderTemplate>
                        新闻标题
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="N_Time" HeaderText="发布日期" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" >
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='AddPicNews.aspx?action=update&nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>'  >编辑</a> &nbsp;
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
        <div style=" background-color:#d7e4f7; line-height:25px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="20" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
	</div>
    </form>
</body>
</html>
