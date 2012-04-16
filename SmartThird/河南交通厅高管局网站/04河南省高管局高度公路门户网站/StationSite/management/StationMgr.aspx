<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StationMgr.aspx.cs" Inherits="management_StationMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>收费站信息管理-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />收费站列表</div>
        <div class="right"><img src="images/add.gif" width="10" height="10" align="absmiddle" /><a href="AddStation.aspx">添加</a></div>
    </div>
    
    <div class="search_mgr mar_t2">
     收费站名称：
        <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox>
     所属地市：
        <asp:DropDownList ID="ddlCity" runat="server" Width="130px">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" CssClass="btn_search" OnClick="Button1_Click" />
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="TS_Name" HeaderText="收费站名称" />
                <asp:BoundField DataField="TS_Manager" HeaderText="负责人"  ItemStyle-Width="12%" />
                <asp:BoundField DataField="TS_Phone" HeaderText="联系电话" ItemStyle-Width="12%" />
                <asp:BoundField DataField="CI_Name" HeaderText="所属地市" ItemStyle-Width="12%" />
                
                  <asp:TemplateField>
                         <HeaderTemplate>
                            LOGO管理
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='LogoView.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>' target="_blank">预览</a> | 
                             <a href='EditLogo.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>'>编辑</a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                  </asp:TemplateField>
                
                
                   <asp:TemplateField>
                         <HeaderTemplate>
                            编辑
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='EditStation.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>'><img src="images/edit.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                    </asp:TemplateField>
                     
                
                
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>' OnClientClick="return confirm('您确定要删除该记录？')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             删除
                         </HeaderTemplate>
                         <ItemStyle Width="12%" />
                    </asp:TemplateField>
                
                
            </Columns>
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
        </asp:GridView>
        
        <div class="gridviewpage">
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="25" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
    
    </div>
    </form>
</body>
</html>
