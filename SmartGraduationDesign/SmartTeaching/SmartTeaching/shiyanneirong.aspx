<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="shiyanneirong.aspx.cs"
    Inherits="SmartTeaching.shiyanneirong" Title="实验内容" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="items">
        <div class="left">
            <img src="images/item1.jpg" /></div>
        <div class="ites">
            实验内容下载</div>
        <div class="right">
            <img src="images/item3.jpg" /></div>
    </div>
    <div id="about">
        <div class="All_about">
            <ul>
                <asp:DataList ID="shiyanlist" runat="server" Width="99%">
                    <ItemTemplate>
                        <li>
                            <table width="95%" height="94" border="0" align="center" cellpadding="0" cellspacing="1"
                                bgcolor="#000000">
                                <tr bgcolor="#FFFCF6">
                                    <td width="59%" bordercolor="#FFFFFF" bgcolor="#FFFCF6">
                                        <strong>
                                            <%#Eval("NewsTitle")%></strong>
                                    </td>
                                    <td width="41%" bgcolor="#FFFCF6">
                                        <%#Eval("Summary") %>
                                    </td>
                                </tr>
                                <tr bgcolor="#FFFFFF">
                                    <td>
                                        整理时间：<%#Eval("CreateDate") %>&nbsp; 文件大小：<%#Eval("FileSize") %>
                                    </td>
                                    <td>
                                        <a href='upload/<%#Eval("FileName")%>'>点击下载</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" bgcolor="#FFFFFF">
                                        内容描述：<%#Eval("Summary")%>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ItemTemplate>
                </asp:DataList>
                <li>
                    <div align="center">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pages" CurrentPageButtonClass="cpb" OnPageChanging="AspNetPager1_PageChanging" PageSize="4">
                            </webdiyer:AspNetPager></div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
