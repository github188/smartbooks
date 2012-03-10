<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminLeft.aspx.cs" Inherits="menber_adminLeft" Title="功能导航--网络舆情监控平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body{margin:0px; padding:0px;}        
        #jq-page-menu{width:147px; height:95%; line-height:23px; margin:0px; padding:0px; text-align:center; font-size:12px; color:black; cursor:pointer;}
        #jq-page-menu span{width:147px; height:23px; float:left; background-image:url("images/main_34.gif");}
        #jq-page-menu a{width:147px; height:23px; display:none; float:left;}
        #jq-page-menuversion{width:147px; height:23px; line-height:23px; margin:0px; padding:0px; text-align:center; font-size:12px; color:black; background-image:url("images/main_69.gif"); float:left;}
    </style>    
    <script language="javascript" type="text/jscript">
        $(document).ready(function () {
            $("#jq-page-menu").children("div").click(function () {
                $(this).children("a").stop().show()
                .fadeTo("fast", 0.5).fadeTo("fast", 1).end().siblings().children("a").hide();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="jq-page-menu">
        <div>
            <span>负面舆情</span>
        </div>
        <div>
            <span>与我相关</span>
        </div>
        <div>
            <span>我的关注</span>
        </div>
        <div>
            <span>专题事件</span>
            <a>西藏问题</a>
            <a>南海问题</a>
            <a>拆迁问题</a>
        </div>
        <div>
            <span>舆情简报</span>
            <a>舆情日报</a>
            <a>舆情周报</a>
            <a>舆情月报</a>
            <a>舆情年报</a>
        </div>
        <div>
            <span>分类评级</span>
            <a>按传播范围评级</a>
            <a>按情感色彩评级</a>
            <a>按事态演变评级</a>
        </div>
        <div>
            <span>统计图表</span>
            <a>按专题统计</a>
            <a>按区域统计</a>
            <a>按媒体统计</a>
            <a>按网站统计</a>
            <a>按评论统计</a>
            <a>按点击统计</a>
        </div>
        <div>
            <span>预警通知</span>
            <a>邮件通知</a>
            <a>短信通知</a>
        </div>
        <div id="jq-page-menuversion">版本:V1.0.0.0</div>
    </div>
</asp:Content>