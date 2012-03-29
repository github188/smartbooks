<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMgr.aspx.cs" Inherits="management_UserMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>收费站用户信息管理-河南省交通运输厅高速公路管理局收费管理网站后台管理系统</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />用户列表</div>
        <div class="right"><img src="images/add.gif" width="10" height="10" align="absmiddle" /><a href="AddUser.aspx">添加</a></div>
    </div>
    
    <div class="search_mgr mar_t2">
     按收费站查询：
        <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" CssClass="btn_search" OnClick="Button1_Click" />
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="U_LoginName" HeaderText="用户名"  />
                <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# CommonFunction.Decrypt(DataBinder.Eval(Container.DataItem, "U_LoginPwd").ToString(),"station")%>'></asp:Label>
                         </ItemTemplate>
                         <HeaderTemplate>
                             密码
                         </HeaderTemplate>
                         <ItemStyle Width="25%" />
                    </asp:TemplateField>
                <asp:BoundField DataField="TS_Name" HeaderText="所属收费站" >
                    <ItemStyle Width="25%" />
                </asp:BoundField>
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"U_ID") %>' OnClientClick="return confirm('您确定要删除该记录？')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             删除
                         </HeaderTemplate>
                         <ItemStyle Width="25%" />
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
