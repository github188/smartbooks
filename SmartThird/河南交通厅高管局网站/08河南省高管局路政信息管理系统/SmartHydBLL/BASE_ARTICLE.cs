using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ARTICLE {
        OracleDAL.BASE_ARTICLE dal = new OracleDAL.BASE_ARTICLE();

        public DataTable GetList(string where) {
            return dal.GetList(where).Tables[0];
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体</param>
        public void Add(Entity.BASE_ARTICLE model) {
            dal.Add(model);
        }

        public DataTable GetReplyList(int sendId) {
            return dal.GetReplyList(sendId);
        }
        public DataTable GetDetail(int id) {
            return dal.GetDetail(id);
        }
        public DataTable GetPublishList(int depCode, int typeCode) {
            return dal.GetPublishList(depCode, typeCode);
        }
    }
}
