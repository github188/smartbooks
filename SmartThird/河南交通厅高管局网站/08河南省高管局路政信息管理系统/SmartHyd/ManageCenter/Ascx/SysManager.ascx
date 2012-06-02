<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysManager.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.SysManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">部门管理</a></li>
        <li><a href="#tabs-2">用户管理</a></li>
        <li><a href="#tabs-3">用户授权</a></li>
        <li><a href="#tabs-4">日志管理</a></li>
    </ul>
    <!--部门管理开始-->
    <div id="tabs-1">
        <!--按钮栏-->
        <div>
            <span>部门名称：</span><asp:TextBox ID="TxtDeptName" runat="server" CssClass="input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearchDept" runat="server" Text="查询" CssClass="BigButtonA" OnClick="btnSearchDept_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddDept" runat="server" Text="新建" CssClass="BigButtonA" OnClick="btnAddDept_Click" />
        </div>
        <!--部门列表开始-->
        <table class="TableList" width="100%">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <tbody>
                        <tr class="TableHeader" align="center">
                          <%--  <td>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </td>--%>
                             <td>
                                操作
                            </td>
                            <td>
                                部门名称
                            </td>
                            <td>
                                上级部门
                            </td>
                            <td>
                                部门描述
                            </td>
                            <td>
                                状态
                            </td>
                           
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="TableLine1">
                    <td align="center">
                            <a href="Dept.aspx?Fid=<%# Eval("DEPTID")%>">编辑</a>
                            <%-- <a href="" id="delhref" runat="server"> 删除</a>
                                 onclick="javascript:delete_notify(<%# Eval("AFFICHEID")%>)"--%>
                        </td>
                      <%--  <td align="center">
                            <asp:CheckBox ID="CheckSingle" runat="server" />
                            <asp:Label ID="DEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        </td>--%>
                        <td align="center">
                            <%# Eval("DPTNAME")%>
                        </td>
                        <td align="center">
                            <%# Eval("PARENTID")%>
                        </td>
                        <td align="center">
                            <%# Eval("DPTINFO")%>
                        </td>
                        <td align="center">
                            <%# TransState((decimal)Eval("STATUS"))%>
                        </td>
                        
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" 
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
        <!--部门列表结束-->
    </div>
    <!--部门管理结束-->
    <!--用户管理开始-->
      <div id="tabs-2">
        <div>
            <span>用户名：</span><asp:TextBox ID="Txtuser" runat="server" CssClass="input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnSearchUser" runat="server" Text="查询" CssClass="BigButtonA" OnClick="btnSearchUser_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddUser" runat="server" Text="添加" CssClass="BigButtonA" 
                onclick="btnAddUser_Click" />
        </div>
        <!--用户列表开始-->
        <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="repList" runat="server">
                    <HeaderTemplate>
                        <tr class="TableHeader" align="center">
                            <td>
                                所属部门
                            </td>
                            <td>
                                工作证号
                            </td>
                            <td>
                                登录账号
                            </td>
                            <td>
                                联系电话
                            </td>
                            <td>
                                用户性别
                            </td>
                            <td>
                                政治面貌
                            </td>
                            <td>
                                最高学历
                            </td>
                            <td>
                                所学专业
                            </td>
                            <td>
                                出生年月
                            </td>
                            <td>
                                身份证号
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td>
                                <%# Eval("dptname") %>
                            </td>
                            <td>
                                <%# Eval("jobnumber")%>
                            </td>
                            <td>
                                <%# Eval("username")%>
                            </td>
                            <td>
                                <%# Eval("phone")%>
                            </td>
                            <td>
                                <%# Eval("sex")%>
                            </td>
                            <td>
                                <%# Eval("face")%>
                            </td>
                            <td>
                                <%# Eval("DEGREE")%>
                            </td>
                            <td>
                                <%# Eval("prof")%>
                            </td>
                            <td>
                                <%# Eval("birthday")%>
                            </td>
                            <td>
                                <%# Eval("idnumber")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
       <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" 
            OnPageChanging="AspNetPager2_PageChanging" CssClass="anpager" 
            CurrentPageButtonClass="cpb" UrlPageIndexName="pageIndex">
        </webdiyer:AspNetPager>
        <!--用户列表结束-->
    </div>
    <!--用户管理结束-->
    <!--用户授权开始-->
    <div id="tabs-3">
       <a href="Empower.aspx">用户授权</a>
       <table class="TableBlock"  width="500" align="center" >
    <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（人员）</td>
      <td class="TableData">
        <input type="hidden" id="USER_ID" name="USER_ID" value=""/>
          <asp:HiddenField ID="HfUserID" runat="server" Value=""/>
        <textarea id="txtUser" cols="40" name="USER_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('txtUser','#dialog')">选择</a>
     <a href="javascript:;" class="orgClear" onclick="Clear('txtUser')">清空</a>
      </td>
   </tr>
   <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（角色）</td>
      <td class="TableData">
        <input type="hidden" name="PRIV_ID" value=""/>
        <asp:HiddenField ID="HfRoleID" runat="server" Value=""/>
        <textarea id="txtRole" cols="40" name="ROLE_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('txtRole','#dialog1')">选择</a>
        <a href="javascript:;" class="orgClear" onclick="Clear('txtRole')">清空</a>
      </td>
   </tr>
     <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（菜单）</td>
      <td class="TableData">
        <input type="hidden" name="DEPT_ID" value=""/>
        <asp:HiddenField ID="HfMenuID" runat="server" Value=""/>
        <textarea id="TxtMenu" cols="40" name="Menu_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly"></textarea>
        <a href="javascript:;" class="orgAdd" onclick="SelectUser('TxtMenu','#dialog2')">添加</a>
        <a href="javascript:;" class="orgClear" onclick="ClearUser('TxtMenu')">清空</a>
      </td>
   </tr>
     <tr>
      <td nowrap="nowrap" class="TableContent"" align="center">授权范围：<br/>（动作）</td>
      <td class="TableData">
          <asp:HiddenField ID="HfActionID" runat="server" Value=""/>
        <textarea id="TxtAction" cols="40" name="ACTION_NAME" rows="8" class="BigStatic" wrap="yes" readonly="readonly"></textarea>
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
    <!--日志管理开始-->
    <div id="tabs-4">
          <div>
            <span>日期：</span><asp:TextBox ID="TxtDate" runat="server" CssClass="input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearchLog" runat="server" Text="查询" CssClass="BigButtonA" OnClick="btnSearchLog_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
          
        </div>
        <!--日志列表开始-->
        <table class="TableList" width="100%">
            <tbody>
                <asp:Repeater ID="RptListLog" runat="server">
                    <HeaderTemplate>
                        <tr class="TableHeader" align="center">
                            <td>
                                日志编号
                            </td>
                            <td>
                                日志类型
                            </td>
                            <td>
                                创建时间
                            </td>
                            <td>
                                日志内容
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td>
                                <%# Eval("LOGID")%>
                            </td>
                            <td>
                                <%# Eval("LOGTYPE")%>
                            </td>
                            <td>
                                <%# Eval("CREATEDATE")%>
                            </td>
                            <td>
                                <%# Eval("DESCRIPTION")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
     <webdiyer:AspNetPager ID="AspNetPager3" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox" 
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" 
            OnPageChanging="AspNetPager3_PageChanging" UrlPageIndexName="pageName">
        </webdiyer:AspNetPager>
        <!--日志列表结束-->
    </div>
    <!--日志管理结束-->
</div>
