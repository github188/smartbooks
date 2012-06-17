<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IllegalOverloadManage.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.IllegalOverloadManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>�Ƿ����޳�����Ϣ����-��������</title>
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
        .style1
        {
            width: 76px;
        }
        .TableHeader
        {
            font-weight: bold;
            color: #ffffff;
        }
    </style>

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function IllageOverloadReport() {
            window.location.href = "EditIlleglOverload.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
             <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã����������Ƿ����س�����Ϣ����</span></div>
             <div class="ReturnPreview"><span id="buttons" onclick="IllageOverloadReport()" style="cursor:hand;"><img src="../../Images/icons/overloadreported.png" alt="" border="0" />�Ƿ����س����ϱ�</span></div>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #045185">
                    <tr class="TableHeader" align="center">
                        <td style="border-right:1px solid #ffffff;">
                            <asp:CheckBox ID="Checkall" runat="server" Text="ȫѡ" OnClick="javascript:selectall(this);" />
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            �鴦ʱ��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            �鴦�ص�
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ��վվ��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ��վʱ��
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ����������λ
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            �鴦��λ
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            ����
                        </td>
                    </tr>
                <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <tr class="TableLine1" align="center">
                        <td style="background-color: #ffffff;">
                            <asp:CheckBox ID="CheckSingle" runat="server" />
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("username")%>
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
                            <a href="../../ManageCenter/Empower.aspx?userid=<%# Eval("userid")%>&name=<%# Eval("username")%>">��ϸ</a>&nbsp;
                            <a href="UserEdit.aspx?action=update&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">�༭</a>&nbsp;
                            <a href="UserCenter.aspx?action=del&userid=<%# Eval("userid")%>">ɾ��
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
    </table>
    <asp:Literal ID="litmsg" Visible="false" Text="<div class='msg'>���޷Ƿ����س���ͨ����Ϣ</msg>" runat="server"></asp:Literal>
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
