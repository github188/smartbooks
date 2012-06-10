<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermList.aspx.cs" Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路产设备列表页</title>
    <link rel="stylesheet" type="text/css" href="../Css/tongdaoa.css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        /*打开/闭合查询条件设置面板*/
        function showConditionPanel() {
            if ($("#search_condition_panel").css("display") == "none") {
                $("#search_condition_panel").css("display", "block");
            } else {
                $("#search_condition_panel").css("display", "none");
            }
        }

        /*查询前 数据验证*/
        function DataValidate() {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
                <tr>
                    <td style="height: 24px;">
                        <div id="menu">
                            <div class="OperateNote">
                                <span id="buttons">
                                    <img src="../../Images/branch.png" alt="" border="0" />当前位置：路产设备管理 > 路产查询</span></div>
                            <ul>
                                <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="RoadTermAdd.aspx"
                                    title="新增路产" target="PatrolFrame"><span id="buttons">
                                        <img src="../../Images/add.png" alt="" border="0" />新增路产</span></a></li>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
                    <td>
                        <table id="PatrolSearch" width="480" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="80" height="24" align="right">
                                    路政<span id="PatrolSearch1">单位：</span>
                                </td>
                                <td width="120" height="24">
                                    <uc1:Department ID="Department1" runat="server" />
                                </td>
                                <td width="80" height="24" align="right">
                                    <span id="PatrolSearch2">设备名称：</span>
                                </td>
                                <td width="120" height="24">
                                    <asp:TextBox ID="txt_vehicleLicense" runat="server" class="controlstyle txtboxstyle"></asp:TextBox>
                                </td>
                                <td width="80" height="24" align="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="24" align="right">
                                    <span id="PatrolSearch3">起始时间：</span>
                                </td>
                                <td height="24">
                                    <asp:TextBox ID="txt_startTime" runat="server" class="Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                                </td>
                                <td height="24" align="right">
                                    <span id="PatrolSearch4">截止时间：</span>
                                </td>
                                <td height="24">
                                    <asp:TextBox ID="txt_endTime" runat="server" class="Wdate controlstyle" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                                </td>
                                <td width="80" height="24" align="center">
                                    <asp:Button ID="btn_ok" runat="server" Text="" CssClass="btn_search" OnClick="btn_ok_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="gv_patrollist" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                            <Columns>
                                <asp:CheckBoxField />
                                <asp:BoundField DataField="TYPENAME" HeaderText="设备类型" />
                                <asp:BoundField DataField="ROADNAME" HeaderText="设备名称" />
                                <asp:BoundField DataField="DPTNAME" HeaderText="所属部门" />
                                <asp:BoundField DataField="LINENAME" HeaderText="高速公路" />
                                <asp:BoundField DataField="STAKEK" HeaderText="桩号位置" />
                                <asp:BoundField DataField="REGTIME" HeaderText="登记时间" />
                                <asp:BoundField DataField="COMPTIME" HeaderText="竣工时间" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
                PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
            </webdiyer:AspNetPager>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript">
    //tab效果通用函数
    function nTabs(tabObj, obj, n) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        for (i = 0; i < n; i++) {
            if (tabList[i].id == obj.id) {
                document.getElementById(tabObj + "_Title" + i).className = "actived";
            } else {
                document.getElementById(tabObj + "_Title" + i).className = "normal";
            }
        }
    }

</script>
