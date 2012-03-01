namespace SmartSpider.Utility {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml.Serialization;
    using Config;

    public class TaskFolderTree : TreeView {
        #region 公共方法定义
        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskFolderTree() {
            this.Nodes.Clear();            
            this.Nodes.Add(Load(_defaultTaskPath, "根文件夹"));
            TreeNode RuntimeArea = new TreeNode("运行区");
            RuntimeArea.Tag = new TaskController();
            this.Nodes.Add(RuntimeArea);
            this.Refresh();
        }

        /// <summary>
        /// 重新加载并刷新任务夹树
        /// </summary>
        public void ReLoad() {
            this.Nodes.Clear();            
            this.Nodes.Add(Load(_defaultTaskPath, "根文件夹"));
            TreeNode RuntimeArea = new TreeNode("运行区");
            RuntimeArea.Tag = new TaskController();
            this.Nodes.Add(RuntimeArea);
            this.Refresh();
        }

        /// <summary>
        /// 加载Task任务目录树
        /// </summary>
        /// <param name="taskPath">Task配置文件目录</param>
        /// <param name="parentNodeName">根节点名称</param>
        /// <returns>Task任务节点树</returns>
        private TreeNode Load(string taskPath, string parentNodeName) {
            string[] dirs = Directory.GetDirectories(taskPath);
            TreeNode node = new TreeNode(parentNodeName);
            node.Expand();
            node.Tag = taskPath;
            node.ImageKey = "foldermax.png";
            //node = AddToNode(node, taskPath);

            if (dirs.Length != 0) {
                for (int i = 0; i < dirs.Length; i++) {
                    string[] files = Directory.GetFiles(dirs[i], "*.xml");
                    string[] curDir = dirs[i].Split('\\');
                    string subNodeName = curDir[curDir.Length - 1];
                    node.Nodes.Add(Load(dirs[i], subNodeName));
                }
            }
            return node;
        }

        /// <summary>
        /// 挂载Task配置文件目录下文件到指定节点
        /// </summary>
        /// <param name="node">Node节点</param>
        /// <param name="taskConfigFilePath">Task配置文件所在目录</param>
        /// <returns>挂在了task配置文件信息的节点</returns>
        private TreeNode AddToNode(TreeNode node, string taskConfigFileDirectory) {
            string[] files = Directory.GetFiles(taskConfigFileDirectory, "*.xml");
            TaskController controller = new TaskController();

            for (int i = 0; i < files.Length; i++) {
                try {
                    XmlSerializer xs = new XmlSerializer(typeof(Task));
                    Stream readStream = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read);
                    Task task = (Task)xs.Deserialize(readStream);
                    readStream.Close();
                    readStream.Dispose();

                    TaskUnit taskUnit = new TaskUnit();
                    taskUnit.TaskConfig = task;
                    taskUnit.ConfigPath = files[i];

                    controller.Add(taskUnit);
                } catch(Exception e) {
                    throw new Exception(e.Message);
                }
            }
            node.Tag = controller;
            return node;
        }
        #endregion

        #region 私有变量定义
        /// <summary>
        /// 默认Task任务文件夹路径
        /// </summary>
        private string _defaultTaskPath = AppDomain.CurrentDomain.BaseDirectory + "Task";
        #endregion
    }
}
