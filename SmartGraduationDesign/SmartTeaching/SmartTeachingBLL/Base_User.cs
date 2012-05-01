using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_User
    public partial class Base_User
    {

        private readonly SmartTeaching.DAL.Base_User dal = new SmartTeaching.DAL.Base_User();
        public Base_User()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            return dal.Exists(UserId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_User model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId)
        {

            return dal.Delete(UserId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string UserIdlist)
        {
            return dal.DeleteList(UserIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_User GetModel(int UserId)
        {

            return dal.GetModel(UserId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_User GetModelByCache(int UserId)
        {

            string CacheKey = "Base_UserModel-" + UserId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_User)objModel;
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
        public List<SmartTeaching.Entity.Base_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_User> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_User> modelList = new List<SmartTeaching.Entity.Base_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_User();
                    if (dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Userpwd = dt.Rows[n]["Userpwd"].ToString();


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