<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="report_menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>述职述廉述学报告列表</title>
    <link href="../style/all.css" rel="stylesheet" type="text/css" />
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <dl class="shuzhi mar_t10" style="width:210px; overflow:hidden; margin-left:5px;">
        <dt style="font-size:12px;">厅高管局领导述职述廉述学报告</dt>
        <dd>
          <ul class="lanmulist">
              <asp:Repeater ID="rptReportList" runat="server">
              <ItemTemplate>
                <li><a href='../workexpress/<%# Eval("N_ImgPath") %>' target="contentFrame"><%# Eval("N_Title") %></a></li>
              </ItemTemplate>
              </asp:Repeater>
          </ul>
        </dd>
        <dd class="lanmu_b"></dd>
      </dl>

    </form>
</body>
</html>
