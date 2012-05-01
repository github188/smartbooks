using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_Role
    public partial class Base_Role
    {

        private readonly SmartTeaching.DAL.Base_Role dal = new SmartTeaching.DAL.Base_Role();
        public Base_Role()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleId)
        {
            return dal.Exists(RoleId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_Role model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleId)
        {

            return dal.Delete(RoleId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string RoleIdlist)
        {
            return dal.DeleteList(RoleIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_Role GetModel(int RoleId)
        {

            return dal.GetModel(RoleId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_Role GetModelByCache(int RoleId)
        {

            string CacheKey = "Base_RoleModel-" + RoleId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(RoleId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_Role)objModel;
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
        public List<SmartTeaching.Entity.Base_Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_Role> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_Role> modelList = new List<SmartTeaching.Entity.Base_Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_Role model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_Role();
                    if (dt.Rows[n]["RoleId"].ToString() != "")
                    {
                        model.RoleId = int.Parse(dt.Rows[n]["RoleId"].ToString());
                    }
                    model.RoleName = dt.Rows[n]["RoleName"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();


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