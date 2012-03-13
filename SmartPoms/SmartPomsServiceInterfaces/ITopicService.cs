
namespace SmartPoms.ServiceInterfaces {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Entity;

    /// <summary>
    /// 专题服务接口定义
    /// </summary>
    public interface ITopicService : IService {
        /// <summary>
        /// 添加专题
        /// </summary>
        /// <param name="entity">实体</param>
        bool add(BASE_TOPIC entity);

        /// <summary>
        /// 删除专题
        /// </summary>
        /// <param name="topicId">专题编号</param>
        bool delete(int topicId);

        /// <summary>
        /// 修改专题
        /// </summary>
        /// <param name="entity">实体</param>
        bool update(BASE_TOPIC entity);

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="rootId">父分类ID</param>
        /// <param name="recursive">递归获取子分类</param>
        List<BASE_TOPIC> getSubtopic(int rootId, bool recursive);

        /// <summary>
        /// 获取分类下文章
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="pageCount">每页记录条数</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="topicid">专题编号</param>
        System.Data.DataTable getArticle(int pageNo, int pageSize, string beginDate, string endDate, int topicid);
    }
}
