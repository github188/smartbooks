<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysManager.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.SysManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr>
            <td width="12%">
                <font size="+2">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+2">系统管理&gt;</font></a>
            </td>
        </tr>
    </table>
    <table width="100%" border="0">
        <tr>
            <td width="50%" align="center">
                <p>
                    <a href="../ManageCenter/DeptManage.aspx">
                        <img src="../../Images/Com.png" alt="部门管理" /></a></p>
                <p>
                    <a href="../ManageCenter/DeptManage.aspx">部门管理</a></p>
            </td>
            <td width="50%" align="center">
                <p>
                    <a href="../ManageCenter/UserManage.aspx">
                        <img src="../../Images/user.png" alt="用户管理" /></a></p>
                <p>
                    <a href="../ManageCenter/UserManage.aspx">用户管理</a></p>
            </td>
        </tr>
        <tr>
            <td  align="center">
                <p>
                    <a href="../ManageCenter/DeptManage.aspx">
                        <img src="../../Images/user.png" alt="用户授权" /></a></p>
                <p>
                    <a href="../ManageCenter/DeptManage.aspx">用户授权</a></p>
            </td>
            <td align="center">
                <p>
                    <a href="../ManageCenter/SysLog.aspx">
                        <img src="../../Images/log.png" alt="日志管理" /></a></p>
                <p>
                    <a href="../ManageCenter/DeptManage.aspx">日志管理</a></p>
            </td>
        </tr>
    </table>
</div>
