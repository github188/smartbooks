<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminLeft.aspx.cs" Inherits="menber_adminLeft" Title="功能导航--智慧校园管理平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
        .STYLE3
        {
            font-size: 12px;
            color: #435255;
        }
        .STYLE4
        {
            font-size: 12px;
        }
        .STYLE5
        {
            font-size: 12px;
            font-weight: bold;
        }
        
        #jq-page-menu{width:147px; height:auto; margin:0px; padding:0px;}
        #jq-page-menu a{ display:none; float:left; text-align:center;} 
        .has_children{cursor:pointer; color:Blue;}
        .highlight{ color:Red;}
        
    </style>    
    <script language="javascript">
        $(".has_children").click(function () {
            $(this).addClass("highlight").children("a").show().end().siblings()
            .removeClass("highlight").children("a").hide();
            alert("hi");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="jq-page-menu">
        <div class="has_children">
            <span>负面舆情</span>
        </div>
        <div class="has_children">
            <span>与我相关</span>
        </div>
        <div class="has_children">
            <span>我的关注</span>
        </div>
        <div class="has_children">
            <span>专题事件</span>
            <a>西藏问题</a>
            <a>南海问题</a>
            <a>拆迁问题</a>
        </div>
        <div class="has_children">
            <span>舆情简报</span>
            <a>舆情日报</a>
            <a>舆情周报</a>
            <a>舆情月报</a>
            <a>舆情年报</a>
        </div>
        <div class="has_children">
            <span>分类评级</span>
            <a>按传播范围评级</a>
            <a>按情感色彩评级</a>
            <a>按事态演变评级</a>
        </div>
        <div class="has_children">
            <span>统计图表</span>
            <a>按专题统计</a>
            <a>按区域统计</a>
            <a>按媒体统计</a>
            <a>按网站统计</a>
            <a>按评论统计</a>
            <a>按点击统计</a>
        </div>
        <div class="has_children">
            <span>预警通知</span>
            <a>邮件通知</a>
            <a>短信通知</a>
        </div>
    </div>
</asp:Content>