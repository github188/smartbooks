using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_AFFICHE
    {
        private OracleDAL.BASE_AFFICHE dal = new OracleDAL.BASE_AFFICHE();

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="strwhere">获取公告数据的条件</param>
        /// <returns>公告数据</returns>

        public DataTable GetAfficheList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 新建公告
        /// </summary>
        /// <param name="model">公告实体</param>
        public void Add(Entity.BASE_AFFICHE model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal AFFICHEID)
        {
            if (dal.Exists(AFFICHEID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据AFFICHEID获取公文实体数据
        /// </summary>
        /// <param name="AFFICHEID"></param>
        /// <returns></returns>
        public Entity.BASE_AFFICHE Getmodel(decimal AFFICHEID)
        {
            return dal.GetEntity(AFFICHEID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_AFFICHE model)
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
        /// <summary>
        /// 删除一条公告
        /// </summary>
        /// <param name="AFFICHEID"></param>
        /// <returns></returns>
        public bool del(decimal AFFICHEID)
        {
            if (dal.Delete(AFFICHEID))
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
