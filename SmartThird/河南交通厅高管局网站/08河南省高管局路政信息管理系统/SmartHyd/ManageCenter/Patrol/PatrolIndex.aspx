<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatrolIndex.aspx.cs" Inherits="SmartHyd.Patrol.PatrolIndex" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路政巡逻管理中心</title>
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
            background: url(../../images/btn_hover1.png) no-repeat;
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
            background: url(../Images/bg_li_hover.png) no-repeat;
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
        .treeViewStyle
        {
            height: 740px;
            overflow-y: scroll;
            color: #000000;
        }
    </style>
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 740px; width: 100%;">
        <tr>
            <td valign="top">
                <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeViewStyle" ImageSet="BulletedList4"
                    ShowExpandCollapse="true" Width="300px" ShowCheckBoxes="All" ShowLines="True">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#000000" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000000" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <RootNodeStyle ImageUrl="~/Images/chart_organisation.png" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#000000" HorizontalPadding="0px"
                        VerticalPadding="0px" BackColor="#0066CC" />
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <iframe src="ArtificialPatrol.aspx" name="PatrolFrame" id="PatrolFrame" frameborder="0"
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
