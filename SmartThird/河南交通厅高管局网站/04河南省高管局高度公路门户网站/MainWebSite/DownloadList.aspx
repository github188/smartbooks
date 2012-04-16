<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadList.aspx.cs" Inherits="DownloadList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>文件下载-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .down{width:560px;margin:0 auto; padding:1px; border:1px #CCC solid;}
    .down_name{text-align:center; background:#bee7e7; height:26px; line-height:26px; color:#06C;}
    .down_r{float:right; width:100px; color:#06C; height:26px; line-height:26px; border-left:1px #FFF solid;}
    tr{background-color:expression((this.sectionRowIndex%2==0)?"#fff":"#eee")}
    td{ height:24px; padding-left:1em;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!--通用头部-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    <div id="main2">
  <div class="right wid580">
    <div class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 文件下载</div>
    	<div class="down">
        <div class="down_name"><p class="down_r">发布日期</p>文件下载列表</div>
    	<table width="560" cellspacing="0" cellpadding="0">
          
         
            <asp:Repeater ID="rptDownload" runat="server">
            <ItemTemplate>
              <tr>
            <td width="472"><a href='DownLoad/<%# Eval("FD_Path") %>' title='<%# Eval("FD_Title") %>'><%# PubClass.Tool.SubString(Eval("FD_Title").ToString(),35)%></a></td>
            <td width="86">[<%# PubClass.Tool.Get_ShortDate(Eval("FD_CreateDate").ToString())%>]</td>
          </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="472"><a href='DownLoad/<%# Eval("FD_Path") %>' title='<%# Eval("FD_Title") %>'><%# PubClass.Tool.SubString(Eval("FD_Title").ToString(),35)%></a></td>
            <td width="86">[<%# PubClass.Tool.Get_ShortDate(Eval("FD_CreateDate").ToString())%>]</td>
          </tr>
            </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
		</div>
        <div class="fanye">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
  </div>
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">站内搜索&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" 搜索 "type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="高级搜索"type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
  </div>
</div>
    
    
     <!--通用底部-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
