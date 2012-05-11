using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_FAWEN
    {
        private OracleDAL.BASE_FAWEN dal = new OracleDAL.BASE_FAWEN();

       /// <summary>
        /// 获取公文列表
       /// </summary>
       /// <param name="strwhere">获取公文数据的条件</param>
        /// <returns>公文数据</returns>
       
        public DataTable GetFaWenList(string strwhere)
        {
           
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 新建公文
        /// </summary>
        /// <param name="model">公文实体</param>
        public void Add(Entity.BASE_FAWEN model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal FID)
        {
            if (dal.Exists(FID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public Entity.BASE_FAWEN Getmodel(decimal FID)
        {
            return dal.GetEntity(FID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_FAWEN model)
        {
            if (dal.Update(model))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
