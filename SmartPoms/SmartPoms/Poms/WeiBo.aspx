<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="WeiBo.aspx.cs" Inherits="SmartPoms.Poms.WeiBo" %>

<%@ Register Src="Ascx/WeiBo.ascx" TagName="WeiBo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jquery.timeago-zh-CN.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            /*加载Cookie*/
            $("#ctl00_ContentPlaceHolder1_WeiBo1_txtKeywordList").attr("value", $.cookie('k'));

            load();

            var scrtime;
            /*导入事件*/
            $("#weiboItem").hover(function () {
                /*删除定时回调事件*/
                clearInterval(loadsin);
            }, function () {
                /*触发定时回调事件*/
                scrtime = setInterval(function () {
                    //淡入滚动效果
                    var $ul = $("#weiboItem");
                    var liHeight = $ul.find("li:last").height();
                    $ul.animate({}, 1000, function () {
                        $ul.find("li:last").prependTo($ul);
                        $ul.find("li:first").hide();
                        $ul.css({ marginTop: 10 });
                        $ul.find("li:first").fadeIn(1000);
                    });
                    /*间隔5秒钟触发一次*/
                }, 2000);
                /*引发mouseleave事件*/
            }).trigger("mouseleave");

            /*定时刷新新浪微博*/
            setInterval(load, 10000);

            /*保存cookie*/
            $("#ctl00_ContentPlaceHolder1_WeiBo1_txtKeywordList").mouseover(function () {
                $.cookie("k", $(this).attr("value"));
            });
        });

        function load() {
            var t = $("#ctl00_ContentPlaceHolder1_WeiBo1_txtKeywordList").attr("value").split(',');
            $.get(
                "../api/HttpUtility.ashx",
                {
                    c: "utf-8",
                    u: "http://api.t.sina.com.cn/statuses/public_timeline.json?source=1256981038"
                },
                function (data) {
                    var json = eval(data);
                    $("#weiboItem").empty();
                    $.each(json, function (i) {
                        /*初始化元素*/
                        var elm = "<li><img src='" + json[i].user.profile_image_url + "' align='" + json[i].user.name + "'/>";
                        elm += "<a href='#'>" + json[i].user.name + "</a>";
                        elm += "<p>" + json[i].text + "</p>";
                        elm += "<span>" + $.timeago(json[i].created_at) + "</span></li>";
                        $("#weiboItem").append(elm);

                        /*根据关键词汇过滤敏感信息*/
                        filterkey(t, json[i]);
                    });
                }
            );            
        }

        /*根据关键词汇过滤敏感信息*/
        function filterkey(words, item) {
            if (words == '') return;
            $.each(words, function (i) {
                if (item.text.indexOf(words[i]) != -1) {
                    var d = '用户名:' + item.user.name + ' 发布时间:' + item.created_at + 
                        ' 微博内容:' + item.text + '所在地:' + item.user.location;
                    /*加入数据库*/
                    $.post(
				        '../api/AddArticle.ashx',
				        {
				            title: item.text,
				            detail: d,
				            stime: new Date(),
				            media: '新浪微博',
				            author: item.user.name,
				            clicknum: '0',
				            commentnum: '0',
				            url: item.user.profile_image_url,
				            extractiontime: new Date(),
				            score: '0',
				            sitename: '新浪微博',
				            urlhash: ''
				        },
				        function (data) {
				        }
                   );
                }
            });	
        }
    </script>
    <!--引入样式-->
    <link type="text/css" rel="stylesheet" href="http://tjs.sjs.sinajs.cn/t3/style/css/common/card.css" />
    <style type="text/css">
        .weiboScrollBox
        {
            width: auto;
            height: auto;
            margin: 2px;
            padding: 4px;
            border: solid 1px #094590;
        }
        .weiboItem
        {
            width: 300px;
            float: left;
            overflow: hidden;
            height: 400px;
            list-style: none;
            border: solid 1px #ebe9e9;
            padding: 10px 10px 10px 10px;
            font-size: 12px;
            line-height: 18px;
            color: #666;
            margin-top: 10px;
            background-color: #ffffff;
        }
        .weiboItem li
        {
            width: 300px;
            float: left;
            padding: 0px;
            margin: 0px;
            border-bottom: dotted 1px #999;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .weiboItem img
        {
            width: 52px;
            height: 52px;
            padding: 0px;
            margin: 0px;
            float: left;
            border: none;
            margin-right: 5px;
        }
        .weiboItem a
        {
            width: auto;
            height: 18px;
            line-height: 18px;
            padding: 0px;
            margin: 0px;
            float: left;
            color: #6EAFD5;
            padding-left: 5px;
            padding-right: 5px;
        }
        .weiboItem p
        {
            width: auto;
            height: auto;
            line-height: 18px;
            margin: 0px;
            color: #666;
        }
        .weiboItem span
        {
            width: auto;
            height: 18px;
            line-height: 18px;
            color: #999;
        }
        #ctl00_ContentPlaceHolder1_WeiBo1_txtKeywordList
        {
            height: 30px;
            width: 800px;
            line-height: 35px;
            font-size: 18px;
            color: #4D4D4C;
            border: 1px solid #9DADC5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span id="ks" style="float: left;"></span>
    <uc1:WeiBo ID="WeiBo1" runat="server" />
</asp:Content>
