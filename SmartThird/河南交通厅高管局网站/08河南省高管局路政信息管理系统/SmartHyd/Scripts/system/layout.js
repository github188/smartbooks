/***************功能菜单****************************************/
var rootModule = new Ext.tree.AsyncTreeNode({
    id: 0,
    text: "功能树",
    loader: new Ext.tree.TreeLoader({
        url: "BusinessHandle/SystemSet/GetModuleTree.aspx",
        listeners: {
            "beforeload": function (treeloader, node) {
                treeloader.baseParams = {
                    id: node.id,
                    method: 'POST'
                };
            }
        }
    })
});
var moduleTreePanel = new Ext.tree.TreePanel({
    //如果超出范围带自动滚动条
    autoScroll: false,
    animate: true,
    root: rootModule,
    //默认根目录不显示
    rootVisible: false,
    border: false,
    animate: true,
    lines: true,
    enableDD: true,
    containerScroll: true,
    listeners:
    {
        "click": function (node, event) {
            //叶子节点点击不进入链接
            if (node.isLeaf()) {
                // 显示叶子节点菜单
                event.stopEvent();
                ALLEvents(node);
            } else {
                //不是叶子节点不触发事件
                event.stopEvent();
                //点击时展开
                node.toggle();
            }

        }
    }

});
//加载时自动展开根节点
moduleTreePanel.expandAll();
/***************功能菜单 结束*************************************/


var filesNav = new Ext.Panel({
    border: false,
    defaults: { bodyStyle: 'margin:0;padding:0;' },
    el: 'files'
});


var north = new Ext.Panel({
    border: false,
    region: "north",
    height: 80,
    defaults: { bodyStyle: 'margin:0;padding:0;' },
    el: 'top'
});

var south = new Ext.Panel({
    region: 'south',
    height: 0,
    title: 'Copyright © 2012 河南省交通运输厅高速通路管理局,All Rights Reserved'
});

var west = new Ext.Panel({
    region: "west",
    split: true,
    width: 230,
    iconCls: "navigationicon",
    title: "<span class='moduletitle position'>高速路政系统导航</a>",
    collapsible: true,

    layout: "accordion",
    layoutConfig: {
        activeontop: true
    },
    items: [{
        title: "<span class='moduletitle'>网络办公</span>",
        autoScroll: false,
        iconCls: "netoaicon",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "filesicon",
        title: "<span class='moduletitle'>档案管理</span>",
        layout: 'fit',
        items: [filesNav]
    }, {
        title: "<span class='moduletitle'>绩效考核</span>",
        iconCls: "hotelmanageicon",
        items: [moduleTreePanel]
    },{
        iconCls: "roadpatrolicon",
        title: "<span class='moduletitle'>路政巡逻</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "customersicon",
        title: "<span class='moduletitle'>人员装备</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "luchanicon",
        title: "<span class='moduletitle'>路产管理</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "chaoxianicon",
        title: "<span class='moduletitle'>超限治理</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "xukeicon",
        title: "<span class='moduletitle'>行政许可</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "securityicon",
        title: "<span class='moduletitle'>应急安全</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "trafficcondition",
        title: "<span class='moduletitle'>路况信息</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }, {
        iconCls: "systemseticon",
        title: "<span class='moduletitle'>系统管理</span>",
        layout: 'fit',
        items: [moduleTreePanel]
    }]
});


var center = new Ext.TabPanel({
    border: true,
    region: "center",
    //默认选中第一个
    activeItem: 0,
    //如果Tab过多会出现滚动条
    enableTabScroll: true,
    //加载时渲染所有
    //deferredRender:false,
    layoutOnTabChange: true,
    items:[{
            xtype: "panel",
            id: "index",
            iconCls: "workbenchicon",
            title: "我的工作台-路政工作动态",
            html: "<iframe src='workbench.aspx' scrolling='no' id='mainFame' name='mainFrame' frameborder=0 width=100% height=100%></iframe>"

        }],
    plugins: new Ext.ux.TabCloseMenu()
});
/***************系统布局 结束****************************************/


Ext.onReady(function () {
    new Ext.Viewport({
        layout: "border",
        items: [north, south, center, west]
    });
});