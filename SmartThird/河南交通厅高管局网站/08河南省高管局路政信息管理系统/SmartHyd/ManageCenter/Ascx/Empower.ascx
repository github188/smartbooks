<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Empower.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Empower" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
<table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/SysManager.aspx"><font size="+1">系统管理&gt;&gt;</font></a> <a
                    href="../ManageCenter/Empower.aspx"><font size="+1">用户授权&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <ul>
        <li><a href="#tabs-1">用户授权</a></li>
    </ul>
    <!--6.7用户授权开始-->
    <div>
    <table>
    <tr><td><asp:RadioButton ID="RadioButton1" runat="server" ValidationGroup="role" /> 系统管理员（拥有系统最高权限）</td></tr>
        
    <tr><td><asp:RadioButton ID="RadioButton2" runat="server" ValidationGroup="role" />管理员（拥有添加，删除，编辑的权限）</td></tr>
    <tr><td><asp:RadioButton ID="RadioButton3" runat="server" ValidationGroup="role" />普通用户（拥有对下级或子单位收文，发文的权限）</td></tr>
    <tr><td><asp:RadioButton ID="RadioButton4" runat="server" ValidationGroup="role" />浏览用户（拥有查看权限）</td></tr>
    <tr><td><asp:Button ID="BtnEmp" runat="server" Text="授权" CssClass="BigButtonA" onclick="BtnEmp_Click" /></td></tr>
    </table>
    </div>
    <!--6.7用户授权结束-->
    <!--用户授权开始-->
    <div id="tabs-1" style="display:none">
        <table class="TableBlock"  width="500" align="center" >
    <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（人员）</td>
      <td class="TableData">
          <asp:HiddenField ID="HfUserID" runat="server" Value=""/>
        <textarea id="txtUsers" cols="40" name="USER_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly" runat="server"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('txtUsers','#dialog')">选择</a>
     <a href="javascript:;" class="orgClear" onclick="Clear('txtUsers')">清空</a>
      </td>
   </tr>
   <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（角色）</td>
      <td class="TableData">
        <textarea id="txtRole" cols="40" name="ROLE_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly" runat="server"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('txtRole','#dialog1')">选择</a>
        <a href="javascript:;" class="orgClear" onclick="Clear('txtRole')">清空</a>
      </td>
   </tr>
     <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（菜单）</td>
      <td class="TableData">
        <asp:HiddenField ID="HfMenuID" runat="server" Value=""/>
        <textarea id="TxtMenu" cols="40" name="Menu_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly" runat="server"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('TxtMenu','#dialog2')">添加</a>
        <a href="javascript:;" class="orgClear" onclick="ClearUser('TxtMenu')">清空</a>
      </td>
   </tr>
     <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（动作）</td>
      <td class="TableData">
          <asp:HiddenField ID="HfActionID" runat="server" Value=""/>
        <textarea id="TxtAction" cols="40" name="ACTION_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly" runat="server"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('TxtAction','#dialog3')">添加</a>
        <a href="javascript:;" class="orgClear" onclick="ClearUser('TxtAction')">清空</a>
      </td>
   </tr>
   <tr>
    <td nowrap="nowrap"  class="TableControl" colspan="2" align="center">
        <asp:Button ID="BtnEmpower" runat="server" Text="提交" CssClass="BigButton"
            onclick="BtnEmpower_Click" />
        <%--<input type="submit" value="确定" class="BigButton" name="button"/>--%>&nbsp;
    </td>
   </tr>
</table>
 <!--dialog窗口开始-->
        <div id="overlay">
        </div>
        <!--用户列表开始-->
        <div id="dialog" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="title" class="title">授权用户列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                <thead>
                    <tr>
                        <td class="TableContent">
                            请选择授权用户
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:CheckBoxList ID="CBLUser" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <input type="button" id="btnsubmit" value="确定" class="BigButtonA" onclick="javascript:btn_submit('txtUser','#dialog')" />
        </div>
        <!--用户列表结束-->
        <!--角色列表开始-->
        <div id="dialog1" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="Span1" class="title">角色列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                <thead>
                    <tr>
                        <td class="TableContent">
                            请选择角色
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:CheckBoxList ID="ChBLRole" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <input type="button" id="Button1" value="确定" class="BigButtonA" onclick="javascript:btn_submit('txtRole','#dialog1')" />
        </div>
        <!--角色列表结束-->
         <!--菜单列表开始-->
        <div id="dialog2" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="Span2" class="title">菜单列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                <thead>
                    <tr>
                        <td class="TableContent">
                            请选择菜单
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:CheckBoxList ID="ChBLMenu" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <input type="button" id="Button2" value="确定" class="BigButtonA" onclick="javascript:btn_submit('TxtMenu','#dialog2')" />
        </div>
        <!--菜单列表结束-->
         <!--动作列表开始-->
        <div id="dialog3" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="Span3" class="title">动作列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                <thead>
                    <tr>
                        <td class="TableContent">
                            请选择动作
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td colspan="2" class="TableData">
                        <asp:CheckBoxList ID="ChBLAction" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <input type="button" id="Button3" value="确定" class="BigButtonA" onclick="javascript:btn_submit('TxtAction','#dialog3')" />
        </div>
        <!--动作列表结束-->
        <!--dialog窗口结束-->
    </div>
    <!--用户授权结束-->
</div>


