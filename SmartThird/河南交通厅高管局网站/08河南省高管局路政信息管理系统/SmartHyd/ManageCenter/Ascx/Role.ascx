<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Role.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.Role" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<div id="tab">
    <ul>
        <li><a href="#tabs-1">添加角色</a></li>
        <li><a href="#tabs-2">角色管理</a></li>
    </ul>
    <!--添加角色开始-->
    <div id="tabs-1">
        <table class="edit" width="100%">
            <thead>
                <tr>
                    <th colspan="3">
                        添加角色
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="角色名称:"></asp:Label>
                        <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                    
                        <asp:TextBox ID="TxtRoleName" runat="server" CssClass="input {required:true}"></asp:TextBox><span>*</span>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="角色描述:"></asp:Label>
                  
                        <asp:TextBox ID="txtdesc" runat="server" CssClass="input {required:true}" TextMode="MultiLine"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;">
                        </div>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" style="text-align: center;">
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    <!--添加角色结束-->
    <!--角色管理开始-->
    <div id="tabs-2">
        <table class="table">
            <asp:Repeater ID="repList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>
                                编号
                            </th>
                            <th>
                                角色名称
                            </th>
                            <th>
                                角色描述
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td>
                                <%#Eval("ROLEID")%>
                            </td>
                            <td>
                                <%#Eval("ROLENAME")%>
                            </td>
                            <td>
                                <%#Eval("ROLEINFO")%>
                            </td>
                            <td>
                                <a href='RoleEdit.aspx?rid=<%#Eval("ROLEID")%>'>编辑</a>
                                <a href="">删除</a>
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td>
                                编号
                            </td>
                            <td>
                                角色名称
                            </td>
                            <td>
                                角色描述
                            </td>
                             <td>
                                
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging"
            PageSize="20">
        </webdiyer:AspNetPager>
    </div>
    <!--角色管理结束-->
</div>
