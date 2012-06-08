<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentCheckOut.ascx.cs"
    Inherits="SmartHyd.ManageCenter.Ascx.DocumentCheckOut" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<table border="0" width="100%" cellspacing="0" class="small">
    <tr>
        <td>
            <span class="big3" style="margin-right: 20px;">考核操作</span>
            <asp:Button ID="btnCheckOut" runat="server" Text="结贴" CssClass="BigButtonA" OnClick="btnCheckOut_Click" />
            <asp:Button ID="btnBacktrack" runat="server" Text="返回" OnClick="btnBacktrack_Click"
                CssClass="BigButtonA" />
        </td>
        <td style="float: right;">
            <asp:Label ID="Label1" runat="server" Text="公文分值:"></asp:Label>
            <asp:TextBox ID="txtScore" runat="server" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="TableList" width="100%">
            <tbody>
                <!--数据列表标题栏-->
                <tr class="TableHeader" align="center">
                    <td width="230">
                        部门名称
                    </td>
                    <td>
                        回复标题
                    </td>
                    <td width="170">
                        回文字号
                    </td>
                    <td width="170">
                        回复时间
                    </td>
                    <td width="170">
                        考核分值
                    </td>
                </tr>
                <!--回文列表-->
                <asp:Repeater ID="repReplyList" runat="server">
                    <ItemTemplate>
                        <tr class="TableLine1" align="center">
                            <td align="left">
                                <input type="hidden" value='<%#Eval("id")%>' />
                                <%#Eval("dptname")%>
                            </td>
                            <td align="left">
                                <%#Eval("title").ToString().Equals("") ? "未回复" : Eval("title")%>
                            </td>
                            <td>
                                <%#Eval("sendcode").ToString().Equals("") ? "未回复" : Eval("sendcode")%>
                            </td>
                            <td>
                                <%#Eval("TIMESTAMP").ToString().Equals("") ? "未回复" : Eval("TIMESTAMP")%>
                            </td>
                            <td>
                                <input type="text" value='<%#Eval("score").ToString().Equals("") ? "0" : Eval("score")%>'
                                    class="input {required:true,minlength:1,maxlength:3}" style="width: 75px;" />
                                <div class="validate ui-state-highlight ui-corner-all " style="border: none;">
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="Go" TextAfterPageIndexBox="页"
            TextBeforePageIndexBox="转到" OnPageChanging="AspNetPager1_PageChanging" CssClass="anpager"
            CurrentPageButtonClass="cpb">
        </webdiyer:AspNetPager>

        <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
