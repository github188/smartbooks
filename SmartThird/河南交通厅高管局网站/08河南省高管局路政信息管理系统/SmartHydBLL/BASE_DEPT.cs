using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace SmartHyd.BLL {
    public class BASE_DEPT {
        private OracleDAL.BASE_DEPT dal = new OracleDAL.BASE_DEPT();

        public Entity.BASE_DEPT GetEntity(decimal deptID)
        {
            return dal.GetEntity(deptID);
        }

        /// <summary>
        /// 获取用户所属的部门和子部门
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="issubdept">-1:包含子部门,其他:用户所属部门</param>
        /// <returns>部门信息</returns>
        public DataTable GetUserWhereDepartment(string userName, int issubdept) {
            //校验用户名合法性

            return dal.GetUserWhereDepartment(userName, issubdept);
        }
        /// <summary>
        /// 根据条件获取部门列表
        /// </summary>
        /// <param name="strWhere">查询部门的条件</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllDep(string strWhere)
        {
            return dal.GetList(strWhere).Tables[0];
        }
        /// <summary>
        /// 新建部门
        /// </summary>
        /// <param name="model">部门实体</param>
        public int Add(Entity.BASE_DEPT model)
        {
           return dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal DEPTID)
        {
            if (dal.Exists(DEPTID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
         /// <summary>
        /// 确定子单位记录是否存在
        /// </summary>
        /// <param name="DEPTID"></param>
        /// <returns></returns>
        public bool ExistsChildDept(decimal DEPTID)
        {
            return dal.ExistsChildDept(DEPTID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_DEPT model)
        {
            if (dal.Update(model))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 部门数据删除
        /// </summary>
        /// <returns></returns>
        public bool del(decimal DEPTID)
        {
            return dal.Delete(DEPTID);
        }
    }
}
