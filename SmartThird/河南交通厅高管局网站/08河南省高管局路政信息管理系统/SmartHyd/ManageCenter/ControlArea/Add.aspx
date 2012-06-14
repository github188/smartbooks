<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SmartHyd.ManageCenter.ControlArea.Add" %>

<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加控制区违章信息</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" border="0" />当前位置：违章管理 > 添加控制区违章信息 </span>
                    </div>
                    <div class="ReturnPreview">
                        <span id="buttons1" onclick="javascript:history.go(-1);">
                            <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td>
                    添加控制区违章信息
                </td>
            </tr>
            <tr nowrap="nowrap" class="TableData">
                <td>
                    <table class="edit" width="100%">
                        <thead>
                            <tr>
                                <th colspan="3">
                                    添加违章建筑
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr height="38">
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="所属部门:"></asp:Label>
                                    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                    <uc1:department id="Department1" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="分类名称:"></asp:Label>
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="input">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="高速公路:"></asp:Label>
                                    <asp:TextBox ID="txtLINENAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <tr height="38">
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="违章名称:"></asp:Label>
                                    <asp:TextBox ID="txtAREANAME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="桩号位置:"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text="K"></asp:Label>
                                    <asp:TextBox ID="txtSTAKEK" runat="server" CssClass="input {required:true}" Width="50"></asp:TextBox>
                                    <asp:Label ID="Label10" runat="server" Text="M"></asp:Label>
                                    <asp:TextBox ID="txtSTAKEM" runat="server" CssClass="input {required:true}" Width="50"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="位置描述:"></asp:Label>
                                    <asp:TextBox ID="txtSUMMARY" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <tr height="38">
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="登记时间:"></asp:Label>
                                    <asp:TextBox ID="txtREGTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="竣工时间:"></asp:Label>
                                    <asp:TextBox ID="txtCOMPTIME" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="物主名称:"></asp:Label>
                                    <asp:TextBox ID="txtOWNER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <tr height="38">
                                <td>
                                    <asp:Image ID="imgPhoto" runat="server" Width="120" Height="120" />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="现场照片:"></asp:Label>
                                    <asp:FileUpload ID="fileupPhoto" runat="server" CssClass="input {required:true}"
                                        Width="160" />
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="备注信息:"></asp:Label>
                                    <asp:TextBox ID="txtREMARK" runat="server" CssClass="input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label11" runat="server" Text="详细描述:"></asp:Label>
                                    <asp:TextBox ID="txtDETAILED" runat="server" CssClass="input {required:true}" TextMode="MultiLine"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label12" runat="server" Text="现状描述:"></asp:Label>
                                    <asp:TextBox ID="txtSTATUS" runat="server" CssClass="input {required:true}" TextMode="MultiLine"></asp:TextBox>
                                    <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="3" style="text-align: center;">
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td colspan="3" nowrap="nowrap">
                    <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="Button" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
