//在Index和MapFrame之间提供接口操作

function MsgAlert(msg) {
    Ext.MessageBox.alert("温馨提示!", msg);
}

function DragZoomIn() {
    window.frames["mapContainer"].dragZoomIn();
}

function DragZoomOut() {
    window.frames["mapContainer"].dragZoomOut();
}

function Pan() {
    window.frames["mapContainer"].mov();
}

function ZoomFull() {
    window.frames["mapContainer"].fullMap();
}

function MeaDistance() {
    window.frames["mapContainer"].mesDistance();
}

function MeaArea() {
    window.frames["mapContainer"].mesArea();
}

function TruncateMap() {
    window.frames["mapContainer"].truncateMap();
}

function RefreshMap() {
    window.frames["mapContainer"].InitialMap();
}

function PublicOperation(operation) {
    window.frames["mapContainer"].addpoitomap(operation);

}

//定位网点
function locateBranch(branchCode, x, y, contentHtml) {
    window.frames["mapContainer"].MapLocate(x, y);
    window.frames["mapContainer"].addPoi(branchCode, x, y);
    window.frames["mapContainer"].PopupInit(branchCode, x, y, 340, 185, true, contentHtml);
}

MarkBranch = function (branchCode, x, y) {
    window.frames["mapContainer"].AddBranchPoi(branchCode, x, y);
}

AddCircle = function (x, y) {
    window.frames["mapContainer"].addCircle(x,y);
}



//图层数据标注
AddLayer = function (id, name, type, lon, lat, icon) {
    window.frames["mapContainer"].addLayer(id, name, type, lon, lat, icon);
}
//图层数据删除
RemoveLayers = function (type) {
    window.frames["mapContainer"].LayerRemove(type);
}


//地市定位
CityLocation = function (cityID) {
    $.ajax({
        type: "POST",
        url: "BusinessHandle/Divisions/JQueryAjaxAccess.aspx/GetCityLonLat",
        data: "{'cityID':'" + cityID + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var dataobj = eval("(" + data.d + ")"); //转换为json对象 

            var lon;
            var lat;

            $.each(dataobj.root, function (i, item) {
                lon = item.lon;
                lat = item.lat;
            })

            window.frames["mapContainer"].PubLocation(lon, lat, 300000);
        }
    });
}


var CityFields = Ext.data.Record.create([
        { name: 'd_id', mapping: 'd_id' }, { name: 'd_name', mapping: 'd_name' }
        ]);

var CityStore = new Ext.data.Store({
    proxy: new Ext.data.HttpProxy({
        url: 'BusinessHandle/Divisions/DivisionsList.aspx'
    }),
    reader: new Ext.data.JsonReader({
        root: 'data',
        id: 'd_id'
    },
            CityFields
            )
});
CityStore.load();

var gmapTypeMenu = [{ text: '物资仓库', icon: '../../Images/icons/map.png', checked: true, group: 'gmap', handler: function () { } },
					{ text: '应急队伍', icon: '../../Images/icons/satelite.png', checked: false, group: 'gmap', handler: function () { } }];

var entityList = [{ text: '居民区', icon: 'images/icons/customers.png', checked: true, group: 'entity', handler: function () { PublicOperation('BZ_JMQ'); } },
					{ text: '公司', icon: 'images/icons/company.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_COMPANY'); } },
					{ text: '专业市场或特色商业街', icon: 'images/icons/street.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_STREET'); } },
					{ text: '政府机关、行政事业单位、部队', icon: 'images/icons/flag.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_ZXJ'); } },
					{ text: '商场/超市', icon: 'images/icons/supermarket.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_SUPERMARKET'); } },
					{ text: '星级酒店、酒店式公寓', icon: 'images/icons/hotel.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_HOTEL'); } },
					{ text: '医院/科研院所', icon: 'images/icons/hospital.png', checked: false, group: 'entity', handler: function () { PublicOperation('BZ_HOSPITAL'); } }];

