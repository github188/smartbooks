<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountMedia.aspx.cs" Inherits="SmartPomsApp.poms.CountMedia" %>

<%@ Register src="ascx/CountMedia.ascx" tagname="CountMedia" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>按媒体统计--网络舆情监控平台</title>
</head>
<body>
    <form id="form1" runat="server">

    <uc1:CountMedia ID="CountMedia1" runat="server" />

    </form>
</body>
</html>
