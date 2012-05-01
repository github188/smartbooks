<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="jiaoxuetuandui.aspx.cs"
    Inherits="SmartTeaching.jiaoxuetuandui" Title="教学团队" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="left" style="width: 750px; height: auto; float: left;">
        <div id="items">
            <div class="left">
                <img src="images/item1.jpg" /></div>
            <div class="ites">
                教学团队</div>
            <div class="right">
                <img src="images/item3.jpg" /></div>
        </div>
        <div id="about">
            <div class="All_news">
                <ul>
                    <asp:Repeater ID="reGsNew" runat="server">
                        <ItemTemplate>
                            <li><span class="left"><a href='newsDetail.aspx?id=<%#Eval("NewsId")%>'>
                                <%#Eval("NewsTitle").ToString().Length > 30 ? Eval("NewsTitle").ToString().Substring(0, 30) + "..." : Eval("NewsTitle")%>
                            </a></span><span class="right">
                                <%#Eval("CreateDate")%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li style="background-image: none;">
                        <div align="center">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pages" CurrentPageButtonClass="cpb" OnPageChanging="AspNetPager1_PageChanging" PageSize="15">
                            </webdiyer:AspNetPager>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
