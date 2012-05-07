

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
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode) {
            //校验开始、结束时间
            
            return dal.GetDeptLog(beginTime, endTime, deptCode);
        }

        public void Add(Entity.BASE_PATROL model) {
            dal.Add(model);
        }
    }
}
