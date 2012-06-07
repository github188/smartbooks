<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManage.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.UserManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
     <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
        <tr>
            <td style="height:24px;">
                <div id="menu">
                    <div class="OperateNote"><span id="buttons"><img src="../Images/branch.png" border="0" />当前位置：系统管理》单位用户综合管理</span></div>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                 <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
                    <tr>
                        <td width="300" style="border-right:4px double #045185">
                             <iframe src="UserManager/UnitCenter.aspx" name="TreeFrame" id="TreeFrame" frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
                        </td>
                        <td> 
                            <iframe src="UserManager/UserCenter.aspx" name="UserFrame" id="UserFrame" frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
                        </td>
                    </tr>
                 </table>
            </td>
        </tr>
    </table>

    
