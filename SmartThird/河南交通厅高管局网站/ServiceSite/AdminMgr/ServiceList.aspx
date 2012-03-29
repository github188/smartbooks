<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceList.aspx.cs" Inherits="AdminMgr_ServiceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区列表</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    fieldset{ border:1px solid #448CCB;width:800px;margin:auto;}
    legend{ font-size:12px; color:#448CCB;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div  class="righttopnavbg"><p style="height:25px;"><img src="images/ico07.gif" width="20" height="18" /><span style="font-size:12px"> 按名称查询：</span><asp:TextBox ID="txtName" runat="server" CssClass="InputBorderStyle" Width="120px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/AdminMgr/images/btnSearch.jpg" ImageAlign="absmiddle" OnClick="ImageButton1_Click"  /></p></div>
    <div  class="divContent">
     <fieldset>
       <legend>服务区列表</legend>
       <div class="ServiceList">
       <ul>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <li><a href='EditServiceInfo.aspx?sid=<%# Eval("S_ID") %>'><%# Eval("S_Name") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
	</ul>
    </div>
    </fieldset>
	</div>
    </form>
</body>
</html>
