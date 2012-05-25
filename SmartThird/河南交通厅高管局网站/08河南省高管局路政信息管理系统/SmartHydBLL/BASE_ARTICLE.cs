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
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity.BASE_ARTICLE GetEntity(int id) {
            return dal.GetEntity(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体</param>
        public void Add(Entity.BASE_ARTICLE model) {
            dal.Add(model);
        }

        /// <summary>
        /// Get reply list data.
        /// </summary>
        /// <param name="sendId">publish article id number.</param>
        /// <returns>search date result.</returns>
        public DataTable GetReplyList(int sendId) {
            return dal.GetReplyList(sendId);
        }

        /// <summary>
        /// get a article detail content.
        /// </summary>
        /// <param name="id">primary id</param>
        /// <returns>return a</returns>
        public DataTable GetDetail(int id) {
            return dal.GetDetail(id);
        }

        /// <summary>
        /// get this is department class list data.
        /// </summary>
        /// <param name="depCode">department code</param>
        /// <param name="typeCode">department class code.</param>
        /// <returns>return datatable result list.</returns>
        public DataTable GetPublishList(int depCode, int typeCode) {
            return dal.GetPublishList(depCode, typeCode);
        }

        /// <summary>
        /// checkout operation
        /// </summary>
        /// <param name="dictionary">key=id,value=score</param>
        public void CheckOut(Dictionary<int, int> dictionary) {
            dal.CheckOut(dictionary);
        }

        /// <summary>
        /// update this is aricle state.
        /// </summary>
        /// <param name="state">0已审核，1未审核，2草稿，3已删除，4隐藏，5结贴</param>
        /// <param name="id">primary id</param>
        public void UpdateState(int state, int id) {
            dal.UpdateState(state, id);
        }
    }
}
