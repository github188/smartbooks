

namespace SmartPoms.ServiceInterfaces {
    using Entity;

    /// <summary>
    /// 用户登录服务
    /// </summary>
    public interface ILoginService : IService {
        /// <summary>
        /// 服务描述
        /// </summary>
        string Description {
            get;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        /// <param name="entity">密码</param>
        /// <returns>true登录成功,false登录失败</returns>
        bool update(BASE_USER entity);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        bool addUser(BASE_USER entity);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        /// <returns>true删除成功，false删除失败</returns>
        bool delete(BASE_USER entity);

        /// <summary>
        /// 获取用户实体
        /// </summary>
        BASE_USER getUser(int userId);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        SmartPoms.Entity.BASE_USER login(string userName, string pwd);
    }
}
