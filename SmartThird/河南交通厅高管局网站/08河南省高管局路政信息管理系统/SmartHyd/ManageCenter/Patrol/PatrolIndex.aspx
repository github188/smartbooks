<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatrolIndex.aspx.cs" Inherits="SmartHyd.Patrol.PatrolIndex" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>·��Ѳ�߹�������</title>
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
    <table border="0" cellpadding="0" cellspacing="0" style="height: 740px; width: 100%;">
        <tr>
            <td colspan="2" style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons0">
                            <img src="../../Images/branch.png" alt="" border="0" />��ǰλ�ã�·��Ѳ�߹�������&gt;&gt;�˹�Ѳ����־����</span></div>
                    <ul>
                        <li id="menu_Title0" onclick="nTabs('menu',this,1)" class="normal"><a href="PatrolEdit.aspx"
                            title="��Ϣ����" target="PatrolFrame"><span id="buttons1">
                                <img src="../../Images/add.png" alt="" border="0" />&nbsp;������־</span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td style="border-right: 4px double #045185; width: 28%" valign="top">
                <iframe src="DeptTree.aspx?type=0" name="TreeFrame" id="TreeFrame" frameborder="0" height="100%">
                </iframe>
            </td>
            <td valign="top">
                <iframe src="ArtificialPatrol.aspx" name="PatrolFrame" id="PatrolFrame" frameborder="0"
                    width="100%" height="100%"></iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<script type="text/javascript">
    //tabЧ��ͨ�ú���
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
