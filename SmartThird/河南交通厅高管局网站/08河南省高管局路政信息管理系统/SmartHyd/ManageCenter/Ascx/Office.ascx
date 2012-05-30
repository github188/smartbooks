<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Office.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Office" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">即时通讯</a></li>
        <li><a href="#tabs-2">事务提醒</a></li>
        <li><a href="#tabs-3">电子公告</a></li>
    </ul>
    <!--即时通讯开始-->
    <div id="tabs-1">
        <table class="TableHeader" width="600">
            <tr>
                <td class="left">
                </td>
                <td align="center">
                    发送消息
                </td>
                <td class="right">
                </td>
            </tr>
        </table>
        <table class="TableBlock no-top-border" width="600">
            <tr class="TableData">
                <td style="width: 70px">
                    收信人：
                </td>
                <td>
                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    <asp:TextBox ID="TxtTouser" runat="server" CssClass="input" Width="354px"></asp:TextBox>
                    <%--   <textarea cols="55" name="TO_NAME" rows="2" class="BigStatic" wrap="yes"></textarea>--%>
                    <a href="javascript:;" class="orgAdd" onclick="SelectUser()">添加</a> <a href="javascript:;"
                        class="orgClear" onclick="ClearUser()">清空</a>
                </td>
            </tr>
            <tr class="TableData">
                <td colspan="2">
                    <textarea id="Message" name="CONTENT" rows="8" cols="60" runat="server"></textarea>
                </td>
            </tr>
            <tr class="TableFooter">
                <td colspan="2" align="center">
                    <div style="position: relative; width: 100%;">
                        <span id="words_count"></span>
                        <input type="hidden" value="" name="SMS_ID_REPLAY" />
                    </div>
                </td>
            </tr>
        </table>
        <!--dialog窗口开始-->
        <div id="overlay">
        </div>
        <div id="dialog" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="title" class="title">收信人列表</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            <table width="95%" class="table" align="center">
                <thead>
                    <tr>
                        <td class="TableContent">
                            请选择收信人
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
            <input type="button" id="btnsubmit" value="确定" onclick="javascript:btn_submit()" />
        </div>
        <!--dialog窗口结束-->
        <!--发送消息结束-->
    </div>
    <!--即时通讯结束-->
    <!--事务提醒开始-->
    <div id="tabs-2">
        <table class="TableBlock" width="100%" cellspacing="0" cellpadding="3">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr class="TableHeader">
                            <th>
                                编号
                            </th>
                            <th>
                                事务类型
                            </th>
                            <th>
                                开始时间
                            </th>
                            <th>
                                结束时间
                            </th>
                            <th>
                                日程内容
                            </th>
                            <th>
                                提醒时间
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="TableLine1">
                            <td align="center">
                                <%#Eval("CALENDARID")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARTYPE")%>
                            </td>
                            <td align="center">
                                <%#Eval("START_DATE")%>
                            </td>
                            <td align="center">
                                <%#Eval("END_DATE")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARCONTENT")%>
                            </td>
                            <td align="center">
                                <%#Eval("CALENDARREMIND")%>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--事务提醒结束-->
    <!--电子公告开始-->
    <div id="tabs-3">
        <table class="TableBlock" width="100%" cellspacing="0" cellpadding="3" align="center">
            <asp:Repeater ID="RptAffiche" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr class="TableHeader">
                            <th>
                                <asp:CheckBox ID="CheckallAffiche" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                发布人
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                创建时间
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td align="center">
                                <asp:CheckBox ID="CheckSingleAffiche" runat="server" />
                                <asp:Label ID="AFFICHEID" runat="server" Text='<%#Eval("AFFICHEID") %>' Visible="false"></asp:Label>
                             
                            </td>
                            <td align="center">
                                <%# Eval("AFFICHER")%>
                            </td>
                            <td align="center">
                                <%# Eval("AFFICHETITLE")%>
                            </td>
                            <td align="center">
                                <%# Eval("AFFICHEDATE")%>
                            </td>
                            <td align="center">
                                <%# Eval("STATES")%>
                            </td>
                            <td align="center">
                                <a href="Affiche.aspx?aid=<%# Eval("AFFICHEID")%>">编辑</a> 
                                <a href="" id="delhref" runat="server"> 删除</a>
                                 <%--onclick="javascript:delete_notify(<%# Eval("AFFICHEID")%>)"--%>
                                    
                                   
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="6">
                                <%--分页--%>
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager2_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--电子公告结束-->
</div>
