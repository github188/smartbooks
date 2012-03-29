<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteMainImg.aspx.cs" Inherits="AdminMgr_SiteMainImg" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区门户网站主页图片管理</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">服务区门户网站主页图片管理</div>
     <div style=" margin:0 auto; width:750px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center">
            <Columns>
                <asp:BoundField HeaderText="服务区名称" DataField="S_Name" >
                    <ItemStyle Width="150" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        图片
                    </HeaderTemplate>
                    <ItemTemplate>
                        <img  src="../ServiceImg/<%#DataBinder.Eval(Container.DataItem,"S_HeaderImg") %>" width="490" height="90"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100">
                    <HeaderTemplate>
                        操作
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href='EditSiteMainImg.aspx?sid=<%#DataBinder.Eval(Container.DataItem,"S_ID") %>'>编辑图片</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EBF2F9" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Height="25px" />
        </asp:GridView>
         <div style=" background-color:#d7e4f7; line-height:25px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="10" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
	    </div>
    </form>
</body>
</html>

