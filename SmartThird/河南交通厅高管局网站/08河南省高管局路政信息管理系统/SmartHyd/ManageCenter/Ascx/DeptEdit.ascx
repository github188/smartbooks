<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeptEdit.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.DeptEdit" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
 <!--编辑部门信息开始-->
    <div id="edit">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="2">
                        编辑部门信息
                    </th>
                </tr>
            </thead>
            <tbody >
                <tr height="38" >
                    <td align="center">
                        <asp:Label ID="Lbdeptname" runat="server" Text="部门名称:"></asp:Label>
                        </td>
                        <td>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtDeptName" runat="server" CssClass="input  {required:true,minlength:3,maxlength:12}"></asp:TextBox>
                         <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr height="38">
                    <td align="center">
                        <asp:Label ID="Lbdept" runat="server" Text="上级部门:"></asp:Label>
                        </td>
                        <td>
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                </tr>
                <tr height="38">
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Text="部门描述:"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="txtDptinfo" runat="server" CssClass="input" Height="81px" TextMode="MultiLine"
                            Width="641px"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
            <%--<tfoot>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="重置" />
                    </td>
                </tr>
            </tfoot>--%>
        </table>
    </div>
    <!--编辑部门信息结束-->