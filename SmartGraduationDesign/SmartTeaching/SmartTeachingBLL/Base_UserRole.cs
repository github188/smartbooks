using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_UserRole
    public partial class Base_UserRole
    {

        private readonly SmartTeaching.DAL.Base_UserRole dal = new SmartTeaching.DAL.Base_UserRole();
        public Base_UserRole()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserRoleId)
        {
            return dal.Exists(UserRoleId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(SmartTeaching.Entity.Base_UserRole model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_UserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserRoleId)
        {

            return dal.Delete(UserRoleId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_UserRole GetModel(int UserRoleId)
        {

            return dal.GetModel(UserRoleId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_UserRole GetModelByCache(int UserRoleId)
        {

            string CacheKey = "Base_UserRoleModel-" + UserRoleId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserRoleId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_UserRole)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_UserRole> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_UserRole> modelList = new List<SmartTeaching.Entity.Base_UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_UserRole model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_UserRole();
                    if (dt.Rows[n]["UserRoleId"].ToString() != "")
                    {
                        model.UserRoleId = int.Parse(dt.Rows[n]["UserRoleId"].ToString());
                    }
                    if (dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
                    if (dt.Rows[n]["RoleId"].ToString() != "")
                    {
                        model.RoleId = int.Parse(dt.Rows[n]["RoleId"].ToString());
                    }
                    if (dt.Rows[n]["NewsTypeId"].ToString() != "")
                    {
                        model.NewsTypeId = int.Parse(dt.Rows[n]["NewsTypeId"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}