<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sue.aspx.cs" Inherits="station_Sue" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����Ͷ��-�շѹ���-����ʡ��ͨ���������ٹ�·������Ż���վ</title>
    <link href="../style/station.css" rel="stylesheet" type="text/css" />
    <link href="../style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!--ͨ��ͷ��-->
            <div style=" width:800px; margin:0 auto;"><iframe src="../CommonTop.aspx" scrolling="no" frameborder="0" style=" margin:0 auto; width:800px; height:253px; overflow:hidden;"></iframe></div>
            
            <div id="main2">
              <div class="right wid580">
                <div class="weizhi">����λ�ã�<a href="../index.aspx">��ҳ</a> >> <a href="Station_Index.aspx">�շѹ���</a> >> ����Ͷ��</div>
                <div class="pages">
                  <div class="page_con">
                      <asp:Repeater ID="rpt_Complain" runat="server">
                        <ItemTemplate>
                            <div class="mess_con">
    	                        <div class="say">
        	                        <div class="say_date"><p class="right mar_r20"><%#Eval("SC_CreateTime") %></p><span class="blue"><%#Eval("SC_CptName")%></span> </div>
                                    <p class="say_con"><%#Eval("SC_CptContent") %></p>
                                </div>
                                <div class="answer"><span class="blue">����Ա�ظ���</span><%#Eval("SC_Reply") %></div>
                             </div>
                        </ItemTemplate>
                      </asp:Repeater>
                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="10" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
                 <div style="margin-top:20px; font-size:14px; color:#C00; font-weight:bold; text-align:center;">������дͶ������</div>
                  <div class="tousu_cons">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                         <table width="90%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <th width="18%" style="height: 21px">�շ�վ���ƣ�</th>
                        <td width="82%" style="height: 21px">
                            <asp:DropDownList ID="ddlStation" runat="server" Width="298px">
                            </asp:DropDownList><span></span></td>
                      </tr>
                      <tr>
                        <th>Ͷ���ˣ�</th>
                        <td>
                            <asp:TextBox ID="txtRen" CssClass="tousu_bor" Width="294px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <th valign="top" style="height: 69px">���ݣ�</th>
                       <td style="height: 69px">
                            <asp:TextBox ID="txtContent" CssClass="tousu_bor" Width="294px" runat="server" Height="74px" TextMode="MultiLine"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <th>�绰��</th>
                        <td>
                            <asp:TextBox ID="txtPhone" CssClass="tousu_bor" Width="294px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <th style="height: 23px">��ַ��</th>
                        <td style="height: 23px">
                            <asp:TextBox ID="txtAddress" CssClass="tousu_bor" Width="294px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Button__Submit" runat="server" Text="�ύ" CssClass="tousu_btn" OnClick="Button__Submit_Click" /> 
                            <asp:Button ID="Button_Reset" runat="server" Text="����" CssClass="tousu_btn" OnClick="Button_Reset_Click" />
                        </td>
                      </tr>
                    </table>
                      </ContentTemplate>
                      </asp:UpdatePanel>
                    </div>
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
