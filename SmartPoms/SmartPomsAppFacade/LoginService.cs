

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

        public bool CheckLogin(string UserName, string pwd) {
            return userDal.CheckLogin(UserName, pwd);
        }

        public void UpdateLoginTime(int userid) {
            userDal.UpdateLoginTime(userid);
        }

        public void RegisterUser(Entity.BASE_USER entity) {
            userDal.Add(entity);
        }

        public Entity.BASE_USER GetUserEntity(string UserName){
            return userDal.GetUserModel(UserName);
        }

        public string Description {
            get { return "实现用户登录和注册服务接口"; }
        }
    }
}
