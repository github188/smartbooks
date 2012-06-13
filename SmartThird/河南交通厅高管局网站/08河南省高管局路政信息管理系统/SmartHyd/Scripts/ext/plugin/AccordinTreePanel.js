/**
 * 扩展了Panel类，其布局设为accordion，所在区域为west；该组件初始化后会根据配置的url和root向后台发
 * 起请求并解析返回的json串，根据parentcode为空的结点生成TreePanel，子节点通过parentcode属性添加为
 * 对应结点的子节点，注意此处每个节点的code必须小于父节点并接大于下方的其它结点;
 *
 * 1.1更新：
 * 1.不再需要leaf属性，程序内部判断；
 * 2.store用完后即销毁，不再可用；
 * 3.修改了结点点击的触发事件，仅注册一次以减少内存占用，该方法传递给监听函数一个Ext.tree.TreeNode对象，
 * 可通过node.attributes属性获取结点属性；
 * 4.添加了一个getNodeById方法，该方法通过id字符串返回对应Ext.tree.TreeNode对象；
 *
 * @author chemzqm@gmail.com
 * @version 1.1
 * @since 2010-5-9
 *
 */
Ext.ns("QM.ui");

QM.ui.MenuPanel = Ext.extend(Ext.Panel, {
    /**
     * @cfg(url) 发送请求的地址
     */
    /**
     * @cfg(root) json数组的根字符串
     */
    constructor: function(config){
        QM.ui.MenuPanel.superclass.constructor.call(this, Ext.apply({ 
            maxSize: 400,
            minSize: 100,
            collapseMode: 'mini',
			collapsible: true,
            animCollapse: false,
            animate: true,
            id: 'menuPanel',
            width: 210,
            header: false,
            split: true,
            layout: 'accordion',
            region: 'west',           
            autoScroll: true,
			margins:'0 0 0 5',
            cmargins: '0 0 0 0',
            ref: 'menuPanel'
        }, config || {}));
    },
    initComponent: function(){
        QM.ui.MenuPanel.superclass.initComponent.call(this);
        this.addEvents(        /**
         * @event itemclick  树结点被点击时触发  参数：node 当前结点对象，record 当前结点对应record对象
         */
        'click',        /**
         * @event afterload 菜单项加载完毕后触发
         */
        'afterload');
        if (!this.store) {
            this.store = new Ext.data.JsonStore({
                url: this.url,
                root: this.root,
                fields: ['id', 'text', 'parentid', 'iconCls', 'href']
            });
        }
        this.store.load({
            callback: this.loadTrees,
            scope: this
        });
    },
    loadTrees: function(records, o, s){
        var pnodes, trees = [], tree;
        this.store.sort('id');
        for (var i = 0; i < records.length; i++) {
            var record = records[i];
            //if (!record.get('parentid')) {
            if (record.get('parentid')=="0") {
                tree = this.creatTreeConfig(record);
                trees.push(tree);
                pnodes = [];
                pnodes.push(tree.root);
            }
            else {
                var next_record = records[i + 1];
                var isLeaf = !next_record || next_record.get('parentid') != record.get('id');
                this.addTreeNode(pnodes, record, isLeaf);
            }
        }
        Ext.each(trees, function(tree){
            this.add(tree);
        }, this);
        this.mon(this.el, 'click', this.onClick, this);
        this.doLayout();
        this.store.destroy();
        this.fireEvent('afterload', this);
    },
    //@public 根据结点id找到结点对象
    getNodeById: function(id){
        var node, trees = this.findByType('treepanel', true);
        Ext.each(trees, function(tree){
            node = tree.getNodeById(id);
            return !node;//找到的话返回false
        });
        return node;
    },
    onClick: function(e, t, o){
        if (Ext.fly(t).hasClass('x-tree-ec-icon')) {//点击伸展按钮时无视
            return;
        }
        var el, id, node;
        if (el = e.getTarget('.x-tree-node-el', 3, true)) {
            e.stopEvent();
            id = el.getAttributeNS('ext', 'tree-node-id');
            node = this.getNodeById(id);
            var workPanel = this.ownerCt.workPanel;
            workPanel.showTab(node);//
            this.fireEvent('click', this, node);
        }
    },
    creatTreeConfig: function(record){
        var config = {
            xtype: 'treepanel',
            autoScroll: true,
            rootVisible: false,
            lines: false,
            title: record.get('text'),
            iconCls: record.get('iconCls'),
			border:false,
            root: {
                nodeType: 'async',
                expanded: true,
                id: record.get('id'),
                children: []
            },
            listeners: {
                'deactivate': function(tree){
                    tree.getSelectionModel().clearSelections(true);
                }
            }
        };
        return config;
    },
    addTreeNode: function(pnodes, record, isLeaf){
        var len = pnodes.length;
        for (var i = len - 1; i >= 0; i--) {
            if (pnodes[i].id != record.get('parentid')) {
                pnodes.pop();
            }
            else {
                var parent = pnodes[i].children;
                var node = {
                    text: record.get('text'),
                    id: record.get('id'),
                    iconCls: record.get('iconCls'),
                    href: record.get('href'),
                    leaf: isLeaf
                };
                if (!isLeaf) {
                    node.children = [];
                    pnodes.push(node);
                }
                parent.push(node);
                return;
            }
        }
    },
    //@public根据node对象/id显示结点所在tree并选中
    selectNode: function(node){
        var tree;
        if (Ext.isString(node)) {
            node = this.getNodeById(node);
        }
        tree = node.getOwnerTree();
        this.getLayout().setActiveItem(tree.getId());
        tree.expandPath(node.getPath());
        tree.getSelectionModel().select(node);
    }
});

//showTab用于显示子组件，loadChild用于子组件的加载
QM.ui.WorkPanel = Ext.extend(Ext.TabPanel, {
    ref: 'workPanel',
    region: 'center',
    resizeTabs: true,
    minTabWidth: 135,
    tabWidth: 135,
    plugins: new Ext.ux.TabCloseMenu(),
    enableTabScroll: true,
    activeTab: 0,
    beforeInit: Ext.emptyFn,
    loadChild: Ext.emptyFn,
    initComponent: function(){
        QM.ui.WorkPanel.superclass.initComponent.call(this);
        this.on('tabchange', this.onChange);
    },
    onChange: function(tp, tab){
        var menuPanel = this.ownerCt.menuPanel;
        var tree;
        if (tab.itemId) {
            menuPanel.selectNode(tab.itemId);
        }
        else //选择主页时清空当前树的选择项
             if (tree = menuPanel.getLayout().activeItem) {
                tree.getSelectionModel().clearSelections(true);
            }
    },
    //@public根据node或id显示对象panel没有的话创建
    showTab: function(node){
        var menuPanel = this.ownerCt.menuPanel;//找到菜单面板
        if (Ext.isString(node)) {
            node = menuPanel.getNodeById(node);
            if (!node) {
                return;
            }
        }
        var tab, attrs = node.attributes;
        if (!this.getItem(attrs.id)) {
            tab = this.add({
                itemId: attrs.id,
                title: attrs.text,
                iconCls: attrs.iconCls,
                closable: true,
                layout: 'fit'
            })
            var child = this.loadChild(tab, node);
            tab.add(child || {});
            this.doLayout();
        }
        this.setActiveTab(attrs.id);
    }
})


