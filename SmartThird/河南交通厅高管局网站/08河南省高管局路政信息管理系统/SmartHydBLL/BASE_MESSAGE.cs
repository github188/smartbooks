using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_MESSAGE {
        private OracleDAL.BASE_MESSAGE Dal = new OracleDAL.BASE_MESSAGE();

        public bool Exists(decimal MESSAGEID) {
            return Dal.Exists(MESSAGEID);
        }
        public Entity.BASE_MESSAGE GetEntity(int MESSAGEID) {
            return Dal.GetEntity(MESSAGEID);
        }
        /// <summary>
        /// 存储消息
        /// </summary>
        /// <param name="model"></param>
        public void Add(Entity.BASE_MESSAGE model) {
            Dal.Add(model);
        }
        /// <summary>
        /// 根据条件获取消息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere) {
            return Dal.GetList(strWhere).Tables[0];
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool update(Entity.BASE_MESSAGE model) {
            return Dal.Update(model);
        }
        /// <summary>
        /// 根据消息编号删除数据
        /// </summary>
        /// <param name="MESSAGEID"></param>
        /// <returns></returns>
        public bool del(decimal MESSAGEID) {
            return Dal.Delete(MESSAGEID);
        }

        /// <summary>
        /// 获取我的消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetMyMessage(int uid) {
            return Dal.GetMyMessage(uid);
        }
    }
}
