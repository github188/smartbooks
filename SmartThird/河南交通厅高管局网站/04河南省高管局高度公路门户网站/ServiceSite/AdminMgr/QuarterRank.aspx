<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuarterRank.aspx.cs" Inherits="AdminMgr_QuarterRank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区季度排名</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">服务区季度排名</div>
     <div style=" margin:0 auto; width:605px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="600"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField HeaderText="服务区名称" DataField="S_Name" ReadOnly="True" >
                    
                </asp:BoundField>
                <asp:BoundField HeaderText="排名" DataField="S_QuarterRank" >
                    <ItemStyle Width="120px" />
                </asp:BoundField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ItemStyle-Width="120" />
            </Columns>
            <RowStyle BackColor="#EBF2F9" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Height="25px" />
        </asp:GridView>
	    </div>
    </form>
</body>
</html>
