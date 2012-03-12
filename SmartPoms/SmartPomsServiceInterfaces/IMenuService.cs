

namespace SmartPoms.ServiceInterfaces {
    using Entity;
    using System.Collections.Generic;

    /// <summary>
    /// 菜单服务接口定义
    /// </summary>
    public interface IMenuService :IService {
        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="roleId">用户菜单ID编号</param>
        List<BASE_ROLE> GetUserMenu(List<int> roleId);

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="entity">菜单实体</param>
        bool Add(BASE_ROLE entity);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="entity">菜单实体</param>
        bool Delete(BASE_ROLE entity);

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="entity">菜单实体</param>
        bool update(BASE_ROLE entity);
    }
}
