using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SmartSpider.Utility {
    public class TaskFolderTree : TreeView {
        #region 公共方法定义
        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskFolderTree() {
            this.Nodes.Clear();
            this.Nodes.Add(Load(_defaultTaskPath, "根文件夹"));
            this.Refresh();
        }

        /// <summary>
        /// 重新加载并刷新任务夹树
        /// </summary>
        public void ReLoad() {
            this.Nodes.Clear();
            this.Nodes.Add(Load(_defaultTaskPath, "根文件夹"));
            this.Refresh();
        }

        /// <summary>
        /// 加载Task任务目录树
        /// </summary>
        /// <param name="taskPath">Task配置文件目录</param>
        /// <param name="parentNodeName">根节点名称</param>
        /// <returns>Task任务节点树</returns>
        private TreeNode Load(string taskPath, string parentNodeName) {
            string[] dirs = Directory.GetDirectories(taskPath);         //获取路径下目录            
            TreeNode node = new TreeNode(parentNodeName);
            node.Expand();
            node.Tag = taskPath;
            node.ImageKey = "foldermax.png";

            if (dirs.Length != 0) {
                for (int i = 0; i < dirs.Length; i++) {
                    string[] curDir = dirs[i].Split('\\');
                    string subNodeName = curDir[curDir.Length - 1];
                    node.Nodes.Add(Load(dirs[i], subNodeName));
                }
            }

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
