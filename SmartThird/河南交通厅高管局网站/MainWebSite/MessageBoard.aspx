<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageBoard.aspx.cs" Inherits="MessageBoard" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>��������-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <!--ͨ��ͷ��-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
   
   
   <div id="main2">
  <div class="right wid580">
    <div class="weizhi">����λ�ã�<a href="index.aspx">��ҳ</a> >> ��������</div>
    	<!--<div style="text-align:center;"><img src="images/liuyan.gif" width="62" height="30" /></div>-->
         <div id="liuyan">
             <asp:Repeater ID="rpt_Mess" runat="server">
             <ItemTemplate>
               <div class="say"><%# Eval("M_Content") %></div>
            <div class="bgfff">������<%# Eval("M_UName") %> �ҵĵ绰��<%# Eval("M_Phone") %>    ����ʱ�䣺<%# PubClass.Tool.Get_ShortDate(Eval("M_Time").ToString())%>  ����Ա�ظ�ʱ�䣺<%# PubClass.Tool.Get_ShortDate(Eval("M_RTime").ToString())%> </div>
            <div class="ans"><%# Eval("M_Reply") %></div>  
             </ItemTemplate>
             </asp:Repeater>
                <div class="fanye">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="5" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
                </div>
    </div>
  
    <p class="align mar_t30"><img src="images/liuyan.gif" width="62" height="30" /></p>
   <div class="liuyan_con">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
           <table width="578" border="0" cellspacing="0" cellpadding="0" style="margin:20px auto;">
        <tr>
          <td width="125" align="right">����������</td>
          <td width="453" >
              <asp:TextBox ID="txtUName" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
          
        </tr>
        <tr>
          <td align="right">�����ʼ���</td>
          <td><asp:TextBox ID="txtEMail" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        <tr>
          <td align="right">��ϵ�绰��</td>
          <td><asp:TextBox ID="txtPhone" runat="server" CssClass="bor" Width="400px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        
        <tr>
          <td align="right" valign="top" style="height: 38px">�������ݣ�</td>
          <td style="height: 38px"><asp:TextBox ID="txtContent" runat="server" CssClass="bor" TextMode="multiLine" Height="80px" Width="401px"></asp:TextBox><span class="red mar_l10">*</span></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>
          <asp:Button ID="btnSubmit" runat="server" Text=" �ύ " CssClass="liuyan_btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnReset" runat="server" Text=" ���� " CssClass="liuyan_btn" OnClick="btnReset_Click" />
          </td>
        </tr>
      </table>
       </ContentTemplate>
       </asp:UpdatePanel>
   </div>
  </div>
  
  <div class="wid210">
    <div class="search2">
      <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">վ������&nbsp;
        <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
      </p>
      <p style="margin-left:60px;margin-top:10px;">
        <input name="search2" value=" ���� "type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
        &nbsp;&nbsp;
        <input name="search2" value="�߼�����"type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
      </p>
    </div>
  </div>
</div>
    
    
     <!--ͨ�õײ�-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
