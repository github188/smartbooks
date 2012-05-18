using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SmartHyd.BLL {
    public class BASE_ARTICLE {
        OracleDAL.BASE_ARTICLE dal = new OracleDAL.BASE_ARTICLE();

        /// <summary>
        /// 根据Id获取发文和回复详细信息
        /// </summary>
        /// <param name="articleId">发文ID</param>
        /// <returns></returns>
        public DataTable GetArticle(int articleId) {
            return dal.GetArticle(articleId);
        }

        public DataTable GetArticleDept(int dptCode, int typeCode, int stateCode) {
            return dal.GetArticleDept(dptCode, typeCode, stateCode);
        }
    }
}
