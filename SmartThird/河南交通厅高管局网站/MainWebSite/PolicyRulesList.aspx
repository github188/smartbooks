<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyRulesList.aspx.cs" Inherits="PolicyRulesList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>-<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Remark"]%>-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="style/all.css" rel="stylesheet" type="text/css" />
<link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <!--ͨ��ͷ��-->
    <div style=" width:800px; margin:0 auto;"><iframe src="CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
    
    
    
    <div id="main2">
	<div class="right wid580">
    	<div class="weizhi">����λ�ã�<a href="index.aspx">��ҳ</a> >> <a href="PolicyRulesList.aspx?tid=50"><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Remark"]%></a> >> <%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%></div>
        <ul class="alllist">
            <asp:Repeater ID="rptzcfg" runat="server">
              <ItemTemplate>
                <li><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString())%>]</span><a href='PolicyRuleInfo.aspx?nid=<%#  Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),37)%> </a></li>
              </ItemTemplate>
            </asp:Repeater>  
        </ul>
        <div class="fanye">
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
    </div>
    <div class="wid210">
    	<div class="search2"><p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">վ������&nbsp;<input name="search" size="18" type="text" style="border:1px #06c solid;"/></p><p style="margin-left:60px;margin-top:10px;"><input name="search" value=" ���� "type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />&nbsp;&nbsp;<input name="search" value="�߼�����"type="button" style="background:url(images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" /></p></div>
        
        <div class="zhengce mar_t10">
        	<dl>
            	<dt></dt>
                <dd>
                	<ul class="lanmulist">
                    	<li><asp:LinkButton ID="LinkButton1" runat="server" CommandName="rulenav" CommandArgument="50" OnCommand="LinkButton1_Command">���ҷ���</asp:LinkButton></li>
                    	<li><asp:LinkButton ID="LinkButton2" runat="server" CommandName="rulenav" CommandArgument="51" OnCommand="LinkButton1_Command">ʡ��������</asp:LinkButton></li>
                    	<li><asp:LinkButton ID="LinkButton3" runat="server" CommandName="rulenav" CommandArgument="52" OnCommand="LinkButton1_Command">��ҵ������</asp:LinkButton></li>
                    	<li><asp:LinkButton ID="LinkButton4" runat="server" CommandName="rulenav" CommandArgument="53" OnCommand="LinkButton1_Command">�޸ķ���</asp:LinkButton></li>
                    </ul>
                </dd>
                <dd class="lanmu_b"></dd>
            </dl>
        </div>
    </div>
</div>
    
    
    
     <!--ͨ�õײ�-->
     <div style=" width:800px; margin:0 auto;"><iframe src="CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
