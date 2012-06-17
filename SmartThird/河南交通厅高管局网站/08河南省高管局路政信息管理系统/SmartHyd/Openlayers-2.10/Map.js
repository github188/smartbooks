//................................//
//           地图操作工具            //
//................................//

var operator;

var tempPlace, tempID, tempHtml, lon, lat;

var _OPERATIONFLAG;

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



function delPoi() {
    operator.delPoi();
}

//居中定位
function center(xx, yy) {
    operator.setCenter(xx, yy);
}

function MapLocate(lon, lat) {
    operator.zoomToScale(3000);
    operator.setCenter(lon, lat);
}

function PubLocation(lon, lat, scale) {
    operator.zoomToScale(scale);
    operator.setCenter(lon, lat);
}

//设定比例尺
function scale(scale) {
    operator.zoomToScale(scale);
}


function deletemc() {
    operator.delMarker();
}


var markersArray = [];




function delMarker() {
    operator.delMarker();
    operator.delPopup();
}



function delcircle() {
    operator.delCircle();
}

function addCircle(x, y) {
    truncateMap();
    operator.setCenter(x + 3000, y);
    operator.zoomToScale(30000);
    addMarker(x, y, "img/flash.gif");
    operator.addCircle(x, y, 2000);
}

//清除地图上的临时标识
function truncateMap() {
    
    operator.delMarker();
    operator.delCircle();
}

function PopupInit(id, x, y, width, height, closePopup, html) {
    operator.addPopup(id, x, y, width, height, closePopup, html);
}

function Refresh() {
    InitialMap();
}

function addMarker(x, y, icon) {
    operator.addMarker(new Date().getMilliseconds(),icon,x,y,20,20,-10,-20);
}

//添加Poi标识
function addPoi(branchCode, lon, lat) {
    operator.addMarker(branchCode+"_"+lon + "_" + lat, "img/red_pin.png", lon, lat, 15, 21, -8, -21, getPoi);
}

function AddBranchPoi(uniqueCode, lon, lat) {
    operator.addPoi(uniqueCode, "img/red_branch.png", lon, lat, 16, 16, -8, -16, getPoi);
}

/*************网点标注**************************/
function addpoitomap(operation) {
    _OPERATIONFLAG = operation;

    var currentScale = map.getScale();
    if (currentScale <= 100000) {
        operator.setReturnClick(getClick);
    }
    else {
        window.parent.MsgAlert("请放大地图到合适比例尺!");
        return;
    }
}

function getClick(x, y) {
    //设置唯一标识变量
    var sequencecode = x + '-' + y;
    switch (_OPERATIONFLAG) {
        case "BZ_BRANCH": //网点标注
            window.parent.AddBankBranchFn(x, y);
            break;
        case "BZ_JMQ": //居民区标注
            window.parent.AddNeighborhood(x, y);
            break;
        case "BZ_COMPANY": //公司标注
            window.parent.AddCompany(x, y);
            break;
        case "BZ_ZXJ": //政府机关、行政事业单位、军队
            window.parent.AddUnit(x, y);
            break;
        case "BZ_STREET": //专业市场、特色商业街
            window.parent.AddMarket(x, y);
            break;
        case "BZ_SUPERMARKET": //商场、超市
            window.parent.AddSupermarket(x, y);
            break;
        case "BZ_HOTEL": //星级酒店、酒店式公寓
            window.parent.AddHotel(x, y);
            break;
        case "BZ_HOSPITAL": //医院、科研机构
            window.parent.AddResearchInstitutes(x,y);
            break;
        case "FX_CHANNEL": //渠道选址分析
            addCircle(x,y);
            window.parent.Analysis(x, y);
            break;

    }
}
/*************网点标注 结束**************************/



/*************弹出银行网点信息窗体**************************/
function getPoi(evt) {
    //1.根据经纬度信息查找当前标注信息
    var guidstr = this.name;

    var x = guidstr.split('_')[1];
    var y = guidstr.split('_')[2];

    scale(3000);
    GetBranchInfoByXY(x,y);
}
/*************弹出银行网点信息窗体 结束*******************/


