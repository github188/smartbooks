<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegratedQueryResult.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.IntegratedQueryResult" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>����ͨ���ۺϲ�ѯ���-��������</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
             font-family:΢���ź�;
        }
        .style1
        {
            width: 76px;
        }
    </style>
    <script type="text/javascript">
        function GoBack() {
            history.go(-1);
        }
    </script>

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
            <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã�������������ͨ���ۺϲ�ѯ���</span></div>
            <div class="ReturnPreview"><span id="buttons" onclick="GoBack()"><img src="../../Images/back.png" alt="" border="0" />������һҳ��</span></div>
        </div>
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:100px">
                    <asp:ImageButton ID="ImgBtnExport" runat="server" 
                    onclick="btnExport_Click" ImageUrl="~/Images/btn_excel.png"  /></td>
            
                <td align="left">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div style=" text-align:center; font-size:12px; font-weight:bold;color:Blue;">
                            <img src="../../Images/searching.gif" border="0" />
                                ���ڽ������ݵ������Ժ󡭡�
                            </div>
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                </td>
            </tr>
        </table>
        <div style="width:100%; height:480px; overflow:auto;">
          <asp:GridView ID="gv_overload" runat="server" AutoGenerateColumns="False"  
                CssClass="GridViewStyle4"  ShowHeaderWhenEmpty="True" BackColor="White" 
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="����" HeaderText="����">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="���վ��" HeaderText="���վ��">
                   <ItemStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="���ʱ��" HeaderText="���ʱ��">
                   <ItemStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="����վ��" HeaderText="����վ��">
                   <ItemStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="����ʱ��" HeaderText="����ʱ��">
                   <ItemStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="֧����ʽ" HeaderText="֧����ʽ">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="����" HeaderText="����">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:TemplateField>
                         <ItemTemplate>
                             <%# DataBinder.Eval(Container.DataItem, "������") + "%"%>
                         </ItemTemplate>
                         <HeaderTemplate>
                             ������
                         </HeaderTemplate>
                         <ItemStyle Width="70px"/>
                </asp:TemplateField>
                <asp:BoundField DataField="��������" HeaderText="����(��)">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="���" HeaderText="���(Ԫ)">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="���" HeaderText="���(KM)">
                   <ItemStyle  />
                </asp:BoundField>
            </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle CssClass="HeaderStyle" BackColor="#003399" Font-Bold="True" 
                  ForeColor="#CCCCFF" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle CssClass="RowStyle" BackColor="White" ForeColor="#003399" />
            <AlternatingRowStyle CssClass="AltRowStyle" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
           </asp:GridView>
            <asp:Literal ID="litMsg" Visible="false" Text="<div class='msg'>���޳���ͨ����Ϣ</msg>" runat="server"></asp:Literal>
            <webdiyer:AspNetPager CssClass="page" ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%������%RecordCount%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ"  PageSize="8" PrevPageText="��һҳ" ShowCustomInfoSection="Left"  OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ImgBtnExport" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
