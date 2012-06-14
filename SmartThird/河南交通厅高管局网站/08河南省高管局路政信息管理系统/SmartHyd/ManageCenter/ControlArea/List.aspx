<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SmartHyd.ManageCenter.ControlArea.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>违章信息管理</title>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：违章管理 > 违章信息管理 </span>
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
                    违章信息管理
                </td>
            </tr>
            <tr nowrap="nowrap" class="TableData">
                <td>
                    <table class="table">
                        <asp:Repeater ID="repList" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>
                                            编号
                                        </th>
                                        <th>
                                            部门名称
                                        </th>
                                        <th>
                                            违章名称
                                        </th>
                                        <th>
                                            违章分类
                                        </th>
                                        <th>
                                            公路名称
                                        </th>
                                        <th>
                                            桩号(K+M)
                                        </th>
                                        <th>
                                            位置描述
                                        </th>
                                        <th>
                                            登记时间
                                        </th>
                                        <th>
                                            竣工时间
                                        </th>
                                        <th>
                                            物主名称
                                        </th>
                                        <th>
                                            现状描述
                                        </th>
                                        <th>
                                            备注信息
                                        </th>
                                        <th>
                                            现场照片
                                        </th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <%#Eval("ID")%>
                                        </td>
                                        <td>
                                            <%#Eval("DPTNAME")%>
                                        </td>
                                        <td>
                                            <%#Eval("AREANAME")%>
                                        </td>
                                        <td>
                                            <%#Eval("TYPENAME")%>
                                        </td>
                                        <td>
                                            <%#Eval("LINENAME")%>
                                        </td>
                                        <td>
                                            <%#Eval("STAKEK").ToString() + "+" + Eval("STAKEM").ToString() %>
                                        </td>
                                        <td>
                                            <%#Eval("SUMMARY")%>
                                        </td>
                                        <td>
                                            <%#Eval("REGTIME")%>
                                        </td>
                                        <td>
                                            <%#Eval("COMPTIME")%>
                                        </td>
                                        <td>
                                            <%#Eval("OWNER")%>
                                        </td>
                                        <td>
                                            <%#Eval("STATUS")%>
                                        </td>
                                        <td>
                                            <%#Eval("REMARK")%>
                                        </td>
                                        <td>
                                            <%#Eval("PHOTO")%>
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tfoot>
                                    <tr>
                                        <td>
                                            编号
                                        </td>
                                        <td>
                                            部门名称
                                        </td>
                                        <td>
                                            违章名称
                                        </td>
                                        <td>
                                            违章分类
                                        </td>
                                        <td>
                                            公路名称
                                        </td>
                                        <td>
                                            桩号(K+M)
                                        </td>
                                        <td>
                                            位置描述
                                        </td>
                                        <td>
                                            登记时间
                                        </td>
                                        <td>
                                            竣工时间
                                        </td>
                                        <td>
                                            物主名称
                                        </td>
                                        <td>
                                            现状描述
                                        </td>
                                        <td>
                                            备注信息
                                        </td>
                                        <td>
                                            现场照片
                                        </td>
                                    </tr>
                                </tfoot>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                        PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
                    </webdiyer:AspNetPager>
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
