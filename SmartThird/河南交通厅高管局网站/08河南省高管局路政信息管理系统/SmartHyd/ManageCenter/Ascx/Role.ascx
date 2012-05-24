<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Role.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Role" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">
            <asp:Label ID="LbTabName" runat="server" Text=""></asp:Label>
        </a></li>
        <li><a href="#tabs-2">
        <asp:Label ID="LbTabName1" runat="server" Text="角色管理"></asp:Label>
        </a></li>
    </ul>
    <!--添加角色开始-->
    <div id="tabs-1">
        <table class="TableBlock" width="100%" align="center">           
            <tbody>
                <!--标题栏-->
                <tr class="TableHeader">
                    <td colspan="4">
                    <asp:Label ID="LbHeadName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">角色名称:</td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtRoleName" runat="server" width="150"
                            CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                </tr>

                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">角色描述:</td>
                    <td>
                        <asp:TextBox ID="txtdesc" runat="server" width="150"
                            CssClass="input {required:true}" TextMode="MultiLine">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--添加角色结束-->
    <!--角色管理开始-->
    <div id="tabs-2">
        <table class="TableList" width="100%">
            <tbody>
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>                    
                    <tr class="TableHeader" align="center">
                        <td>编号</td>
                        <td>角色名称</td>
                        <td>角色描述</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>                    
                    <tr class="TableLine1" align="center">
                        <td>
                            <%#Eval("ROLEID")%>
                        </td>
                        <td>
                            <%#Eval("ROLENAME")%>
                        </td>
                        <td>
                            <%#Eval("ROLEINFO")%>
                        </td>
                    </tr>                    
                </ItemTemplate>                
            </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20">
        </webdiyer:AspNetPager>
    </div>
    <!--角色管理结束-->
</div>
