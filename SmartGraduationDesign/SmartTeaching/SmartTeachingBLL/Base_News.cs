using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_News
    public partial class Base_News
    {

        private readonly SmartTeaching.DAL.Base_News dal = new SmartTeaching.DAL.Base_News();
        public Base_News()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NewsId)
        {
            return dal.Exists(NewsId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_News model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_News model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NewsId)
        {

            return dal.Delete(NewsId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string NewsIdlist)
        {
            return dal.DeleteList(NewsIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_News GetModel(int NewsId)
        {

            return dal.GetModel(NewsId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_News GetModelByCache(int NewsId)
        {

            string CacheKey = "Base_NewsModel-" + NewsId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(NewsId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_News)objModel;
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
        public List<SmartTeaching.Entity.Base_News> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_News> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_News> modelList = new List<SmartTeaching.Entity.Base_News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_News();
                    if (dt.Rows[n]["NewsId"].ToString() != "")
                    {
                        model.NewsId = int.Parse(dt.Rows[n]["NewsId"].ToString());
                    }
                    if (dt.Rows[n]["NewsTypeId"].ToString() != "")
                    {
                        model.NewsTypeId = int.Parse(dt.Rows[n]["NewsTypeId"].ToString());
                    }
                    if (dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
                    model.NewsTitle = dt.Rows[n]["NewsTitle"].ToString();
                    model.NewsContent = dt.Rows[n]["NewsContent"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    model.Summary = dt.Rows[n]["Summary"].ToString();
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    if (dt.Rows[n]["FileSize"].ToString() != "")
                    {
                        model.FileSize = int.Parse(dt.Rows[n]["FileSize"].ToString());
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