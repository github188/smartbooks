var map_onclick;
function enable_click() {
    map_onclick = new OpenLayers.Control.Click();
    map.addControl(map_onclick);
    map_onclick.activate();
}


//注册添加添加标注Handler
//注册添加标注Event
OpenLayers.Control.Click = OpenLayers.Class(OpenLayers.Control, {
    defaultHandlerOptions:
                {
                    'single': true,
                    'double': false,
                    'pixelTolerance': 0,
                    'stopSingle': false,
                    'stopDouble': false
                },

    initialize: function (options) {
        this.handlerOptions = OpenLayers.Util.extend({}, this.defaultHandlerOptions);
        OpenLayers.Control.prototype.initialize.apply(this, arguments);
        this.handler = new OpenLayers.Handler.Click(this, { 'click': this.trigger }, this.handlerOptions);
    },

    trigger: function (e) {
        var lonlat = this.map.getLonLatFromPixel(e.xy); //map.getLonLatFromViewPortPx(e.xy);      
        //removeAll();
        createMarker("<a href='http://www.handandaily.com' target='_blank'>Visit China</a>", lonlat.lon, lonlat.lat, false);
    }
});



function createMarker(html, lon, lat, isHide) {
    var ll, popupClass, popupContentHTML;
    ll = new OpenLayers.LonLat(lon, lat);
    //popupClass = AutoSizeFramedCloud;
    popupContentHTML = html;
    addMarker(ll, popupClass, popupContentHTML, true, false);
    setCenter(lon, lat);
}



function addMarker(ll, popupClass, html, closeBox, overflow) {
    var feature = new OpenLayers.Feature(markers, ll);
    feature.closeBox = closeBox;
    //feature.popupClass = popupClass;
    feature.data.popupContentHTML = html;
    feature.data.overflow = (overflow) ? "auto" : "hidden";

    var marker = feature.createMarker();
    marker.setUrl('img/marker1.png');   //ICON
    marker.display(true);

    var markerClick = function (evt) {
        if (this.popup == null) {
            this.popup = this.createPopup(this.closeBox);
            map.addPopup(this.popup);
            this.popup.show();
        }
        else {
            this.popup.toggle();
        }
        currentPopup = this.popup;
        OpenLayers.Event.stop(evt);
    };
    marker.events.register("mousedown", feature, markerClick);
    markers.addMarker(marker);
}