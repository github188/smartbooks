﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RatingDissemination.aspx.cs" Inherits="SmartPomsApp.poms.RatingDissemination" %>

<%@ Register src="ascx/RatingDissemination.ascx" tagname="RatingDissemination" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>按传播范围评测--网络舆情监控平台</title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:RatingDissemination ID="RatingDissemination1" runat="server" />
    </form>
</body>
</html>
