<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FaWen.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.FaWen" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">发文管理</a></li>
        <li><a href="#tabs-2">公文拟稿</a></li>
        <li><a href="#tabs-3">公文类型管理</a></li>
    </ul>
    <!--发文管理开始-->
    <div id="tabs-1">
        <table class="table">
            <asp:Repeater ID="RptFawen" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="CheckallFawen" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                文号
                            </th>
                            <th>
                                类型
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
                            <td>
                                <asp:CheckBox ID="CheckSingleFawen" runat="server" />
                                <asp:Label ID="FID" runat="server" Text='<%#Eval("FID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("F_TITLE")%>
                            </td>
                            <td>
                                <%# Eval("F_NUMBER")%>
                            </td>
                            <td>
                                <%# Eval("F_TYPE")%>
                            </td>
                            <td>
                                <a href="javascript:edit_fawen('<%# Eval("FID")%>')">编辑</a>

                                <a href="javascript:send_doc('<%# Eval("FID")%>')" onclick="javascript:send_doc('<%# Eval("FID")%>')">发送</a> 
                                <a href="<%# Eval("FID")%>">删除</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="2">
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
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" 
            onpagechanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
        <!--dialog窗口开始-->
        <div id="overlay">
        </div>
        <div id="dialog" class="ModalDialog" style="display: none">
            <div class="header">
                <span id="title" class="title">发送公文</span><a class="operation" href="javascript:HideDialog('send');"></a></div>
            
            <form name="form1" method="post" action="">
            <div id="send_body" class="body">
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
            </div>
            <div id="footer" class="footer">
                <input type="hidden" name="dept_str" id="dept_str"/>
                <input type="hidden" name="sid" id="sid"/>
                <input class="BigButton" type="submit" value="确定" />
                <input class="BigButton" onclick="HideDialog('send')" type="button" value="关闭" />
            </div>
            </form>
        </div>
        <!--dialog窗口结束-->
    </div>
    <!--发文管理结束-->
    <!--公文拟稿开始-->
    <div id="tabs-2">
        <div id="content">
            <form action="" name="form1">
            <h1 align="center">
                河南省交通运输厅高速公路管理局</h1>
            <table class="TableList red" align="center" width="700">
                <tr>
                    <td class="left" align="center">
                        发文字号
                    </td>
                    <td class="red">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="txNumber" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                    <%--<td class="red" align="center">密级</td>
		<td class="red"><input type="text" name="secret" class="field" size=20
			value=""></td>--%>
                </tr>
                <tr>
                    <td class="left" align="center">
                        发文类型
                    </td>
                    <td>
                        <asp:DropDownList ID="Ddl_type" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        发文标题
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="txTitle" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        公文内容
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxContent" runat="server" CssClass="input" Height="140px" TextMode="MultiLine"
                            Width="215px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        主办单位
                    </td>
                    <td class="red">
                        <uc1:Department ID="department1" runat="server" />
                    </td>
                    <%--<td class="red" align="center">缓急程度</td>
		<td class="red"><input type="text" name="priority" class="field"
			size=20 value=""></td>--%>
                </tr>
                <%--<tr>
		<td class="red" align="center">主送</td>
		<td class="red" colspan=3>&nbsp;</td>
	</tr>--%>
                <tr>
                    <td class="left" align="center">
                        备注
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxRemark" runat="server" CssClass="input" Height="40px" TextMode="MultiLine"
                            Width="313px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="left" align="center">
                        附件
                    </td>
                    <td class="red" colspan="3">
                        <asp:FileUpload ID="FileUploadPath" runat="server" CssClass="input" />
                    </td>
                </tr>
               <%-- <tr>
                    <td class="red" align="center" colspan='3'>
                        <asp:Button ID="BtnSave" runat="server" Text="保存" CssClass="input" 
                            onclick="BtnSave_Click" />
                        <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
                    </td>
                </tr>--%>
            </table>
            </form>
        </div>
    </div>
    <!--公文拟稿结束-->
    <!--公文类型管理开始-->
    <div id="tabs-3">
        <div id="content1">
            <table class="TableList" align="left" width="95%">
                <tr>
                    <td nowrap="nowrap" class="TableContent">
                        公文类型名称：
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:TextBox ID="TxtTypeName" runat="server"></asp:TextBox>
                    </td>
                    <td nowrap="nowrap" class="TableContent">
                        分类：
                    </td>
                    <td nowrap="nowrap" class="TableData">
                        <select id="category" name="category" class="BigSelect" runat="server">
                            <option value="">所有类型</option>
                            <option value="1">行政</option>
                            <option value="2">其他</option>
                        </select>
                    </td>
                    <td class="TableContent">
                        <asp:Button ID="BtnSearch" runat="server" Text="查询" OnClick="BtnSearch_Click1" />&nbsp;
                        <asp:Button ID="BtnNewType" runat="server" Text="新建类型" OnClick="BtnNewType_Click" />
                    </td>
                </tr>
            </table>
        </div>
       
        <br />
        <div id="content2">
            <table class="table">
                <asp:Repeater ID="RptType" runat="server">
                    <HeaderTemplate>
                        <thead>
                            <tr>
                                <th>
                                    <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                                </th>
                                <th>
                                    名称
                                </th>
                                <th>
                                    所属类别
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
                                <td>
                                    <asp:CheckBox ID="CheckSingle" runat="server" />
                                    <asp:Label ID="SDID" runat="server" Text='<%#Eval("FTID") %>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                </td>
                                <td>
                                    <%# Eval("FT_NAME")%>
                                </td>
                                <td>
                                    <%# Eval("FT_DEPT")%>
                                </td>
                                <td>
                                    <a href="javascript:edit_type('<%# Eval("FTID")%>','0');">编辑</a> <a href="javascript:clean_type('<%# Eval("FTID")%>','43');">
                                        清空公文</a> <a href="javascript:delete_type('<%# Eval("FTID")%>','43');">删除</a>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="2">
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
    </div>
    <!--公文类型管理结束-->
</div>
