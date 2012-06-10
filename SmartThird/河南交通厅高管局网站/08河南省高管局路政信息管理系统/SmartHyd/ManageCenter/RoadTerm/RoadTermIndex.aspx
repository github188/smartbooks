<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoadTermIndex.aspx.cs"
    Inherits="SmartHyd.ManageCenter.RoadTerm.RoadTermIndex" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路产设备管理</title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            width: 100%;
            height: 100%;
        }
        ul li
        {
            margin: 0;
            padding: 0;
            border: 0;
            list-style: none;
        }
        #menu
        {
            height: 35px;
            background-image: url(../../Images/ui-hander-background-1.png);
            background-repeat: repeat-x;
            font-family: 微软雅黑;
        }
        #menu .patrolsitemap
        {
            height: 27px;
            line-height: 27px;
            margin-top: 8px;
            width: auto;
            color: #f2a41e;
            font-size: 12px;
            font-weight: bold;
            float: left;
        }
        #menu ul
        {
            margin: 0;
            float: right;
            padding-top: 8px;
            height: 27px;
        }
        #menu ul li
        {
            width: 140px;
            line-height: 27px;
            float: left;
            margin-left: 5px;
        }
        
        #menu .normal
        {
            display: block;
            text-align: center;
            color: #FFF;
            font-weight: bold;
            background: url(../../images/btn_hover1.png) no-repeat;
            width: 140px;
            height: 27px;
            line-height: 27px;
            overflow: hidden;
            font-size: 13px;
            text-decoration: none;
            color: #ffffff;
        }
        #menu .normal a
        {
            display: block;
            text-align: center;
            color: #FFF;
            font-size: 13px;
            font-weight: bold;
            background: url(../images/btn_hover1.png) no-repeat;
            width: 140px;
            height: 27px;
            line-height: 27px;
            overflow: hidden;
            text-decoration: none;
            color: #ffffff;
        }
        
        #menu ul li a:hover
        {
            display: block;
            text-align: center;
            font-weight: bold;
            background: url(../../Images/bg_a_hover.png) no-repeat;
            width: 140px;
            color: #0c3a86;
            height: 27px;
            line-height: 27px;
            overflow: hidden;
            text-decoration: none;
        }
        
        #menu .actived
        {
            display: block;
            text-align: center;
            font-weight: bold;
            background-color: #ffffff;
            width: 140px;
            color: #0c3a86;
            height: 27px;
            line-height: 27px;
            overflow: hidden;
            text-decoration: none;
            background: url(../../Images/bg_li_hover.png) no-repeat;
        }
        #menu .actived a
        {
            display: block;
            text-align: center;
            font-size: 13px;
            text-decoration: none;
            font-weight: bold;
            background: url(../../images/btn_hover1.png) no-repeat;
            width: 140px;
            height: 27px;
            line-height: 27px;
            overflow: hidden;
            font-size: 13px;
            text-decoration: none;
            color: #0c3a86;
        }
        
        #buttons *
        {
            vertical-align: middle;
            text-align: center;
        }
    </style>
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;">
        <tr>
            <td style="height: 37px; line-height: 37px;">
                <div style="border-top: 2px solid #e7eaef">
                </div>
                <div id="menu">
                    <div class="patrolsitemap">
                    </div>
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="actived"><a href="RoadTermList.aspx"
                            target="PatrolFrame"><span id="buttons">
                                <img src="../../Images/doc_publish.png" border="0" />路产管理</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <iframe src="RoadTermList.aspx" name="PatrolFrame" id="PatrolFrame" frameborder="0"
                    width="100%" height="100%" scrolling="auto"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<script type="text/javascript">
    //tab效果通用函数
    function nTabs(tabObj, obj, n) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        for (i = 0; i < n; i++) {
            if (tabList[i].id == obj.id) {
                document.getElementById(tabObj + "_Title" + i).className = "actived";
            } else {
                document.getElementById(tabObj + "_Title" + i).className = "normal";
            }
        }
    }
</script>
