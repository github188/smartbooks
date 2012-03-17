﻿

namespace SmartPoms.Code {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Value {
        static SQLServerDAL.BASE_CONFIGURATION config = new SQLServerDAL.BASE_CONFIGURATION();

        /// <summary>
        /// 注册时初始化权限
        /// </summary>
        public static int InitRoleID {
            get {
                string s = config.GetItemValue("InitRoleID");
                if (s != "") {
                    return int.Parse(s);
                } else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 注册时初始化用户组
        /// </summary>
        public static int initGroupID {
            get {
                string s = config.GetItemValue("initGroupID");
                if (s != "") {
                    return int.Parse(s);
                } else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 注册时是否启用审核，启用则不写入用户权限和用户组信息，审核时写入
        /// </summary>
        public static bool IsVerifyUser {
            get {
                bool ret = false;
                string s = config.GetItemValue("IsVerifyUser");
                if (s != "") {
                    if (s == "1")
                        ret = true;
                }

                return ret;
            }
        }
    }
}