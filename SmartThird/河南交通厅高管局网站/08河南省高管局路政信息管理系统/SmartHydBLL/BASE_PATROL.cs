

namespace SmartHyd.BLL {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;

    public class BASE_PATROL {
        private OracleDAL.BASE_PATROL dal = new OracleDAL.BASE_PATROL();

        /// <summary>
        /// 获取指定时间范围内某部门下日志
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptId">部门ID编号</param>
        /// <returns>日志数据</returns>
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode,int state) {
            //校验开始、结束时间

            return dal.GetDeptLog(beginTime, endTime, deptCode, state);
        }
        /// <summary>
        /// 确定该记录是否存在
        /// </summary>
        /// <param name="PATROLID"></param>
        /// <returns></returns>
        public bool Exists(decimal PATROLID)
        {
            return dal.Exists(PATROLID);
        }
        /// <summary>
        /// 根据条件获取巡逻日志
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetPatrol(string strwhere)
        {
            return dal.GetList(strwhere).Tables[0];
        }
        /// <summary>
        /// 获取人工巡逻日志信息实体
        /// </summary>
        /// <param name="PATROLID"></param>
        /// <returns></returns>
        public Entity.BASE_PATROL GetModel(decimal PATROLID)
        {
            return dal.GetEntity(PATROLID);
        }
        /// <summary>
        /// 添加一条人工巡逻日志信息
        /// </summary>
        /// <param name="model"></param>
        public int Add(Entity.BASE_PATROL model) {
           return dal.Add(model);
        }
        /// <summary>
        /// 更新一条人工巡逻日志信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_PATROL model)
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
