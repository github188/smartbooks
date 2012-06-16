<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverloadSummary.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.OverloadSummary" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>���س�����Ϣ����-��������</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckPositiveInteger(obj) {
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

            startDate = startDate.replace(/-/g, "/");
            endDate = endDate.replace(/-/g, "/");
            startDate = new Date(startDate);
            endDate = new Date(endDate);

            if (Date.parse(startDate) - Date.parse(endDate) > 0) {
                window.alert("�������� ����С�� ��ʼ����");
                return false;
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

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
            <span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã������������س�����Ϣ����</span>
        </div>
        <div class="mar_box5">
       <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="border-bottom:1px dashed #CCCCCC; overflow:hidden;">
        <tr>
            <td style="height:120px">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="border-bottom:1px dashed #CCCCCC; overflow:hidden;">
        <tr>
          <td style="height:24px; line-height:24px;" bgcolor="#cccccc" colspan="5">
             <asp:RadioButton ID="rdoCity" runat="server" GroupName="hz" Text="�����л���" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoCity_CheckedChanged" /><asp:RadioButton ID="rdoCompany" runat="server" GroupName="hz" Text="������˾����"  AutoPostBack="true" oncheckedchanged="rdoCity_CheckedChanged"/>
             (<asp:RadioButton ID="rdoRK" runat="server"  GroupName="crk" Text="���" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoRK_CheckedChanged" /><asp:RadioButton ID="rdoCK" runat="server" GroupName="crk" Text="����"  AutoPostBack="true" oncheckedchanged="rdoRK_CheckedChanged" />)
             
          </td>
        </tr>
        <tr style="height:24px; line-height:24px;">
    <td width="70" style="background-color:#FFF; width:70px;">����˾:</td>
    <td width="260" style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_units" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_units_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td width="60" style="background-color:#FFF; width:70px;">���ڵ���:</td>
    <td width="260" style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_cities" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_cities_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF;">&nbsp;</td>
  </tr>
    <tr style="height:24px; line-height:24px;">
    <td style="background-color:#FFF; width:70px;">���ٹ�·:</td>
    <td style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_highways" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_highways_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF; width:60px;">�շ�վ��:</td>
    <td style="background-color:#FFF;">
        <asp:DropDownList ID="ddl_tolls" runat="server" Width="200px" Enabled="False">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF;">&nbsp;</td>
  </tr>
  <tr style="height:24px; line-height:24px;">
    <td style="background-color:#FFF">��&nbsp;��&nbsp;��:</td>
    <td style="background-color:#FFF">
        <asp:DropDownList ID="ddl_olrate" runat="server" Width="200px">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF">��&nbsp;&nbsp;&nbsp;&nbsp;��:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_axis" runat="server" Width="190px" onblur="CheckPositiveInteger(this)"></asp:TextBox>
      </td>
    <td style="background-color:#FFF">&nbsp;</td>
  </tr>
  <tr style="height:24px; line-height:20px;">
    <td style="background-color:#FFF">���أ��֣�:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_startTon" runat="server" Width="80px" onblur="CheckFloatValue(this)"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="��"></asp:Label>
        <asp:TextBox ID="txt_endTon" runat="server" Width="80px" onblur="CheckFloatValue(this)"></asp:TextBox>
      </td>
    <td style="background-color:#FFF">��ֹʱ��:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_startDate" runat="server" Width="80px" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="��"></asp:Label>
        <asp:TextBox ID="txt_endDate" runat="server" Width="80px" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
    </td>
    <td style="background-color:#FFF">
        <asp:Button ID="btnSummary" runat="server" CssClass="btn_summary" 
            Text=" " OnClientClick="DateValidate()" onclick="btnSummary_Click" />
        <asp:Button ID="btnExport" runat="server" CssClass="btn_export" 
            onclick="btnExport_Click" Text=" " />
      </td>
      

  </tr>
  </table>
            </td>
        </tr>
            <tr>
            <td colspan="5" valign="top">
                <table width="100%" style=" height:auto;" border=0 cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div style="width:100%; height:450px; overflow:auto;">
                                        <p class="czclhz_tit">ȫʡ���ٹ�·�շ�վ���ͨ�г��س���������ܱ�</p>
                            <table cellpadding="0" cellspacing="0" class="czclhz_tab" align="center">
                                <tr class="tit">
                                <td width="50">���</td>
                                <td width="151"><asp:Label ID="lblCityOrCompany" runat="server" Text="��������"></asp:Label></td>
                                <td width="120">���ڸ��ٹ�·<br />����</td>
                                <td width="100"><asp:Label ID="lblEnterOrOutStation" runat="server" Text="���վ��"></asp:Label></td>
                                <td width="100">����0%-30%<br />(��λ������)</td>
                                <td width="100">����30%-50%<br />(��λ������)</td>
                                <td width="100">����50%-100%<br />(��λ������)</td>
                                <td width="100">����100%����<br />(��λ������)</td>
                                </tr>
                                <asp:Literal ID="litHZList" runat="server" Text=""></asp:Literal>
                            </table>
                                    </div>
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
      </table>
       
      </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
