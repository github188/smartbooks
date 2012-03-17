

namespace SmartPoms.BLL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;

    public class BASE_USERGROUP {
        private readonly SQLServerDAL.BASE_USERGROUP dal = new SQLServerDAL.BASE_USERGROUP();

        #region 用户分组
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="Name">用户分组名称</param>
        /// <returns></returns>
        public bool UserGroupExists(string Name)
        {
            return dal.UserGroupExists(Name);
        }

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public int CreateUserGroup(Entity.BASE_USERGROUP model)
        {
            if (!UserGroupExists(model.UG_Name))
                return dal.CreateUserGroup(model);
            else
                return 2;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public bool UpdateUserGroup(Entity.BASE_USERGROUP model)
        {
            return dal.UpdateUserGroup(model);
        }

        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public int DeleteUserGroup(int id)
        {
            return dal.DeleteUserGroup(id);
        }

        /// <summary>
        /// 获取模块深度
        /// </summary>
        /// <param name="ID">模块ID</param>
        /// <returns></returns>
        public int GetUserGroupDepth(int id)
        {
            return dal.GetUserGroupDepth(id);
        }

        /// <summary>
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public Entity.BASE_USERGROUP GetUserGroupModel(int id)
        {
            return dal.GetUserGroupModel(id);
        }

        /// <summary>
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetUserGroupList(string strWhere)
        {
            return dal.GetUserGroupList(strWhere);
        }

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildUserGroupList(int id)
        {
            return dal.GetChildUserGroupList(id);
        }

        /// <summary>
        /// 判断用户分组下是否有模块
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        public bool IsUser(int id)
        {
            return dal.IsUser(id);
        }

        #endregion
    }
}
