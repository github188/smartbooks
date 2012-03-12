

namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using ServiceInterfaces;

    /// <summary>
    /// 菜单服务接口
    /// </summary>
    public class MenuService : IMenuService {
        private SQLServerDAL.BASE_ROLE role = new SQLServerDAL.BASE_ROLE();

        public List<Entity.BASE_ROLE> GetUserMenu(List<int> roleId) {
            List<Entity.BASE_ROLE> r = new List<Entity.BASE_ROLE>();
            foreach (int id in roleId) {
                r.Add(role.GetEntity(id));
            }
            return r;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="entity">菜单实体</param>
        /// <returns></returns>
        public bool Add(Entity.BASE_ROLE entity) {
            if (role.Add(entity) == 0) {
                return false;
            } else {
                return true;
            }
        }

        public bool Delete(Entity.BASE_ROLE entity) {
            return role.Delete(entity.ROLEID);
        }

        public bool update(Entity.BASE_ROLE entity) {
            return role.Update(entity);
        }

        /// <summary>
        /// 服务描述
        /// </summary>
        public string Description {
            get { return "提供菜单服务"; }
        }
    }
}
