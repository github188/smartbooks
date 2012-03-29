<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileDownloadMgr.aspx.cs" Inherits="AdminMgr_FileDownloadMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title><%=((DataTable)ViewState["dtType"]).Rows[0]["FT_Name"]%>-河南省交通运输厅高速公路管理局网站后台管理系统</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="ContentBox">
    
    <div  id="mgrmenu">
    <div class="top">文件下载 >> <%=((DataTable)ViewState["dtType"]).Rows[0]["FT_Name"]%></div>
    <div class="buttom"><span><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/AdminMgr/images/btnAdd.jpg" OnClick="ImageButton1_Click" /></span></div>
    </div> 
    
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" HeaderStyle-BackColor="#6298e1" HeaderStyle-Height="25" RowStyle-BackColor="#ebf2f9" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="13" RowStyle-Height="20" RowStyle-HorizontalAlign="Center" BorderColor="#6298E1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" PageSize="20" PagerStyle-HorizontalAlign="center"  PagerStyle-BackColor="#d7e4f7" PagerStyle-Height="25px">
            <Columns>
                <asp:BoundField DataField="FD_Title" HeaderText="文件标题" >
                    <ItemStyle HorizontalAlign="Left" CssClass="textIndent4" />
                </asp:BoundField>
                <asp:BoundField DataField="FD_Size" HeaderText="文件大小" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="FT_Name" HeaderText="文件类型" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="FD_CreateDate" HeaderText="上传日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        删除
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="del" runat="server"  CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FD_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EBF2F9" BorderColor="#6298E1" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Font-Bold="True" Font-Size="13pt" Height="25px" />
            <PagerStyle BackColor="#D7E4F7" Height="25px" HorizontalAlign="Center" />
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
