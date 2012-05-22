using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_USER_ROLE {
        private OracleDAL.BASE_USER_ROLE dal = new OracleDAL.BASE_USER_ROLE();

        /// <summary>
        /// 获取用户功能模块
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public DataTable GetList(decimal userId)
        {
            return dal.GetList(string.Format("USERID={0}", userId.ToString())).Tables[0];
        }
        /// <summary>
        /// 确定用户权限是否存在
        /// </summary>
        /// <param name="USERID"></param>
        /// <returns></returns>
        public bool ExistsUserid(decimal USERID)
        {
            return dal.ExistsUserid(USERID);
        }
        /// <summary>
        /// 向用户授权
        /// </summary>
        public void Add(Entity.BASE_USER_ROLE model)
        {
            dal.Add(model);

        }
        /// <summary>
        /// 根据指定条件获取用户权限列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where) {
            return dal.GetList(where).Tables[0];
        }
        /// <summary>
        /// 根据指定条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool deletelist(string strWhere)
        {
            return dal.deletelist(strWhere);
        }
    }
}
