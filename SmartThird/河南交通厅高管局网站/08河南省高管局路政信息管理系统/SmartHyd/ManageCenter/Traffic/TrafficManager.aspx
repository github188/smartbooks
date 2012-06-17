<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrafficManager.aspx.cs" Inherits="SmartHyd.ManageCenter.Traffic.TrafficManager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路况信息管理-高速路况</title>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/QDRegEx.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
        	 margin:0px;
        	 padding:0px;
        	 font-size:12px;
             font-family:微软雅黑;
        }
        .TableHeader
        {
            font-weight: bold;
            color: #ffffff;
        }
        .titlebar{ height:20px;line-height:20px;  text-align:right; font-weight:bold;
        }
        .td_content{height:24px; line-height:24px;}
    </style>

    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function IllageOverloadReport() {
            window.location.href = "TrafficReported.aspx";
        }

        function search() {
            alert('系统没有检索到符合条件的数据！');
        }

        function exportexcel() {
            alert('系统没有检索到路况信息数据，无法导出Excel报表！');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="1000"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="menu">
             <div class="OperateNote"><span id="buttons"><img src="../../Images/branch.png" alt="" border="0" />当前位置：高速路况》路况信息管理</span></div>
             <div class="ReturnPreview"><span id="buttons" onclick="IllageOverloadReport()" style="cursor:hand;"><img src="../../Images/icons/trafficreport.png" alt="" border="0" />路况信息上报</span></div>
        </div>
        <table width="100%" border="0" cellspacing="1" cellpadding="0" style=" background-color:#82aadf">
  <tr>
    <td width="100px" bgcolor="white" class="titlebar">路况类型：</td>
    <td bgcolor="white" colspan="3">
        <asp:RadioButton ID="RadioButton1" runat="server" Text="全部路况" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="高速路况" />
        <asp:RadioButton ID="RadioButton3" runat="server" Text="涉桥路况" />
        <asp:RadioButton ID="RadioButton4" runat="server" Text="涉隧路况" />
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">高速主线：</td>
    <td bgcolor="white"><asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
        </asp:DropDownList></td>
    <td bgcolor="white" class="titlebar">路段：</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">上报单位：</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList3" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
    <td bgcolor="white" class="titlebar">阻断原因：</td>
    <td bgcolor="white">
        <asp:DropDownList ID="DropDownList4" runat="server" Width="150px">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td bgcolor="white" class="titlebar">上报时间：</td>
    <td bgcolor="white">
        <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>
        至
        <asp:TextBox ID="TextBox2" runat="server" Width="120px"></asp:TextBox>
      </td>
    <td bgcolor="white" class="titlebar">信息状态：</td>
    <td bgcolor="white">
        <asp:RadioButton ID="RadioButton5" runat="server" Text="即时信息" />
        <asp:RadioButton ID="RadioButton6" runat="server" Text="历史信息" />
        <asp:RadioButton ID="RadioButton7" runat="server" Text="无效信息" />
      </td>
  </tr>
  <tr>
    <td bgcolor="white" colspan="4" class="titlebar">
    <div id="menu">
        <span id="buttons" style="cursor:hand;" onclick="search()">
            <img src="../../Images/icons/search.png" />信息检索</span>&nbsp;
            <span id="buttons" style="cursor:hand;padding-right:10px;" onclick="exportexcel()">
            <img src="../../Images/icons/excel.png" />导出Excel</span>
        </div>
    </td>
  </tr>
</table>


        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background-color: #045185">
                    <tr class="TableHeader" align="center">

                        <td width="60px"  style="border-right:1px solid #ffffff;">
                            序号
                        </td>
                        <td width="120px" style="border-right:1px solid #ffffff;">
                            信息状态
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            路线编号
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            路段名称
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            起止位置
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            路况类型
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            阻断原因
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            上报单位
                        </td>
                        <td style="border-right:1px solid #ffffff;">
                            上报时间
                        </td>
                        <td width="150px" style="border-right:1px solid #ffffff;">
                            操作
                        </td>
                    </tr>
                <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <tr class="TableLine1" align="center">
                        <td style="background-color: #ffffff;">
                            <%# Eval("username")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("jobnumber")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("jobnumber")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("realname")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <%# Eval("PHONE")%>
                        </td>
                        <td style="background-color: #ffffff;">
                            <a href="../../ManageCenter/Empower.aspx?userid=<%# Eval("userid")%>&name=<%# Eval("username")%>">详细</a>&nbsp;
                            <a href="UserEdit.aspx?action=update&deptid=<%# Eval("DEPTID")%>&userid=<%# Eval("userid")%>">编辑</a>&nbsp;
                            <a href="UserCenter.aspx?action=del&userid=<%# Eval("userid")%>">删除
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
    </table>
    <asp:Literal ID="litmsg" Visible="false" Text="<div class='msg'>暂无高速路况信息</msg>" runat="server"></asp:Literal>
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
