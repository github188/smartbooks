<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Affiche.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Affiche" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <table width="100%" class="TableBlock">
        <tr class="TableHeader">
            <td width="12%">
                <font size="+1">当前位置：</font>
            </td>
            <td width="88%">
                <a href="../ManageCenter/Office.aspx"><font size="+1">网络办公&gt;&gt;</font></a> <a
                    href="../ManageCenter/Affiche.aspx"><font size="+1">电子公告&gt;&gt;</font></a>
            </td>
        </tr>
    </table>
    <ul id="menu">
        <li><a href="#tabs-1">
            <asp:Label ID="LbTabName2" runat="server" Text="电子公告管理"></asp:Label>
        </a></li>
        <li><a href="#tabs-2">
            <asp:Label ID="LbTabName" runat="server" Text=""></asp:Label>
        </a></li>
    </ul>
    <!--公告管理开始-->
    <div id="tabs-1">
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
                                <%-- <a href="" id="delhref" runat="server"> 删除</a>
                                 onclick="javascript:delete_notify(<%# Eval("AFFICHEID")%>)"--%>
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
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--公告管理结束-->
    <!--新建公告开始-->
    <div id="tabs-2">
        <table border="0" width="100%" cellspacing="0" cellpadding="3" class="TableBlock">
            <thead>
                <tr class="TableHeader">
                    <th colspan="3" align="center">
                        <asp:Label ID="LbHeadName" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp; 公告标题：
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtTitle" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <font color="red">*</font>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                        <%--<input type="text" name="SUBJECT" id="SUBJECT" runat="server" size="55" maxlength="200" class="BigInput"
                        value="请输入公告标题..." style="color: #8896A0" 
                         onmouseover="if(document.getElementById('SUBJECT').value=='请输入公告标题...')document.getElementById('SUBJECT').style.color='#000000';"
                        onmouseout="if(document.getElementById('SUBJECT').value=='请输入公告标题...')document.getElementById('SUBJECT').style.color='#8896A0';" onfocus="if(document.getElementById('SUBJECT').value=='请输入公告标题...'){document.getElementById('SUBJECT').value='';document.getElementById('SUBJECT').style.color='#000000';}"/>
                        <font color="red">(*)</font> <a id="font_color_link" href="javascript:;" class="dropdown"
                                onclick="showMenu(this.id, 1);" hidefocus="true"><span>设置标题颜色</span></a>&nbsp;&nbsp;
                        <div id="font_color_link_menu" style="display: none;">--%>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;发布时间：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtTime" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;内容简介：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtContent" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;事务提醒：
                    </td>
                    <td class="TableData">
                        <input type="checkbox" name="SMS_REMIND" id="SMS_REMIND" checked="checked" /><label
                            for="SMS_REMIND">发送事务提醒消息</label>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr align="center" class="TableControl">
                    <td colspan="2" nowrap="nowrap">
                        <input type="hidden" name="PUBLISH" value="" />
                        <input type="hidden" name="SUBJECT_COLOR" value="" />
                        <input type="hidden" name="OP" value="" />
                        <input type="hidden" name="OP1" value="" />
                        <input type="hidden" name="TOP_FLAG" value="0" />
                        <asp:Button ID="BtnSend" runat="server" Text="发布" class="BigButton" OnClick="BtnSend_Click" />
                        <asp:Button ID="BtnSave" runat="server" Text="保存" class="BigButton" OnClick="BtnSave_Click" />
                        <%-- <asp:Button ID="BtnBack" runat="server" Text="返回" class="BigButton" OnClick="BtnBack_Click" />--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建公告结束-->
    <!--dialog窗口开始-->
    <div id="overlay">
    </div>
    <div id="dialog" class="ModalDialog" style="display: none">
        <div class="header">
            <span id="title" class="title">发布公告</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
        <table width="95%" class="table" align="center">
            <thead>
                <tr>
                    <td colspan="2" class="TableContent">
                        请选择发送单位/部门
                    </td>
                </tr>
            </thead>
            <tr>
                <td colspan="2" class="TableData">
                    <asp:TreeView ID="TvDept" runat="server">
                    </asp:TreeView>
                </td>
            </tr>
            <tr>
                <td class="left">
                    自定义数据
                </td>
                <td class="TableData">
                </td>
            </tr>
            <%-- <tr>
                        <td class="TableContent">
                            提醒
                        </td>
                        <td>
                            <input type="checkbox" name="sms_notice" id="sms_notice" checked="checked" /><label
                                for="sms_notice">提醒登记员</label>
                        </td>
                    </tr>--%>
        </table>
        <form name="form1" method="post" action="">
        <div id="send_body" class="body">
        </div>
        <div id="footer" class="footer">
            <input type="hidden" name="dept_str" id="dept_str" />
            <input type="hidden" name="sid" id="sid" />
            <input class="BigButton" type="submit" value="确定" />
            <input class="BigButton" type="button" value="关闭" />
        </div>
        </form>
    </div>
    <!--dialog窗口结束-->
</div>
