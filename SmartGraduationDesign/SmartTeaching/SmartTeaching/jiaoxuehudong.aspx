<%@ Page  Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="jiaoxuehudong.aspx.cs" Inherits="SmartTeaching.jiaoxuehudong" Title="教学互动" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="items">
        <div class="left">
            <img src="images/item1.jpg" /></div>
        <div class="ites">
            教学互动</div>
        <div class="right">
            <img src="images/item3.jpg" /></div>
    </div>
    <div id="about">
        <div class="All_about">
            <ul>
                <asp:DataList ID="bbsList" runat="server" Width="99%">
                    <ItemTemplate>
                        <li>
                            <table width="95%" height="94" border="0" align="center" cellpadding="0" cellspacing="1"
                                bgcolor="#000000">
                                <tr bgcolor="#FFFCF6">
                                    <td width="59%" bordercolor="#FFFFFF" bgcolor="#FFFCF6">
                                        <strong>发送者：<%#Eval("UserName")%></strong>
                                    </td>
                                    <td width="41%" bgcolor="#FFFCF6">
                                        接收者：<%#Eval("ToUserName") %>
                                    </td>
                                </tr>
                                <tr bgcolor="#FFFFFF">
                                    <td>
                                        发送时间：<%#Eval("CreateDate") %></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr bgcolor="#FFFFFF">
                                    <td colspan="2">
                                        消息内容:<%#Eval("NewsContent") %>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ItemTemplate>
                </asp:DataList>
                <li>
                    <div align="center">
                        <webdiyer:aspnetpager ID="AspNetPager1" runat="server" CssClass="pages" 
                            CurrentPageButtonClass="cpb" OnPageChanging="AspNetPager1_PageChanging" 
                            PageSize="4">
                            </webdiyer:aspnetpager></div>
                </li>
            </ul>
        </div>
    </div>


</asp:Content>
