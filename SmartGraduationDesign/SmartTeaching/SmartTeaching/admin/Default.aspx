<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartTeaching.admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理中心</title>
</head>
<frameset rows="50,*"  frameborder="no" frameborder="1" framespacing="0">
	<frame src="top.aspx" noresize="noresize" frameborder="1" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="tops" />
  <frameset cols="184,*"   id="frame">
	<frame src="left.aspx" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="1" scrolling="no" target="lefts" />
	<frame src="right.aspx" name="main" marginwidth="0" marginheight="0" frameborder="1" scrolling="auto" target="main" />
  </frameset>
<noframes>
  <body></body>
    </noframes>
</html>
