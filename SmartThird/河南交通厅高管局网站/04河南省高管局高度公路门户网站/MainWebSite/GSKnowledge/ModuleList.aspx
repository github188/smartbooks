<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModuleList.aspx.cs" Inherits="GSKnowledge_ModuleList" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>高速知识列表-河南省交通运输厅高速公路管理局门户网站</title>
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
        	<dl class="answer_list">
            	<dt>
                    <asp:Label ID="lblModule" runat="server" Text=""></asp:Label></dt>
                <asp:Repeater ID="rptArticle" runat="server">
                <ItemTemplate>
                 <dd><a href='ViewArticle.aspx?kaid=<%# Eval("KA_ID") %>' title='<%# Eval("KA_Title") %>'><%# PubClass.Tool.SubString(Eval("KA_Title").ToString(),34)%></a></dd>
                </ItemTemplate>
                </asp:Repeater>
                
            </dl>
            <div class="fanye">
             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
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
