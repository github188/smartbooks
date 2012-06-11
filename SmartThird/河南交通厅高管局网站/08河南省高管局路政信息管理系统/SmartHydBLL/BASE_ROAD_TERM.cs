using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ROAD_TERM {
        private OracleDAL.BASE_ROAD_TERM dal = new OracleDAL.BASE_ROAD_TERM();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">路产路产设备</param>
        public void Add(Entity.BASE_ROAD_TERM model) {
            dal.Add(model);
        }

        /// <summary>
        /// 获取部门下路产设备
        /// </summary>
        /// <param name="deptCode">部门编号</param>
        /// <returns></returns>
        public DataTable GetDepartmentRoad(int deptCode) {
            string where = string.Format("DEPTID={0} and STATUS=0", deptCode.ToString());

            return dal.GetList(where).Tables[0];
        }

        public DataTable GetDepartmentRoad(DateTime beginTime, DateTime endTime, int typeCode, int deptCode) {
            string where = string.Format("DEPTID={0} and STATUS=0 and TYPEID={1} and REGTIME>=to_date('{2}','yyyy-mm-dd') and REGTIME<=to_date('{3}','yyyy-mm-dd')",
                deptCode.ToString(),
                typeCode.ToString(),
                beginTime.ToString("yyyy-MM-dd"),
                endTime.ToString("yyyy-MM-dd"));
            return dal.GetList(where).Tables[0];
        }
    }
}
