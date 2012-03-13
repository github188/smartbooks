<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NegativeComments.aspx.cs" Inherits="SmartPomsApp.poms.NegativeComments" %>

<%@ Register src="ascx/NegativeComments.ascx" tagname="NegativeComments" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>负面评论--网络舆情监控平台</title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:NegativeComments ID="NegativeComments1" runat="server" />
    </form>
</body>
</html>
