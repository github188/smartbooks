<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditIlleglOverload.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.EditIlleglOverload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>非法超载车辆信息上报-超限治理</title>
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
        }
        .titlebar{ height:20px; line-height:20px; font-size:12px; background-color:#ccc; color:#000; padding-left:5px;}
        .td_title{ width:100px; height:24px;line-height:24px; text-align:right; font-weight:bold;}
        .td_content{height:24px; line-height:24px;}
    </style>
    <script type="text/javascript">
        function GoBack() {
            history.go(-1);
        }

        function addAttach() {
            var filebutton = '<br><input type="file" size="50" name="File" />';
            document.getElementById('FileList').insertAdjacentHTML("beforeEnd", filebutton);
        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
            <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》非法超载车辆信息上报</span></div>
            <div class="ReturnPreview"><span id="buttons" onclick="GoBack()"><img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
        </div>

        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="titlebar">一、基本信息</td>
          </tr>
          <tr>
            <td>
            <table width="600" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="td_title">承运单位：</td>
                <td><asp:TextBox ID="txt_carrier_unit" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">货主单位：</td>
                <td><asp:TextBox ID="txt_cargoower_unit" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="td_title">经办人：</td>
                <td><asp:TextBox ID="txt_manager" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">联系电话：</td>
                <td><asp:TextBox ID="txt_telephone" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
            </table>
            </td>
          </tr>
          <tr>
            <td class="titlebar">二、超限车辆信息</td>
          </tr>
          <tr>
            <td>
    	        <table width="600" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td class="td_title">车牌号：</td>
                    <td><asp:TextBox ID="txt_license" runat="server" Width="190px"></asp:TextBox></td>
                    <td class="td_title">车辆类型：</td>
                    <td><asp:TextBox ID="txt_vehicle_type" runat="server" Width="190px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="td_title">车辆自重（T）：</td>
                    <td><asp:TextBox ID="txt_vehicle_weight" runat="server" Width="190px"></asp:TextBox></td>
                    <td class="td_title">核定载重（T）：</td>
                    <td><asp:TextBox ID="txt_vehicle_load" runat="server" Width="190px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="td_title">轴数：</td>
                    <td><asp:TextBox ID="txt_axis" runat="server" Width="190px"></asp:TextBox></td>
                    <td class="td_title">轴荷分布：</td>
                    <td><asp:TextBox ID="txt_axis_layout" runat="server" Width="190px"></asp:TextBox></td>
                  </tr>
                </table>

            </td>
          </tr>
          <tr>
            <td class="titlebar">三、货物信息</td>
          </tr>
          <tr>
            <td>
            <table width="600" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="td_title">货物名称：</td>
                <td><asp:TextBox ID="txt_cargo_name" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">货物自重：</td>
                <td><asp:TextBox ID="txt_cargo_weight" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="td_title">货物尺寸：</td>
                <td colspan="3" align="center">                    
                    长(M)：<asp:TextBox ID="txt_cargo_length" runat="server" Width="110px"></asp:TextBox>
                    宽(M)：<asp:TextBox ID="txt_cargo_width" runat="server" Width="110px"></asp:TextBox>
                    高(M)：<asp:TextBox ID="txt_cargo_height" runat="server" Width="110px"></asp:TextBox>
                </td>
              </tr>
            </table>
            </td>
          </tr>
          <tr>
            <td class="titlebar">四、车货概况</td>
          </tr>
          <tr>
            <td><table width="600" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="td_title">车货总重：</td>
                <td><asp:TextBox ID="txt_vehicle_cargo_weight" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">超载重量：</td>
                <td><asp:TextBox ID="txt_overload_weight" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="td_title">车货总尺寸：</td>
                <td colspan="3" align="center">
                    长(M)：<asp:TextBox ID="txt_vehicle_cargo_length" runat="server" Width="110px"></asp:TextBox>
                    宽(M)：<asp:TextBox ID="txt_vehicle_cargo_width" runat="server" Width="110px"></asp:TextBox>
                    高(M)：<asp:TextBox ID="txt_vehicle_cargo_height" runat="server" Width="110px"></asp:TextBox>
                </td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <td class="titlebar">五、路政执法信息</td>
          </tr>
          <tr>
            <td><table width="600" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td class="td_title">入口站名称：</td>
                <td><asp:TextBox ID="txt_entrance" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">入站时间：</td>
                <td><asp:TextBox ID="txt_inboundTime" runat="server" Width="190px" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="td_title">查处时间：</td>
                <td><asp:TextBox ID="txt_investigated_time" runat="server" Width="190px" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox></td>
                <td class="td_title">查处地点：</td>
                <td><asp:TextBox ID="txt_investigated_address" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="td_title">执行单位：</td>
                <td><asp:TextBox ID="txt_roadunit" runat="server" Width="190px"></asp:TextBox></td>
                <td class="td_title">执行人：</td>
                <td><asp:TextBox ID="txt_executor" runat="server" Width="190px"></asp:TextBox></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td class="titlebar">六、附件上传&nbsp;<span id="buttons"><img src="../../Images/add.png" alt="" border="0" onclick="addAttach();" style="cursor:hand;" /></span></td>
          </tr>
          <tr>
            <td class="td_content">
                <p id="FileList"><input type="file" id="file1" runat="server" size="50" name="File"/></p>
            </td>
          </tr>
            <tr>
            <td class="td_content" align="center">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Images/submit1.jpg" />&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/Images/btn_return.png" />
                </td>
          </tr>
        </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
