<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatrolDetail.aspx.cs" Inherits="SmartHyd.Patrol.PatrolDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div id="menu">
        <div class="OperateNote"><span id="buttons0"><img src="../Images/addDocument.png" alt="" border="0" />&nbsp;<asp:Label ID="LabName" runat="server"
                Text=""></asp:Label></span></div>
        <div class="ReturnPreview"><span id="buttons1" onclick="GoBack()"><img src="../Images/back.png" alt="" border="0" />返回上一页面</span></div>
    </div>
    <table class="edit" width="100%">
            <tbody>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="巡查中队:"></asp:Label>
                        <div id="deptname" runat="server"></div>
                        
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="负责人员:"></asp:Label>
                        <div id="RespUser" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="巡查人员:"></asp:Label>
                        <div id="PatrolUser" runat="server"></div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="车牌号码:"></asp:Label>
                        <div id="busNumber" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="巡查里程:"></asp:Label>
                        <div id="Mileage" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="天气情况:"></asp:Label>
                        <div id="Weather" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="巡查处理情况:"></asp:Label>
                        <div id="result" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label8" runat="server" Text="移交内业处理事项:"></asp:Label>
                        <div id="WITHIN" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label9" runat="server" Text="移交下班处理事项:"></asp:Label>
                       <div id="NEXTWITHIN" runat="server"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label10" runat="server" Text="移交下班器材:"></asp:Label>
                       <div id="GOODS" runat="server"></div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="交班中队:"></asp:Label>
                        <div id="AcceptDeptname" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="接班中队:"></asp:Label>
                         <div id="shiftDeptName" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="车牌号码:"></asp:Label>
                         <div id="AcceptNumber" runat="server"></div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="开始时间:"></asp:Label>
                         <div id="starttime" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="结束时间:"></asp:Label>
                         <div id="endtime" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="里程表数:"></asp:Label>
                         <div id="BUSKM" runat="server"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
