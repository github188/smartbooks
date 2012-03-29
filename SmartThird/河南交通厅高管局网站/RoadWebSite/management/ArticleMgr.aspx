<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleMgr.aspx.cs" Inherits="management_ArticleMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息管理-路政网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mr2">
    
          <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />路政动态&nbsp;&nbsp;>>&nbsp;&nbsp;<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>信息管理</div>
           <div class=" right"><img src="images/001.gif" width="14" height="14" align="absmiddle"/><a href="<%=((DataTable)ViewState["dtType"]).Rows[0]["T_AddURL"]%>">添加文章</a></div>
        </div>
        
        
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="N_Title" HeaderText="文章标题" />
                <asp:BoundField DataField="N_From" HeaderText="文章来源" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="T_Name" HeaderText="文章类型" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="N_Date" HeaderText="发布日期" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                
                  <asp:TemplateField>
                         <HeaderTemplate>
                            预览
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='OverView.aspx?nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' target="_blank"><img src="images/gif-0072.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                  </asp:TemplateField>
                
                
                   <asp:TemplateField>
                         <HeaderTemplate>
                            编辑
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='<%#DataBinder.Eval(Container.DataItem,"T_EditURL") %>&nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>'><img src="images/edit.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                    </asp:TemplateField>
                     
                
                
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' OnClientClick="return confirm('您确定要删除该记录？')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             删除
                         </HeaderTemplate>
                         <ItemStyle Width="60px" />
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
