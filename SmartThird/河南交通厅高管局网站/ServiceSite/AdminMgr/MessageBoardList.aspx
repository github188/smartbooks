<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageBoardList.aspx.cs" Inherits="AdminMgr_MessageBoardList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>留言板信息管理</title>
       <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">服务区留言板信息管理</div>
	<div  class="divContent">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-Height="20" RowStyle-BackColor="#ebf2f9"   OnRowCommand="GridView1_RowCommand" RowStyle-HorizontalAlign="center">
            <Columns>
                <asp:BoundField HeaderText="昵称" DataField="M_UName" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="留言内容" DataField="M_Content" >
                </asp:BoundField>
                <asp:BoundField HeaderText="留言时间" DataField="M_Time" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}">
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="是否发布" DataField="M_Status" >
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='ReplyMessage.aspx?mid=<%#DataBinder.Eval(Container.DataItem,"M_ID") %>'  >回复</a> &nbsp;
                        <asp:LinkButton ID="upd" runat="server" CommandName="updRecord"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>'>审核发布</asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                    <ItemStyle Width="140px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="background-color:#d7e4f7; line-height:25px;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged" PageSize="25" ShowCustomInfoSection="Left">
        </webdiyer:AspNetPager>
	</div>
	</div>
    </form>
</body>
</html>
