<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysManager.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.SysManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>


<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
        <tr>
            <td style="height:37px; line-height:37px;">
                <div style="border-top:2px solid #e7eaef"></div>
                <div id="menu">
                    <div class="patrolsitemap"></div>
                        <ul>
                            <li id="menu_Title0" onclick="nTabs('menu',this,4)" class="actived"><a href="../ManageCenter/DeptManage.aspx" target="SysFrame"><span id="buttons"><img src="../Images/i_department.png" border="0"/>部门管理</span></a></li>
                            <li id="menu_Title1" onclick="nTabs('menu',this,4)" class="normal"><a href="../ManageCenter/UserManage.aspx" target="SysFrame"><span id="buttons"><img src="../Images/i_user.png" border="0"/>用户管理</span></a></li>
                            <li id="menu_Title2" onclick="nTabs('menu',this,5)" class="normal"><a href="javascript:void(0)" target="SysFrame"><span id="buttons"><img src="../Images/i_role.png" border="0"/>权限管理</span></a></li>
                            <li id="menu_Title3" onclick="nTabs('menu',this,6)" class="normal"><a href="../ManageCenter/SysLog.aspx" target="SysFrame"><span id="buttons"><img src="../Images/i_log.png" border="0"/>系统日志</span></a></li>
                        </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
            <iframe src="" name="SysFrame" id="SysFrame" frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
            </td>
        </tr>
    </table>
<div style=" height:20px;"></div>
    
