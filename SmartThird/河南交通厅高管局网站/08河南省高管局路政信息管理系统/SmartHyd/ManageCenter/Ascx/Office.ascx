<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Office.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Office" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
   <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;">
    <tr>
        <td style="height: 37px; line-height: 37px;">
            <div style="border-top: 2px solid #e7eaef">
            </div>
            <div id="menu">
                <div class="patrolsitemap">
                </div>
                <ul>
                    <li id="menu_Title0" onclick="nTabs('menu',this,3)" class="actived"><a href="../../ManageCenter/WorkPlan/Plan.aspx"
                        target="SysFrame"><span id="buttons0">
                            <img src="../../Images/i_user.png" alt="" border="0" />事务提醒</span></a></li>
                    <li id="menu_Title1" onclick="nTabs('menu',this,3)" class="normal"><a href="../../ManageCenter/Affiche.aspx"
                        target="SysFrame"><span id="buttons1">
                            <img src="../../Images/i_role.png" alt="" border="0" />电子公告</span></a></li>
                    <li id="menu_Title2" onclick="nTabs('menu',this,3)" class="normal"><a href="../../ManageCenter/Chat.aspx"
                        target="SysFrame"><span id="buttons2">
                            <img src="../../Images/i_log.png" alt="" border="0" />即时通讯</span></a></li>
                </ul>
            </div>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <iframe src="../../ManageCenter/WorkPlan/Plan.aspx" name="SysFrame" id="SysFrame" frameborder="0" width="100%"
                height="100%" scrolling="auto"></iframe>
        </td>
    </tr>
</table>
<div style="height: 20px;">
</div>
