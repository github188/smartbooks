<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicList.aspx.cs" Inherits="road_PicList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>��ҳ</title>
    <link href="../style/road.css" rel="stylesheet" type="text/css" />
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--ͨ��ͷ��-->
        <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
        <div id="main2">
          <div class="right wid580">
            <div class="weizhi">����λ�ã�<a href="../index.aspx">��ҳ</a>>><a href="Road_Index.aspx"><%=ViewState["Remark"] %></a>>><a href="PicList.aspx?tid=<%=ViewState["tid"] %>"><%=ViewState["TName"] %></a></div>
   	        <div class="pages">
                <ul class="piclist">                
                    <asp:Repeater ID="Repeater_Pic" runat="server">
                      <ItemTemplate>
                        <li>
                            <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>">
                                <img alt="<%#Eval("N_Title") %>" src='../newsimages/<%#Eval("N_ImgView") %>' width="261" height="196" />
                            </a>
                            <a href="Page.aspx?id=<%#Eval("N_ID") %>" title="<%#Eval("N_Title") %>">
                                <%#PubClass.Tool.SubString(Eval("N_Title").ToString(),8) %>
                            </a>
                        </li>
                      </ItemTemplate>
                    </asp:Repeater>  
                 </ul>
                <div class="clear"></div>
               <div class="fanye">
                 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
                 </webdiyer:AspNetPager>
               </div>
   	        </div>    
       </div>
          <div class="wid210">
            <div class="search2">
              <p style=" margin:5px 0 0 20px; color:#FFF; font-weight:bold;">վ������&nbsp;
                <input name="search" size="18" type="text" style="border:1px #06c solid;"/>
              </p>
              <p style="margin-left:60px;margin-top:10px;">
                <input name="search2" value=" ���� "type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
                &nbsp;&nbsp;
                <input name="search2" value="�߼�����"type="button" style="background:url(../images/search_btn2.jpg) no-repeat; width:59px; height:22px; overflow:hidden;" />
              </p>
            </div>
          </div>
        </div>
        <!--ͨ�õײ�-->
        <div style=" width:800px; margin:0 auto;"><iframe src="../CommonButtom.aspx" scrolling="no" frameborder="0" style="margin:0 auto; width:800px; height:50px; overflow:hidden;"></iframe></div>
    </form>
</body>
</html>
