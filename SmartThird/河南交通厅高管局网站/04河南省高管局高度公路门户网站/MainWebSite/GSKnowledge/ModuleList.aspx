<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModuleList.aspx.cs" Inherits="GSKnowledge_ModuleList" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����֪ʶ�б�-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
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
             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
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
