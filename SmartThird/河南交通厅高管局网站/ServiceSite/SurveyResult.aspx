<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyResult.aspx.cs" Inherits="SurveyResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"> 
    <title>服务区用户在线满意度调查</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <%
        Model.ServiceInfo info = (Model.ServiceInfo)Session["serviceinfo"];
         %>
    <img alt="" src="pie.ashx?type=bar&serviceid=<%=info.S_ID %>" />
    </div>
    </form>
</body>
</html>
