using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_FILETYPE
    {
        private OracleDAL.BASE_FILETYPE dal = new OracleDAL.BASE_FILETYPE();

        /// <summary>
        /// 获取公文类型列表
        /// </summary>
        /// <param name="strwhere">获取公文数据的条件</param>
        /// <returns>公文数据</returns>

        public DataTable GetFileTypeList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 新建公文类型
        /// </summary>
        /// <param name="model">公文类型实体</param>
        public void Add(Entity.BASE_FILETYPE model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal FTID)
        {
            if(dal.Exists(FTID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_FILETYPE model)
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
