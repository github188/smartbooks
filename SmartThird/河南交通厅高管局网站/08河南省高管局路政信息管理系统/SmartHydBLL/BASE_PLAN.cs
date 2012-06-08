using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL
{
    public class BASE_PLAN
    {
        private OracleDAL.BASE_PLAN dal = new OracleDAL.BASE_PLAN();

        /// <summary>
        /// 获取日程信息列表
        /// </summary>
        /// <param name="strwhere">获取日程信息的条件</param>
        /// <returns>日程信息数据</returns>

        public DataTable GetPlanList(string strwhere)
        {
            //
            DataSet ds = dal.GetList(strwhere);
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取事务实体数据
        /// </summary>
        /// <param name="Planid"></param>
        /// <returns></returns>
        public Entity.BASE_PLAN GetModel(decimal Planid)
        {
            return dal.GetEntity(Planid);
        }
        /// <summary>
        /// 新建日程信息
        /// </summary>
        /// <param name="model">日程信息实体</param>
        public void Add(Entity.BASE_PLAN model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 确定记录是否存在
        /// </summary>
        /// <param name="FTID"></param>
        /// <returns></returns>
        public bool Exists(decimal CALENDARID)
        {
            if (dal.Exists(CALENDARID))
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
        public bool update(Entity.BASE_PLAN model)
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
        /// 删除指定编号事务数据
        /// </summary>
        /// <param name="CALENDARID"></param>
        /// <returns></returns>
        public bool del(decimal CALENDARID)
        {
            return dal.Delete(CALENDARID);
        }
    }
}
