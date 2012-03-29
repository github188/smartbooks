<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceModelMgr.aspx.cs" Inherits="AdminMgr_ServiceModelMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务项目管理</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg"><p style="height:25px;"><img src="images/ico07.gif" width="20" height="18" /><span style="font-size:12px"> 按服务项目查询：</span><asp:DropDownList ID="ddlSearch" runat="server" Width="120px" CssClass="TextAreaStyle" />
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSearch.jpg" ImageAlign="absmiddle" OnClick="btnSearch_Click" /></p></div>
    <div class="divContent">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  HeaderStyle-Height="25px"   OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField HeaderText="子服务项目名称" DataField="M_Name" >  
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="200">
                    <ItemTemplate>
                   
                        <asp:LinkButton ID="del" runat="server" CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"M_ID") %>' >删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        用户操作
                    </HeaderTemplate>
                   
                </asp:TemplateField>
            </Columns>  
        </asp:GridView>
        <div style="width:100%; line-height:40px; text-align:right;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AddServiceModel.aspx">添加子服务项目</asp:HyperLink>
         </div>
	</div>
    </form>
</body>
</html>

