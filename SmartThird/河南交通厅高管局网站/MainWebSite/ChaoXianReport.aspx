<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChaoXianReport.aspx.cs" Inherits="ChaoXianReport" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
     <title>河南省高速公路超限运输审批情况表-河南省交通运输厅高速公路管理局门户网站</title>
     <link href="style/all.css" rel="stylesheet" type="text/css" />
     <link href="style/default.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
        table,tr,td{border:1px solid #E3E3E3;}
        .tr_header1{height:22px; background:#efefef;}
        .tr1{height:22px;}
        .tr2{height:22px; background:#F0F0F0;}
        .fengye{text-align:center;}
   /*拍拍网风格*/
.paipai { font: 11px Arial, Helvetica, sans-serif;padding:5px 0px 5px 0px; margin: 0px;}    
.paipai a {padding: 3px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}    
.paipai a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}    
.paipai .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}    
.paipai a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
     </style>
</head>
<body>
    <form id="form1" runat="server">
     <!--通用头部-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    <div id="main2">
    <div class="contact_weizhi"><a href="index.aspx">首页</a> >> 河南省高速公路超限运输审批情况表</div>
    
    <table width="800px"  align="center" cellpadding="0" cellspacing="0" style="text-align:center; border-collapse:collapse; margin-top:10px;">
  <tr class="tr_header1">
    <td width="60" rowspan="2">车牌号</td>
    <td colspan="3">车货总尺寸(米)</td>
    <td width="70" rowspan="2">货物名称</td>
    <td width="50" rowspan="2">车货总<br />
    重(T)</td>
    <td rowspan="2">通行路线</td>
    <td width="80" rowspan="2">办理时间</td>
    <td width="85" rowspan="2">通行时间</td>
    <td width="110" rowspan="2">运输单位</td>
    <td width="70" rowspan="2">通行证编号</td>
    <td width="50" rowspan="2">备注</td>
  </tr>
  <tr class="tr_header1">
    <td width="30">长</td>
    <td width="30">宽</td>
    <td width="30">高</td>
      
  </tr>
  <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
     <tr class="tr1">
    <td><%# Eval("OI_LicencePlate") %></td>
    <td><%# Eval("OI_Length") %></td>
    <td><%# Eval("OI_Width") %></td>
    <td><%# Eval("OI_Heigth") %></td>
    <td><%# Eval("OI_GoodsName") %></td>
    <td><%# Eval("OI_Weight")%></td>
    <td><%# Eval("OI_Path") %></td>
    <td><%# Eval("OI_CreateDate").ToString().Replace(" 0:00:00","") %></td>
    <td><%# Eval("OI_PassDate") %></td>
    <td><%# Eval("OI_TransUnit") %></td>
    <td><%# Eval("OI_PassCode") %></td>
    <td><%# Eval("OI_Remark") %></td>
  </tr>
  </ItemTemplate>
  <AlternatingItemTemplate>
    <tr class="tr2">
    <td><%# Eval("OI_LicencePlate") %></td>
    <td><%# Eval("OI_Length") %></td>
    <td><%# Eval("OI_Width") %></td>
    <td><%# Eval("OI_Heigth") %></td>
    <td><%# Eval("OI_GoodsName") %></td>
    <td><%# Eval("OI_Weight")%></td>
    <td><%# Eval("OI_Path") %></td>
    <td><%# Eval("OI_CreateDate").ToString().Replace(" 0:00:00", "") %></td>
    <td><%# Eval("OI_PassDate") %></td>
    <td><%# Eval("OI_TransUnit") %></td>
    <td><%# Eval("OI_PassCode") %></td>
    <td><%# Eval("OI_Remark") %></td>
  </tr>
  </AlternatingItemTemplate>
  </asp:Repeater>
</table>
  <div class="fengye" style="text-align:center;">
          <asp:Panel ID="dataMsg" runat="server">
              <div style=" width:100%; height:30px; line-height:30px; text-align:center; color:#F00">抱歉,暂无数据!</div>
           </asp:Panel>
          <webdiyer:AspNetPager CssClass="paipai" CurrentPageButtonClass="cpb" 
                ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"   
                Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="40" 
                PrevPageText="上一页"   ShowBoxThreshold="11" TextAfterInputBox="" 
                TextBeforeInputBox=""
                onpagechanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>   
      </div>  
     <!--通用底部-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
