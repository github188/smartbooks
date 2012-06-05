<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtificialPatrol.aspx.cs" Inherits="SmartHyd.Patrol.ArtificialPatrol" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人工巡逻列表页</title>
    <link rel="stylesheet" type="text/css" href="../Css/tongdaoa.css" />
    <link href="../Css/patrol.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
        <tr>
            <td style="height:30px;">
                <div id="menu">
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,4)" class="actived"><a href="PatrolEdit.aspx" title="信息新增" target="PatrolFrame"><span id="buttons"><img src="../Images/add.png" border="0"/>新增</span></a></li>
                        <li id="menu_Title1" onclick="nTabs('menu',this,4)" class="normal"><a href="#"><span id="buttons"><img src="../Images/edit.png" border="0"/>编辑</span></a></li>
                        <li id="menu_Title2" onclick="nTabs('menu',this,4)" class="normal"><a href="#"><span id="Span1"><img src="../Images/delete.png" border="0"/>删除</span></a></li>
                        <li id="Li1" onclick="nTabs('menu',this,4)" class="normal"><a href="#"><span id="Span2"><img src="../Images/search.png" border="0"/>查询</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="gv_patrollist" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" Width="100%">
                    <Columns>
                        <asp:CheckBoxField />
                        <asp:BoundField DataField="dptname" HeaderText="隶属部门" />
                        <asp:BoundField DataField="username" HeaderText="巡逻人员" />
                        <asp:BoundField DataField="busnumber" HeaderText="车牌号" />
                        <asp:BoundField DataField="mileage" HeaderText="巡查里程" />
                        <asp:BoundField DataField="weather" HeaderText="天气状况" />
                        <asp:BoundField DataField="ticktime" HeaderText="交接班时间" />
                        <asp:BoundField DataField="buskm" HeaderText="接班巡逻车里程表" />
                        <asp:CommandField DeleteImageUrl="~/Images/delete.png" 
                            EditImageUrl="~/Images/edit.png" ShowEditButton="True" />
                        <asp:CommandField DeleteImageUrl="~/Images/delete.png" 
                            ShowDeleteButton="True" />
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
    



    <%--<table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>单位部门</th>
                            <th>巡逻人员</th>
                            <th>巡查车牌号</th>
                            <th>巡查里程</th>
                            <th>天气情况</th>
                            <th>交接班时间</th>
                            <th>接班巡逻车里程表（KM）</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td><%#Eval("dptname") %></td>
                            <td><%#Eval("username") %></td>
                            <td><%#Eval("busnumber") %>></td>
                            <td><%#Eval("mileage") %></td>
                            <td><%#Eval("weather") %>></td>
                            <td><%#Eval("ticktime") %>></td>
                            <td><%#Eval("buskm") %>></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>--%>

        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20" CssClass="anpager" CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>
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