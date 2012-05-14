using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_LICENSE_ACCEPT
    {
        private OracleDAL.BASE_LICENSE_ACCEPT dal = new OracleDAL.BASE_LICENSE_ACCEPT();

        /// <summary>
        /// 获取申请单列表
        /// </summary>
        /// <param name="strwhere">获取申请单数据的条件</param>
        /// <returns>申请单列表</returns>

        public DataTable GetList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 涉路申请
        /// </summary>
        /// <param name="model">申请书实体</param>
        public void Add(Entity.BASE_LICENSE_ACCEPT model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal REQUISITIONID)
        {
            if (dal.Exists(REQUISITIONID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据REQUISITIONID获取申请单实体数据
        /// </summary>
        /// <param name="AFFICHEID"></param>
        /// <returns></returns>
        public Entity.BASE_LICENSE_ACCEPT Getmodel(decimal REQUISITIONID)
        {
            return dal.GetEntity(REQUISITIONID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_LICENSE_ACCEPT model)
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
