using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.Utility {
    public class UserRole : Entity.BASE_ROLE {
        private List<UserMenu> _userMenu = new List<UserMenu>();

        /// <summary>
        /// 当前角色下用户功能菜单集合
        /// </summary>
        public List<UserMenu> UserMenu {
            get {
                return _userMenu;
            }
            set {
                _userMenu = value;
            }
        }
    }
}
