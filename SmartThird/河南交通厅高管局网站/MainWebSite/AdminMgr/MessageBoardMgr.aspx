<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageBoardMgr.aspx.cs" Inherits="AdminMgr_MessageBoardMgr" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>高速留言信息管理-河南省交通运输厅高速公路管理局</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  id="ContentBox">
    
    <div id="editmenu1">网站首页 >> 高速留言信息管理</div>
    
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" HeaderStyle-BackColor="#6298e1" HeaderStyle-Height="25" RowStyle-BackColor="#ebf2f9" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="13" RowStyle-Height="20" RowStyle-HorizontalAlign="Center" BorderColor="#6298E1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
            <RowStyle BackColor="#EBF2F9" BorderColor="#6298E1" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Font-Bold="True" Font-Size="13pt" Height="25px" />
            <Columns>
                
                <asp:BoundField DataField="M_UName" HeaderText="留言人" >
                    <ItemStyle Width="80" />
                </asp:BoundField>
                <asp:BoundField DataField="M_Email" HeaderText="电子邮件" >
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="M_Phone" HeaderText="联系电话"  ItemStyle-Width="120"  />
                <asp:BoundField DataField="M_Time" HeaderText="留言日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="M_Content" HeaderText="留言内容" ItemStyle-CssClass="textIndent4" ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="M_Open" HeaderText="是否发布" ItemStyle-Width="60" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href='ReplyMessageBoard.aspx?mid=<%#DataBinder.Eval(Container.DataItem,"M_ID") %>'>回复</a>&nbsp;
                        <asp:LinkButton ID="upd" runat="server" CommandName="updRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>' OnClientClick="return confirm('确定要对外公开发布？')" >审核发布</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="del" runat="server"  CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="130px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="background-color:#d7e4f7;height:25px; line-height:25px; padding-top:3px; margin-top:3px; padding-left:5px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="25" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
    </div>
    
    
    </div>
    </form>
</body>
</html>
