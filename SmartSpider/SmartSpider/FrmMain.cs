namespace SmartSpider {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml.Serialization;
    using Config;

    public partial class FrmMain : Form {
        #region 构造方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain() {
            InitializeComponent();

            //初始化为默认Ui
            SetDefaultUI();

            //加载系统配置文件
            LoadConfiguration();

            //加载本地XML任务配置文件
            LoadLocationTaskItem();

            /*加载DBTaskList*/
            //LoadDBTaskItem();

            this.Text = "网络信息智能采集系统 V1.0.0.0 内部测试版 - 郑州豫图信息技术有限公司";
            this.Icon = new System.Drawing.Icon("mainProgram.ico");
        }
        #endregion

        #region 菜单栏事件
        #region 文件菜单
        //文件菜单：发布结果
        private void FileItemPublishResults_Click(object sender, EventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                int index = (int)livTaskView.SelectedItems[0].Tag;    //当前任务索引
                taskItem[index].PublishResult();    //发布采集结果
            }
        }
        //文件菜单：结果另存为Excel
        private void FileItemSaveAsExcel_Click(object sender, EventArgs e) {

        }
        //文件菜单：结果另存在文本文件
        private void FileItemSaveAsTextFile_Click(object sender, EventArgs e) {

        }
        //文件菜单：结果另存为Access
        private void FileItemSaveAsAccessDB_Click(object sender, EventArgs e) {

        }
        //文件菜单：查看结果
        private void FileItemViewResult_Click(object sender, EventArgs e) {

        }
        //文件菜单：清空结果
        private void FileItemClearResult_Click(object sender, EventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                int index = (int)livTaskView.SelectedItems[0].Tag;    //当前任务索引
                taskItem[index].Results.Rows.Clear();    //清除所有行
            }
        }
        //文件菜单：发布时重复行-查看
        private void FileItemPublishResultRepeatView_Click(object sender, EventArgs e) {

        }
        //文件菜单：发布时重复行-清空
        private void FileItemPublishResultRepeatClear_Click(object sender, EventArgs e) {

        }
        //文件菜单：发布时出错行-查看
        private void FileItemPublishResultErrorView_Click(object sender, EventArgs e) {

        }
        //文件菜单：发布时出错行-清空
        private void FileItemPublishResultErrorClear_Click(object sender, EventArgs e) {

        }
        //文件菜单：历史记录-查看
        private void FileItemHistoryView_Click(object sender, EventArgs e) {

        }
        //文件菜单：历史记录-清空
        private void FileItemHistoryClear_Click(object sender, EventArgs e) {

        }
        //文件菜单：历史记录-启用
        private void FileItemHistoryEnable_Click(object sender, EventArgs e) {

        }
        //文件菜单：任务日志-查看
        private void FileItemTaskLogView_Click(object sender, EventArgs e) {

        }
        //文件菜单：任务日志-清空
        private void FileItemTaskLogClear_Click(object sender, EventArgs e) {

        }
        //文件菜单：退出
        private void FileItemExit_Click(object sender, EventArgs e) {
            /*保存配置文件*/
            SaveConfiguration();

            /*保存任务信息到数据库*/
            //SaveTaskItemToDB();

            /*保存任务信息到本地Task目录下*/
            //SaveLoactionTaskItem();

            Application.ExitThread();
            Application.Exit();
        }
        #endregion

        #region 查看菜单
        //查看菜单：显示/关闭工具栏
        private void ViewItemShowToolBar_Click(object sender, EventArgs e) {

        }
        //查看菜单：显示关闭浮动窗口
        private void ViewItemShowFloatFrom_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 文件夹菜单
        //文件夹菜单：新建
        private void FolderItemAdd_Click(object sender, EventArgs e) {

        }
        //文件夹菜单：重命名
        private void FolderItemRename_Click(object sender, EventArgs e) {

        }
        //文件夹菜单：删除
        private void FolderItemDelete_Click(object sender, EventArgs e) {

        }
        //文件夹菜单：刷新
        private void FolderItemRefresh_Click(object sender, EventArgs e) {
            LoadLocationTaskItem(); //刷新任务
            trwTaskFolder.ReLoad(); //刷新树节点
        }
        //文件夹菜单：导出
        private void FolderItemExport_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 任务菜单
        //任务菜单：显示运行信息
        private void TaskItemShowInfo_Click(object sender, EventArgs e) {

        }
        //任务菜单：开始
        private void TaskItemStart_Click(object sender, EventArgs e) {

        }
        //任务菜单：暂停
        private void TaskItemSpace_Click(object sender, EventArgs e) {

        }
        //任务菜单：停止
        private void TaskItemStop_Click(object sender, EventArgs e) {

        }
        //任务菜单：新建
        private void TaskItemAdd_Click(object sender, EventArgs e) {
            TaskUnit unit = new TaskUnit();
            FrmTask newTask = new FrmTask(ref unit);
            newTask.ShowDialog();
        }
        //任务菜单：编辑
        private void TaskItemEdit_Click(object sender, EventArgs e) {
            if (this.livTaskView.SelectedItems.Count != 0) {
                TaskUnit unit = (TaskUnit)this.livTaskView.SelectedItems[0].Tag;
                FrmTask newTask = new FrmTask(ref unit);
                newTask.ShowDialog();
            }
        }
        //任务菜单：复制
        private void TaskItemCopy_Click(object sender, EventArgs e) {

        }
        //任务菜单：删除
        private void TaskItemDelete_Click(object sender, EventArgs e) {

        }
        //任务菜单：导出
        private void TaskItemExport_Click(object sender, EventArgs e) {

        }
        //任务菜单：导入
        private void TaskItemImport_Click(object sender, EventArgs e) {

        }
        //任务菜单：全选
        private void TaskItemSelectAll_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 设置菜单
        //设置菜单：Html标记
        private void configItemHtmlLable_Click(object sender, EventArgs e) {

        }
        //设置菜单：正则表达式
        private void configItemRegex_Click(object sender, EventArgs e) {

        }
        //设置菜单：预置正则名称
        private void configItemPreviewRulesName_Click(object sender, EventArgs e) {

        }
        //设置菜单：选项
        private void configItemOption_Click(object sender, EventArgs e) {
            FrmOption option = new FrmOption(this._Configuration);
            option.ShowDialog();
        }
        #endregion

        #region 工具菜单
        //工具菜单：源文件查看器
        private void ToolItemSourceView_Click(object sender, EventArgs e) {

        }
        //工具菜单：正则式测试器
        private void ToolItemRegesTest_Click(object sender, EventArgs e) {

        }
        //工具菜单：网址编码器
        private void ToolItemUrlEncoding_Click(object sender, EventArgs e) {

        }
        //工具菜单：任务升级器
        private void ToolItemTaskUpdate_Click(object sender, EventArgs e) {

        }
        //工具菜单：在线发布器
        private void ToolItemOnLinePublish_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 帮助菜单
        //帮助菜单：在线帮助
        private void HelpItemOnLineHelp_Click(object sender, EventArgs e) {

        }
        //帮助菜单：网站
        private void HelpItemSite_Click(object sender, EventArgs e) {

        }
        //帮助菜单：论坛
        private void HelpItemBBS_Click(object sender, EventArgs e) {

        }
        //帮助菜单：购买
        private void HelpItemBuy_Click(object sender, EventArgs e) {

        }
        //帮助菜单：关于SmartSpider
        private void HelpItemAboutUS_Click(object sender, EventArgs e) {
            FrmAboutUS about = new FrmAboutUS();
            about.ShowDialog();
        }
        #endregion

        #region 私有变量定义
        #endregion
        #endregion

        #region 工具栏事件
        //工具栏：开始
        private void tolStartTask_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                int taskIndex = (int)item.Tag;
                if (taskItem[taskIndex].Action == Action.Finish) {
                    if (MessageBox.Show("该任务已经采集完毕，确定重新采集吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                        System.Windows.Forms.DialogResult.Yes) {
                        ShowTaskRuntimesInfo(ref taskItem[taskIndex]);  //显示任务运行日志信息窗口
                        taskItem[taskIndex].Action = Action.Start;
                    }
                } else {
                    ShowTaskRuntimesInfo(ref taskItem[taskIndex]);      //显示任务运行日志信息窗口
                    taskItem[taskIndex].Action = Action.Start;
                }
            }

            this.tolStartTask.Enabled = false;
            this.tolPauseTask.Enabled = true;
            this.tolStopTask.Enabled = true;

            this.tolAddTask.Enabled = true;
            this.tolEditTask.Enabled = false;
            this.tolDeleteTask.Enabled = false;
        }
        //工具栏：暂停
        private void tolPauseTask_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                int taskIndex = (int)item.Tag;
                taskItem[taskIndex].Action = Action.Pause;

                this.tolPauseTask.Enabled = false;
                this.tolStartTask.Enabled = true;
                this.tolStopTask.Enabled = true;

                this.tolAddTask.Enabled = true;
                this.tolEditTask.Enabled = true;
                this.tolDeleteTask.Enabled = true;
            }
        }
        //工具栏：停止
        private void tolStopTask_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                int taskIndex = (int)item.Tag;
                taskItem[taskIndex].Action = Action.Stop;

                this.tolPauseTask.Enabled = false;
                this.tolStartTask.Enabled = true;
                this.tolStopTask.Enabled = false;

                this.tolAddTask.Enabled = true;
                this.tolEditTask.Enabled = true;
                this.tolDeleteTask.Enabled = true;
            }
        }
        //工具栏：新建任务
        private void tolAddTask_Click(object sender, EventArgs e) {
            TaskUnit unit = new TaskUnit();
            unit.ConfigDir = (string)trwTaskFolder.SelectedNode.Tag;
            FrmTask newTask = new FrmTask(ref unit);
            newTask.ShowDialog();

            LoadLocationTaskItem(); //刷新任务
            trwTaskFolder.ReLoad(); //刷新树节点
        }
        //工具栏：编辑任务
        private void tolEditTask_Click(object sender, EventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                int selectIndex = (int)livTaskView.SelectedItems[0].Tag;    //当前任务索引
                FrmTask taskEdit = new FrmTask(ref taskItem[selectIndex]);
                taskEdit.ShowDialog();
            }
        }
        //工具栏：删除任务
        private void tolDeleteTask_Click(object sender, EventArgs e) {
            if (MessageBox.Show("确定要删除选定的任务吗？", "消息提示", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information)
                == System.Windows.Forms.DialogResult.Yes) {
                foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                    int selectIndex = (int)item.Tag;    //当前任务索引
                    taskItem[selectIndex].DeleteTask(); //删除任务
                    taskItem[selectIndex] = null;       //任务对象置为Null
                    this.livTaskView.Items.Remove(item);
                    break;
                }
            }
        }
        //工具栏：所有任务完成后关机
        private void tolAllTaskSuccessShutdown_Click(object sender, EventArgs e) {

        }
        //工具栏：禁用定时采集
        private void TolDisableAllTimingAcquisitionTask_Click(object sender, EventArgs e) {

        }
        //工具栏：选项
        private void tolOption_Click(object sender, EventArgs e) {
            FrmOption option = new FrmOption(this._Configuration);
            option.ShowDialog();
        }
        //工具栏：在线帮助
        private void TolOnLineHelp_Click(object sender, EventArgs e) {

        }
        //工具栏：关于SmartSpider
        private void TolAboutUS_Click(object sender, EventArgs e) {
            FrmAboutUS about = new FrmAboutUS();
            about.ShowDialog();
        }
        //工具栏：退出
        private void TolExit_Click(object sender, EventArgs e) {
            /*保存配置文件*/
            SaveConfiguration();

            /*保存任务信息到数据库*/
            //SaveTaskItemToDB();

            /*保存任务信息到本地Task目录下*/
            //SaveLoactionTaskItem();

            Application.ExitThread();
            Application.Exit();
        }
        //工具栏：导出到Excel
        private void ExportToExcel_Click(object sender, EventArgs e) {

        }
        //工具栏：导出到文本文件
        private void ExportToTextFile_Click(object sender, EventArgs e) {

        }
        //工具栏：导出到Access
        private void ExportToAccessDB_Click(object sender, EventArgs e) {

        }
        #endregion

        #region 窗体控件事件
        //主窗体：点击X按钮，退出程序
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            /*保存配置文件*/
            SaveConfiguration();

            /*保存任务信息到数据库*/
            //SaveTaskItemToDB();

            /*保存任务信息到本地Task目录下*/
            //SaveLoactionTaskItem();

            Application.ExitThread();
            Application.Exit();
        }
        //任务文件夹：单击节点显示到任务信息到任务窗口
        private void trwTaskFolder_AfterSelect(object sender, TreeViewEventArgs e) {
            //筛选出tag分类下任务显示到任务详细信息窗口
            this.livTaskView.Items.Clear();
            string dir = (string)trwTaskFolder.SelectedNode.Tag;
            for (int i = 0; i < taskItem.Length; i++) {
                if (taskItem[i] != null) {
                    if (taskItem[i].ConfigDir.Equals(dir)) {
                        Utility.TaskViewItem item = new Utility.TaskViewItem(ref taskItem[i], i);
                        this.livTaskView.Items.Add(item);
                    }
                }
            }
        }
        //任务运行信息窗口：双击编辑任务配置
        private void livTaskView_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                int taskIndex = (int)livTaskView.SelectedItems[0].Tag;
                FrmTask edit = new FrmTask(ref taskItem[taskIndex]);
                if (taskItem[taskIndex].Action == Action.Start) {
                    if (MessageBox.Show("任务处于非停止状态，单击YES按钮暂停任务已进行编辑，单击No按钮取消编辑操作!", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        System.Windows.Forms.DialogResult.Yes) {
                        taskItem[taskIndex].Action = Action.Stop;
                        taskItem[taskIndex].time.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                        edit.ShowDialog();
                    }
                    return;
                } else {
                    edit.ShowDialog();
                }
            }
        }
        //任务运行信息窗口：单击任务
        private void livTaskView_MouseClick(object sender, MouseEventArgs e) {
            foreach (Utility.TaskViewItem item in this.livTaskView.SelectedItems) {
                SetTaskStatusUi(item.Action);
            }
        }
        //任务运行信息窗口：选定项改变
        private void livTaskView_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.livTaskView.SelectedItems.Count == 0) {
                SetDefaultUI();
            } else if (this.livTaskView.SelectedItems.Count == 1) {
                foreach (Utility.TaskViewItem item in this.livTaskView.SelectedItems) {
                    SetTaskStatusUi(item.Action);
                }
            } else {
                SetSelectMultiTask();
            }
        }
        #endregion

        #region 私有方法定义
        #region 加载/保存配置文件和任务列表
        /// <summary>
        /// 加载系统配置文件
        /// </summary>
        private void LoadConfiguration() {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "Configuration.xml";
            Stream readStream;
            try {
                XmlSerializer xs = new XmlSerializer(typeof(Config.Configuration));
                readStream = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Delete);
                this._Configuration = (Config.Configuration)xs.Deserialize(readStream);
                readStream.Close();
                readStream.Dispose();
            } catch {
                readStream = null;

                SaveConfiguration();
            }
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        private void SaveConfiguration() {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "Configuration.xml";
            File.Delete(configPath);
            XmlSerializer xs = new XmlSerializer(typeof(Config.Configuration));
            Stream WriteStream = new FileStream(configPath, FileMode.Create, FileAccess.Write, FileShare.Read);
            xs.Serialize(WriteStream, this._Configuration);
            WriteStream.Close();
            WriteStream.Dispose();
        }
        /// <summary>
        /// 从数据库加载task列表
        /// </summary>
        private void LoadDBTaskItem() {
            /*从数据库加载task列表*/
            DataTable dt = new DataTable();
            string sec = "";
            dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];

            /*构造任务实例*/
            taskItem = new TaskUnit[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++) {
                string configStr = dt.Rows[i][""].ToString();/*读取配置文件字段内容*/
                if (taskItem[i] == null) {
                    taskItem[i] = new TaskUnit();
                }
                taskItem[i].TaskConfig = Smart.Utility.SerializeUtilities.Desrialize(taskItem[i].TaskConfig, configStr);
            }

            /*构造左侧导航树分类*/
            sec = ""; //节点:ID,名称,父ID
            dt = Smart.DBUtility.SqlServerHelper.Query(sec).Tables[0];
            TreeNode rootNode = new TreeNode();
            foreach (DataRow row in dt.Rows) {
                TreeNode subNode = new TreeNode();
                string id = row["id"].ToString();
                string nodeText = row["nodeName"].ToString();
                string pid = row["pid"].ToString(); /*父ID*/
                if (pid.Equals("0")) {
                    /*添加根节点*/
                } else {
                    /*遍历子节点*/
                    foreach (DataRow subRow in dt.Rows) {
                        string subId = row["id"].ToString();
                        string subNodeText = row["nodeName"].ToString();
                        string subPid = row["pid"].ToString();
                        if (subId.Equals(id)) {
                            /*添加子节点*/
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 保存任务列表到数据库
        /// </summary>
        private void SaveTaskItemToDB() {
            for (int i = 0; i < taskItem.Length; i++) {
                if (taskItem[i] != null) {
                    /*将任务序列化为字符串然后进行Base64编码处理*/
                    string configStr = Smart.Utility.SerializeUtilities.Serialize(taskItem[i].TaskConfig);

                    /*构造Sql语句，更新任务配置信息*/
                    string update = "";
                    Smart.DBUtility.SqlServerHelper.Query(update);
                }
            }
        }
        /// <summary>
        /// 加载本地任务列表(默认在当前程序所在目录task目录下)
        /// </summary>
        private void LoadLocationTaskItem() {
            string taskRootPath = AppDomain.CurrentDomain.BaseDirectory + "Task";
            string[] files = Directory.GetFiles(taskRootPath, "*.xml", SearchOption.AllDirectories);
            this.taskItem = new TaskUnit[files.Length];
            for (int i = 0; i < files.Length; i++) {
                try {
                    //反序列化配置文件
                    XmlSerializer xs = new XmlSerializer(typeof(Task));
                    Stream readStream = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                    Task task = (Task)xs.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();

                    if (taskItem[i] == null) {
                        taskItem[i] = new TaskUnit();
                    }

                    taskItem[i].ConfigPath = files[i];
                    taskItem[i].TaskConfig = task;
                    taskItem[i].ConfigDir = Directory.GetParent(files[i]).FullName;

                } catch (Exception ex) {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void SaveLoactionTaskItem() {
        }

        private TreeNode RecursiveCreateNode(string id, DataTable dt) {
            TreeNode node = new TreeNode();
            foreach (DataRow row in dt.Rows) {
                if (row["pid"].ToString().Equals(id)) {
                    node.Text = row["nodeName"].ToString();
                } else {
                    return RecursiveCreateNode(row[""].ToString(), dt);
                }
            }
            return node;
        }
        #endregion

        /// <summary>
        /// 显示任务运行日志信息窗口
        /// </summary>
        /// <param name="unit">任务单元</param>
        private void ShowTaskRuntimesInfo(ref TaskUnit unit) {
            bool isNull = true;
            foreach (TabPage page in this.tabContent.TabPages) {
                string kind = (string)page.Tag;
                if (kind == unit.ConfigPath) {
                    this.tabContent.SelectedTab = page;
                    isNull = false;
                    break;
                }
            }
            if (isNull) {
                Utility.TaskResultLog log = new Utility.TaskResultLog(ref unit);
                this.tabContent.TabPages.Add(log);
                this.tabContent.SelectedTab = log;
            }
        }
        #endregion

        #region 私有字段定义
        private Configuration _Configuration = new Configuration();
        private TaskUnit[] taskItem;
        #endregion

        #region 公共属性定义
        /// <summary>
        /// 系统配置
        /// </summary>
        public Configuration Configuration {
            get { return _Configuration; }
            set { _Configuration = value; }
        }
        #endregion
    }
}