<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoadDepartMgr.aspx.cs" Inherits="management_RoadDepartMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>路政单位列表-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
 <div id="box_mr2">
    
        <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />路政单位信息管理&nbsp;&nbsp;>>&nbsp;&nbsp;路政单位列表</div>
           <div class=" right"><img src="images/001.gif" width="14" height="14" align="absmiddle"/><a href="AddRoadDepart.aspx">添加路政单位</a></div>
        </div>
        
         <div class="search_mgr mar_t2">
             路政单位名称：<asp:TextBox ID="txtName" runat="server" Width="180px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;所属地市：<asp:DropDownList ID="ddlCity" runat="server" Width="130px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="btn_search" OnClick="btnSearch_Click" />
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="RD_Name" HeaderText="单位名称" />
                <asp:BoundField DataField="RD_Manager" HeaderText="单位负责人" >
                    <ItemStyle Width="12%" />
                </asp:BoundField>
                <asp:BoundField DataField="RD_Phone" HeaderText="联系电话" >
                    <ItemStyle Width="12%" />
                </asp:BoundField>
                <asp:BoundField DataField="CI_Name" HeaderText="所属地市" >
                    <ItemStyle Width="12%" />
                </asp:BoundField>
                
                  <asp:TemplateField>
                         <HeaderTemplate>
                            LOGO管理
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='LogoView.aspx?rdid=<%#DataBinder.Eval(Container.DataItem,"RD_ID") %>' target="_blank">预览</a> | 
                             <a href='EditLogo.aspx?rdid=<%#DataBinder.Eval(Container.DataItem,"RD_ID") %>'>编辑</a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                  </asp:TemplateField>
                
                
                   <asp:TemplateField>
                         <HeaderTemplate>
                            编辑
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='EditRoadDepart.aspx?rdid=<%#DataBinder.Eval(Container.DataItem,"RD_ID") %>'><img src="images/edit.gif"  alt="编辑"/></a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                    </asp:TemplateField>
                     
                
                
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RD_ID") %>' OnClientClick="return confirm('您确定要删除该记录？')" ToolTip="删除" />
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
