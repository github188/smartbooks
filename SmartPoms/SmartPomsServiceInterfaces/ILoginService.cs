
namespace SmartPoms.ServiceInterfaces {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SmartPoms.Entity;

    /// <summary>
    /// 登录服务接口定义
    /// </summary>
    public interface ILoginService : IService {
        BASE_USER Login(BASE_USER entity);

        void UpdateLoginTime(BASE_USER entity);

        void RegisterUser(BASE_USER entity);
    }
}
