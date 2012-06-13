// JScript 文件
ALLEvents=function(node)
{
    //银行信息管理
    if(node.id==5)
    {
        BankBranchInfoManage(node);
    }
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
 


