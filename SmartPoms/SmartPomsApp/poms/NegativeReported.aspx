<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NegativeReported.aspx.cs"
    Inherits="SmartPomsApp.poms.NegativeReported" %>

<%@ Register Src="ascx/NegativeReported.ascx" TagName="NegativeReported" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>负面报道--网络舆情监控平台</title>
    <style type="text/css">
        #jqpageresultitem{width:600px; float:left; overflow:hidden; margin-bottom:20px; font-size:small; color:#222;}
        #jqpageresultitem a{ color:#00F; cursor:pointer; text-decoration:underline; float:left;}
        #jqpageresultitem em{color:#F00; font-style:normal;}
        #jqpageresultitem p{ width:600px; float:left; overflow:hidden; line-height:20px; font-size:small;}
        #jqpageresultitem b{font-weight: bold;#2222; font-family: arial,sans-serif;}
        #jqpageresultitemtitle{ width:600px; height:25px; line-height:25px; font-size:medium; float:left; overflow:hidden;}	
        #jqpageresultitemreferer{ color:#093; font-style:normal; float:left; margin-right:6px;}
        #jqpageresultitempublishdate{ color:#666; float:left;}
        #jqpageresultiteminfo{ list-style:disc; list-style:inside; float:left; width:600px; height:20px; margin:0px; padding:0px; overflow:hidden;}
        #jqpageresultiteminfo li{ float:left;  height:20px; line-height:20px; color:#666; padding-right:10px;}
        #jqpageresultitemrelated{ list-style:none; float:left; width:600px; margin:0px; padding:0px; overflow:hidden;}
        #jqpageresultitemrelated li{float:left; width:570px; padding-left:30px; height:18px; line-height:18px;}
        #jqpageresultitemrelated li a{ text-decoration:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:NegativeReported ID="NegativeReported1" runat="server" />
    </form>
</body>
</html>
