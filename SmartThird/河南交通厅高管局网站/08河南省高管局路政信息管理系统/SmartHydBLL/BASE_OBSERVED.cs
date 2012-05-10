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
        public DataTable GetDeptLog(DateTime beginTime, DateTime endTime, int deptCode) {
            return dal.GetDeptLog(beginTime, endTime, deptCode);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void Add(Entity.BASE_OBSERVED model) {
            dal.Add(model);
        }
    }
}
