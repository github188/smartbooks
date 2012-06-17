<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrafficManager.aspx.cs" Inherits="SmartHyd.ManageCenter.Traffic.TrafficManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>·����Ϣ����-����·��</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
             font-family:΢���ź�;
        }
        .TableHeader
        {
            font-weight: bold;
            color: #ffffff;
        }
        .titlebar{ height:20px;line-height:20px;  text-align:right; font-weight:bold;
        }
        .td_content{height:24px; line-height:24px;}
    </style>

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function IllageOverloadReport() {
            window.location.href = "TrafficReported.aspx";
        }

        function search() {
            alert('ϵͳû�м������������������ݣ�');
        }

        function exportexcel() {
            alert('ϵͳû�м�����·����Ϣ���ݣ��޷�����Excel����');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
             <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã�����·����·����Ϣ����</span></div>
             <div class="ReturnPreview"><span id="buttons" onclick="IllageOverloadReport()" style="cursor:hand;"><img src="../../Images/icons/trafficreport.png" alt="" border="0" />·����Ϣ�ϱ�</span></div>
        </div>
        <table width="100%" border="0" cellspacing="1" cellpadding="0" style=" background-color:#82aadf">
  <tr>
    <td width="100px" bgcolor="white" class="titlebar">·�����ͣ�</td>
    <td bgcolor="white" colspan="3">
        <asp:RadioButton ID="RadioButton1" runat="server" Text="ȫ��·��" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="����·��" />
        <asp:RadioButton ID="RadioButton3" runat="server" Text="����·��" />
        <asp:RadioButton ID="RadioButton4" runat="server" Text="����·��" />
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">�������ߣ�</td>
    <td bgcolor="white"><asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
        </asp:DropDownList></td>
    <td bgcolor="white" class="titlebar">·�Σ�</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">�ϱ���λ��</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList3" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
    <td bgcolor="white" class="titlebar">���ԭ��</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList4" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">�ϱ�ʱ�䣺</td>
    <td bgcolor="white">
        <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>
        ��
        <asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>
      </td>
    <td bgcolor="white" class="titlebar">��Ϣ״̬��</td>
    <td bgcolor="white">
        <asp:RadioButton ID="RadioButton5" runat="server" Text="��ʱ��Ϣ" />
        <asp:RadioButton ID="RadioButton6" runat="server" Text="��ʷ��Ϣ" />
        <asp:RadioButton ID="RadioButton7" runat="server" Text="��Ч��Ϣ" />
      </td>
  </tr>
  <tr>
    <td bgcolor="white" colspan="4" class="titlebar">
    <div id="menu">
        <span id="buttons" style="cursor:hand;" onclick="search()">
            <img src="../../Images/icons/search.png" />��Ϣ����</span>&nbsp;
            <span id="buttons" style="cursor:hand;padding-right:10px;" onclick="exportexcel()">
            <img src="../../Images/icons/excel.png" />����Excel</span>
        </div>
    </td>
  </tr>
</table>


        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #045185">
                    <tr class="TableHeader" align="center">

                        <td width="60px"  style="border-right:1px solid #ffffff;">
                            ���
                        </td>
                        <td width="120px" style="border-right:1px solid #ffffff;">
                            ��Ϣ״̬
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ·�߱��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ·������
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ��ֹλ��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ·������
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ���ԭ��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            �ϱ���λ
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            �ϱ�ʱ��
                        </td>
                        <td width="150px" style="border-right:1px solid #ffffff;">
                            ����
                        </td>
                    </tr>
                <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <tr class="TableLine1" align="center">
                        <td style="background-color: #ffffff;">
                            <%# Eval("username")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("jobnumber")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("jobnumber")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("realname")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <a href="../../ManageCenter/Empower.aspx?userid=<%# Eval("userid")%>&name=<%# Eval("username")%>">��ϸ</a>&nbsp;
                            <a href="UserEdit.aspx?action=update&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">�༭</a>&nbsp;
                            <a href="UserCenter.aspx?action=del&userid=<%# Eval("userid")%>">ɾ��
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
    </table>
    <asp:Literal ID="litmsg" Visible="false" Text="<div class='msg'>���޸���·����Ϣ</msg>" runat="server"></asp:Literal>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%PageCount%ҳ����ǰΪ��%CurrentPageIndex%ҳ"
        FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="TextBox"
        PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
        TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanging="AspNetPager1_PageChanging"
        PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
    </webdiyer:AspNetPager>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
