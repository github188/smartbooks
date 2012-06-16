<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassageCountSummary.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.PassageCountSummary" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>车辆通行次数统计-超限治理</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
        <div id="menu">
            <span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》车辆通行通行次数统计</span>
        </div>
        <div style=" border:5px double #0e2f5c; margin:auto;">
        <table width="730" border="0" cellspacing="0" cellpadding="0" style="font-size:12px; font-weight:bold; margin:auto;">
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
        <td height="30" align="right" valign="middle" style="width:80px;">所在地市：</td>
        <td width="160" height="30" valign="middle">
            <asp:DropDownList ID="ddlCity" runat="server" Width="160px"></asp:DropDownList>
        </td>
        <td height="30" align="right" valign="middle" style="width:80px">通行时间：</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txt_startDate" runat="server" Width="68px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>~<asp:TextBox ID="txt_endDate" runat="server" Width="69px"  class="Wdate"  onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>   
        </td>
      </tr>
      <tr>
        <td height="30" align="right" valign="middle">车牌号：</td>
        <td width="170" height="30" valign="middle">
            <asp:TextBox ID="txtVehicleLicense" runat="server" CssClass="input_bor1" Width="166px"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">入口站名：</td>
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
        <td height="30" align="right" valign="middle">总重(吨)：</td>
        <td width="160" height="30" valign="middle">
            <asp:TextBox ID="txtStartTotalWeight" runat="server" CssClass="input_bor1" Width="65px" onblur="CheckFloatValue(this)"></asp:TextBox>~<asp:TextBox ID="txtEndTotalWeight" runat="server" CssClass="input_bor1" Width="72px" onblur="CheckFloatValue(this)"></asp:TextBox>
        </td>
        <td height="30" align="right" valign="middle">超载率：</td>
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
                系统正在进行车辆通行次数统计，请稍等……</div>
            </ProgressTemplate>
        </asp:UpdateProgress>
       <div id="reportlist" style="width:100%;  margin-top:0px;  text-align:center;">
            <table cellpadding="0" cellspacing="0" class="txcstj_tab" align="center">
                <asp:Repeater ID="rptTraffic" runat="server">
                    <HeaderTemplate>
                          <tr>
                            <td colspan="2"><p class="txcstj_tit">全省高速公路通行超载车辆通行次数统计</p></td>
                          </tr>
                          <tr class="tit">
                            <td width="250">车牌号</td>
                            <td width="250">通行次数</td>
                          </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                          <tr>
                            <td><%#Eval("车牌")%></td>
                            <td><%#Eval("通行次数")%></td>
                          </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
            </table>
            <webdiyer:AspNetPager CssClass="page" ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，每页%PageSize%条，结果共%RecordCount%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"  PageSize="10" PrevPageText="上一页" ShowInputBox="Never" ShowCustomInfoSection="Left"  OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
            <asp:Literal ID="litTJList" runat="server" Text=""></asp:Literal>
      </div>
      </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
