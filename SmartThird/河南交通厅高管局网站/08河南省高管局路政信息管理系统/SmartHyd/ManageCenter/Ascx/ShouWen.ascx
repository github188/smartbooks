<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShouWen.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Shouwen" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">收文管理</a></li>
        <li><a href="#tabs-2">收文批复</a></li>
    </ul>
    <!--收文管理开始-->
    <div id="tabs-1">
        <div id="search" style="float: right;">
            发文类型：
            <select name="tid" class="SmallSelect">
                <option value="">全部</option>
                <option value="88">会议纪要</option>
                <option value="89">通知</option>
                <option value="25">邀请函</option>
                <option value="35">上级转发</option>
                <option value="69">通知通报</option>
                <option value="79">政府发文稿纸</option>
            </select>
            标题：<input type="text" name="title" size="15" value="" onclick="this.value='';" class="input" />
            <input type="submit" value="查询" class="SmallButton" />
            <input type="reset" value="重置" class="SmallButton" />
        </div>
        <table class="table">
            <asp:Repeater ID="RptShouwen" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                <asp:CheckBox ID="Checkallshouwen" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                标题
                            </th>
                            <th>
                                原号
                            </th>
                            <th>
                                来文机关
                            </th>
                            <th>
                                来文时间
                            </th>
                            <th>
                                办理进度
                            </th>
                            <th>
                                办理结果
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
                                <asp:CheckBox ID="CheckSingleShouwen" runat="server" />
                                <asp:Label ID="SID" runat="server" Text='<%#Eval("SID") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                            </td>
                            <td>
                                <%# Eval("S_TITLE")%>
                            </td>
                            <td>
                                <%# Eval("S_NUMBERS")%>
                            </td>
                            <td>
                                <%# Eval("S_ORGAN")%>
                            </td>
                            <td>
                                <%# Eval("S_FROMDATE")%>
                            </td>
                            <td>
                                <%# Eval("S_HANDLEPROGRESS")%>
                            </td>
                            <td>
                                <%# Eval("S_RESULT")%>
                            </td>
                            <td>
                                <a href="<%# Eval("SID")%>">编辑</a> <a href="<%# Eval("SID")%>">删除</a>
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
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--收文管理结束-->
    <!--收文批复开始-->
    <div id="tabs-2">
        <div id="content">
            <h1 align="center">
                通知<%# Eval("F_TYPE")%></h1>
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
                        来文机关
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOrgan" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        来文标题
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="txTitle" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        来文内容
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxContent" runat="server" CssClass="input" Height="108px" TextMode="MultiLine"
                            Width="238px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        来文时间
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtFromTime" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        承办时间
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtHandTime" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        涉及相关运营单位
                    </td>
                    <td class="red">
                        <asp:TextBox ID="TxtRelateOrgan" runat="server" TextMode="MultiLine" 
                            Width="220px"></asp:TextBox>
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
                    <td class="red" align="center">
                        办理进度
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtProgress" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        办理结果
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtResult" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="left" align="center">
                        申请人
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtApplicant" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="red" align="center">
                        相关单位承办人
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtHandler" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="left" align="center">
                        备注
                    </td>
                    <td class="red" colspan="3">
                        <asp:TextBox ID="TxtRemark" runat="server" CssClass="input" Height="40px" TextMode="MultiLine"
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
                <tr>
                    <td class="red" align="center" colspan='3'>
                        <asp:Button ID="BtnSave" runat="server" Text="批复" />
                        <asp:Button ID="BtnBack" runat="server" Text="返回" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--收文批复开始-->
</div>