/* 图层数据存放 */
var pointBankChinaArray = [];
var pointBankArray = [];
var pointNeighborhoodArray = [];
var pointCompanyArray = [];
var pointHotelArray = [];
var pointMarketsArray = [];
var pointResearchInstitutesArray = [];
var pointSupermarketArray = [];
var pointUnitsArray = [];
var pointSchoolArray = [];
var pointSSB = [];
var pointATM = [];


/*************图层数据标注**************************/
//分类标注
function addLayer(id, name, type, lon, lat, icon) {
    var pointMarker;
    if (type == "中行网点") {
        pointMarker = operator.addPoi(name + "_" + lon + "_" + lat, "img/" + icon, lon, lat, 16, 16, -8, -16, getPoi);
    } else {
        pointMarker = operator.addPoi(type+"_"+name+"_"+lon+"_"+lat, "img/" + icon, lon, lat, 16, 16, -8, -16, getProperties);
    }
    switch (type) {
        case "中行网点":
            pointBankChinaArray.push(pointMarker);
            break;
        case "同业网点":
            pointBankArray.push(pointMarker);
            break;
        case "居民区":
            pointNeighborhoodArray.push(pointMarker);
            break;
        case "公司":
            pointCompanyArray.push(pointMarker);
            break;
        case "专业市场":
            pointMarketsArray.push(pointMarker);
            break;
        case "特色商业街":
            pointMarketsArray.push(pointMarker);
            break;
        case "政府机关":
            pointUnitsArray.push(pointMarker);
            break;
        case "行政事业单位":
            pointUnitsArray.push(pointMarker);
            break;
        case "部队":
            pointUnitsArray.push(pointMarker);
            break;
        case "商场":
            pointSupermarketArray.push(pointMarker);
            break;
        case "超市":
            pointSupermarketArray.push(pointMarker);
            break;
        case "星级酒店":
            pointHotelArray.push(pointMarker);
            break;
        case "酒店式公寓":
            pointHotelArray.push(pointMarker);
            break;
        case "医院":
            pointResearchInstitutesArray.push(pointMarker);
            break;
        case "科研院所":
            pointResearchInstitutesArray.push(pointMarker);
            break;
        case "学校":
            pointSchoolArray.push(pointMarker);
            break;
        case "离行自助":
            pointSSB.push(pointMarker);
            break;
        case "离行ATM":
            pointATM.push(pointMarker);
            break;
    }

    //operator.addPoint(name, lon, lat,icon);
}
//获取
getProperties = function (evt) {
    var entity = this.name;
    var etype = entity.split('_')[0];
    var ename = entity.split('_')[1];



    var x = entity.split('_')[2];
    var y = entity.split('_')[3];

    var content;
    switch (etype) {
        case "同业网点":
            //OperateDelete(pointBankArray);
            break;
        case "居民区":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'"+etype+"'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var name, population, nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        name = item.Neighborhood,
                        population = item.Population;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='NeighborhoodBar'>" + name + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>居民区</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>人口数量：</span>" + population + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "公司":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var cid;
                    var content;
                    $.each(dataobj.root, function (i, item) {
                    cid=item.ID;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='CompanyBar'>" + item.Company + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>公司企业</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>年销售额：</span>" + item.AnnualSales + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>规模：</span>" + item.Proportion + "</div>";
                        content += "<div class='properties telephone'><span style='font-weight:bold;'>地址：</span>未知</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (lon != null && lat != null) {
                        PopupInit(cid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "专业市场":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var content,mid;
                    $.each(dataobj.root, function (i, item) {
                        mid = item.ID;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='MarketBar'>" + item.Market + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>专业市场</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>商户数量：</span>" + item.MerchantAmount + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "特色商业街":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 

                    var content, mid;
                    $.each(dataobj.root, function (i, item) {
                        mid = item.ID;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='MarketBar'>" + item.Market + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>特色商业街</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>商户数量：</span>" + item.MerchantAmount + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(mid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "政府机关":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='UnitsBar'>" + item.UnitName + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>政府机关</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>行政级别：</span>" + item.UnitLevel + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "行政事业单位":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='UnitsBar'>" + item.UnitName + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>行政事业单位</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>行政级别：</span>" + item.UnitLevel + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "部队":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='UnitsBar'>" + item.UnitName + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>部队</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>行政级别：</span>" + item.UnitLevel + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "商场":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var cid;
                    var content;
                    $.each(dataobj.root, function (i, item) {
                        cid = item.ID;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='SupermarketBar'>" + item.Supermarket + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>商场</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>年营业额：</span>" + item.AnnualTurnover + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>规模：</span>" + item.Proportion + "</div>";
                        content += "<div class='properties telephone'><span style='font-weight:bold;'>地址：</span>未知</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (lon != null && lat != null) {
                        PopupInit(cid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "超市":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var cid;
                    var content;
                    $.each(dataobj.root, function (i, item) {
                        cid = item.ID;
                        content = "<div id='ClientPopup'>";
                        content += "<div id='SupermarketBar'>" + item.Supermarket + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>超市</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>年营业额：</span>" + item.AnnualTurnover + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>规模：</span>" + item.Proportion + "</div>";
                        content += "<div class='properties telephone'><span style='font-weight:bold;'>地址：</span>未知</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (lon != null && lat != null) {
                        PopupInit(cid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "星级酒店":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='HotelBar'>" + item.Hotel + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>星级酒店</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>行政级别：</span>" + item.Star + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "酒店式公寓":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='HotelBar'>" + item.Hotel + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>酒店式公寓</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>行政级别：</span>" + item.Star + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "医院":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='ResearchInstitutesBar'>" + item.ResearchInstitutes + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>医院</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "科研院所":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='ResearchInstitutesBar'>" + item.ResearchInstitutes + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>医院</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "学校":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='SchoolsBar'>" + item.School + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>客户源类型：</span>学校</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>类型：</span>" + item.Type + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>暂时为空</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "离行自助":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='UnitsBar'>" + item.SSB_Name + "</div>";
                        content += "<div class='properties parent'><span style='font-weight:bold;'>取款机数量：</span>"+item.TM_Amount+"台&nbsp;存款机数量:"+item.CD_Amount+"</div>";
                        content += "<div class='properties kindAndType'><span style='font-weight:bold;'>一体机数量：</span>" + item.OM_Amount + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>"+item.InstallAddress+"</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
        case "离行ATM":
            $.ajax({
                type: "POST",
                url: "BusinessHandle/ChannelAnalysis/Client.aspx/GetClientInfo",
                data: "{'lon':'" + x + "','lat':'" + y + "','type':'" + etype + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dataobj = eval("(" + data.d + ")"); //转换为json对象 
                    var nid, content;

                    $.each(dataobj.root, function (i, item) {
                        nid = item.ID,
                        content = "<div id='ClientPopup'>";
                        content += "<div id='UnitsBar'>" + item.NAME + "</div>";
                        content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>" + item.Address + "</div>";
                        content += "<div class='detail'>";
                        content += "<ul>";
                        content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                        content += "<li><a href='' title='周边业态'><img alt='周边业态' src='images/properties/chart.png'  border='0'/></a></li>";
                        content += "</ul>";
                        content += "</div>";
                        content += "</div>";
                    });
                    if (x != null && y != null) {
                        PopupInit(nid, x, y, 300, 175, true, content);
                    }
                }
            });
            break;
    }
    PopupInit(ename, x, y, 300, 185, true, content);

}

//分类删除
function LayerRemove(type) {
    switch (type) {
        case "中行网点":
            OperateDelete(pointBankChinaArray);
            break;
        case "同业网点":
            OperateDelete(pointBankArray);
            break;
        case "居民区":
            OperateDelete(pointNeighborhoodArray);
            break;
        case "公司":
            OperateDelete(pointCompanyArray);
            break;
        case "专业市场":
            OperateDelete(pointMarketsArray);
            break;
        case "特色商业街":
            OperateDelete(pointMarketsArray);
            break;
        case "政府机关":
            OperateDelete(pointUnitsArray);
            break;
        case "行政事业单位":
            OperateDelete(pointUnitsArray);
            break;
        case "部队":
            OperateDelete(pointUnitsArray);
            break;
        case "商场":
            OperateDelete(pointSupermarketArray);
            break;
        case "超市":
            OperateDelete(pointSupermarketArray);
            break;
        case "星级酒店":
            OperateDelete(pointHotelArray);
            break;
        case "酒店式公寓":
            OperateDelete(pointHotelArray);
            break;
        case "医院":
            OperateDelete(pointResearchInstitutesArray);
            break;
        case "科研院所":
            OperateDelete(pointResearchInstitutesArray);
            break;
        case "学校":
            OperateDelete(pointSchoolArray);
            break;
        case "离行自助":
            alert(type);
            OperateDelete(pointSSB);
            break;
        case "离行ATM":
            OperateDelete(pointATM);
            break;
    }
}

//执行删除
function OperateDelete(pointArray) {
    for (i = 0; i < pointArray.length; i++) {
        operator.delPoi(pointArray[i]);
    }
}
/*************图层数据标注**************************/
//显示周边业态
function ShowAround(x, y) {
    alert(x, y);
    addCircle(x, y);
    window.parent.Analysis(x, y);
}

function GetBranchInfoByXY(x, y) {
    $.ajax({
        type: "POST",
        url: "BusinessHandle/BankBranch/JQueryAjaxAccess.aspx/GetBranchInfoByXY",
        data: "{'lon':'" + x + "','lat':'" + y + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var dataobj = eval("(" + data.d + ")"); //转换为json对象 

            var lon;
            var lat;
            var branchCode;
            var content;

            var branchKind, branchType, address, telephone, branchParent;



            $.each(dataobj.root, function (i, item) {
                branchCode = item.BranchID;
                lon = item.Branch_X;
                lat = item.Branch_Y;
                branchKind = item.BranchKindName;
                branchType = item.BranchTypeName;
                address = item.BranchAddress;
                telephone = item.BranchPhone;
                branchParent = item.BranchParent;

                if (branchKind == null) { branchKind = "暂未知"; }
                if (branchType == null) { branchType = "暂未知"; }
                if (address == null) { address = "暂未知"; }
                if (telephone == null) { telephone = "暂未知"; }
                if (branchParent == null) { branchParent = "中国银行有限公司总行" }



                content = "<div id='framedPopup'>";
                content += "<div id='titleBar'>" + item.BranchShortName + "</div>";
                content += "<div class='properties parent'><span style='font-weight:bold;'>上级管辖行：</span>" + branchParent + "</div>";
                content += "<div class='properties kindAndType'><span style='font-weight:bold;'>网点种类：</span>" + branchKind + "</div>";
                content += "<div class='properties kindAndType'><span style='font-weight:bold;'>网点类型：</span>" + branchType + "</div>";
                content += "<div class='properties address'><span style='font-weight:bold;'>地址：</span>" + address + "</div>";
                content += "<div class='properties telephone'><span style='font-weight:bold;'>联系电话：</span>" + telephone + "</div>";
                content += "<div class='detail'>";
                content += "<ul>";
                content += "<li><a href='' title='基本信息'><img alt='基本信息' src='images/properties/basicInfo.png'  border='0'/></a></li>";
                content += "<li><a href='' title='业务范围'><img alt='业务范围' src='images/properties/business.png'  border='0'/></a></li>";
                content += "<li><a href='' title='人员数量'><img alt='人员数量' src='images/properties/people.png'  border='0'/></a></li>";
                content += "<li><a href='' title='设备配置'><img alt='设备配置' src='images/properties/equipment.png'  border='0'/></a></li>";
                content += "<li><a href='' title='图片'><img alt='图片' src='images/properties/images.png'  border='0'/></a></li>";
                content += "<li><a href='javascript:void(0)' title='周边业态' onclick='ShowAround(" + lon + "," + lat + ")'><img alt='周边业态' src='images/properties/around.png'  border='0'/></a></li>";
                if (branchCode != 29) {
                    content += "<li><a href='javascript:void(0)' title='经营数据报表' onclick='ShowTradeChart(" + branchCode + ")'><img alt='经营数据报表' src='images/properties/chart.png'  border='0'/></a></li>";
                }
                content += "</ul>";
                content += "</div>";
                content += "</div>";
            })




            if (lon != null && lat != null) {
                PopupInit(branchCode, lon, lat, 340, 185, true, content);
            }
        },
        error: function () {

        }
    });
}

//显示经营数据报表
function ShowTradeChart(branchCode) {
    window.parent.parent.parent.TradeDataReport(branchCode);
}