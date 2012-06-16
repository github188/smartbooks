<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Electronic.aspx.cs" Inherits="SmartHyd.ManageCenter.Patrol.Electronic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>电子巡逻日志</title>
     <link href="../../Css/tongdaoa.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <style type="text/css">
        .treeViewStyle
        {
            height: 740px;
            overflow-y: scroll;
            color: #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="0" cellspacing="0" style="height: 740px; width: 100%;">
        <tr>
            <td colspan="2" style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons0">
                            <img src="../../Images/branch.png" alt="" border="0" />当前位置：路政巡逻管理中心&gt;&gt;电子巡逻日志管理</span></div>
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="ElectronicEdit.aspx"
                            title="信息新增" target="PatrolFrame"><span id="buttons1">
                                <img src="../../Images/add.png" alt="" border="0" />&nbsp;新增日志</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td style="border-right: 4px double #045185; width: 28%" valign="top">
                <iframe src="DeptTree.aspx?type=1" name="TreeFrame" id="TreeFrame" frameborder="0" height="100%">
                </iframe>
            </td>
            <td valign="top">
                <iframe src="ElectronicPatrol.aspx" name="PatrolFrame" id="PatrolFrame" frameborder="0"
                    width="100%" height="100%"></iframe>
            </td>
        </tr>
    </table>
    </div>
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
