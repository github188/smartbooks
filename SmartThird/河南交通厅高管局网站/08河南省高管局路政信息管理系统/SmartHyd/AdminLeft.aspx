<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLeft.aspx.cs" Inherits="SmartHyd.AdminLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导航菜单 - 河南省高速公路路政管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/basemain.css" />
    <script type="text/javascript" src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" language="javascript">
        $(function () {
            $('.ui-left-menublock li').mouseover(function () {
                $(this).css("background-color", "#065c8f");
                $(this).children("a").css("color", "#ffffff");
            });

            $('.ui-left-menublock li').mouseout(function () {
                $(this).css("background-color", "#E7EAEF");
                $(this).children("a").css("color", "#334b63");
            });
        });
    </script>
</head>
<body class="ul-left-content">
    <form id="form1" runat="server">
        <!--常用功能开始-->
		<div class="ui-left-menublock-max ui-left-menublock">
			<ul>
				<li>
					<img src="images/ui-left-ico01.png" alt="发文"/>
					<a href="ManageCenter/DocumentCreate.aspx" target="mainFrame">发文</a>
				</li>
				<li>
					<img src="images/ui-left-ico01.png" alt="收文"/>
					<a href="Official/OfficialIndex.aspx" target="mainFrame">收文</a>
				</li>
				<li>
					<img src="images/ui-left-ico01.png" alt="单位考核"/>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">单位考核</a>
				</li>
			</ul>
		</div>
		<!--常用功能结束-->

		<!--系统菜单开始-->
		<div id="menu" class="ui-left-menublock">
			<ul>
				<li>
					<img src="images/ui-left-ico01.png" alt="路政巡逻" />
					<%--<a href="ManageCenter/Patrol.aspx" target="mainFrame">路政巡逻</a>--%>
                    <a href="Patrol/PatrolIndex.aspx" target="mainFrame">路政巡逻</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico02.png" alt="人员装备"/>
					<a href="ManageCenter/Term.aspx" target="mainFrame">人员装备</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico03.png" alt="路产管理"/>
                    <a href="ManageCenter/RoadTerm/RoadTermIndex.aspx" target="mainFrame">路产管理</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="超限治理"/>
					<a href="ManageCenter/Overrun/OverrunIndex.aspx" target="mainFrame">超限治理</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="行政许可"/>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">行政许可</a>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="应急安全"/>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">应急安全</a>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="路况信息"/>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">路况信息</a>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="考核系统"/>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">考核系统</a>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="网络办公"/>
					<a href="ManageCenter/Office.aspx" target="mainFrame">网络办公</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="档案管理"/>
					<a href="Official/OfficialIndex.aspx" target="mainFrame">档案管理</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
				
				<li>
					<img src="images/ui-left-ico01.png" alt="系统管理"/>
					<a href="ManageCenter/SysManager.aspx" target="mainFrame">系统管理</a>
                    <img src="images/ui-left-menustar.png" alt="新功能上线"/>
				</li>
			</ul>
		</div>
		<!--系统菜单结束-->

		<!--其他应用开始-->
		<div class="ui-left-menublock">
			<ul>
				<li>
					<a href="ManageCenter/ConstructionPage.aspx" target="mainFrame">附加功能</a>
				</li>
			</ul>
		</div>
		<!--其他应用结束-->
    </form>
</body>
</html>
