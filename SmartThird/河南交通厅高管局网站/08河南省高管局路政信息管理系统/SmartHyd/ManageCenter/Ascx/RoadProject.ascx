<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoadProject.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.RoadProject" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">路政许可申请单</a></li>
        <li><a href="#tabs-2">许可案件办理进度</a></li>
    </ul>
    <!--路政许可申请单开始-->
    <div id="tabs-1">
        <table border="0" width="100%" cellspacing="0" cellpadding="3" class="edit">
            <thead>
                <tr>
                    <th colspan="3">
                        路政许可申请单
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp; 申请人及法定代表人名称：
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtName" runat="server" CssClass="input {required:true}"></asp:TextBox>
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
                    <td nowrap="nowrap" class="TableHeader" colspan="2">
                        <b>&nbsp;联系方式</b>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        住址：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtAddress" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        邮箱：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        邮编：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtPost" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        电话：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TEL_NO_DEPT" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        手机：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="MOBIL_NO" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        申请许可事项及内容：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        委托代理人：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtDEPUTY" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        申请材料目录：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtMATERIALS" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        申请日期：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtTime" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;备注：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="Txtremark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        &nbsp;附件：
                    </td>
                    <td class="TableData">
                        <asp:FileUpload ID="FulRoad" runat="server" />
                    </td>
                </tr>
                <tr align="center" class="TableControl">
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--路政许可申请单结束-->
    <!--许可案件办理进度开始-->
    <div id="tabs-2">
    </div>
    <!--许可案件办理进度结束-->
</div>
