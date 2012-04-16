<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceItemMgr.aspx.cs" Inherits="AdminMgr_ServiceItemMgr" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务项目动态管理</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">服务项目动态管理</div>
     <div  class="divContent">
     
        <div style=" line-height:20px; text-align:right" >
           <span>服务项目：</span> <asp:Label ID="lblSelectedModel" runat="server"  CssClass="Font13">新闻简介</asp:Label>
            &nbsp;
            <asp:HyperLink ID="linkAddTitle" runat="server" CssClass="Font13Add" >添加文章</asp:HyperLink></div>
            
        <div  class="ServiceItemNavDvi">
           <ul>
               <asp:Repeater ID="RepeaterNav" runat="server" OnItemCommand="RepeaterNav_ItemCommand">
               <ItemTemplate>
              <li><asp:Button ID='btn' Text='<%#DataBinder.Eval(Container.DataItem,"M_Name") %>' CssClass="ServiceItemNavBtn" CommandName='<%#DataBinder.Eval(Container.DataItem,"M_Name") %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>' runat="server"  /></li>
               </ItemTemplate>
               </asp:Repeater>
           </ul> 
        </div>
        
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-Height="25px"   OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center" >
            <Columns>
                <asp:BoundField HeaderText="文章标题" DataField="I_Title" ItemStyle-HorizontalAlign="left" >
                </asp:BoundField>
                <asp:BoundField DataField="M_Name" HeaderText="所属模块" ItemStyle-Width="120px"/>
                <asp:BoundField HeaderText="发布日期" DataField="I_Time">
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='AddServiceItemNews.aspx?action=update&mid=<%#DataBinder.Eval(Container.DataItem,"M_ID") %>&iid=<%#DataBinder.Eval(Container.DataItem,"I_ID") %>'  >编辑</a> &nbsp;
                       
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"I_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style=" background-color:#d7e4f7; line-height:25px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PageSize="25" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
	</div>
    </form>
</body>
</html>
