<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapEngine.aspx.cs" Inherits="SmartHyd.MapEngine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地图引擎</title>
    <script type="text/javascript" language="javascript" src="Openlayers-2.10/OpenLayers.js " charset="utf-8"></script>
    <script language="javascript" type="text/javascript" src="Openlayers-2.10/MapOperate.js"></script>
    <script language="javascript" type="text/javascript" src="Openlayers-2.10/Map.js"></script>

    <link rel="stylesheet" href="Openlayers-2.10/theme/default/style.css" type="text/css" />
    <script src="Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript"  defer="defer">
        var map;
        var operator;
        function InitialMap() {
            map = new OpenLayers.Map('map',
                                    {
                                        units: 'm',
                                        maxExtent: new OpenLayers.Bounds(393688.2, 3474929.3, 1067036.0, 4039257.4),
                                        scales: [2500000, 1000000, 500000, 200000, 100000],
                                        numZoomLevels: 8,
                                        maxResolution: "auto",
                                        controls: [new OpenLayers.Control.Navigation(),
                                        new OpenLayers.Control.ScaleLine()]
                                    }
                            );
            map.addControl(new OpenLayers.Control.PanZoomBar(), new OpenLayers.Pixel(4, 8));
            map.addControl(new OpenLayers.Control.MousePosition());

            var kamapVectorCache = new OpenLayers.Layer.KaMap("HNMap", "http://www.hngsgl.info:8008/kamap/tile.php?", { i: "PNG", map: "gmap" });
            map.addLayer(kamapVectorCache);

            var overviewMap = new OpenLayers.Control.OverviewMap();
            map.addControl(overviewMap);
            map.zoomToMaxExtent();
            operator = new MapOperate(map);
        }
    </script>

    <style type="text/css">
	body{
		margin:0px 0px 0px 0px;
		height:100%;
		overflow:hidden;
        background-image:url(Resources/img_mapbg.png);
		background-repeat:repeat;
	}
    </style>
</head>

<body onload="InitialMap()" scroll="no">
    <!--地图容器 开始-->
    <div id="map" style="width:100%; height:100%; position:absolute;"></div>
    <!--地图容器 结束-->
    <div id="status"></div>
</body>
</html>

<!--[if IE 6]>
<script src="Scripts/DD_belatedPNG_0.0.8a.js" type=text/javascript></script>
<script type=text/javascript>
	DD_belatedPNG.fix('img');
</script>
<![endif]-->
