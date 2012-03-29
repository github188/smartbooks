<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageBoard.aspx.cs" Inherits="MessageBoard" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>高速留言-河南省交通运输厅高速公路管理局门户网站</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <!--通用头部-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
   
   
   <div id="main2">
  <div class="right wid580">
    <div class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 高速留言</div>
    	<!--<div style="text-align:center;"><img src="images/liuyan.gif" width="62" height="30" /></div>-->
         <div id="liuyan">
             <asp:Repeater ID="rpt_Mess" runat="server">
             <ItemTemplate>
               <div class="say"><%# Eval("M_Content") %></div>
            <div class="bgfff">姓名：<%# Eval("M_UName") %> 我的电话：<%# Eval("M_Phone") %>    留言时间：<%# PubClass.Tool.Get_ShortDate(Eval("M_Time").ToString())%>  管理员回复时间：<%# PubClass.Tool.Get_ShortDate(Eval("M_RTime").ToString())%> </div>
            <div class="ans"><%# Eval("M_Reply") %></div>  
             </ItemTemplate>
             </asp:Repeater>
                <div class="fanye">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="5" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
                </div>
    </div>
  
    <p class="align mar_t30"><img src="images/liuyan.gif" width="62" height="30" /></p>
   <div class="liuyan_con">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
           <table width="578" border="0" cellspacing="0" cellpadding="0" style="margin:20px auto;">
        <tr>
          <td width="125" align="right">您的姓名：</td>
          <td width="453" >
              <asp:TextBox ID="txtUName" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
          
        </tr>
        <tr>
          <td align="right">电子邮件：</td>
          <td><asp:TextBox ID="txtEMail" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        <tr>
          <td align="right">联系电话：</td>
          <td><asp:TextBox ID="txtPhone" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        
        <tr>
          <td align="right" valign="top" style="height: 38px">留言内容：</td>
          <td style="height: 38px"><asp:TextBox ID="txtContent" runat="server" CssClass="bor" TextMode="multiLine" Height="80px" Width="401px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>
          <asp:Button ID="btnSubmit" runat="server" Text=" 提交 " CssClass="liuyan_btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnReset" runat="server" Text=" 重置 " CssClass="liuyan_btn" OnClick="btnReset_Click" />
          </td>
        </tr>
      </table>
       </ContentTemplate>
       </asp:UpdatePanel>
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
