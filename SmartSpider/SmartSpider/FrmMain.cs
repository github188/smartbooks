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
            this.Text = "网络信息智能采集系统 V1.0.0.0 内部测试版 - 郑州豫图信息技术有限公司";
            this.Icon = new System.Drawing.Icon("mainProgram.ico");

            //初始化为默认Ui
            SetDefaultUI();

            //加载系统配置文件
            LoadConfiguration();

            //测试选项卡
            //Utility.TaskResultLog log = new Utility.TaskResultLog("测试选项卡", new DataTable());
            //this.tabContent.TabPages.Add(log);
            //for (int i = 0; i < 100; i++) {
            //    log.AppendLog("追加的测试日志", 4);
            //}
            //log.AppendRow(new DataGridViewRow());
        }

        /// <summary>
        /// 获取任务运行区指定名称的任务单元
        /// </summary>
        /// <param name="taskPath">任务单元完整文件路径+文件名称</param>
        /// <returns>任务单元</returns>
        private TaskUnit GetRuntimeAreaTaskUnit(string taskPath) {
            foreach (TreeNode node in this.trwTaskFolder.Nodes) {
                if (node.Text.Equals("运行区")) {
                    TaskController controller = (TaskController)node.Tag;
                    foreach (TaskUnit unit in controller.TaskUnit) {
                        if (unit.ConfigPath.Equals(taskPath)) {
                            return unit;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 返回任务状态对应的图标
        /// </summary>
        /// <param name="sender">任务状态</param>
        /// <returns>小图标</returns>
        private string SetTaskStatusImages(Action action) {
            switch (action) {
                case Action.Start:
                    SetStartTaskStatus();
                    return "startmin.png";
                case Action.Pause:
                    SetPauseTaskStatus();
                    return "pausemin.png";
                case Action.Stop:
                    SetStartTaskStatus();
                    return "stopmin.png";
                case Action.Finish:
                    SetStopTaskStatus();
                    return "editmin.png";
                case Action.Ready:
                    return "taskmin.png";
                default :
                    return "stopmin.png";
            }
        }

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

        #region 菜单栏事件
        #region 文件菜单
        //文件菜单：发布结果
        private void FileItemPublishResults_Click(object sender, EventArgs e) {

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
            //筛选出运行区节点
            foreach (TreeNode node in this.trwTaskFolder.Nodes) {
                if (node.Text.Equals("运行区")) {
                    //将任务加入运行区
                    TaskController controller = (TaskController)node.Tag;   //获取运行区任务控制器
                    foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                        TaskUnit unit = (TaskUnit)item.Tag;
                        if (unit.Action == Action.Finish) {
                            if (MessageBox.Show("该任务已经采集完毕，确定重新采集吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                                System.Windows.Forms.DialogResult.Yes) {
                                ShowTaskRuntimesInfo(ref unit);                     //显示任务运行日志信息窗口
                                unit.Start();                                       //启动任务
                                controller.Add(unit);                               //任务单元加入运行区域
                                item.ImageKey = SetTaskStatusImages(unit.Action);   //设置任务状态图标
                            }
                        } else {
                            ShowTaskRuntimesInfo(ref unit);                     //显示任务运行日志信息窗口
                            unit.Start();                                       //启动任务
                            controller.Add(unit);                               //任务单元加入运行区域
                            item.ImageKey = SetTaskStatusImages(unit.Action);   //设置任务状态图标
                        }
                    }
                }
            }
        }
        //工具栏：暂停/继续
        private void tolPauseTask_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                TaskUnit unit = (TaskUnit)item.Tag;
                switch (unit.Action) {
                    case Action.Pause:
                        unit.Continue();
                        break;
                    case Action.Continue:
                        unit.Pause();
                        break;
                }
            }
        }
        //工具栏：停止
        private void tolStopTask_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in this.livTaskView.SelectedItems) {
                TaskUnit unit = (TaskUnit)item.Tag;
                unit.Stop();
            }
        }
        //工具栏：新建任务
        private void tolAddTask_Click(object sender, EventArgs e) {
            TaskUnit unit = new TaskUnit();
            FrmTask newTask = new FrmTask(ref unit);
            newTask.ShowDialog();
        }
        //工具栏：编辑任务
        private void tolEditTask_Click(object sender, EventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                TaskUnit unit = (TaskUnit)livTaskView.SelectedItems[0].Tag;
                FrmTask taskEdit = new FrmTask(ref unit);
                taskEdit.ShowDialog();
            }
        }
        //工具栏：删除任务
        private void tolDeleteTask_Click(object sender, EventArgs e) {
            //foreach (ListViewItem item in this.livTaskView.SelectedItems) {
            //    TaskUnit unit = (TaskUnit)item.Tag;
            //    unit.DeleteTask();                
            //    unit.Dispose();
            //    item.Remove();
            //    this.livTaskView.Refresh();
            //}
            //this.trwTaskFolder.ReLoad();
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
            Application.Exit();

            this.SaveConfiguration();
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
            Application.Exit();
        }
        //任务文件夹：单击节点显示到任务信息到任务窗口
        private void trwTaskFolder_AfterSelect(object sender, TreeViewEventArgs e) {
            if (this.trwTaskFolder.SelectedNode != null) {
                this.livTaskView.Items.Clear();

                if (this.trwTaskFolder.SelectedNode.Text.Equals("运行区")) {
                    #region 显示运行区任务
                    TaskController runtimeAreaTask = (TaskController)this.trwTaskFolder.SelectedNode.Tag;
                    for (int i = 0; i < runtimeAreaTask.TaskUnit.Count; i++) {
                        //Utility.TaskViewItem item = new Utility.TaskViewItem(ref runtimeAreaTask.TaskUnit[i]);
                        //livTaskView.Items.Add(item);
                    }
                    #endregion
                } else {
                    #region 加载指定目录下Xml配置文件
                    string[] files = Directory.GetFiles(trwTaskFolder.SelectedNode.Tag.ToString(), "*.xml");
                    for (int i = 0; i < files.Length; i++) {
                        try {
                            //反序列化配置文件
                            XmlSerializer xs = new XmlSerializer(typeof(Task));
                            Stream readStream = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                            Task task = (Task)xs.Deserialize(readStream);
                            readStream.Close();
                            readStream.Dispose();

                            //生成任务控制单元
                            TaskUnit unit = GetRuntimeAreaTaskUnit(files[i]);

                            //判断该任务是否已在运行区存在
                            if (unit == null) {
                                unit = new TaskUnit();
                                unit.TaskConfig = task;
                                unit.ConfigPath = files[i];
                            }
                            Utility.TaskViewItem item = new Utility.TaskViewItem(ref unit);
                            livTaskView.Items.Add(item);
                        } catch (Exception ex) {
                            throw new Exception(ex.Message);
                        }
                    }
                    #endregion
                }
                this.livTaskView.Refresh();
            }
        }
        //任务运行信息窗口：双击编辑任务配置
        private void livTaskView_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (livTaskView.SelectedItems.Count != 0) {
                TaskUnit unit = (TaskUnit)livTaskView.SelectedItems[0].Tag;
                if (GetRuntimeAreaTaskUnit(unit.ConfigPath) == null) {
                    FrmTask taskConfig = new FrmTask(ref unit);
                    taskConfig.ShowDialog();
                } else {
                    MessageBox.Show("任务正在运行中不能进行编辑操作!", "提示");
                }
            }
        }
        //任务运行信息窗口：单击任务
        private void livTaskView_MouseClick(object sender, MouseEventArgs e) {
            foreach (Utility.TaskViewItem item in this.livTaskView.SelectedItems) {
                item.ImageKey = SetTaskStatusImages(item.Action);
            }
        }
        //任务运行信息窗口：选定项改变
        private void livTaskView_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.livTaskView.SelectedItems.Count == 0) {
                SetDefaultUI();
            } else if (this.livTaskView.SelectedItems.Count == 1) {
                SetSelectOneTask();
            } else {
                SetSelectMultiTask();
            }
        }
        #endregion

        #region 私有方法定义
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
        #endregion

        #region 私有字段定义
        private Configuration _Configuration = new Configuration();
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