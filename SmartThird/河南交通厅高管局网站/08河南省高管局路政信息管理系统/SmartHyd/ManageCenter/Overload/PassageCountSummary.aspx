<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassageCountSummary.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.PassageCountSummary" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����ͨ�д���ͳ��-��������</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkPositiveInteger(obj) {
            var str = obj.value;
            if (str != "") {
                if (!QDRegEx.CheckPositiveInteger(str)) {
                    alert("�Ƿ�������!");
                    obj.focus();
                    return;
                }
            }
        }

        function CheckFloatValue(obj) {
            var str = obj.value;
            if (str != "") {
                if (!QDRegEx.CheckNonnegativeNumber(str)) {
                    alert("�Ƿ��Ǹ���(С������������λ)!");
                    obj.focus();
                    return;
                }
            }
        }

        function DateValidate() {
            var startDate = $("#txt_startDate").val();
            var endDate = $("#txt_endDate").val();

            if (startDate != "" && endDate != "") {
                startDate = startDate.replace(/-/g, "/");
                endDate = endDate.replace(/-/g, "/");
                startDate = new Date(startDate);
                endDate = new Date(endDate);

                if (Date.parse(startDate) - Date.parse(endDate) > 0) {
                    window.alert("�������� ����С�� ��ʼ����");
                    return false;
                }
            }
        }
     </script>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
        <div id="menu">
            <span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã�������������ͨ��ͨ�д���ͳ��</span>
        </div>
        <div style=" border:5px double #0e2f5c; margin:auto;">
        <table width="730" border="0" cellspacing="0" cellpadding="0" style="font-size:12px; font-weight:bold; margin:auto;">
      <tr>
        <td height="30" align="right" valign="middle" style="width:80px;">��ѯ����</td>
        <td height="30" colspan="5" align="center" valign="middle">
            <asp:RadioButton ID="rdoW" runat="server" GroupName="tj" Text="����" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoW_CheckedChanged" />&nbsp;&nbsp;
            <asp:RadioButton ID="rdoRK" runat="server" GroupName="tj" Text="���վ"  AutoPostBack="true"  oncheckedchanged="rdoW_CheckedChanged"/>&nbsp;&nbsp;
            <asp:RadioButton ID="rdoCK" runat="server" GroupName="tj" Text="����վ"  AutoPostBack="true" oncheckedchanged="rdoW_CheckedChanged" />
        </td>
      </tr>
      <tr>
        <td height="30" align="right" valign="middle" style="width:80px;">��Ӫ��λ��</td>
        <td width="170" height="30" valign="middle">
            <asp:DropDownList ID="ddlCompany" runat="server" Width="170px"></asp:DropDownList>
        </td>
        <td height="30" align="right" valign="middle" style="width:80px;">���ڵ��У�</td>
        <td width="160" height="30" valign="middle">
            <asp:DropDownList ID="ddlCity" runat="server" Width="160px"></asp:DropDownList>
        </td>
        <td height="30" align="right" valign="middle" style="width:80px">ͨ��ʱ�䣺</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txt_startDate" runat="server" Width="68px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>~<asp:TextBox ID="txt_endDate" runat="server" Width="69px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>   
        </td>
      </tr>
      <tr>
        <td height="30" align="right" valign="middle">���ƺţ�</td>
        <td width="170" height="30" valign="middle">
            <asp:TextBox ID="txtVehicleLicense" runat="server" CssClass="input_bor1" Width="166px"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">���վ����</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txtEnterStation" runat="server" CssClass="input_bor1" Width="156px"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">����վ����</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txtOutStation" runat="server" CssClass="input_bor1" Width="156px"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td height="30" align="right" valign="middle">������</td>
        <td width="170" height="30" valign="middle">
            <asp:TextBox ID="txtVehicleAxle" runat="server" CssClass="input_bor1" Width="166px" onblur="checkPositiveInteger(this)"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">����(��)��</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txtStartTotalWeight" runat="server" CssClass="input_bor1" Width="65px" onblur="CheckFloatValue(this)"></asp:TextBox>~<asp:TextBox ID="txtEndTotalWeight" runat="server" CssClass="input_bor1" Width="72px" onblur="CheckFloatValue(this)"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">�����ʣ�</td>
        <td width="160" height="30" valign="middle">
            <asp:DropDownList ID="ddlChaoZaiLv" runat="server" Width="160px"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td height="30" align="center" valign="middle"  colspan="6">
            <asp:Button ID="btnSearch" runat="server" Text=" "  CssClass="btn_search" onclick="btnSearch_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btnExport" runat="server" Text=" "  CssClass="btn_export" onclick="btnExport_Click" />
          </td>
      </tr>
    </table>
    </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div style=" text-align:center; font-size:12px; font-weight:bold;color:Blue;"><img src="../../Images/searching.gif" border="0" />
                ϵͳ���ڽ��г���ͨ�д���ͳ�ƣ����Եȡ���</div>
            </ProgressTemplate>
        </asp:UpdateProgress>
       <div id="reportlist" style="width:100%;  margin-top:0px;  text-align:center;">
            <table cellpadding="0" cellspacing="0" class="txcstj_tab" align="center">
                <asp:Repeater ID="rptTraffic" runat="server">
                    <HeaderTemplate>
                          <tr>
                            <td colspan="2"><p class="txcstj_tit">ȫʡ���ٹ�·ͨ�г��س���ͨ�д���ͳ��</p></td>
                          </tr>
                          <tr class="tit">
                            <td width="250">���ƺ�</td>
                            <td width="250">ͨ�д���</td>
                          </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                          <tr>
                            <td><%#Eval("����")%></td>
                            <td><%#Eval("ͨ�д���")%></td>
                          </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
            </table>
            <webdiyer:AspNetPager CssClass="page" ID="AspNetPager1" runat="server" CustomInfoHTML="��%PageCount%ҳ��ÿҳ%PageSize%���������%RecordCount%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ"  PageSize="10" PrevPageText="��һҳ" ShowInputBox="Never" ShowCustomInfoSection="Left"  OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
            <asp:Literal ID="litTJList" runat="server" Text=""></asp:Literal>
      </div>
      </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
