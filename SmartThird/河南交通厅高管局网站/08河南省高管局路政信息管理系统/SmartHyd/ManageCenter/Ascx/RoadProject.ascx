<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoadProject.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.RoadProject" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">许可案件办理进度</a></li>
        <li><a href="#tabs-2">路政许可申请单</a></li>
    </ul>
    <!--许可案件办理进度开始-->
    <div id="tabs-1">
        <table class="edit">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                        <th>
                                <asp:CheckBox ID="Checkall" runat="server" Text="全选" OnClick="javascript:selectall(this);" />
                            </th>
                            <th>
                                申请人
                            </th>
                            <th>
                                申请许可事项及内容
                            </th>
                            <th>
                                申请材料目录
                            </th>
                            <th>
                                审核状态
                            </th>
                            <th>
                                审核意见
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
                                <asp:CheckBox ID="Checkitem" runat="server" />
                            </td>
                            <td>
                            <%# Eval("REQUISITIONNAME")%>
                            </td>
                            <td>
                             <%# Eval("REQUISITIONCONTENT")%>
                            </td>
                            <td>
                            <%# Eval("MATERIALS")%>
                            </td>
                            <td>
                            <%# Eval("AUDIT_STATE")%>
                            </td>
                            <td>
                            <%# Eval("AUDIT_DESC")%>
                            </td>
                            <td>
                            <a href="">查看</a>  &nbsp;
                            <a href="">回复</a>  &nbsp;
                            <a href="">转交领导批示</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                </asp:Repeater>
                </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" 
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb" onpagechanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--许可案件办理进度结束-->
    <!--路政许可申请单开始-->
    <div id="tabs-2">
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
                        &nbsp; 申请人（及法定代表人）名称：
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
                    <td nowrap="nowrap" align="center" colspan="2">
                        <b>&nbsp;联系方式</b>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" >
                        住址：
                    </td>
                    <td >
                        <asp:TextBox ID="TxtAddress" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        邮箱：
                    </td>
                    <td >
                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" >
                        邮编：
                    </td>
                    <td >
                        <asp:TextBox ID="TxtPost" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        电话：
                    </td>
                    <td >
                        <asp:TextBox ID="TEL_NO" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" >
                        手机：
                    </td>
                    <td >
                        <asp:TextBox ID="MOBIL_NO" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                 <tr align="center">
                    <td nowrap="nowrap" colspan="2">
                        <b >&nbsp;申请事项</b>
                    </td>
                </tr>
                 <tr>
                    <td nowrap="nowrap">
                        委托代理人：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtDEPUTY" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td nowrap="nowrap">
                        申请日期：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtTime" runat="server" ReadOnly="true" CssClass="input"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        申请许可事项及内容：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td nowrap="nowrap">
                        申请材料目录：
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="TxtMATERIALS" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td nowrap="nowrap">
                        &nbsp;备注：
                    </td>
                    <td>
                        <asp:TextBox ID="Txtremark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap" >
                        &nbsp;附件：
                    </td>
                    <td >
                        <asp:FileUpload ID="FulRoad" runat="server" />
                    </td>
                </tr>
               <%-- <tr  colspan="2">
                    <td align="center" >
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" />
                    </td>
                </tr>--%>
            </tbody>
        </table>
    </div>
    <!--路政许可申请单结束-->
</div>
