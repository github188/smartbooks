

namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using SmartPoms.ServiceInterfaces;
    using e = SmartPoms.Entity;
    using d = SmartPoms.SQLServerDAL;

    public class LoginService :ILoginService {
        d.BASE_USER userDal = new d.BASE_USER();

        public Entity.BASE_USER Login(Entity.BASE_USER entity) {
            DataTable dt = userDal.GetList(string.Format("UserName='{0}' AND Password='{1}'", 
                entity.UserName, entity.Password)).Tables[0];
            if (dt != null && dt.Rows.Count != 0) {
                return userDal.GetEntity(Convert.ToInt32(dt.Rows[0]["UserID"].ToString()));
            }
            return null;
        }

        public void UpdateLoginTime(Entity.BASE_USER entity) {
            entity.LastLoginTime = DateTime.Now;
            userDal.Update(entity);
        }

        public void RegisterUser(Entity.BASE_USER entity) {
            userDal.Add(entity);
        }

        public string Description {
            get { return "实现用户登录和注册服务接口"; }
        }
    }
}