var toolbarItems = [{ xtype: 'combo',
    width: 120,
    id: 'city',
    name: "CityNames",
    fieldLabel: "<font color=black>地市列表</font>",
    editable: false,
    store: CityStore,
    mode: 'remote',
    selectOnFocus: true,
    triggerAction: "all",
    hiddenName: "CityName",
    displayField: "d_name",
    valueField: "d_id",
    emptyText: '地市选择',
    anchor: '100%',
    listeners: {
        select: function () {
            try {
                CityLocation(this.value);
            } catch (ex) {
                Ext.MessageBox.alert(ex);
            }
        }
    }
},
                    { xtype: 'tbseparator' },
                    { xtype: 'tbbutton', text: '放大', cls: 'x-btn-text-icon', icon: '../../Images/maptool/magnifier_zoom.png', tooltip: '拉框放大', handler: function () { DragZoomIn(); } },
					{ xtype: 'tbbutton', text: '缩小', cls: 'x-btn-text-icon', icon: '../../Images/maptool/magnifier_zoom_out.png', tooltip: '拉框缩小', handler: function () { DragZoomOut(); } },
					{ xtype: 'tbbutton', text: '平移', cls: 'x-btn-text-icon', icon: '../../Images/maptool/magnifier_pan.png', tooltip: '地图漫游', handler: function () { Pan(); } },
                    { xtype: 'tbbutton', text: '全图', cls: 'x-btn-text-icon', icon: '../../Images/maptool/image_resize.png', tooltip: '全图显示', handler: function () { ZoomFull(); } },
					{ xtype: 'tbbutton', text: '测距', cls: 'x-btn-text-icon', icon: '../../Images/maptool/ruler.png', tooltip: '测量距离', handler: function () { MeaDistance(); } },
					{ xtype: 'tbbutton', text: '测面', cls: 'x-btn-text-icon', icon: '../../Images/maptool/ruler_crop.png', tooltip: '测量面积', handler: function () { MeaArea(); } },

                    { xtype: 'tbbutton', text: '清除', cls: 'x-btn-text-icon', icon: '../../Images/maptool/cross.png', tooltip: '清除结果', handler: function () { TruncateMap(); } }
//                    { xtype: 'tbbutton', text: '刷新', cls: 'x-btn-text-icon', icon: 'images/maptool/arrow_circle_double.png', tooltip: '刷新地图[Refresh map]', handler: function () { RefreshMap(); } },
//					{xtype: 'tbseparator' },
 //                   { xtype: 'tbbutton', text: '仓库标注', cls: 'x-btn-text-icon', icon: '../../Images/maptool/pin.png', tooltip: '仓库标注', handler: function () { PublicOperation('BZ_STORE'); } },
 //                   { xtype: 'tbbutton', text: '队伍标注', cls: 'x-btn-text-icon', icon: '../../Images/icons/customer.png', tooltip: '队伍标注', handler: function () { PublicOperation('BZ_TEAM'); } },
   //                 { xtype: 'tbseparator' },
//                    { xtype: 'tbbutton', text: '<b><font color="#15428b">渠道选址分析</font></b>', cls: 'x-btn-text-icon', icon: 'images/icons/analyze.png', tooltip: '渠道选址分析', handler: function () { PublicOperation('FX_CHANNEL'); } },
    //                { xtype: 'tbfill' },
//			{ xtype: 'tbbutton', text: '专题图', cls: 'x-btn-text-icon', icon: '../../Images/icons/basicmap.png', menu: gmapTypeMenu, tooltip: '专题图显示'}
        ];

Ext.onReady(function () {

    Ext.QuickTips.init();

    new Ext.Viewport({
        layout: "border",
        items: [{
            region: "north",
            xtype: 'toolbar',
            frame: true,
            deferredRender: true,
            items: toolbarItems
        },
					    {
					        region: "center",
					        id: 'mapPanel',
					        deferredRender: true,
					        border: true,
					        html: '<iframe id="mapContainer" width="100%" src="MapEngine.aspx" height=100% name="mapContainer"  frameborder="0" scrolling="no" style="border:0px none; background-color:#BBBBBB; "></iframe>'
					    }]
    });
});