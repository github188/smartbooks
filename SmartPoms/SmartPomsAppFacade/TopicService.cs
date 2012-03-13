
namespace SmartPoms.AppFacade {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using ServiceInterfaces;

    /// <summary>
    /// 专题服务接口实现
    /// </summary>
    public class TopicService : ITopicService {
        SQLServerDAL.BASE_TOPIC topic = new SQLServerDAL.BASE_TOPIC();

        public bool add(Entity.BASE_TOPIC entity) {
            if (topic.Add(entity) != 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool delete(int topicId) {
            return topic.Delete(topicId);
        }

        public bool update(Entity.BASE_TOPIC entity) {
            return topic.Update(entity);
        }

        public List<Entity.BASE_TOPIC> getSubtopic(int rootId, bool recursive) {
            List<Entity.BASE_TOPIC> t = new List<Entity.BASE_TOPIC>();
            if (recursive) {
                t.Add(GetRecursiveEntity(rootId));
            } else {
                t.Add(topic.GetEntity(rootId));
            }
            return t;
        }

        public DataTable getArticle(int pageNo, int pageSize, string beginDate, string endDate, int topicid) {
            SQLServerDAL.BASE_ARTICLE artDal = new SQLServerDAL.BASE_ARTICLE();
            DataTable dt = new DataTable();
            string strWhere = string.Format("PUBLISHDATE >= '{0}' AND PUBLISHDATE <= '{1}' AND ", beginDate, endDate);

            #region 获取文章
            Entity.BASE_TOPIC top = new Entity.BASE_TOPIC();
            top = topic.GetEntity(topicid);
            if (top != null && top.TOPICIDPARENT != 0) {
                //递归获取子专题id
                List<Entity.BASE_TOPIC> topItem = new List<Entity.BASE_TOPIC>();
                topItem.Add(GetRecursiveEntity(top.TOPICID));
                strWhere += "topicid like '%";
                topItem.Sort(delegate(Entity.BASE_TOPIC x, Entity.BASE_TOPIC y) {
                    return x.TOPICID - y.TOPICID;
                });
                foreach (Entity.BASE_TOPIC t in topItem) {
                    strWhere += string.Format("{0},%", t.TOPICID.ToString());
                }
                strWhere += "%'";
                dt = artDal.GetList(strWhere).Tables[0];
            } else {
                //直接获取专题下文章
                strWhere += string.Format("topicid like '%{0},%'", topicid.ToString());
                dt = artDal.GetList(strWhere).Tables[0];
            }
            #endregion

            #region 文章分页
            if (dt.Rows.Count > pageSize) {
                int pageCount = dt.Rows.Count / pageSize; //总页数
                if (pageNo < pageCount) {
                    int beginIndex = pageNo * pageSize;
                    int endIndex = beginIndex + pageSize;
                    DataTable dtResult = dt.Clone();
                    while (beginIndex < endIndex) {
                        dtResult.Rows.Add(dt.Rows[beginIndex].ItemArray);
                        beginIndex++;
                    }
                    return dtResult;
                }
            }
            #endregion

            return dt;
        }

        public string Description {
            get { return "提供专题事件服务"; }
        }

        private Entity.BASE_TOPIC GetRecursiveEntity(int rootId) {
            Entity.BASE_TOPIC t = new Entity.BASE_TOPIC();
            t = topic.GetEntity(rootId);
            if (t.TOPICIDPARENT != 0) {
                GetRecursiveEntity(t.TOPICID);
            }
            return t;
        }
    }
}
