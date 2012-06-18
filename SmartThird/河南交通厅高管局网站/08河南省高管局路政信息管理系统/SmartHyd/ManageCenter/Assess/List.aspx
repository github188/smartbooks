<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SmartHyd.ManageCenter.Assess.List" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>考评管理</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：绩效考核 > 考评管理 </span>
                    </div>
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="Add.aspx"
                            target="EvaluationManagerFrame"><span id="Span1">
                                <img src="../../Images/add.png" alt="" border="0" />单位加分</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <!--首选行-->
            <tr class="TableHeader">
                <td>
                    考评管理
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    
                    <table cellpadding="0" cellspacing="0" style="float:left;" class="TableBlock">
                        <tr>
                            <td width="60" nowrap="nowrap" class="TableData">选择部门:</td>
                            <td nowrap="nowrap" class="TableData">
                                <uc1:Department ID="Department1" runat="server" />
                            </td>
                            <td width="60" nowrap="nowrap" class="TableData">考评项目:</td>
                            <td nowrap="nowrap" class="TableData">
                                <asp:DropDownList ID="ddlParentType" runat="server" CssClass="input {required:true}" Width="190">
                                </asp:DropDownList>
                            </td>
                            <td nowrap="nowrap" class="TableData"></td>
                        </tr>
                        <tr>
                            <td width="60" nowrap="nowrap" class="TableData">开始时间:</td>
                            <td nowrap="nowrap" class="TableData">
                                <asp:TextBox ID="txtBeginTime" runat="server" CssClass="input Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            </td>
                            <td width="60" nowrap="nowrap" class="TableData">结束时间:</td>
                            <td nowrap="nowrap" class="TableData">
                                <asp:TextBox ID="txtEndTime" runat="server" CssClass="input Wdate" Width="120" onFocus="WdatePicker({isShowClear:false,readOnly:true})"></asp:TextBox>
                            </td>
                            <td nowrap="nowrap" class="TableData">
                                <asp:Button ID="btnSubmit" runat="server" Text="查询" CssClass="Button" 
                                    onclick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                   <asp:GridView ID="grvList" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" Font-Size="12px" 
                        BorderWidth="1px" CellPadding="3"
                        Width="100%" onrowcommand="grvList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="TICKTIME" HeaderText="日期时间">
                                <ItemStyle Width="110" />
                            </asp:BoundField>

                            <asp:BoundField DataField="SCORE" HeaderText="考评分值">
                                <ItemStyle Width="60" />
                            </asp:BoundField>

                            <asp:BoundField DataField="REASON" HeaderText="考评原因" />


                            <asp:TemplateField HeaderText="操作选项">
                                <ItemTemplate>                                    
                                    <asp:LinkButton runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>'>编辑</asp:LinkButton>
                                    <asp:LinkButton runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60" />
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
                    <asp:Literal ID="Literal1" Visible="false" runat="server"></asp:Literal>
                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="anpager" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" onpagechanging="AspNetPager1_PageChanging">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td nowrap="nowrap">
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>

