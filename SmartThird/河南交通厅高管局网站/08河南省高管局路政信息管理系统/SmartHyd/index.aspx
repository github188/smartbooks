<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SmartHyd.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>����ʡ���ٹ�··����Ϣ����ϵͳ</title>

    <link href="Css/css.css" rel="stylesheet" type="text/css" />
    <link href="Css/Loading.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />

    <script src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <!--ExtJS Library-->
    <link href="Scripts/ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ext/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="Scripts/ext/ext-all.js" type="text/javascript"></script>


    <script src="Scripts/system/ALLEvents.js" type="text/javascript"></script>
    <script src="Scripts/system/layout.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        ///IE9�¼����Խ��
        if ((typeof Range !== "undefined") && !Range.prototype.createContextualFragment) {
            Range.prototype.createContextualFragment = function (html) {
                var frag = document.createDocumentFragment(),
            div = document.createElement("div");
                frag.appendChild(div);
                div.outerHTML = html;
                return frag;
            };
        }

        $(function () {
            /*search box focus*/
            $('#searchbox').click(function () {
                $(this).attr("value", "").focus();
            });
            $('#searchbox').mouseout(function () {
                $(this).attr("value", "��������...");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top" style="height:80px; line-height:80px;">
    <%
        SmartHyd.Utility.UserSession userSession = (SmartHyd.Utility.UserSession)Session["user"];
    %>
    <div class="ui-hander-content">
        <!--Logo��ʼ-->
        <div class="ui-hander-logo"></div>
        <!--Logo����-->

        <!--�û���Ϣ��ʼ-->
        <div class="ui-hander-userinfo">
            <span>
                <%=userSession.REALNAME == null ? userSession.USERNAME : userSession.REALNAME %>
                &lt;
                <%=userSession.Department.DPTNAME %>
                &gt; 
            </span><br/>
            <span>
                <a href="main.aspx" target="mainFrame">ϵͳ��ҳ</a> | <a href="#">�����޸� </a>
                - <a href="#">ע��</a>
            </span>
        </div>
        <!--�û���Ϣ����-->


        <!--������Ϣ��ʼ-->
        <div class="ui-hander-feedback">
            <a href="http://www.google.cn/chrome" style="color: Red;" target="_blank">�Ƽ�Google�����</a>
            | <a>��������</a> | <a>��������</a> | <a href="AdminLogout.aspx" target="_parent">�˳�</a>
            |
        </div>
        <!--������Ϣ����-->

        <!--�ı�������ʼ-->
        <input type="text" class="ui-hander-searchbox" value="��������..." id="searchbox" />
        <!--�ı����������-->
    </div>
    </div>

    
    <div id="files">
        <span><img src="Images/shouwen.png" alt=""/><img src="Images/shouwen.png" alt=""/></span>
        <a href="ManageCenter/Official/Index.aspx" target="sysFrame">������</a>
        <a href="javascript:void(0)" target="F1">������</a>
        <a href="javascript:void(0)" target="F1">�ݸ���</a>
        <a href="javascript:void(0)" target="F1">�ѷ���</a>
        <a href="javascript:void(0)" target="F1">ͨѶ¼</a>
    </div>
    </form>
</body>
</html>
<!--[if IE 6]>
<script src="Scripts/DD_belatedPNG_0.0.8a.js" type=text/javascript></script>
<script type=text/javascript>
	DD_belatedPNG.fix('img');
</script>
<![endif]-->