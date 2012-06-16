<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverloadSummary.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.OverloadSummary" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>超载车辆信息汇总-超限治理</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckPositiveInteger(obj) {
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

            startDate = startDate.replace(/-/g, "/");
            endDate = endDate.replace(/-/g, "/");
            startDate = new Date(startDate);
            endDate = new Date(endDate);

            if (Date.parse(startDate) - Date.parse(endDate) > 0) {
                window.alert("结束日期 不能小于 开始日期");
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
             font-family:微软雅黑;
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
            <span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》超载车辆信息汇总</span>
        </div>
        <div class="mar_box5">
       <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="border-bottom:1px dashed #CCCCCC; overflow:hidden;">
        <tr>
            <td style="height:120px">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" style="border-bottom:1px dashed #CCCCCC; overflow:hidden;">
        <tr>
          <td style="height:24px; line-height:24px;" bgcolor="#cccccc" colspan="5">
             <asp:RadioButton ID="rdoCity" runat="server" GroupName="hz" Text="按地市汇总" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoCity_CheckedChanged" /><asp:RadioButton ID="rdoCompany" runat="server" GroupName="hz" Text="按管理公司汇总"  AutoPostBack="true" oncheckedchanged="rdoCity_CheckedChanged"/>
             (<asp:RadioButton ID="rdoRK" runat="server"  GroupName="crk" Text="入口" Checked="true" AutoPostBack="true"  oncheckedchanged="rdoRK_CheckedChanged" /><asp:RadioButton ID="rdoCK" runat="server" GroupName="crk" Text="出口"  AutoPostBack="true" oncheckedchanged="rdoRK_CheckedChanged" />)
             
          </td>
        </tr>
        <tr style="height:24px; line-height:24px;">
    <td width="70" style="background-color:#FFF; width:70px;">管理公司:</td>
    <td width="260" style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_units" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_units_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td width="60" style="background-color:#FFF; width:70px;">所在地市:</td>
    <td width="260" style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_cities" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_cities_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF;">&nbsp;</td>
  </tr>
    <tr style="height:24px; line-height:24px;">
    <td style="background-color:#FFF; width:70px;">高速公路:</td>
    <td style="background-color:#FFF; width:200px;">
        <asp:DropDownList ID="ddl_highways" runat="server" Width="200px" 
            AutoPostBack="True" Enabled="False" 
            onselectedindexchanged="ddl_highways_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF; width:60px;">收费站点:</td>
    <td style="background-color:#FFF;">
        <asp:DropDownList ID="ddl_tolls" runat="server" Width="200px" Enabled="False">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF;">&nbsp;</td>
  </tr>
  <tr style="height:24px; line-height:24px;">
    <td style="background-color:#FFF">超&nbsp;载&nbsp;率:</td>
    <td style="background-color:#FFF">
        <asp:DropDownList ID="ddl_olrate" runat="server" Width="200px">
        </asp:DropDownList>
            </td>
    <td style="background-color:#FFF">轴&nbsp;&nbsp;&nbsp;&nbsp;数:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_axis" runat="server" Width="190px" onblur="CheckPositiveInteger(this)"></asp:TextBox>
      </td>
    <td style="background-color:#FFF">&nbsp;</td>
  </tr>
  <tr style="height:24px; line-height:20px;">
    <td style="background-color:#FFF">总重（吨）:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_startTon" runat="server" Width="80px" onblur="CheckFloatValue(this)"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="—"></asp:Label>
        <asp:TextBox ID="txt_endTon" runat="server" Width="80px" onblur="CheckFloatValue(this)"></asp:TextBox>
      </td>
    <td style="background-color:#FFF">起止时间:</td>
    <td style="background-color:#FFF">
        <asp:TextBox ID="txt_startDate" runat="server" Width="80px" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="—"></asp:Label>
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
                                        <p class="czclhz_tit">全省高速公路收费站入口通行超载车辆情况汇总表</p>
                            <table cellpadding="0" cellspacing="0" class="czclhz_tab" align="center">
                                <tr class="tit">
                                <td width="50">序号</td>
                                <td width="151"><asp:Label ID="lblCityOrCompany" runat="server" Text="所属地市"></asp:Label></td>
                                <td width="120">所在高速公路<br />名称</td>
                                <td width="100"><asp:Label ID="lblEnterOrOutStation" runat="server" Text="入口站名"></asp:Label></td>
                                <td width="100">超载0%-30%<br />(单位：辆次)</td>
                                <td width="100">超载30%-50%<br />(单位：辆次)</td>
                                <td width="100">超载50%-100%<br />(单位：辆次)</td>
                                <td width="100">超载100%以上<br />(单位：辆次)</td>
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
