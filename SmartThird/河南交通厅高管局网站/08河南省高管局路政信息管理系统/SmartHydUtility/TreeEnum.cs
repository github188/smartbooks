using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.Utility {
    public enum TreeEnum {
        /// <summary>
        /// 部门树
        /// </summary>
        Department = 0,
        /// <summary>
        /// 部门员工树
        /// </summary>
        DepartmentAndEmployees = 1,
        /// <summary>
        /// 菜单树
        /// </summary>
        Menu = 2,
        /// <summary>
        /// 文档分类树
        /// </summary>
        DocuemntClass = 3,
    }
}
