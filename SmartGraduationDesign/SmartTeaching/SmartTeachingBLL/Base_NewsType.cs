using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_NewsType
    public partial class Base_NewsType
    {

        private readonly SmartTeaching.DAL.Base_NewsType dal = new SmartTeaching.DAL.Base_NewsType();
        public Base_NewsType()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NewsTypeId)
        {
            return dal.Exists(NewsTypeId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_NewsType model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_NewsType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NewsTypeId)
        {

            return dal.Delete(NewsTypeId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string NewsTypeIdlist)
        {
            return dal.DeleteList(NewsTypeIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_NewsType GetModel(int NewsTypeId)
        {

            return dal.GetModel(NewsTypeId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_NewsType GetModelByCache(int NewsTypeId)
        {

            string CacheKey = "Base_NewsTypeModel-" + NewsTypeId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(NewsTypeId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_NewsType)objModel;
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
        public List<SmartTeaching.Entity.Base_NewsType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_NewsType> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_NewsType> modelList = new List<SmartTeaching.Entity.Base_NewsType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_NewsType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_NewsType();
                    if (dt.Rows[n]["NewsTypeId"].ToString() != "")
                    {
                        model.NewsTypeId = int.Parse(dt.Rows[n]["NewsTypeId"].ToString());
                    }
                    model.NewsTypeName = dt.Rows[n]["NewsTypeName"].ToString();
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    if (dt.Rows[n]["ParentId"].ToString() != "")
                    {
                        model.ParentId = int.Parse(dt.Rows[n]["ParentId"].ToString());
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