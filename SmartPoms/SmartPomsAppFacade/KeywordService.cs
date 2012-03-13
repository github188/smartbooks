
namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using ServiceInterfaces;

    public class KeywordService : IKeywordService {
        SQLServerDAL.BASE_WORD wordDal = new SQLServerDAL.BASE_WORD();

        public DataTable getAllWord() {
            return wordDal.GetList("").Tables[0];
        }

        /// <summary>
        /// 获取专题关键字
        /// </summary>
        /// <param name="topicId">专题Id</param>
        public DataTable getTopicKeywords(int topicId) {
            return wordDal.GetList(string.Format("topicid like '%{0}%'", topicId.ToString())).Tables[0];
        }

        public string Description {
            get { return "提供关键字服务"; }
        }
    }
}
