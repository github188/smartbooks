

namespace SmartPoms.BLL {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Collections;

    public class BASE_MODULE {
        private readonly SQLServerDAL.BASE_MODULE dal = new SQLServerDAL.BASE_MODULE();


        #region 模块分类

        /// <summary>
        /// 判断模块分类是否存在
        /// </summary>
        /// <param name="ModuleTypeName">模块分类名称</param>
        /// <returns></returns>
        public bool ModuleTypeExists(string ModuleTypeName)
        {
            return dal.ModuleTypeExists(ModuleTypeName);
        }

        /// <summary>
        /// 增加一个模块分类
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        public int CreateModuleType(Entity.BASE_MODULETYPE model)
        {
            if (!ModuleTypeExists(model.ModuleTypeName))
                return dal.CreateModuleType(model);
            else
                return 2;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">模块分类实体类</param>
        /// <returns></returns>
        public bool UpdateModuleType(Entity.BASE_MODULETYPE model)
        {
            return dal.UpdateModuleType(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        public int DeleteModuleType(int ModuleTypeID)
        {
            return dal.DeleteModuleType(ModuleTypeID);
        }

        /// <summary>
        /// 得到一个模块分类实体
        /// </summary>
        /// <param name="ModuleTypeID">模块分类ID</param>
        /// <returns></returns>
        public Entity.BASE_MODULETYPE GetModuleTypeModel(int ModuleTypeID)
        {
            return dal.GetModuleTypeModel(ModuleTypeID);
        }

        /// <summary>
        /// 获得模块分类数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleTypeList(string strWhere)
        {
            return dal.GetModuleTypeList(strWhere);
        }

        #endregion

        #region 模块操作
        /// <summary>
        /// 判断模块是否存在
        /// </summary>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        public bool ModuleExists(string ModuleTag)
        {
            return dal.ModuleExists(ModuleTag);
        }

        /// <summary>
        /// 更新时判断模块是否存在
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="ModuleName">模块名称</param>
        /// <returns></returns>
        public bool UpdateExists(int ModuleID, string ModuleTag)
        {
            return dal.UpdateExists(ModuleID, ModuleTag);
        }

        /// <summary>
        /// 增加一个模块
        /// </summary>
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        public int CreateModule(Entity.BASE_MODULE model)
        {
            if (!ModuleExists(model.ModuleTag))
            {
                return dal.CreateModule(model);
            }
            else
                return 2;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">模块实体类</param>
        /// <returns></returns>
        public int UpdateModule(Entity.BASE_MODULE model)
        {
            if (!UpdateExists(model.ModuleID, model.ModuleTag))
            {
                return dal.UpdateModule(model);
            }
            else
                return 2;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public bool DeleteModule(int ModuleID)
        {
            return dal.DeleteModule(ModuleID);
        }

        /// <summary>
        /// 得到一个模块实体
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public Entity.BASE_MODULE GetModuleModel(int ModuleID)
        {
            return dal.GetModuleModel(ModuleID);
        }

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleList(string strWhere)
        {
            return dal.GetModuleList(strWhere);
        }

        /// <summary>
        /// 获得模块数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetModuleList2(string strWhere)
        {
            return dal.GetModuleList2(strWhere);
        }

        /// <summary>
        /// 获取模块ID
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        public int GetModuleID(string ModuleTag)
        {
            return dal.GetModuleID(ModuleTag);
        }

        /// <summary>
        /// 模块是否关闭
        /// </summary>
        /// <param name="ModuleTag">模块标识</param>
        /// <returns></returns>
        public bool IsModule(string ModuleTag)
        {
            return dal.IsModule(ModuleTag);
        }

        #endregion

        #region 模块授权

        /// <summary>
        /// 增加模块权限
        /// </summary>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        public bool CreateAuthorityList(ArrayList list)
        {
            return dal.CreateAuthorityList(list);
        }

        /// <summary>
        /// 更新模块权限
        /// </summary>
        public bool UpdateAuthorityList(ArrayList list)
        {
            return dal.UpdateAuthorityList(list);
        }

        /// <summary>
        /// 删除指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int ModuleID)
        {
            return dal.DeleteAuthority(ModuleID);
        }

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int ModuleID)
        {
            return dal.GetAuthorityList(ModuleID);
        }

        /// <summary>
        /// 获得指定模块的权限列表
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityNameList(int ModuleID)
        {
            return dal.GetAuthorityNameList(ModuleID);
        }

        #endregion
    }
}
