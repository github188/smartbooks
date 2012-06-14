// JScript 文件
ALLEvents=function(node)
{
    if(node.id==5)
    {
        BankBranchInfoManage(node);
    }
}

/*加载模块窗口*/
LoadModule = function (node) {
    var moduleId = node.id; //获取模块ID

    if (moduleId == 74) {
        /*人工巡逻*/
        var pnlArtificialPatrol = new Ext.Panel({
            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='ManageCenter/Patrol/ArtificialPatrol.aspx' scrolling='no' id='ArtificialPatrolFrame' name='ArtificialPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlArtificialPatrol, '');
    } else if (moduleId == 75) {
        /*电子巡逻*/
        var pnlElectronicPatrol = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='ManageCenter/Patrol/ElectronicPatrol.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlElectronicPatrol, '');
    } else if (moduleId == 76) {
        /*即时通讯*/
        var pnlInstantMessaging = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlInstantMessaging, '');
    } else if (moduleId == 77) {
        /*事务提醒*/
        var pnlRemind = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlRemind, '');
    } else if (moduleId == 78) {
        /*电子公告*/
        var pnlEAnnouncement = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlEAnnouncement, '');
    } else if (moduleId == 79) {
        /*公文管理*/

    } else if (moduleId == 80) {
        /*档案分类*/
        var pnlFilesType = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlFilesType, '');
    } else if (moduleId == 81) {
        /*档案管理*/
        var pnlFilesManager = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlFilesManager, '');
    } else if (moduleId == 82) {
        /*考评项目*/
        var pnlEvaluationProject = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlEvaluationProject, '');
    } else if (moduleId == 83) {
        /*考评管理*/
        var pnlpnlEvaluationManager = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlpnlEvaluationManager, '');
    } else if (moduleId == 84) {
        /*路产设备*/
        var pnlRoadProperty = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlRoadProperty, '');
    } else if (moduleId == 85) {
        /*违章管理*/
        var pnlViolation = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlViolation, '');
    } else if (moduleId == 86) {
        /*路产案件*/
        var pnlRoadCase = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlRoadCase, '');
    } else if (moduleId == 87) {
        /*超限车辆汇总*/
        var pnlOverloadSummary = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlOverloadSummary, '');
    } else if (moduleId == 88) {
        /*车辆通行次数统计*/
        var pnlTrafficCount = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlTrafficCount, '');
    } else if (moduleId == 89) {
        /*超限信息查询*/
        var pnlOverLoadSearch = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlOverLoadSearch, '');
    } else if (moduleId == 90) {
        /*非法超限车辆上报*/
        var pnlOverloadReported = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlOverloadReported, '');
    } else if (moduleId == 91) {
        /*涉路工程*/
        var pnlRoadProject= new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlRoadProject, '');
    } else if (moduleId == 92) {
        /*非公路标志*/
        var pnlNonRoadSign = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlNonRoadSign, '');
    } else if (moduleId == 93) {
        /*应急安全*/
        var pnlSecurity = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlSecurity, '');
    } else if (moduleId == 94) {
        /*路况信息*/
        var pnlTraffic = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlTraffic, '');
    } else if (moduleId == 95) {
        /*路况上报*/
        var pnlTrafficReported = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlTrafficReported, '');
    } else if (moduleId == 96) {
        /*路况信息查询*/
        var pnlTrafficSearch = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlTrafficSearch, '');
    } else if (moduleId == 97) {
        /*装备管理*/
        var pnlEquipment = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlEquipment, '');
    } else if (moduleId == 98) {
        /*用户管理*/
        var pnlUserManager = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlUserManager, '');
    } else if (moduleId == 99) {
        /*系统日志*/
        var pnlSystemLog = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlSystemLog, '');
    } else if (moduleId == 111) {
        /*公文发送*/
        var pnlDocumentSend = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlDocumentSend, '');
    } else if (moduleId == 112) {
        /*公文接收*/
        var pnlEAnnouncement = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlEAnnouncement, '');
    } else if (moduleId == 113) {
        /*考评回复*/
        var pnlEvaluationReply = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlEvaluationReply, '');
    } else if (moduleId == 114) {
        /*已发送*/
        var pnlSended = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlSended, '');
    } else if (moduleId == 115) {
        /*草稿箱*/
        var pnlDrafts = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlDrafts, '');
    } else if (moduleId == 116) {
        /*垃圾箱*/
        var pnlTrashcan = new Ext.Panel({

            border: false,
            defaults: { bodyStyle: 'margin:0;padding:0;' },
            html: "<iframe src='main.aspx' scrolling='no' id='ElectronicPatrolFrame' name='ElectronicPatrolFrame' frameborder=0 width=100% height=100%></iframe>"
        });
        LoadModuleMain(node, pnlTrashcan, '');
    }
}


LoadModuleMain = function (node, panel, icon) {
    var tab = center.getItem(node.id);
    if (!tab) {
        var tab = center.add({
            id: node.id,
            iconCls: icon,
            xtype: "panel",
            title: node.text,
            closable: true,
            layout: "fit",
            items: [panel]
        });
    }
    center.setActiveTab(tab);
}


//关闭TabPanel标签
Ext.ux.TabCloseMenu = function(){
      var tabs, menu, ctxItem;
      this.init = function(tp) {
         tabs = tp;
         tabs.on('contextmenu', onContextMenu);
      }
      function onContextMenu(ts, item, me) {
         if (!menu) { // create context menu on first right click
            menu = new Ext.menu.Menu([{
               id: tabs.id + '-close',
               text: '关闭当前标签',
               iconCls:"closetabone",
               handler : function() {
                  tabs.remove(ctxItem);
               }
            },{
               id: tabs.id + '-close-others',
               text: '除此之外全部关闭',
               iconCls:"closetaball",
               handler : function() {
                  tabs.items.each(function(item){
                     if(item.closable && item != ctxItem){
                        tabs.remove(item);
                     }
                  });
               }
            }]);
         }
         ctxItem = item;
         var items = menu.items;
         items.get(tabs.id + '-close').setDisabled(!item.closable);
         var disableOthers = true;
         tabs.items.each(function() {
            if (this != item && this.closable) {
               disableOthers = false;
               return false;
            }
         });
         items.get(tabs.id + '-close-others').setDisabled(disableOthers);
         menu.showAt(me.getXY());
      }
   };
   
   
//内容为Grid
GridMain=function(node,grid,icon){
    var tab = center.getItem(node.id);
	    if(!tab){
		   var tab = center.add({
			    id:node.id,
			    iconCls:icon,
			    
			    xtype:"panel",
			    title:node.text,
			    closable:true,
			    layout:"fit",
			    items:[grid]
			   
		    });
	    }
  center.setActiveTab(tab);
 }
 


