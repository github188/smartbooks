<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageTextNewsMgr.aspx.cs" Inherits="AdminMgr_ImageTextNewsMgr" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1"  runat="server">
    <title><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>-河南省交通运输厅高速公路管理局网站后台管理系统</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="ContentBox">
    
    <div  id="mgrmenu">
    <div class="top"><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Remark"]%> >> <%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%></div>
    <div class="buttom"><span><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnAdd.jpg" OnClick="ImageButton1_Click" /></span></div>
    </div>
    
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" HeaderStyle-BackColor="#6298e1" HeaderStyle-Height="25" RowStyle-BackColor="#ebf2f9" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="13" RowStyle-Height="20" RowStyle-HorizontalAlign="Center" BorderColor="#6298E1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <RowStyle BackColor="#EBF2F9" BorderColor="#6298E1" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Font-Bold="True" Font-Size="13pt" Height="25px" />
            <Columns>
                <asp:BoundField DataField="N_Title" HeaderText="文章标题" >
                    <ItemStyle HorizontalAlign="Left" CssClass="textIndent4" />
                </asp:BoundField>
                <asp:BoundField DataField="N_From" HeaderText="文章出处" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="T_Name" HeaderText="文章类型" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="N_Time" HeaderText="发布日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href='ViewNewsInfo.aspx?nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' target="_blank">预览</a>&nbsp;
                        <a href='AddImageTextNewsMgr.aspx?tid=<%#DataBinder.Eval(Container.DataItem,"T_ID") %>&nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>&action=update'>编辑</a>&nbsp;
                        <asp:LinkButton ID="del" runat="server"  CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="background-color:#d7e4f7;height:25px; line-height:25px; padding-top:3px; margin-top:3px; padding-left:5px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
    </div>
    
    
    </div>
    </form>
</body>
</html>
