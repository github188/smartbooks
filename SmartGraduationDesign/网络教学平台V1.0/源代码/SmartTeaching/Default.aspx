<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="SmartTeaching.Default" Title="网站首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cen_right">
        <div id="items">
            <div class="left">
                <img src="images/item1.jpg" /></div>
            <div class="ites">
                平台描述</div>
            <div class="right">
                <img src="images/item3.jpg" /></div>
        </div>
        <div id="about">
            本网站是一个动态演示数据结构算法执行过程的辅助教学软件, 它可适应读者对算法的输入数据和过程执行的控制方式的不同需求, 在计算机的屏幕上显示算法执行过程中数据的逻辑结构或存储结构的变化状况或递归算法执行过程中栈的变化状况。整个系统使用菜单驱动方式, 每个菜单包括若干菜单项。每个菜单项对应一个动作或一个子菜单。系统一直处于选择菜单项或执行动作状态, 直到选择了退出动作为止。《相关软件请到多媒体课件分类下下载》
        </div>
        <div class="item_news">
            <div class="left" style="width: 356px; margin-left: 5px;">
                <div class="item_item">
                    <span style="margin-left: 35px; float: left">教学团队</span><span style="float: right;
                        font-weight: normal; font-size: 12px"><a href='#'>更多</a></span></div>
                <div class="news_li">
                    <ul>
                        <asp:Repeater ID="jiaoxuetuandui" runat="server">
                            <ItemTemplate>
                                <li><span class="left">
                                        <a href='newsDetail.aspx?id=<%#Eval("NewsId")%>'>
                   <%#Eval("NewsTitle").ToString().Length > 15 ? Eval("NewsTitle").ToString().Substring(0, 15) + "..." : Eval("NewsTitle")%>
                                        </a>
                                    </span>
                                    <span class="right"><%#Eval("CreateDate")%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="left" style="width: 356px; margin-left: 15px;">
                <div class="item_item">
                    <span style="margin-left: 35px; float: left">教学大纲</span><span style="float: right;
                        font-weight: normal; font-size: 12px"><a href='#'>更多</a></span></div>
                <div class="news_li">
                    <ul>
                        <asp:Repeater ID="jiaoxuedagang" runat="server">
                            <ItemTemplate>
                                <li><span class="left">
                                        <a href='newsDetail.aspx?id=<%#Eval("NewsId")%>'>
                   <%#Eval("NewsTitle").ToString().Length > 15 ? Eval("NewsTitle").ToString().Substring(0, 15) + "..." : Eval("NewsTitle")%>
                                        </a>
                                    </span>
                                    <span class="right"><%#Eval("CreateDate")%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="left" style="width: 750px; margin-top: 10px; float: left">
            
        </div>
        <div class="item_news">
            <div class="left" style="width: 356px; margin-left: 5px;">
                <div class="item_item">
                    <span style="margin-left: 35px; float: left">教学教案</span><span style="float: right;
                        font-weight: normal; font-size: 12px"><a href='#'>更多</a></span></div>
                <div class="news_li">
                    <ul>
                        <asp:Repeater ID="jiaoxuejiaoan" runat="server">
                            <ItemTemplate>
                                <li><span class="left">
                                        <a href='newsDetail.aspx?id=<%#Eval("NewsId")%>'>
                   <%#Eval("NewsTitle").ToString().Length > 15 ? Eval("NewsTitle").ToString().Substring(0, 15) + "..." : Eval("NewsTitle")%>
                                        </a>
                                    </span>
                                    <span class="right"><%#Eval("CreateDate")%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="left" style="width: 356px; margin-left: 15px;">
                <div class="item_item">
                    <span style="margin-left: 35px; float: left">学习园地</span><span style="float: right;
                        font-weight: normal; font-size: 12px"><a href='#'>更多</a></span></div>
                <div class="news_li">
                    <ul>
                        <asp:Repeater ID="xuexiyuandi" runat="server">
                            <ItemTemplate>
                                <li><span class="left">
                                        <a href='newsDetail.aspx?id=<%#Eval("NewsId")%>'>
                   <%#Eval("NewsTitle").ToString().Length > 15 ? Eval("NewsTitle").ToString().Substring(0, 15) + "..." : Eval("NewsTitle")%>
                                        </a>
                                    </span>
                                    <span class="right"><%#Eval("CreateDate")%></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
