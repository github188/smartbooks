
namespace SmartPoms.ServiceInterfaces {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SmartPoms.Entity;

    /// <summary>
    /// 登录服务接口定义
    /// </summary>
    public interface ILoginService : IService {
        bool CheckLogin(string UserName, string pwd);

        void UpdateLoginTime(int userid);

        void RegisterUser(BASE_USER entity);

        Entity.BASE_USER GetUserEntity(string UserName);
    }
}
