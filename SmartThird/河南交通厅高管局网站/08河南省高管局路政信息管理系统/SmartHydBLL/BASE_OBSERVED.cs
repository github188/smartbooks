using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_OBSERVED {
        private OracleDAL.BASE_OBSERVED dal = new OracleDAL.BASE_OBSERVED();
        
        /// <summary>
        /// 根据指定时间范围，获取某个部门下的电子巡逻日志数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">部门ID</param>
        /// <returns>电子巡逻日志数据</returns>
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode,int state) {
            return null;//dal.GetDeptLog(beginTime, endTime, deptCode, state);
        }
        /// <summary>
        /// 根据指定条件，获取部门下电子巡逻日志数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetLogObserved(string strwhere)
        {
            return dal.GetLogObserved(strwhere);
        }
        /// <summary>
        /// 获取电子巡逻日志实体
        /// </summary>
        /// <param name="observedid"></param>
        /// <returns></returns>
        public Entity.BASE_OBSERVED GetModel(decimal observedid)
        {
            return dal.GetEntity(observedid);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public int Add(Entity.BASE_OBSERVED model) {
           return dal.Add(model);
        }
        /// <summary>
        /// 根据条件获取巡逻日志
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetObserved(string strwhere)
        {
            return dal.GetList(strwhere).Tables[0];
        }
        /// <summary>
        /// 更新一条人工巡逻日志信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_OBSERVED model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 根据日志编号删除
        /// </summary>
        /// <param name="patrol"></param>
        /// <returns></returns>
        public bool del(decimal patrolid)
        {
            return dal.Delete(patrolid);
        }
    }
}
