<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegratedQueryResult.aspx.cs" Inherits="SmartHyd.ManageCenter.Overload.IntegratedQueryResult" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>车辆通行综合查询结果-超限治理</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
             font-family:微软雅黑;
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
            <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：超限治理》车辆通行综合查询结果</span></div>
            <div class="ReturnPreview"><span id="buttons" onclick="GoBack()"><img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
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
                                正在进行数据导出请稍后……
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
                <asp:BoundField DataField="车牌" HeaderText="车牌">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="入口站名" HeaderText="入口站名">
                   <ItemStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="入口时间" HeaderText="入口时间">
                   <ItemStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="出口站名" HeaderText="出口站名">
                   <ItemStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="出口时间" HeaderText="出口时间">
                   <ItemStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="支付形式" HeaderText="支付形式">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="轴数" HeaderText="轴数">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:TemplateField>
                         <ItemTemplate>
                             <%# DataBinder.Eval(Container.DataItem, "超载率") + "%"%>
                         </ItemTemplate>
                         <HeaderTemplate>
                             超载率
                         </HeaderTemplate>
                         <ItemStyle Width="70px"/>
                </asp:TemplateField>
                <asp:BoundField DataField="车货总重" HeaderText="总重(吨)">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="金额" HeaderText="金额(元)">
                   <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="里程" HeaderText="里程(KM)">
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
            <asp:Literal ID="litMsg" Visible="false" Text="<div class='msg'>暂无车辆通行信息</msg>" runat="server"></asp:Literal>
            <webdiyer:AspNetPager CssClass="page" ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条，共%RecordCount%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"  PageSize="8" PrevPageText="上一页" ShowCustomInfoSection="Left"  OnPageChanged="AspNetPager1_PageChanged">
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
