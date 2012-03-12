
namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using ServiceInterfaces;
    using Entity;

    /// <summary>
    /// 用户登录服务
    /// </summary>
    public class LoginService :ILoginService {
        private SQLServerDAL.BASE_USER userDal = new SQLServerDAL.BASE_USER();

        /// <summary>
        /// 服务描述
        /// </summary>
        public string Description {
            get { return "提供用户登录和注册服务"; }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public bool update(SmartPoms.Entity.BASE_USER entity) {
            return userDal.Update(entity);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public bool addUser(SmartPoms.Entity.BASE_USER entity) {
            if (userDal.Add(entity) != 0) {
                return true;
            } else {
                return false;
            }            
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public bool delete(SmartPoms.Entity.BASE_USER entity) {
            return userDal.Delete(entity.USERID);
        }

        /// <summary>
        /// 获取用户实体
        /// </summary>
        /// <param name="userId">用户ID</param>
        public SmartPoms.Entity.BASE_USER getUser(int userId) {
            return userDal.GetEntity(userId);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        public SmartPoms.Entity.BASE_USER login(string userName, string pwd) {
            DataSet ds = new DataSet();
            ds = userDal.GetList(string.Format("USERNAME='{0}' AND USERPWD='{1}'", userName, pwd));
            if (ds.Tables[0].Rows.Count == 1) {
                int uid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                return userDal.GetEntity(uid);
            }
            return null;
        }
    }
}
