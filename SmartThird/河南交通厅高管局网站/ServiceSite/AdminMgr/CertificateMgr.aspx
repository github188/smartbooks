<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertificateMgr.aspx.cs" Inherits="AdminMgr_CertificateMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ISO国际标准化认证证书管理</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div  class="righttopnavbg">ISO国际标准化认证证书管理</div>
     <div style=" margin:0 auto; width:605px;">
      <div style=" line-height:15px; text-align:right" >
            &nbsp;<asp:HyperLink ID="linkAddTitle" runat="server" CssClass="Font13Add" NavigateUrl="AddCertificate.aspx">添加证书</asp:HyperLink></div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="600px"  HeaderStyle-Height="25px" HeaderStyle-BackColor="#6298e1" RowStyle-BackColor="#ebf2f9" RowStyle-Height="20" RowStyle-HorizontalAlign="center" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField ItemStyle-Width="200px">
                    <ItemTemplate>
                        <img src="../CertificateImg/<%# CommonFunction._GetMidInfo(DataBinder.Eval(Container.DataItem,"N_Title").ToString(),"[","]")  %>" alt="ISO认证证书" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        ISO认证证书图片
                    </HeaderTemplate>
                   
                </asp:TemplateField>
                <asp:BoundField HeaderText="证书简介" DataField="N_Content" >
                </asp:BoundField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ItemStyle-Width="120px" />
            </Columns>
            <RowStyle BackColor="#EBF2F9" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Height="25px" />
        </asp:GridView>
	    </div>
    </form>
</body>
</html>
