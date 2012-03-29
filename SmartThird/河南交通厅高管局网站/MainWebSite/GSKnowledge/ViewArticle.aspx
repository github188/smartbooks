<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewArticle.aspx.cs" Inherits="GSKnowledge_ViewArticle" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Title"]%>-<%=((DataTable)ViewState["dtArticle"]).Rows[0]["KM_Name"]%>-高速知识-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="../style/zhishi.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="list_bg">
    	<!--返回高速知识-->
  <div class="left left1"><a href="index.html">返回高速知识</a></div>
    <!--问题列表-->
    	<div class="left left2">
        	<dl class="wenti_list">
            	<dt>高速知识</dt>
                <asp:Repeater ID="rptModule" runat="server" OnItemCommand="rptModule_ItemCommand">
                <ItemTemplate>
                   <dd><asp:LinkButton ID="btnModule" runat="server" CommandName='<%# Eval("KM_Name") %>' CommandArgument='<%# Eval("KM_ID") %>' ToolTip='<%# Eval("KM_Name") %>'><%# PubClass.Tool.SubString(Eval("KM_Name").ToString(), 23)%></asp:LinkButton></dd>
                </ItemTemplate>
                </asp:Repeater>
            </dl>
    </div>
        <!--单个问题列表-->
  <div class="left left3">
   		<div class="page_name"><%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Title"] %></div>
        <div class="page_btn"><a href='javascript:window.history.go(-1);'>返回上页</a><a href="javascript:window.print();">打印本页</a></div>
        <div class="page_con">
        <%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Content"] %>
        </div>
    </div>
    <!--标签-->
    <div class="left left4"><a href="#">我<br />要<br />提<br />问</a> 
</div>
    <div class="clear"></div>
</div>
    </form>
</body>
</html>
