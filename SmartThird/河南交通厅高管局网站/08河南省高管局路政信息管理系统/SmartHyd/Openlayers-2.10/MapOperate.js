
MapOperate = OpenLayers.Class({

    map: null,
    timeStamp: null,
    LayerValue: 0,
    maxZoomLevel: 0,
    measureControls: null,
    zoomBox: null,
    ob: null,
    result: null,
    lastResult: null,
    popup: null,
    mouseDownLonlat: null, //获取当前鼠标所在的坐标
    dynamicTipDiv: null,       //用于动态提示
    poiMarkers: null,            //addpoi中存储到这里
    tipMarker: null,          //也存储到poiMarkers中
    marMarkers: null,         //addMark中存储到这里  

    bReturnClick: false,
    vectorLayer: null,

    coordeSet: "", //用于存储划线、画面的点集合
    CurrentTool: "LINE",
    initialize: function (map) {

        this.timeStamp = new Date();
        this.map = map;
        this.maxZoomLevel = this.map.getNumZoomLevels();

        sketchSymbolizers = {
            "Point": {
                pointRadius: 2,
                graphicName: "square",
                fillColor: "white",
                fillOpacity: 1,
                strokeWidth: 1,
                strokeOpacity: 1,
                strokeColor: "#333333"
            },
            "Line": {
                strokeWidth: 3,
                strokeOpacity: 1,
                strokeColor: "blue"
            },
            "Polygon": {
                strokeWidth: 2,
                strokeOpacity: 1,
                strokeColor: "blue",
                fillColor: "yellow",
                fillOpacity: 0.6
            }
        };

        var style = new OpenLayers.Style();
        style.addRules([new OpenLayers.Rule({ symbolizer: sketchSymbolizers })]);
        var styleMap = new OpenLayers.StyleMap({ "default": style });

        var options = {
            handlerOptions: {
                style: "default",
                layerOptions: { styleMap: styleMap },
                persist: true
            }
        };
        this.measureControls = {
            line: new OpenLayers.Control.Measure(
                  OpenLayers.Handler.Path, options
                ),
            polygon: new OpenLayers.Control.Measure(
                    OpenLayers.Handler.Polygon, options
                )
        };

        var control;
        eventHandler = OpenLayers.Function.bindAsEventListener(this.handleMeasurements, this);
        for (var key in this.measureControls) {
            control = this.measureControls[key];

            control.events.on({
                "measure": eventHandler,
                "measurepartial": eventHandler
            });
            this.map.addControl(control);
        };

        this.map.events.register('click', this.map, this.outputLonLat);
        this.poiMarkers = new OpenLayers.Layer.Markers("Markers");
        this.map.addLayer(this.poiMarkers);
        this.map.setLayerZIndex(this.poiMarkers, 10);
        this.marMarkers = new OpenLayers.Layer.Markers("Markers");
        this.map.addLayer(this.marMarkers);
    },

    outputLonLat: function (evt) {
        this.mouseDownLonlat = this.getLonLatFromPixel(evt.xy);
        if (Boolean(this.clickFun))
            this.clickFun(this.mouseDownLonlat.lon, this.mouseDownLonlat.lat);

    },
    zoomIn: function () {

        var curTimestamp = new Date();
        var tick = Math.abs(curTimestamp.getTime() - this.timeStamp.getTime());
        this.timeStamp = curTimestamp;
        if (tick >= 800) {
            this.map.zoomIn();
        }
    },
    zoom: function (val) {
        if (val >= 0 && val <= this.maxZoomLevel) {
            this.map.zoomTo(val);
        }
    },

    zoomOut: function () {
        var curTimestamp = new Date();
        var tick = Math.abs(curTimestamp.getTime() - this.timeStamp.getTime());
        this.timeStamp = curTimestamp;
        if (tick >= 800) {
            this.map.zoomOut();
        }
    },

    setMove: function () {

        this.deactivateContrl();

    },

    zoomTo: function (zoom) {

        if (!this.zoomBox) {

            var movecontrol = new OpenLayers.Control();
            movecontrol.parent = this;
            OpenLayers.Util.extend(movecontrol, {
                draw: function () {

                    this.zoomBox = new OpenLayers.Handler.Box(movecontrol,
			    { "done": this.notice },
			    { keyMask: OpenLayers.Handler.MOD_NONE });
                    this.zoomBox.activate();
                    this.zoomBox.zoom = zoom;
                    this.parent.zoomBox = this.zoomBox;

                },
                notice: function (bounds) {
                    var ll = this.map.getLonLatFromPixel(new OpenLayers.Pixel(bounds.left, bounds.bottom));
                    var ur = this.map.getLonLatFromPixel(new OpenLayers.Pixel(bounds.right, bounds.top));

                    var lon = ll.lon + (ur.lon - ll.lon) / 2;
                    var lat = ll.lat + (ur.lat - ll.lat) / 2;
                    var zoomInNum = this.map.getZoom() - 2;
                    if (zoomInNum < 0) { zoomInNum = 0; }

                    if (this.zoomBox.zoom == "in" && bounds.left != undefined) {

                        this.parent.map.setCenter(new OpenLayers.LonLat(lon, lat));
                        var bounds = new OpenLayers.Bounds(ll.lon, ll.lat, ur.lon, ur.lat);
                        this.parent.map.zoomToExtent(bounds);

                    }
                    if (this.zoomBox.zoom == "out") {
                        this.parent.zoomOut();
                        this.parent.map.setCenter(new OpenLayers.LonLat(lon, lat));
                    }
                }
            });

            this.map.addControl(movecontrol);

        }
        else {
            this.zoomBox.zoom = zoom;
            this.zoomBox.activate();
        }
    },


    deactivateContrl: function () {
        this.map.clickFun = null;
        if (this.zoomBox != null) {
            this.zoomBox.deactivate();
        }
        if (this.tipMarker) {
            this.poiMarkers.removeMarker(this.tipMarker);
            this.tipMarker = null;
        }
        if (this.measureControls != null) {
            for (var key in this.measureControls) {
                control = this.measureControls[key];
                control.deactivate();
            };
        }
    },



    mouseMoveZoomIn: function () {
        this.deactivateContrl();
        this.zoomTo("in");

    },
    mouseMoveZoomOut: function () {
        this.deactivateContrl();
        this.zoomTo("out");
    },


    measureDistance: function () {

        var control = this.measureControls['line'];
        control.activate();

        var control = this.measureControls['polygon'];
        control.deactivate();

        if (this.zoomBox != null) {
            this.zoomBox.deactivate();
        }
        if (this.tipMarker) {
            this.poiMarkers.removeMarker(this.tipMarker);
            this.tipMarker = null;
        }
        this.map.setLayerZIndex(this.poiMarkers, 10);
    },

    measureArea: function () {

        var control = this.measureControls['line'];
        control.deactivate();

        var control = this.measureControls['polygon'];
        control.activate();

        if (this.zoomBox != null) {
            this.zoomBox.deactivate();
        }
        if (this.tipMarker) {
            this.poiMarkers.removeMarker(this.tipMarker);
            this.tipMarker = null;
        }
        this.map.setLayerZIndex(this.poiMarkers, 10);
    },
    handleMeasurements: function (event) {
        var geometry = event.geometry;
        var units = event.units;
        var order = event.order;
        var measure = event.measure;
        var out = "";
        if (order == 1) {
            out += measure.toFixed(3) + " " + units;
        }
        else {
            out += measure.toFixed(3) + " " + units + "<sup>2</sup>";
        }

        this.poiMarkers.clearMarkers();
        geometryArray = geometry.getVertices();
        if (geometryArray.length > 1) {
            pointX = geometryArray[geometryArray.length - 1].x;
            pointY = geometryArray[geometryArray.length - 1].y;
            var size = new OpenLayers.Size(80, 17);
            var offset = new OpenLayers.Pixel(1, -15);
            var icon = new OpenLayers.Icon(null, size, offset);
            this.tipMarker = new OpenLayers.Marker(new OpenLayers.LonLat(pointX, pointY), icon);
            var text = "<span style=\"display:block;FONT-SIZE: 12pt;font-weight:bold;color:#000000 ;width:auto;\">" + out + "</span>  "
            this.tipMarker.icon.imageDiv.innerHTML = "<span style=\"display:block;FONT-SIZE: 10pt; width:auto; font-family:微软雅黑;color:blue ;font-weight:bold;border:1px solid black;background-Color:#FFFFFF;\">" + out + "</span>  ";

            this.poiMarkers.addMarker(this.tipMarker);
        }
        else {
            if (this.tipMarker) {
                this.poiMarkers.removeMarker(this.tipMarker);
                this.tipMarker = null;
            }
        }
    },

    addPoi: function (name, url, lon, lat, sizeX, sizeY, offsetX, offsetY, fun) {
        var size = new OpenLayers.Size(sizeX, sizeY);
        var offset = new OpenLayers.Pixel(offsetX, offsetY);
        var icon = new OpenLayers.Icon(url, size, offset);
        var marker = new OpenLayers.Marker(new OpenLayers.LonLat(lon, lat), icon);

        marker.name = name;
        marker.showLabel = true;

        this.poiMarkers.addMarker(marker);

        if (fun) {
            marker.events.register("click", marker, fun);
            marker.events.register("mouseover", marker, this.mouseover);
            marker.events.register("mouseout", marker, this.mouseout);
        }
        return marker;
    }
,
    addMarker: function (name, url, lon, lat, sizeX, sizeY, offsetX, offsetY, fun) {
        var size = new OpenLayers.Size(sizeX, sizeY);
        var offset = new OpenLayers.Pixel(offsetX, offsetY);
        var icon = new OpenLayers.Icon(url, size, offset);
        var marker = new OpenLayers.Marker(new OpenLayers.LonLat(lon, lat), icon);
        marker.showLabel = true;
        marker.name = name;

        this.marMarkers.addMarker(marker);
        if (fun) {
            marker.events.register("click", marker, fun);
            marker.events.register("mouseover", marker, this.mouseover);
            marker.events.register("mouseout", marker, this.mouseout);
        }
        return marker;
    }
,
    delMarker: function (marker) {
        if (marker) {
            this.marMarkers.removeMarker(marker);
        }
        else {
            this.marMarkers.clearMarkers();
        }
    },
    delPoi: function (marker) {
        if (marker) {
            this.poiMarkers.removeMarker(marker);
        }
        else {
            this.poiMarkers.clearMarkers();
        }
    },


    mouseout: function (evt) {
        if (OpenLayers.Util.getBrowserName() != "msie") {
            this.icon.imageDiv.style.cursor = "hand";
        }
        else {
            this.icon.imageDiv.style.cursor = "pointer";
        }
        var redRegex = /(red_)/g;
        var bluRegex = /(blue_)/g;
        var changePic = null;
        if (redRegex.test(this.icon.url)) {
            changePic = this.icon.url.replace(redRegex, "blue_");
        }
        if (bluRegex.test(this.icon.url)) {
            changePic = this.icon.url.replace(bluRegex, "red_");
        }
        if (changePic) {
            this.icon.url = changePic;
            OpenLayers.Util.modifyAlphaImageDiv(this.icon.imageDiv, null, null, null, changePic, "absolute");
        }
    },

    mouseover: function (evt) {
        if (OpenLayers.Util.getBrowserName() != "msie") {
            this.icon.imageDiv.style.cursor = "pointer";
        } else {
            this.icon.imageDiv.style.cursor = "hand";
        }
        var redRegex = /(red_)/g;
        var bluRegex = /(blue_)/g;
        var changePic = null;
        if (redRegex.test(this.icon.url)) {
            changePic = this.icon.url.replace(redRegex, "blue_");
        }
        if (bluRegex.test(this.icon.url)) {
            changePic = this.icon.url.replace(bluRegex, "red_");
        }
        if (changePic) {
            this.icon.url = changePic;
            OpenLayers.Util.modifyAlphaImageDiv(this.icon.imageDiv, null, null, null, changePic, "absolute");
        }

    },
    fullMap: function () {
        this.map.zoomToExtent(this.map.maxExtent)

    },
    setCenter: function (lon, lat, nLevel) {
        if (nLevel)
            this.map.setCenter(new OpenLayers.LonLat(lon, lat), nLevel);
        else
            this.map.setCenter(new OpenLayers.LonLat(lon, lat));
    },

    setReturnClick: function (fun) {
        this.deactivateContrl();
        this.map.clickFun = fun;

    },
    addPopup: function (id, lon, lat, width, height, closePopUp, html) {
        id = String(id);
        var midpoint = new OpenLayers.LonLat(lon, lat);
        var popup = new OpenLayers.Popup.FramedCloud(id, midpoint, new OpenLayers.Size(width, height), null, null, true);
        popup.setContentHTML(html);
        this.map.addPopup(popup, closePopUp);
        this.map.panTo(midpoint);
        return popup;
    },
    removePopup: function (popup) {
        this.map.removePopup(popup);
    },
    zoomToScale: function (nScale) {
        this.map.zoomToScale(nScale, true);
    },

    ///添加点图层
    addPoint: function (pointName, lon, lat, icon) {
        var renderer = OpenLayers.Util.getParameters(window.location.href).renderer;
        renderer = (renderer) ? [renderer] : OpenLayers.Layer.Vector.prototype.renderers;

        var style_green =
        {
            pointRadius: 4,
            externalGraphic: "img/" + icon,
            graphicOpacity: 0.5,
            graphicWidth: 16,
            graphicHeight: 16,
            label: name,
            pointerEvents: "visiblePainted",
            label: pointName,

            fontColor: "#000000",
            fontSize: "12px",
            fontFamily: "微软雅黑",
            labelAlign: "lc",
            labelXOffset: 10,
            labelYOffset: 0,
            labelOutlineColor: "white",
            labelOutlineWidth: 3
        };

        var bankLayer = this.map.getLayersByName("bankLayer");
        if (vectorLayer.length == 0) {
            bankLayer = new OpenLayers.Layer.Vector("Bank Layer", {
                renderers: renderer,
                styleMap: new OpenLayers.StyleMap({
                    "default": new OpenLayers.Style(OpenLayers.Util.applyDefaults({
                        pointRadius: 4,
                        externalGraphic: "img/" + icon,
                        graphicOpacity: 1,
                        graphicWidth: 16,
                        graphicHeight: 16,
                        pointerEvents: "visiblePainted",
                        label: pointName,

                        fontColor: "#000000",
                        fontSize: "11px",
                        fontWeight: "bold",
                        fontFamily: "微软雅黑",
                        labelAlign: "lc",
                        labelXOffset: 10,
                        labelYOffset: 0,
                        labelOutlineColor: "white",
                        labelOutlineWidth: 3
                    }, OpenLayers.Feature.Vector.style["default"])),
                    "select": new OpenLayers.Style({
                        externalGraphic: "img/layer/bc_ico_blue.png",
                        graphicOpacity: 1,
                        pointRadius: 4,
                        graphicWidth: 16,
                        graphicHeight: 16,
                        pointerEvents: "visiblePainted",
                        label: pointName,

                        fontColor: "#CC0000",
                        fontSize: "12px",
                        fontWeight: "bold",
                        fontFamily: "微软雅黑",
                        labelAlign: "lc",
                        labelXOffset: 10,
                        labelYOffset: 0,
                        labelOutlineColor: "white",
                        labelOutlineWidth: 3,
                        cursor: "pointer"
                    }, OpenLayers.Feature.Vector.style["select"])
                })
            });
            this.map.addLayer(bankLayer);
        }
        var selectCtrl = new OpenLayers.Control.SelectFeature(bankLayer, {
            clickout: true, toggle: true,
            multiple: false, hover: true,
            toggleKey: "ctrlKey", // ctrl key removes from selection
            multipleKey: "shiftKey" // shift key adds to selection
        });
        map.addControl(selectCtrl);
        selectCtrl.activate();

        var point = new OpenLayers.Geometry.Point(lon, lat);
        var pointFeature = new OpenLayers.Feature.Vector(point);
        pointFeature.attributes = { bankname: pointName };
        bankLayer.addFeatures(pointFeature);

        bankLayer.events.on({
            "featureselected": function (e) {
                alert(e.feature.attributes.bankname);
            },
            "featureselected": function (e) {
            },
            "click": function (e) {

            }
        });
    },
    //添加圆
    addCircle: function (lon, lat, radius) {
        var style_green =
	    {
	        strokeWidth: 1,
	        strokeOpacity: 1,
	        strokeColor: "#00ff00",
	        fillColor: "white",
	        fillOpacity: 0.3
	    };
        var option = {
            rendererOptions: { zIndexing: true },
            styleMap: new OpenLayers.StyleMap({
                "default": new OpenLayers.Style({
                    strokeColor: '#3683e8',
                    strokeOpacity: .9,
                    strokeWidth: 1,
                    fillColor: '#BE1711',
                    fillOpacity: .5,
                    graphicZIndex: 10,
                    cursor: "pointer"
                }),
                "select": new OpenLayers.Style({
                    strokeColor: '#3683e8',
                    strokeOpacity: .9,
                    strokeWidth: 1,
                    fillColor: '#f36522',
                    fillOpacity: .5,
                    graphicZIndex: 12,
                    cursor: "pointer"
                })
            })
        };

        var vectorLayer = this.map.getLayersByName("Vector Layer");
        if (vectorLayer.length == 0) {
            vectorLayer = new OpenLayers.Layer.Vector("Vector Layer", option);
            this.map.addLayer(vectorLayer);
        }
        vectorLayer = this.map.getLayersByName("Vector Layer");
        var point = new OpenLayers.Geometry.Point(lon, lat);
        var pointFeature = new OpenLayers.Feature.Vector(point);
        var inM = OpenLayers.INCHES_PER_UNIT['m'];
        var inD = OpenLayers.INCHES_PER_UNIT['m'];
        radius *= (inM / inD);
        var RedcircleFeature = new OpenLayers.Feature.Vector(OpenLayers.Geometry.Polygon.createRegularPolygon(point, radius, 200, 0), option);
        vectorLayer[0].addFeatures([RedcircleFeature]);

        var selectCtrl = new OpenLayers.Control.SelectFeature(vectorLayer[0], {
            onSelect: this.report2,
            clickout: true
        });
        this.map.addControl(selectCtrl);
        var highlightCtrl = new OpenLayers.Control.SelectFeature(vectorLayer[0], {
            hover: true,
            highlightOnly: true,
            renderIntent: "temporary",
            onSelect: this.report,
            eventListeners: {
                beforefeaturehighlighted: this.report,
                featurehighlighted: this.report,
                featureunhighlighted: this.report
            }
        });
        this.map.addControl(highlightCtrl);
        highlightCtrl.activate();
        selectCtrl.activate();
        return RedcircleFeature;
    },

    delCircle: function (feature) {
        var vectorLayer = this.map.getLayersByName("Vector Layer");
        if (vectorLayer.length > 0) {
            if (feature)
                vectorLayer[0].removeFeatures(feature);
            else
                vectorLayer[0].removeAllFeatures();
        }
    },

    delPopup: function (Popup) {
        if (Popup)
            this.map.removePopup(Popup);
        else {
            for (var i = this.map.popups.length - 1; i >= 0; --i) {
                this.map.removePopup(this.map.popups[i]);
            }
        }
    },

    addLine: function (points, type, color, opacity) {
        var style_green =
	    {
	        strokeColor: color,
	        strokeOpacity: opacity,
	        strokeWidth: 5,
	        pointRadius: 2,
	        strokeDashstyle: type,
	        pointerEvents: "visiblePainted"
	    };

        var vectorLayer = this.map.getLayersByName("Line Layer");
        if (vectorLayer.length == 0) {
            vectorLayer = new OpenLayers.Layer.Vector("Line Layer");
            this.map.addLayer(vectorLayer);
        }
        vectorLayer = this.map.getLayersByName("Line Layer");

        var lineString = new OpenLayers.Geometry.LineString(points);
        var lineFeature = new OpenLayers.Feature.Vector(lineString, null, style_green);
        vectorLayer[0].addFeatures([lineFeature]);

        return lineFeature;

    },
    delLine: function (feature) {
        var vectorLayer = this.map.getLayersByName("Line Layer");
        if (vectorLayer.length > 0) {
            if (feature)
                vectorLayer[0].removeFeatures(feature);
            else
                vectorLayer[0].removeAllFeatures();
        }
    },



    CLASS_NAME: "MapOperate"
});   



