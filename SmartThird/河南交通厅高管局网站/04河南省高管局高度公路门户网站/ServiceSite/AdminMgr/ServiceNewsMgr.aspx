<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceNewsMgr.aspx.cs" Inherits="AdminMgr_ServiceNewsMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区栏目管理</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div  class="righttopnavbg">服务区栏目</div>
     <div  class="divContent">
        <div style=" line-height:15px; text-align:right" >
            &nbsp;<asp:HyperLink ID="linkAddTitle" runat="server" CssClass="Font13Add">添加文章</asp:HyperLink></div>
        <div  class="ServiceItemNavDvi">
        <asp:Button ID='btnYZXW'   CssClass="ServiceItemNavBtn"  runat="server" Text="驿站新闻" OnClick="btnYZXW_Click"  />
         <asp:Button ID='btnGLZD'   CssClass="ServiceItemNavBtn"  runat="server" Text="管理制度" OnClick="btnGLZD_Click"  />
           <asp:Button ID='btnWMCJ'   CssClass="ServiceItemNavBtn"  runat="server" Text="文明创建" OnClick="btnWMCJ_Click"  />
            <asp:Button ID='btnYZWH'   CssClass="ServiceItemNavBtn"  runat="server" Text="驿站文化" OnClick="btnYZWH_Click"  />
             <asp:Button ID='btnXXYD'   CssClass="ServiceItemNavBtn"  runat="server" Text="学习园地" OnClick="btnXXYD_Click"  />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:BoundField HeaderText="文章标题" DataField="N_Title" >
                </asp:BoundField>
                <asp:BoundField DataField="TypeName" HeaderText="文章类别" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="N_Frorm" HeaderText="文章出处" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="发布日期" DataField="N_Time" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='AddServiceNewsInfo.aspx?action=update&tid=<%#DataBinder.Eval(Container.DataItem,"N_NewsType") %>&nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>'  >编辑</a> &nbsp;
                       
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EBF2F9" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Height="25px" />
        </asp:GridView>
        <div style=" background-color:#d7e4f7; line-height:25px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="25" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
	</div>
    </form>
</body>
</html>
