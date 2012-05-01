using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using SmartTeaching.Entity;
namespace SmartTeaching.BLL
{
    //Base_BBS
    public partial class Base_BBS
    {

        private readonly SmartTeaching.DAL.Base_BBS dal = new SmartTeaching.DAL.Base_BBS();
        public Base_BBS()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SmartTeaching.Entity.Base_BBS model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SmartTeaching.Entity.Base_BBS model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SmartTeaching.Entity.Base_BBS GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public SmartTeaching.Entity.Base_BBS GetModelByCache(int ID)
        {

            string CacheKey = "Base_BBSModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (SmartTeaching.Entity.Base_BBS)objModel;
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
        public List<SmartTeaching.Entity.Base_BBS> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SmartTeaching.Entity.Base_BBS> DataTableToList(DataTable dt)
        {
            List<SmartTeaching.Entity.Base_BBS> modelList = new List<SmartTeaching.Entity.Base_BBS>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SmartTeaching.Entity.Base_BBS model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SmartTeaching.Entity.Base_BBS();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
                    if (dt.Rows[n]["ToUserId"].ToString() != "")
                    {
                        model.ToUserId = int.Parse(dt.Rows[n]["ToUserId"].ToString());
                    }
                    if (dt.Rows[n]["NewsId"].ToString() != "")
                    {
                        model.NewsId = int.Parse(dt.Rows[n]["NewsId"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    model.NewsContent = dt.Rows[n]["NewsContent"].ToString();


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