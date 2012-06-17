<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IllegalOverloadManage.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.IllegalOverloadManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
     <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>非法超限车辆信息管理-超限治理</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
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
             <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》非法超载车辆信息管理</span></div>
             <div class="ReturnPreview"><span id="buttons" onclick="IllageOverloadReport()" style="cursor:hand;"><img src="../../Images/icons/overloadreported.png" alt="" border="0" />非法超载车辆上报</span></div>
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #045185">
                    <tr class="TableHeader" align="center">
                        <td style="border-right:1px solid #ffffff;">
                            <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            查处时间
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            查处地点
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            入站站名
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            上站时间
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            车辆所属单位
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            查处单位
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            操作
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
                            <a href="../../ManageCenter/Empower.aspx?userid=<%# Eval("userid")%>&name=<%# Eval("username")%>">详细</a>&nbsp;
                            <a href="UserEdit.aspx?action=update&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">编辑</a>&nbsp;
                            <a href="UserCenter.aspx?action=del&userid=<%# Eval("userid")%>">删除
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
    </table>
    <asp:Literal ID="litmsg" Visible="false" Text="<div class='msg'>暂无非法超载车辆通行信息</msg>" runat="server"></asp:Literal>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
        PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
    </webdiyer:AspNetPager>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
