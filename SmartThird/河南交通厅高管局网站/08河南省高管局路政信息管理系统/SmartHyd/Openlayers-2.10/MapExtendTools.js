
var tempPlace, tempID, tempHtml, lon, lat;

//漫游
function mov() {
    operator.setMove();
}

//放大地图
function zoomOut() {
    operator.zoomOut();
}

//缩小地图
function zoomIn() {
    operator.zoomIn();
}

//拉框放大
function dragZoomIn() {
    operator.mouseMoveZoomIn();
}

//拉框缩小
function dragZoomOut() {
    operator.mouseMoveZoomOut();
}

//测距
function mesDistance() {
    operator.measureDistance();
}

//测面积
function mesArea() {
    operator.measureArea();
}

//全图显示
function fullMap() {
    operator.fullMap();
}

//添加Poi标识
function addPoi(placeName, longitude, latitude, number) {
    operator.addPoi(placeName, "img/number/blu_" + number + ".png", longitude, latitude, 24, 30, -12, -30, getPoi);
}

function getPoi(evt) {
    operator.addPopup(tempID, this.lonlat.lon, this.lonlat.lat, 300, 3000, true, tempHtml); //true 自动关闭上一个pop;
}

function delPoi() {
    operator.delPoi();
}

//居中定位
function center(xx, yy) {
    operator.setCenter(xx, yy);
}

function SearchAround() {
    var radius = $("#radius").val();
    var typeSelected = $("#placeType").val();
    this.SearchArroundAccess(typeSelected);
    this.delcircle();
    operator.addCircle(lon, lat, radius);

}

//周边查询，x-经度，y-维度，r-范围半径
function SearchAround2(x, y, r) {
    this.delcircle();
    operator.addCircle(x, y, r);
}

//设定比例尺
function scale(scale) {
    operator.zoomToScale(scale);
}


function delLayer() {
    layerbase.params.LAYERS = "DAREA_region,ROAD1_polyline";
    layerbase.redraw();

}


//添加图层
function addLayer() {
    layerbase.params.LAYERS = "DAREA_region,GREENBELT_region,ROAD1_polyline,GOV_font_point";
    layerbase.redraw();
}

//地图上添加标记
function addpoitomap() {
    operator.setReturnClick(getClick)
}

function getClick(x, y) {
    operator.addMarker("daxun", "img/mark1.png", x, y, 32, 32, -10, -30, getPoi);
    operator.addPopup("1", x, y, 200, 3000, true); //true 自动关闭上一个pop	
}

function delMarker() {
    operator.delMarker();
    operator.delPopup();
}

function addCircle() {
    var x = 516360.295164219;
    var y = 3974551.50892226;
    operator.setCenter(x, y);
    operator.zoomToScale(5000);
    operator.addCircle(x, y, 1000);
}

function delcircle() {
    operator.delCircle();
}

//清除地图上的临时标识
function truncateMap() {
    operator.delPopup();
    operator.delPoi();
}

function PopupInit(id, x, y, width, height, closePopup, html) {
    operator.addPopup(id, x, y, width, height, closePopup, html);
}



function setTab(tabObj, obj, n) {
    var tabList = document.getElementById(tabObj).getElementsByTagName("li");
    for (i = 0; i < n; i++) {
        if (tabList[i].id == obj.id) {
            document.getElementById(tabObj + "_menu" + i).className = "active";
            document.getElementById(tabObj + "_content" + i).style.display = "block";
        } else {
            document.getElementById(tabObj + "_menu" + i).className = "normal";
            document.getElementById(tabObj + "_content" + i).style.display = "none";
        }
    }
    this.BindTypeList();
}

function BindTypeList() {
    $.ajax({
        type: "POST",
        url: "../json/JsonAccess.aspx/GetJSONType",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var dataobj = eval("(" + data.d + ")"); //转换为json对象 
            var str;

            $("#placeType").empty();
            $.each(dataobj.root, function (i, item) {
                $("<option value='" + item.type + "'>" + item.type + "</option>").appendTo("#placeType")
            })

        }
    });
}


//周边查询业务处理
function SearchArroundAccess(typeValue) {
    var key = '三';
    window.parent.parent.frames["mainFrame"].leftFrame.document.getElementById("Spoi").src = 'searchresult.aspx?key=' + key + '&type=' + typeValue;

}