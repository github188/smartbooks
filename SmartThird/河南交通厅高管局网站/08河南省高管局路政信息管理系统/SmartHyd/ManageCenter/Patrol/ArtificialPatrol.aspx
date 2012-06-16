<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtificialPatrol.aspx.cs"
    Inherits="SmartHyd.Patrol.ArtificialPatrol" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>�˹�Ѳ���б�ҳ</title>
    <link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        /*��/�պϲ�ѯ�����������*/
        function showConditionPanel() {
            if ($("#search_condition_panel").css("display") == "none") {
                $("#search_condition_panel").css("display", "block");
            } else {
                $("#search_condition_panel").css("display", "none");
            }
        }

        /*��ѯǰ ������֤*/
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
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 740px">
                <tr>
                    <td valign="top">
                        <table class="edit" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr id="search_condition_panel" style="height: 48px; border-bottom: 1px solid #8cb2e2;">
                                <td>
                                    <table id="PatrolSearch" width="480" border="0" cellspacing="0" cellpadding="0">
                                        <%--  <tr>
                                            <td width="80" height="24" align="right">
                                                <span id="PatrolSearch1">Ѳ�ߵ�λ��</span>
                                            </td>
                                            <td width="120" height="24" colspan="3">
                                                <uc1:Department ID="Department1" runat="server" />
                                            </td>
                                             <td width="80" height="24" align="right">
                                   <span id="PatrolSearch2">���ƺţ�</span>
                                </td>
                                <td width="120" height="24">
                                   <asp:TextBox ID="txt_vehicleLicense" runat="server" class="controlstyle txtboxstyle"></asp:TextBox>
                                </td>
                                            <td width="80" height="24" align="right">
                                                &nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td height="24" align="right">
                                                <span id="PatrolSearch3">��ʼʱ�䣺</span>
                                            </td>
                                            <td height="24">
                                                <asp:TextBox ID="txt_startTime" runat="server" class="Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true,readOnly:true})"></asp:TextBox>
                                            </td>
                                            <td height="24" align="right">
                                                <span id="PatrolSearch4">��ֹʱ�䣺</span>
                                            </td>
                                            <td height="24">
                                                <asp:TextBox ID="txt_endTime" runat="server" class="Wdate controlstyle" onFocus="WdatePicker({isShowClear:false,startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true,readOnly:true})"></asp:TextBox>
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
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%"
                                        OnRowCommand="gv_patrollist_RowCommand">
                                        <Columns>
                                            <asp:CheckBoxField />
                                            <asp:BoundField DataField="DEPTID" HeaderText="Ѳ���ж�" />
                                            <asp:BoundField DataField="BUSNUMBER" HeaderText="���ƺ�" />
                                            <asp:BoundField DataField="MILEAGE" HeaderText="Ѳ�����" />
                                            <asp:BoundField DataField="RESPUSER" HeaderText="������" />
                                            <asp:BoundField DataField="WEATHER" HeaderText="����״��" />
                                            <asp:BoundField DataField="ACCEPTCAPTAIN" HeaderText="�Ӱ��жӳ�" />
                                            <asp:BoundField DataField="TICKTIME" HeaderText="���Ӱ�ʱ��" />
                                            <asp:BoundField DataField="BUSKM" HeaderText="�Ӱ�Ѳ�߳���̱�" />
                                            <%--  <asp:CommandField DeleteImageUrl="~/Images/delete.png" EditImageUrl="~/Images/edit.png"
                                    ShowEditButton="True" />
                                <asp:CommandField DeleteImageUrl="~/Images/delete.png" ShowDeleteButton="True" />--%>
                                            <asp:TemplateField HeaderText="����ѡ��">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Lbtview" runat="server" CommandName="view" CommandArgument='<%#Eval("patrolid") %>'>�鿴</asp:LinkButton>
                                                    <%--<asp:LinkButton ID="LbtEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("patrolid") %>'>�༭</asp:LinkButton>--%>
                                                    <asp:LinkButton ID="LbtDel" runat="server" OnClientClick="return confirm('ȷ��ɾ������־��')"
                                                        CommandName="del" CommandArgument='<%#Eval("patrolid") %>'>ɾ��</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="90" />
                                            </asp:TemplateField>
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
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%PageCount%ҳ����ǰΪ��%CurrentPageIndex%ҳ"
                            FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="TextBox"
                            PrevPageText="��һҳ" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                            TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanging="AspNetPager1_PageChanging"
                            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript">
    //tabЧ��ͨ�ú���
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
