<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.WorkPlan.PlanEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>事务编辑</title>
<link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--添加事务提醒开始-->
        <table class="TableBlock" width="100%">
            <thead>
                <tr class="TableHeader">
                    <th colspan="2">
                        <asp:Label ID="LabName" runat="server" Text=""></asp:Label></th>
                </tr>
            </thead>
            <tbody>
             <tr>
                    <td class="TableData">
                        <asp:Label ID="LbUser" runat="server" Text="事务标题:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtTitle" CssClass="input {required:true}" runat="server"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="LabType" runat="server" Text="事务类型:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="DdrType" runat="server">
                            <asp:ListItem Value="0">工作计划</asp:ListItem>
                            <asp:ListItem Value="1">个人事务</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
               
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbstart" runat="server" Text="开始时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                         <asp:TextBox ID="txt_startTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="LbEnd" runat="server" Text="结束时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                         <asp:TextBox ID="txt_endTime" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbcontent" runat="server" Text="事务内容:"></asp:Label>
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="input {required:true}"
                            Height="40px" Width="341px"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="TableData">
                        <asp:Label ID="Lbprompt" runat="server" Text="提醒时间:"></asp:Label>
                    </td>
                    <td class="TableData">
                      <asp:TextBox ID="txtPrompt" runat="server" Width="120" class="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>
    <!--添加事务提醒结束-->
    </div>
    </form>
</body>
</html>
