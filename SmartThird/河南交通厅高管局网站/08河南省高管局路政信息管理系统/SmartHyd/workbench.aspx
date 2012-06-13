<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workbench.aspx.cs" Inherits="SmartHyd.workbench" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>我的工作台</title>

    <link href="Css/css.css" rel="stylesheet" type="text/css" />
    <link href="Css/Loading.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />

    <script src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <!--ExtJS Library-->
    <link href="Scripts/ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ext/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="Scripts/ext/ext-all.js" type="text/javascript"></script>
    <script src="Scripts/system/ALLEvents.js" type="text/javascript"></script>
    <script type="text/javascript">

//        Ext.onReady(function () {
//            var center = new Ext.TabPanel({
//                id:"work",
//                border: true,
//                region: "south",
//                //默认选中第一个
//                activeItem: 0,
//                //如果Tab过多会出现滚动条
//                enableTabScroll: true,
//                //加载时渲染所有
//                //deferredRender:false,
//                layoutOnTabChange: true,
//                items:
//                [{
//                    xtype: "panel",
//                    id: "index",
//                    iconCls: "workbenchicon",
//                    title: "即时通讯",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                }, {
//                    xtype: "panel",
//                    id: "index1",
//                    iconCls: "workbenchicon",
//                    title: "事务提醒",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                } ,{
//                    xtype: "panel",
//                    id: "index2",
//                    iconCls: "workbenchicon",
//                    title: "最新公告",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                } ,{
//                    xtype: "panel",
//                    id: "index3",
//                    iconCls: "workbenchicon",
//                    title: "未读公文",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                } ,{
//                    xtype: "panel",
//                    id: "index4",
//                    iconCls: "workbenchicon",
//                    title: "待办事项",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                }, {
//                    xtype: "panel",
//                    id: "index5",
//                    iconCls: "workbenchicon",
//                    title: "今日路况",
//                    html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

//                }],
//                plugins: new Ext.ux.TabCloseMenu()
//            });

//            var north = new Ext.Panel({
//                border: false,
//                region:"center",
//                defaults: { bodyStyle: 'margin:0;padding:0;' },
//                id:"title"
//            });

//            new Ext.Viewport({
//                layout: "border",
//                items: [north, center]
//            });
//        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="title">
        <div class="welcome">欢迎您，Administrator!</div>
        <div class="weather">今日天气：郑州 21°C-35°C 晴</div>
    </div>

    <div id="work"></div>
    </form>
</body>
</html>
