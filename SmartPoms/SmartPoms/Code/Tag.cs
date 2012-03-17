using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPoms.Code {
    public class Tag {
        /// <summary>
        /// 浏览权限
        /// </summary>
        public static string Browse {
            get { return "BROWSE"; }
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        public static string Add {
            get { return "ADD"; }
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        public static string Edit {
            get { return "EDIT"; }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        public static string Delete {
            get { return "DELETE"; }
        }

        /// <summary>
        /// 搜索权限
        /// </summary>
        public static string Search {
            get { return "SEARCH"; }
        }

        /// <summary>
        /// 审核权限
        /// </summary>
        public static string Verify {
            get { return "VERIFY"; }
        }

        /// <summary>
        /// 移动权限
        /// </summary>
        public static string Move {
            get { return "MOVE"; }
        }

        /// <summary>
        /// 打印权限
        /// </summary>
        public static string Print {
            get { return "PRINT"; }
        }

        /// <summary>
        /// 下载权限
        /// </summary>
        public static string Download {
            get { return "DOWNLOAD"; }
        }

        /// <summary>
        /// 备份权限
        /// </summary>
        public static string Backup {
            get { return "BACKUP"; }
        }

        /// <summary>
        /// 授权权限
        /// </summary>
        public static string Grant {
            get { return "GRANT"; }
        }

        /// <summary>
        /// 查看权限
        /// </summary>
        public static string View {
            get { return "VIEW"; }
        }
    }
}