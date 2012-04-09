
namespace SmartPoms.Code {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System.Data;
    using System.Web;
    using System.Configuration;
    using SmartPoms;

    public class UserHandle {
        /// <summary>
        /// 初始化模块权限
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        public static void InitModule(string ModuleTag) {
            SQLServerDAL.BASE_MODULE bll = new SQLServerDAL.BASE_MODULE();
            SQLServerDAL.BASE_ROLE Rolebll = new SQLServerDAL.BASE_ROLE();

            //判断模块是否启用
            if (bll.IsModule(ModuleTag)) {
                if (!Code.SessionBox.GetUserSession().IsLimit) {
                    ArrayList Mlists = new ArrayList();//模块权限
                    ArrayList Ulists = new ArrayList();//用户的模块权限

                    //读取模块权限
                    int id = bll.GetModuleID(ModuleTag);
                    DataSet MALds = bll.GetAuthorityList(id);

                    for (int i = 0; i < MALds.Tables[0].Rows.Count; i++) {
                        Mlists.Add(MALds.Tables[0].Rows[i]["AuthorityTag"].ToString());
                    }
                    Code.SessionBox.RemoveModuleList();              //先清空Session中的列表
                    Code.SessionBox.CreateModuleList(Mlists);        //登记新的列表

                    #region 读取用户的所有权限

                    //读取用户角色拥有的该模块权限
                    if (ConfigurationManager.AppSettings["RoleGrant"].ToString().ToLower() == "true") {
                        ArrayList rid = Code.SessionBox.GetUserSession().RoleID;
                        for (int ri = 0; ri < rid.Count; ri++) {
                            DataSet RALds = Rolebll.GetRoleAuthorityList(int.Parse(rid[ri].ToString().Split(',')[0]), id);
                            for (int i = 0; i < RALds.Tables[0].Rows.Count; i++) {
                                if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString()))
                                    Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                            }
                        }
                    }

                    //读取用户分组拥有的该模块权限
                    //if (ConfigurationManager.AppSettings["GroupGrant"].ToString().ToLower() == "true")
                    //{
                    //    DataSet RALds = Rolebll.GetGroupAuthorityList(Code.SessionBox.GetUserSession().GroupID, id);
                    //    for (int i = 0; i < RALds.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString()))
                    //            Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                    //    }
                    //}

                    //读取用户拥有的该模块权限
                    if (ConfigurationManager.AppSettings["UserGrant"].ToString().ToLower() == "true") {
                        DataSet RALds = Rolebll.GetUserAuthorityList(Code.SessionBox.GetUserSession().LoginId, id);
                        for (int i = 0; i < RALds.Tables[0].Rows.Count; i++) {
                            if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString())) {
                                if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() == "true") {
                                    Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                                }
                            } else {
                                if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() != "true") {
                                    Ulists.Remove(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                                }
                            }
                        }
                    }

                    #endregion

                    Code.SessionBox.RemoveAuthority();
                    Code.SessionBox.CreateAuthority(Ulists);
                }
            } else {
                throw new Exception("此功能不存在");
            }

        }

        /// <summary>
        /// 校验用户是否对模块有该权限
        /// </summary>
        /// <param name="tag">权限标识</param>
        /// <returns></returns>
        public static bool ValidationHandle(string ModuleTag) {
            bool ret = false;
            if (!Code.SessionBox.GetUserSession().IsLimit) //判断用户是否授权限限制
            {
                ArrayList Mlist = Code.SessionBox.GetModuleList();
                ArrayList Ulist = Code.SessionBox.GetAuthority();

                for (int i = 0; i < Mlist.Count; i++) {
                    if (Mlist[i].ToString().ToLower() == ModuleTag.ToLower())//是否在模块存在
                    {
                        for (int j = 0; j < Ulist.Count; j++) {
                            if (Ulist[j].ToString().ToLower() == ModuleTag.ToLower())//是否在用户权限表中
                            {
                                ret = true;
                            }
                        }
                    }
                }
            } else {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 判断是否有模块访问权限
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public static bool ValidationModule(int ModuleID, string AuthorityTag) {
            bool ret = false;
            SQLServerDAL.BASE_ROLE bll = new SQLServerDAL.BASE_ROLE();
            Entity.BASE_ROLEAUTHORITYLIST model = new Entity.BASE_ROLEAUTHORITYLIST();
            ArrayList rid = Code.SessionBox.GetUserSession().RoleID;
            for (int ri = 0; ri < rid.Count; ri++) {
                model.UserID = 0;
                model.RoleID = int.Parse(rid[ri].ToString().Split(',')[0]);
                model.ModuleID = ModuleID;
                model.AuthorityTag = AuthorityTag;
                if (bll.RoleAuthorityExists(model)) {
                    //只要有一个角色有操作权限都会返回真
                    ret = true;
                    break;
                }
            }

            //读取用户拥有的该模块权限
            if (ConfigurationManager.AppSettings["UserGrant"].ToString().ToLower() == "true") {
                DataSet RALds = bll.GetUserAuthorityList(Code.SessionBox.GetUserSession().LoginId, ModuleID);
                for (int i = 0; i < RALds.Tables[0].Rows.Count; i++) {
                    //判断模块的浏览权限
                    if (RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToUpper() == "BROWSE") {
                        if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() == "true")//允许查看
                        {
                            ret = true;
                            break;
                        } else if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() != "true")//禁止收查看
                        {
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 返回对应的状态字符串
        /// </summary>
        /// <param name="n">状态标识</param>
        /// <returns></returns>
        public static string ReturnState(int n) {
            string ret = "";
            switch (n) {
                case 0:
                    ret = "禁止登录";
                    break;
                case 1:
                    ret = "允许登录";
                    break;
                case 2:
                    ret = "锁定";
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 检测标识在列表中是否存在
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ModuleTag"></param>
        /// <returns></returns>
        public static bool ModuleTagExists(ArrayList list, string ModuleTag) {
            bool ret = false;
            for (int i = 0; i < list.Count; i++) {
                if (ModuleTag.ToLower() == list[i].ToString().ToLower()) {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}