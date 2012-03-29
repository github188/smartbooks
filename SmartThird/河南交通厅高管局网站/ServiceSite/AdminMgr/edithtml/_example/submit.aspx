<%@ Page language="VB" AutoEventWireup="false" validateRequest="False"%>

<%
Dim sContent1, i
sContent1 = Request.Form("content1")

Response.Write ("编辑内容如下：<br><br>" & sContent1)
Response.Write ("<br><br><p><input type=button value=' 退回 ' onclick='history.back()'></p>")
%>