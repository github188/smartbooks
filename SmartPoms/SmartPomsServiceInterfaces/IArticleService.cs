
namespace SmartPoms.ServiceInterfaces {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;

    public interface IArticleService : IService {
        /// <summary>
        /// 获取指定分类下文章
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="eventId">分类编号</param>
        DataTable GetEventArticle(string beginDate, string endDate, int eventId);
    }
}
