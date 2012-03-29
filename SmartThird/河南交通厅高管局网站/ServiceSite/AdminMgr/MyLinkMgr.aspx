<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLinkMgr.aspx.cs" Inherits="AdminMgr_MyLinkMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>友情链接管理</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg">友情链接</div>
	<div class="divContent">
	 <div class="topadd"><a href="AddMyLink.aspx?action=add"><img src="images/btnAdd1.jpg" width="60" height="25" /></a></div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#6298e1" RowStyle-Height="20" RowStyle-BackColor="#ebf2f9" RowStyle-HorizontalAlign="center">
            <Columns>
                <asp:BoundField HeaderText="标题" DataField="L_Title" ItemStyle-Width="200" >
                </asp:BoundField>
                <asp:BoundField HeaderText="链接地址" DataField="L_URL"  >
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="200">
                    <ItemTemplate>
                     <a href='AddMyLink.aspx?action=update&lid=<%#DataBinder.Eval(Container.DataItem,"L_ID") %>'  >编辑</a> &nbsp;
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"L_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
	<div  style=" background-color:#d7e4f7; line-height:25px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"  PageSize="15" OnPageChanged="AspNetPager1_PageChanged" ShowCustomInfoSection="Left">
        </webdiyer:AspNetPager>
	</div>
    </div>
    </form>
</body>
</html>
