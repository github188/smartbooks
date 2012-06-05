<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dept.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Department" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr>
            <td width="12%">
                <font size="+2">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+2">系统管理</font></a>&gt;
                <a href="../ManageCenter/DeptManage.aspx"><font size="+2">部门管理</font></a>&gt;
                <a href="../ManageCenter/Dept.aspx"><font size="+2">部门编辑</font></a>&gt;
            </td>
        </tr>
    </table>
    <!--新建部门开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2">
                       <asp:Label ID="LbHeadName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <!--部门名称-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        部门名称:
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtDeptName" runat="server" CssClass="input  {required:true,minlength:1,maxlength:50}"
                            Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
               
                <!--部门描述-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        部门描述:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtDptinfo" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                            Height="81px" TextMode="MultiLine" Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>

                <!--按钮栏-->
                <tr class="TableControl" align="center">
                    <td colspan="2" nowrap="nowrap">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="BigButtonA" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建部门结束-->
   
</div>
