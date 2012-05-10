using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_SHOUWEN
    {
        private OracleDAL.BASE_SHOUWEN dal = new OracleDAL.BASE_SHOUWEN();

        /// <summary>
        /// 获取收文列表
        /// </summary>
        /// <param name="strwhere">获取收文数据的条件</param>
        /// <returns>收文数据</returns>

        public DataTable GetShouWenList(string strwhere)
        {

            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 新建公文
        /// </summary>
        /// <param name="model">公文实体</param>
        public void Add(Entity.BASE_SHOUWEN model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal SID)
        {
            if (dal.Exists(SID))
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
        public bool update(Entity.BASE_SHOUWEN model)
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
