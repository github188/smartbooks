<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="657px">
            <Columns>
                <asp:BoundField DataField="N_Title" HeaderText="文章标题" />
                <asp:BoundField DataField="N_From" HeaderText="文章来源" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="">编辑</a>
                    </ItemTemplate>
                    <HeaderTemplate>
                       编辑
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
