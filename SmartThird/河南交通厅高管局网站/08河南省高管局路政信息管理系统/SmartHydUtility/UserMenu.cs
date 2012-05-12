using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHyd.Utility {
    public class UserMenu : Entity.BASE_MENU {
        private List<Entity.BASE_ACTION> _UserAction = new List<Entity.BASE_ACTION>();

        /// <summary>
        /// 用户操作权限集合
        /// </summary>
        public List<Entity.BASE_ACTION> UserAction {
            get {
                return _UserAction;
            }
            set {
                _UserAction = value;
            }
        }
    }
}
