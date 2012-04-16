<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChaoXianMgr.aspx.cs" Inherits="AdminMgr_ChaoXianMgr" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>超限运输审批情况表-河南省交通运输厅高速公路管理局网站后台管理系统</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="ContentBox">
    <div id="editmenu1">超限运输审批情况表 >> 信息列表</div>
    
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" HeaderStyle-BackColor="#6298e1" HeaderStyle-Height="25" RowStyle-BackColor="#ebf2f9" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="13" RowStyle-Height="20" RowStyle-HorizontalAlign="Center" BorderColor="#6298E1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <RowStyle BackColor="#EBF2F9" BorderColor="#6298E1" Height="20px" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#6298E1" Font-Bold="True" Font-Size="13pt" Height="25px" />
            <Columns>
                <asp:BoundField DataField="OI_LicencePlate" HeaderText="车牌号" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Length" HeaderText="长(米)" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Width" HeaderText="宽(米)" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Heigth" HeaderText="高(米)" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_GoodsName" HeaderText="货物名称" >
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Weight" HeaderText="车货总重(T)" >
                    <ItemStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Path" HeaderText="通行路线" >
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_CreateDate" HeaderText="办理时间" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_PassDate" HeaderText="通行时间" >
                    <ItemStyle Width="8%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_TransUnit" HeaderText="运输单位" >
                    <ItemStyle Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_PassCode" HeaderText="通行证编号" >
                    <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="OI_Remark" HeaderText="备注" >
                    
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        删除
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="del" runat="server"  CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"OI_ID") %>' OnClientClick="return confirm('确定要删除该记录吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="fengye" style="text-align:center;">
          <asp:Panel ID="dataMsg" runat="server">
              <div style=" width:100%; height:30px; line-height:30px; text-align:center; color:#F00">抱歉,暂无数据!</div>
           </asp:Panel>
          <webdiyer:AspNetPager CssClass="paipai" CurrentPageButtonClass="cpb" 
                ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"   
                Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="30" 
                PrevPageText="上一页"   ShowBoxThreshold="11" TextAfterInputBox="" 
                TextBeforeInputBox=""
                onpagechanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>   
      </div>
    </div>
    
    </div>
    </form>
</body>
</html>
