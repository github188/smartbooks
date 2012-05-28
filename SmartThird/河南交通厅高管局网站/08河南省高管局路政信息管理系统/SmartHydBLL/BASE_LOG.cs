using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_LOG
    {
        private OracleDAL.BASE_LOG dal = new OracleDAL.BASE_LOG();

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="strwhere">获取日志列表的条件</param>
        /// <returns>日志数据Table</returns>

        public DataTable GetList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model">日志实体</param>
        public void Add(Entity.BASE_LOG model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal LOGID)
        {
            if (dal.Exists(LOGID))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据LOGID获取日志实体数据
        /// </summary>
        /// <param name="LOGID">日志编号</param>
        /// <returns></returns>
        public Entity.BASE_LOG Getmodel(decimal LOGID)
        {
            return dal.GetEntity(LOGID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_LOG model)
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
        /// 删除日志数据
        /// </summary>
        /// <param name="LOGID"></param>
        /// <returns></returns>
        public bool Del(decimal LOGID)
        {
            return dal.Delete(LOGID);
        }
    }
}
