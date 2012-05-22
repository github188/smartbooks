<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentTypeManage.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.DocumentTypeManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../../Ascx/Department.ascx" TagName="Department" TagPrefix="uc1" %>
<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">新建档案分类</a></li>
        <li><a href="#tabs-2">档案分类管理</a></li>
    </ul>
    <!--新建档案分类开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">
                    <td colspan="2">
                        新建档案分类
                    </td>
                </tr>
                <!--所属部门-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        所属部门:
                    </td>
                    <td class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                </tr>

                <!--父级节点-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        父级节点:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlParentNode" runat="server" CssClass="input">
                        </asp:DropDownList>
                    </td>
                </tr>

                <!--分类名称-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        分类名称:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtTypeName" runat="server" 
                            CssClass="input {required:true,minlength:1,maxlength:50}"
                            Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;"></div>
                    </td>
                </tr>

                <!--分类描述-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        类别描述:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSummary" runat="server" CssClass="input {required:true,minlength:1,maxlength:50}"
                            Height="81px" TextMode="MultiLine" Width="350">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                        </div>
                    </td>
                </tr>

                <!--排序-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        排序:
                    </td>
                    <td class="TableData">
                        <asp:TextBox ID="txtSort" runat="server" Width="25" 
                            CssClass="input {required:true,minlength:1,maxlength:2}" Text="0">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;"></div>
                    </td>
                </tr>

                <!--分类节点状态-->
                <tr>
                    <td nowrap="nowrap" class="TableData">
                        状态:
                    </td>
                    <td class="TableData">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="input">
                            <asp:ListItem Text="正常" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="删除" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--新建档案分类结束-->
    <!--档案分类管理开始-->
    <div id="tabs-2">
        <table class="TableList" width="100%">
            <asp:Repeater ID="RptList" runat="server">
                <HeaderTemplate>
                    <tbody>
                        <tr class="TableHeader" align="center">                            
                            <td>分类名称</td>
                            <td>分类描述</td>
                            <td>排序</td>
                            <td>状态</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="TableLine1">                        
                        <td><%# Eval("TYPENAME")%></td>
                        <td><%# Eval("SUMMARY")%></td>
                        <td><%# Eval("SORT")%></td>
                        <td><%# Eval("STATUS").ToString().Equals("0") ? "正常" : "删除"%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
    </div>
    <!--档案分类管理结束-->
</div>
