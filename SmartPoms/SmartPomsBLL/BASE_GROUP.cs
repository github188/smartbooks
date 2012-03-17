

namespace SmartPoms.BLL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    
    public class BASE_GROUP {
        private readonly SQLServerDAL.BASE_GROUP dal = new SQLServerDAL.BASE_GROUP();

        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        public bool Exists(string GroupName, int GroupType)
        {
            return dal.Exists(GroupName, GroupType);
        }

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool CreateGroup(Entity.BASE_GROUP model)
        {
            return dal.CreateGroup(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool UpdateGroup(Entity.BASE_GROUP model)
        {
            return dal.UpdateGroup(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public int DeleteGroup(int GroupID)
        {
            return dal.DeleteGroup(GroupID);
        }

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public Entity.BASE_GROUP GetGroupModel(int GroupID)
        {
            return dal.GetGroupModel(GroupID);
        }

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetGroupList(string strWhere, string strOrder)
        {
            return dal.GetGroupList(strWhere, strOrder);
        }
    }
}
