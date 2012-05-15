<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AfficheEdit.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.AfficheEdit" %>
<div id="divedit">
<table border="0" width="100%" cellspacing="0" cellpadding="3" class="edit">
            <thead>
                <tr>
                    <th colspan="3">
                        编辑公告通知
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
             <%--   <tr>
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
                        <asp:Button ID="BtnSend" runat="server" Text="发布" class="BigButton" 
                            onclick="BtnSend_Click"  />
                        <asp:Button ID="BtnSave" runat="server" Text="保存" class="BigButton" 
                            onclick="BtnSave_Click" />
                        <asp:Button ID="BtnBack" runat="server" Text="返回" class="BigButton" 
                            onclick="BtnBack_Click"  />
                    </td>
                </tr>--%>
            </tbody>
        </table>
</div>