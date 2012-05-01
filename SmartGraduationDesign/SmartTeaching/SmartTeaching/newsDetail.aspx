<%@ Page Title="文章详情" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true"
    CodeBehind="newsDetail.aspx.cs" Inherits="SmartTeaching.newsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="items">
        <div class="left">
            <img src="images/item1.jpg" /></div>
        <div class="ites">
            文章详情</div>
        <div class="right">
            <img src="images/item3.jpg" /></div>
    </div>
    <div id="about">
        <div class="All_about">
            <div class="news_name">
                <h2><asp:Literal ID="litNewsTitle" runat="server"></asp:Literal></h2>
                发布时间：<asp:Literal ID="ltlCreateDate" runat="server"></asp:Literal>
            </div>
            <table width="712">
                <tr>
                    <td>
                        <div style="background-color: #DDD; width: 712px;">
                            <strong>摘要：</strong>
                            <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                        </div>
                        <asp:Literal ID="litNewsContent" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
