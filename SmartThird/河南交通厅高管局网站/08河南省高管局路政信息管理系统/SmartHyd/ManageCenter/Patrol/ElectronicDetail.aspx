<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElectronicDetail.aspx.cs" Inherits="SmartHyd.Patrol.ElectronicDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>电子巡逻详情</title>
     <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../Css/base.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/tongdaoa.css" />
    <link rel="stylesheet" type="text/css" href="../../Scripts/jquery-ui-1.8.18.custom/css/redmond/jquery-ui-1.8.18.custom.css" />
    <script src="../../Scripts/base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div id="menu">
        <div class="OperateNote"><span id="buttons"><img src="../../Images/addDocument.png" alt="" border="0" />&nbsp;<asp:Label ID="LabName"
                runat="server" Text="电子巡逻详情"></asp:Label></span></div>
        <div class="ReturnPreview"><span id="buttons" onclick="GoBack()"><img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
    </div>
    <table class="edit" width="100%">
            <tbody>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="巡查中队:"></asp:Label>
                        <div id="deptname" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="巡查人员:"></asp:Label>
                        <div id="divuser" runat="server"></div>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="天气情况:"></asp:Label>
                        <div id="weather" runat="server"></div>
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
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="巡查处理情况:"></asp:Label>
                        <div id="result" runat="server"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
