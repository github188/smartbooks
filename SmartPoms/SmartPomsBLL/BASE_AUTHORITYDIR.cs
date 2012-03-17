

namespace SmartPoms.BLL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartPoms;

    public class BASE_AUTHORITYDIR {
        private readonly SQLServerDAL.BASE_AUTHORITYDIR dal = new SQLServerDAL.BASE_AUTHORITYDIR();

        /// <summary>
        /// 判断权限标识否存在
        /// </summary>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public bool Exists(string AuthorityTag) {
            return dal.Exists(AuthorityTag);
        }

        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool CreateAuthority(Entity.BASE_AUTHORITYDIR model) {
            return dal.CreateAuthority(model);
        }

        /// <summary>
        /// 更新指定的权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool UpdateAuthority(Entity.BASE_AUTHORITYDIR model) {
            return dal.UpdateAuthority(model);
        }

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int AuthorityID) {
            return dal.DeleteAuthority(AuthorityID);
        }

        /// <summary>
        /// 得到一个权限实体
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public Entity.BASE_AUTHORITYDIR GetAuthorityModel(int AuthorityID) {
            return dal.GetAuthorityModel(AuthorityID);
        }

        /// <summary>
        /// 获得权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(string strWhere, string strOrder) {
            return dal.GetAuthorityList(strWhere, strOrder);
        }
    }
}
