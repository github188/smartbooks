<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Office.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Office" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/Office.aspx"><font size="+1">网络办公&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <table width="100%" border="0">
        <tr>
            
        </tr>
        <tr>
        <td align="center">
                <p>
                    <a href="../ManageCenter/Chat.aspx">
                        <img src="../../Images/user.png" alt="即时通讯" /></a></p>
                <p>
                    <a href="../ManageCenter/Chat.aspx">即时通讯</a></p>
            </td>
            <td align="center">
                <p>
                    <a href="../ManageCenter/Plan.aspx">
                        <img src="../../Images/Alarm.png" alt="事务提醒" /></a></p>
                <p>
                    <a href="../ManageCenter/Plan.aspx">事务提醒</a></p>
            </td>
            <td align="center">
                <p>
                    <a href="../ManageCenter/Affiche.aspx">
                        <img src="../../Images/log.png" alt="电子公告" /></a></p>
                <p>
                    <a href="../ManageCenter/Affiche.aspx">电子公告</a></p>
            </td>
        </tr>
        <tr>
            
        </tr>
    </table>
</div>
