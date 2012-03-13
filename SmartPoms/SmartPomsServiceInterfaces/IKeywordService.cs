
namespace SmartPoms.ServiceInterfaces {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using Entity;

    public interface IKeywordService : IService{
        /// <summary>
        /// 获取全部关键字
        /// </summary>
         DataTable getAllWord();

         /// <summary>
         /// 获取专题关键字
         /// </summary>
         /// <param name="topicId">专题Id</param>
         DataTable getTopicKeywords(int topicId);
    }
}
