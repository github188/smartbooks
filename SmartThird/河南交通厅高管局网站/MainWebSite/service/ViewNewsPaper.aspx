<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNewsPaper.aspx.cs" Inherits="service_ViewNewsPaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>浏览报刊-行业报刊-服务区管理-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/service.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

        /*Default CSS for pan containers*/
        .pancontainer{
        position:relative; /*keep this intact*/
        overflow:hidden; /*keep this intact*/
        width:100%;
        height:1500px;
        margin-top:5px;
        }

</style>
<script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript" src="../js/imagepanner.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="hybk_page_t_bg">
	<div class="hybk_page_t_l">
    	<div class="hybk_page_t_r">
    	<div class=" hybk_weizhi">
    	    您的位置：&nbsp;<asp:Label ID="lblPosition" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;
            <asp:LinkButton ID="btnPage1" runat="server" OnClick="btnPage1_Click">第A01版</asp:LinkButton>&nbsp;&nbsp;
    	    <asp:LinkButton ID="btnPage2" runat="server" OnClick="btnPage2_Click">第A02版</asp:LinkButton>&nbsp;&nbsp;
    	    <asp:LinkButton ID="btnPage3" runat="server" OnClick="btnPage3_Click">第A03版</asp:LinkButton>&nbsp;&nbsp;
    	    <asp:LinkButton ID="btnPage4" runat="server" OnClick="btnPage4_Click">第A04版</asp:LinkButton>&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>第A01版</asp:ListItem>
                <asp:ListItem>第A02版</asp:ListItem>
                <asp:ListItem>第A03版</asp:ListItem>
                <asp:ListItem>第A04版</asp:ListItem>
            </asp:DropDownList>
          </div>
    </div>
    </div>
    
    <div class="pancontainer" >
    <asp:Image ID="NewsImg"  runat="server"  />
    </div>
</div>



    </form>
</body>
</html>
