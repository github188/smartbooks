<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TermEdit.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.TermEdit" %>

<%@ Register src="~/Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        <asp:Label ID="LabName" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        
                        <uc1:Department ID="Department1" runat="server" />
                        
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="装备类型:"></asp:Label>
                        <asp:DropDownList ID="ddlTermType" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="设备编号:"></asp:Label>
                        <asp:TextBox ID="txtTERMCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="设备名称:"></asp:Label>
                        <asp:TextBox ID="txtTERMNAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="出厂编号:"></asp:Label>
                        <asp:TextBox ID="txtSERIALCODE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="规格型号:"></asp:Label>
                        <asp:TextBox ID="txtFORMAT" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="制造厂商:"></asp:Label>
                        <asp:TextBox ID="txtBRAND" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="装备用途:"></asp:Label>
                        <asp:TextBox ID="txtUse" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="投入时间:"></asp:Label>
                        <asp:TextBox ID="txtUSETIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>

                <tr height="38">
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="设备状态:"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input" >
                            <asp:ListItem Text="正常" Value="0" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label9" runat="server" Text="备注信息:"></asp:Label>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>

            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </tfoot>
        </table>