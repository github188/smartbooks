<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewArticle.aspx.cs" Inherits="GSKnowledge_ViewArticle" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Title"]%>-<%=((DataTable)ViewState["dtArticle"]).Rows[0]["KM_Name"]%>-����֪ʶ-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/zhishi.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="list_bg">
    	<!--���ظ���֪ʶ-->
  <div class="left left1"><a href="index.html">���ظ���֪ʶ</a></div>
    <!--�����б�-->
    	<div class="left left2">
        	<dl class="wenti_list">
            	<dt>����֪ʶ</dt>
                <asp:Repeater ID="rptModule" runat="server" OnItemCommand="rptModule_ItemCommand">
                <ItemTemplate>
                   <dd><asp:LinkButton ID="btnModule" runat="server" CommandName='<%# Eval("KM_Name") %>' CommandArgument='<%# Eval("KM_ID") %>' ToolTip='<%# Eval("KM_Name") %>'><%# PubClass.Tool.SubString(Eval("KM_Name").ToString(), 23)%></asp:LinkButton></dd>
                </ItemTemplate>
                </asp:Repeater>
            </dl>
    </div>
        <!--���������б�-->
  <div class="left left3">
   		<div class="page_name"><%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Title"] %></div>
        <div class="page_btn"><a href='javascript:window.history.go(-1);'>������ҳ</a><a href="javascript:window.print();">��ӡ��ҳ</a></div>
        <div class="page_con">
        <%=((DataTable)ViewState["dtArticle"]).Rows[0]["KA_Content"] %>
        </div>
    </div>
    <!--��ǩ-->
    <div class="left left4"><a href="#">��<br />Ҫ<br />��<br />��</a> 
</div>
    <div class="clear"></div>
</div>
    </form>
</body>
</html>
