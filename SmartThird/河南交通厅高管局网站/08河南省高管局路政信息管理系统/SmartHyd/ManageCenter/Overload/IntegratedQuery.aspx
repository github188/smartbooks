<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegratedQuery.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.IntegratedQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>综合查询-超限治理</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>


    <script type="text/javascript">
        function checkPositiveInteger(obj) {
            var str = obj.value;
            if (str != "") {
                if (!QDRegEx.CheckPositiveInteger(str)) {
                    alert("非法正整数!");
                    obj.focus();
                    return;
                }
            }
        }
        function CheckFloatValue(obj) {
            var str = obj.value;
            if (str != "") {
                if (!QDRegEx.CheckNonnegativeNumber(str)) {
                    alert("非法非负数(小数部分做多两位)!");
                    obj.focus();
                    return;
                }
            }
        }
        function ClearForm() {
            if (window.confirm("一旦执行删除操作,数据将无法恢复,您确定要清除所有车辆通行记录数据吗？")) {
                return true;
            } else {
                return false;
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
                    window.alert("结束日期 不能小于 开始日期");
                    return false;
                }
            }

            var smoney = $("#txt_smoney").val();
            var emoney = $("#txt_emoney").val();
            if (smoney != "" && emoney != "") {
                if ((parseInt(emoney) - parseInt(smoney)) < 0) {
                    window.alert("截止金额数 不能小于 起始金额数");
                    return false;
                }
            }

            var smileage = $("#txt_smileage").val();
            var emileage = $("#txt_emileage").val();
            if (smileage != "" && emileage != "") {
                if ((parseFloat(emileage) - parseFloat(smileage)) < 0) {
                    window.alert("截止里程数 不能小于 起始里程数");
                    return false;
                }
            }
        }

        function HideProgress() {
            if (Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
                Sys.WebForms.PageRequestManager.getInstance().abortPostBack();
            }
        }
    </script>

    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
             font-family:微软雅黑;
        }
        .style1
        {
            width: 76px;
        }
    </style>

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
            <span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》综合查询</span>
        </div>
          <div style=" border:5px double #0e2f5c; margin:auto; text-align:center;">
          <table width="740px" border="0" cellspacing="0" cellpadding="0" align="center" style="font-size:12px; font-weight:bold;">
          <tr>
            <td height="30" align="right" valign="middle" style="width:80px;">查询规则：</td>
            <td height="30" colspan="5" align="center" valign="middle">
                <asp:RadioButton ID="rdoW" runat="server" GroupName="tj" Text="常规" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoW_CheckedChanged" />&nbsp;&nbsp;
                <asp:RadioButton ID="rdoRK" runat="server" GroupName="tj" Text="入口站"  AutoPostBack="true"  oncheckedchanged="rdoW_CheckedChanged"/>&nbsp;&nbsp;
                <asp:RadioButton ID="rdoCK" runat="server" GroupName="tj" Text="出口站"  AutoPostBack="true" oncheckedchanged="rdoW_CheckedChanged" />
            </td>
          </tr>
          <tr>
            <td height="30" align="right" valign="middle" style="width:80px;">运营单位：</td>
            <td width="170" height="30" valign="middle">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="170px"></asp:DropDownList>
            </td>
            <td height="30" align="right" valign="middle" class="style1">所在地市：</td>
            <td width="160" height="30" valign="middle">
                <asp:DropDownList ID="ddlCity" runat="server" Width="160px"></asp:DropDownList>
            </td>
            <td height="30" align="right" valign="middle" style="width:80px">高速公路：</td>
            <td width="160" height="30" valign="middle">
                <asp:DropDownList ID="ddlHighWay" runat="server" Width="160px"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td height="30" align="right" valign="middle">车牌号：</td>
            <td width="170" height="30" valign="middle">
                <asp:TextBox ID="txtVehicleLicense" runat="server" CssClass="input_bor1" Width="166px"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle" class="style1">入口站名：</td>
            <td width="160" height="30" valign="middle">
                <asp:TextBox ID="txtEnterStation" runat="server" CssClass="input_bor1" Width="156px"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle">出口站名：</td>
            <td width="160" height="30" valign="middle">
                <asp:TextBox ID="txtOutStation" runat="server" CssClass="input_bor1" Width="156px"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td height="30" align="right" valign="middle">轴数：</td>
            <td width="170" height="30" valign="middle">
                <asp:TextBox ID="txtVehicleAxle" runat="server" CssClass="input_bor1" Width="166px" onblur="checkPositiveInteger(this)"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle" class="style1">总重(吨)：</td>
            <td width="165" height="30" valign="middle">
                <asp:TextBox ID="txtStartTotalWeight" runat="server" CssClass="input_bor1" Width="70px" onblur="CheckFloatValue(this)"></asp:TextBox>~<asp:TextBox ID="txtEndTotalWeight" runat="server" CssClass="input_bor1" Width="70px" onblur="CheckFloatValue(this)"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle">超载率：</td>
            <td width="160" height="30" valign="middle">
                <asp:DropDownList ID="ddlChaoZaiLv" runat="server" Width="160px"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td height="30" align="right" valign="middle">通行时间：</td>
            <td width="170" height="30" valign="middle">
                <asp:TextBox ID="txt_startDate" runat="server" Width="75px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>~<asp:TextBox ID="txt_endDate" runat="server" Width="75px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle" class="style1">支付形式：</td>
            <td width="160" height="30" valign="middle">
                <asp:TextBox ID="txt_pay" runat="server" Width="156px" CssClass="input_bor1"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle">金额：</td>
            <td width="160" height="30" valign="middle">
                <asp:TextBox ID="txt_smoney" runat="server" Width="68px" CssClass="input_bor1"  onblur="checkPositiveInteger(this)"></asp:TextBox>~
                <asp:TextBox ID="txt_emoney" runat="server" Width="65px" CssClass="input_bor1"  onblur="checkPositiveInteger(this)"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td height="30" align="right" valign="middle">里程：</td>
            <td width="170" height="30" valign="middle">
                <asp:TextBox ID="txt_smileage" runat="server" Width="74px" CssClass="input_bor1"></asp:TextBox>~<asp:TextBox ID="txt_emileage" runat="server" Width="74px" CssClass="input_bor1"></asp:TextBox>
            </td>
            <td height="30" align="right" valign="middle" class="style1">&nbsp;</td>
            <td width="160" height="30" valign="middle">&nbsp;</td>
            <td height="30" align="right" valign="middle">&nbsp;</td>
            <td width="160" height="30" valign="middle">&nbsp;</td>
          </tr>
          <tr>
            <td height="30" colspan="6" align="center" valign="middle">
            <span class="mar_l5"><asp:Button ID="btnSearch" runat="server" Text=" " CssClass="btn_search_new" OnClientClick="DateValidate()" onclick="btnSearch_Click" /></span>
              <span class="mar_l30">
              <asp:Button ID="btnExport" runat="server" Text=" "  CssClass="btn_export_new" onclick="btnExport_Click" />
              <%--<input id="btnExcel"  type="button" value="" class="btn_export" onclick="ExcelReport()" />--%></span>
              <span class="mar_l30"><asp:Button ID="btnClear" runat="server" Text=" " CssClass="btn_truncate" OnClientClick="return ClearForm();" onclick="btnClear_Click"/></span>
            </td>
          </tr>
        </table>
        <div id="tipMsg"></div>
        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
      
          </div>
            </span>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnExport" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
          </Triggers>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div style=" text-align:center; font-size:12px; font-weight:bold;color:Blue;">
                <img src="../../Images/searching.gif" border="0" />
                数据处理中，请稍等……
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        
    </form>
</body>
</html>
