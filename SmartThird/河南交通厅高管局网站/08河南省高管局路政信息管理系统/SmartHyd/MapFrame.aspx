<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapFrame.aspx.cs" Inherits="SmartHyd.MapFrame" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地图框架</title>
    <link href="Css/css.css" rel="stylesheet" type="text/css" />
    <link href="Css/Loading.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <!--ExtJS Library-->
    <link href="Scripts/ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ext/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="Scripts/ext/ext-all.js" type="text/javascript"></script>
    <script src="Scripts/MapInterface.js" type="text/javascript"></script>
    <style type="text/css">
        body{
        	margin:0px;
            padding:0px;
            background-color:#e0eaf7;
        }
    </style>
    <script type="text/javascript">
        //IE9下 ExtJS 效果无法正常使用解决
        if ((typeof Range !== "undefined") && !Range.prototype.createContextualFragment) {
            Range.prototype.createContextualFragment = function (html) {
                var frag = document.createDocumentFragment(),
            div = document.createElement("div");
                frag.appendChild(div);
                div.outerHTML = html;
                return frag;
            };
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="docbody"></div>
    </form>
</body>
</html>
